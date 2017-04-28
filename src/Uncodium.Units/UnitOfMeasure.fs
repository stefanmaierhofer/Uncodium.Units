namespace Uncodium.Units

open System
open System.Collections.Generic

type UnitOfMeasure(name : string, symbol : string, baseUnits : UnitPowers, factor : Fraction) =

    member self.Name = name
    member self.Symbol = symbol
    member self.BaseUnits = baseUnits
    member self.Factor = factor
    
    new(name : string, symbol : string, unit : UnitOfMeasure, factor : Fraction) =
        match unit.BaseUnits.IsEmpty with

        | true ->
            if unit.Name = "" then
                UnitOfMeasure(name, symbol, UnitPowers.None, factor * unit.Factor)
            else
                UnitOfMeasure(name, symbol, UnitPowers {Unit = unit; Power = 1}, factor * unit.Factor)
        
        | false ->
            let dim = if unit.BaseUnits.IsEmpty then UnitPowers.None else unit.BaseUnits
            UnitOfMeasure(name, symbol, dim, factor * unit.Factor)
                
    new(name : string, symbol : string, unit : UnitOfMeasure, factor : bigint) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)
        
    new(name : string, symbol : string, unit : UnitOfMeasure, factor : int) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)

    new(name : string, symbol : string, unit : UnitOfMeasure, factor : float) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)

    new(name : string, symbol : string, unit : UnitOfMeasure) =
        UnitOfMeasure(name, symbol, unit, Fraction.One)

    new(name : string, symbol : string) =
        UnitOfMeasure(name, symbol, UnitPowers.None, Fraction.One)

    member self.IsBaseUnit with get () = self.BaseUnits.IsBaseUnit

    static member None = UnitOfMeasure("dimensionless", "-")

    static member (*) (a : float, b : UnitOfMeasure)    = Value(Fraction a, b)
    static member (*) (a : UnitOfMeasure, b : float)    = Value(Fraction b, a)
    static member (*) (a : int, b : UnitOfMeasure)    = Value(Fraction a, b)
    static member (*) (a : UnitOfMeasure, b : int)    = Value(Fraction b, a)
    static member (*) (a : int64, b : UnitOfMeasure)    = Value(Fraction a, b)
    static member (*) (a : UnitOfMeasure, b : int64)    = Value(Fraction b, a)
    static member (*) (a : bigint, b : UnitOfMeasure)    = Value(Fraction a, b)
    static member (*) (a : UnitOfMeasure, b : bigint)    = Value(Fraction b, a)
        
    static member (*) (a : UnitOfMeasure, b : UnitOfMeasure) =
        let psa =
            match a.BaseUnits.IsEmpty with
            | true -> UnitPowers { Unit = a; Power = 1 }
            | false -> a.BaseUnits
        let psb =
            match b.BaseUnits.IsEmpty with
            | true -> UnitPowers { Unit = b; Power = 1 }
            | false -> b.BaseUnits
        let ps : UnitPowers = psa * psb
        let s = string ps
        match ps.Count with
        | 0 -> UnitOfMeasure(s, s, UnitPowers.None, a.Factor * b.Factor)
        | _ -> UnitOfMeasure(s, s, ps, a.Factor * b.Factor)

    static member (/) (a : UnitOfMeasure, b : UnitOfMeasure) =
        let psa =
            match a.BaseUnits.IsEmpty with
            | true -> UnitPowers { Unit = a; Power = 1 }
            | false -> a.BaseUnits
        let psb =
            match b.BaseUnits.IsEmpty with
            | true -> UnitPowers { Unit = b; Power = 1 }
            | false -> b.BaseUnits
        let ps : UnitPowers = psa / psb
        let s = string ps
        match ps.Count with
        | 0 -> UnitOfMeasure(s, s, UnitPowers.None, a.Factor / b.Factor)
        | _ -> UnitOfMeasure(s, s, ps, a.Factor / b.Factor)

    static member (/) (a : int, b : UnitOfMeasure) =
        let ps =
            match b.BaseUnits.IsEmpty with
            | true -> UnitPowers { Unit = b; Power = -1 }
            | false -> b.BaseUnits.Inverse
        let s = string ps
        match ps.Count with
        | 0 -> UnitOfMeasure(s, s, UnitPowers.None, a / b.Factor)
        | _ -> UnitOfMeasure(s, s, ps, a / b.Factor)

    member self.Pow (b : int) =
        if b = 0 then
            UnitOfMeasure("", "", UnitPowers.None, Fraction.One)
        else
            let ps =
                match self.BaseUnits.IsEmpty with
                | true -> UnitPowers { Unit = self; Power = b }
                | false -> self.BaseUnits.Pow(b)
            let s = string ps
            match ps.Count with
            | 0 -> UnitOfMeasure(s, s, UnitPowers.None, self.Factor.Pow(b))
            | _ -> UnitOfMeasure(s, s, ps, self.Factor.Pow(b))

    member self.HasUnitsEquivalentTo (other : UnitOfMeasure) =
        if obj.ReferenceEquals(self, other) then
            true
        else
            match (self.BaseUnits.IsEmpty, other.BaseUnits.IsEmpty) with
            | (false, false) -> self.BaseUnits.HasUnitsEquivalentTo(other.BaseUnits)
            | (false, true) -> self.BaseUnits.HasUnitsEquivalentTo(other)
            | (true, false) -> other.BaseUnits.HasUnitsEquivalentTo(self)
            | _ -> false

    override self.ToString () = 
        match self.BaseUnits.IsEmpty with
        | true -> sprintf "%s (%s) %s" self.Name self.Symbol (string self.Factor)
        | false -> 
            let ps : UnitPower[] = self.BaseUnits.Powers
            if self.BaseUnits.Count = 1 && (ps.[0].Power = 1) then
                let p = ps.[0].Unit
                sprintf "%s (%s) %s" p.Name p.Symbol (string p.Factor)
            else
                sprintf "%s (%s) %s %s" self.Name self.Symbol (string self.BaseUnits) (string self.Factor)

 
    static member private normalize (powers : Dictionary<UnitOfMeasure,int>) : UnitPower[] =
        let pos = powers |> Seq.filter (fun kv -> kv.Value > 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let neg = powers |> Seq.filter (fun kv -> kv.Value < 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        Seq.append pos neg |> Seq.map (fun kv -> {Unit = kv.Key; Power = kv.Value}) |> Seq.toArray

and UnitPower = { Unit : UnitOfMeasure; Power : int }

and UnitPowers(powers : UnitPower[]) =
    
    static member None : UnitPowers = UnitPowers [| |]

    member self.Powers with get () = powers
    member self.Count = self.Powers.Length

    new(powers : seq<UnitPower>) = UnitPowers (powers |> UnitPowers.normalize)
    new(power : UnitPower) = UnitPowers [| power |]

    member self.IsBaseUnit with get() = self.Powers.Length = 0
        
    member self.Inverse
        with get () =
            let xs = self.Powers |> Seq.map (fun x -> { Unit = x.Unit; Power = -x.Power }) |> UnitPowers.normalize
            UnitPowers(xs)

    member self.IsEmpty with get () = self.Powers.Length = 0 || (self.Powers.Length = 1 && self.Powers.[0].Unit.Name = "")

    override self.ToString () = String.Join("", self.Powers |> Seq.map (fun x -> "[" + x.Unit.Symbol + "^" + string(x.Power) + "]"))

    static member (*) (a : UnitPowers, b : UnitPowers) =
        if a.Powers.Length = 0 then b
        elif b.Powers.Length = 0 then a
        else
            let d = Dictionary<UnitOfMeasure, int>()
            for x in a.Powers do d.Add(x.Unit, x.Power)
            for x in b.Powers do
                match d.ContainsKey x.Unit with
                | false -> d.Add(x.Unit, x.Power)
                | true -> d.[x.Unit] <- (d.[x.Unit] + x.Power)
            
            d |> Seq.map (fun kv -> { Unit = kv.Key; Power = kv.Value }) |> UnitPowers

    static member (/) (a : UnitPowers, b : UnitPowers) =
        if a.Powers.Length = 0 then b.Inverse
        elif b.Powers.Length = 0 then a
        else
            let d = Dictionary<UnitOfMeasure, int>()
            for x in a.Powers do d.Add(x.Unit, x.Power)
            for x in b.Powers do
                match d.ContainsKey x.Unit with
                | false -> d.Add(x.Unit, -x.Power)
                | true -> d.[x.Unit] <- (d.[x.Unit] - x.Power)
            
            d |> Seq.map (fun kv -> { Unit = kv.Key; Power = kv.Value }) |> UnitPowers

    member self.Pow(b : int) =
        self.Powers
        |> Seq.map (fun x -> { Unit = x.Unit; Power = x.Power * b})
        |> Seq.filter (fun x -> x.Power <> 0)
        |> Seq.toArray
        |> UnitPowers
        
    member self.HasUnitsEquivalentTo (other : UnitPowers) =
        match self.Count = other.Count with
        | true -> Seq.zip self.Powers other.Powers |> Seq.forall (fun (x,y) -> x.Unit = y.Unit && x.Power = y.Power) 
        | false -> false

    member self.HasUnitsEquivalentTo (other : UnitOfMeasure) =
        match self.Count with
        | 1 ->
            let x = self.Powers.[0]
            x.Unit = other && x.Power = 1
        | _ -> false
        
    static member private normalize (powers : seq<UnitPower>) : UnitPower[] =
        let pos = powers |> Seq.filter (fun x -> x.Power > 0) |> Seq.sortBy (fun x -> x.Unit.Name)
        let neg = powers |> Seq.filter (fun x -> x.Power < 0) |> Seq.sortBy (fun x -> x.Unit.Name)
        Seq.append pos neg |> Seq.toArray
        
and UnitPrefix(name : string, symbol : string, factor : Fraction) =
    member this.Name = name
    member this.Symbol = symbol
    member this.Factor = factor
    
    new(name : string, symbol : string, factor : int) = UnitPrefix(name, symbol, Fraction factor)
    new(name : string, symbol : string, factor : bigint) = UnitPrefix(name, symbol, Fraction factor)

    static member (*) (a : UnitPrefix, b : UnitOfMeasure) = UnitOfMeasure(a.Name + b.Name, a.Symbol + b.Symbol, UnitPrefix.baseOrSelf b, a.Factor * b.Factor)
    static member (*) (a : UnitOfMeasure, b : UnitPrefix) = UnitOfMeasure(b.Name + a.Name, b.Symbol + a.Symbol, UnitPrefix.baseOrSelf a, a.Factor * b.Factor)
    static member (/) (a : UnitPrefix, b : UnitOfMeasure) = UnitOfMeasure(a.Name + b.Name, a.Symbol + b.Symbol, UnitPrefix.baseOrSelf b, a.Factor / b.Factor)
    static member (/) (a : UnitOfMeasure, b : UnitPrefix) = UnitOfMeasure(b.Name + a.Name, b.Symbol + a.Symbol, UnitPrefix.baseOrSelf a, a.Factor / b.Factor)

    static member private baseOrSelf (unit:UnitOfMeasure) : UnitPowers =
        match unit.BaseUnits.IsEmpty with
        | true -> UnitPowers {Unit = unit; Power = 1}
        | false -> unit.BaseUnits

and Value(x : Fraction, unit : UnitOfMeasure) =
    member self.X = x
    member self.Unit = unit
    
    new(x : Fraction) = Value(x, UnitOfMeasure.None)
    
    new(x : bigint, unit : UnitOfMeasure) = Value(Fraction x, unit)
    new(x : bigint) = Value(Fraction x, UnitOfMeasure.None)
    
    new(x : int64, unit : UnitOfMeasure) = Value(Fraction x, unit)
    new(x : int64) = Value(Fraction x, UnitOfMeasure.None)
    
    new(x : int, unit : UnitOfMeasure) = Value(Fraction x, unit)
    new(x : int) = Value(Fraction x, UnitOfMeasure.None)
    
    new(x : float, unit : UnitOfMeasure) = Value(Fraction x, unit)
    new(x : float) = Value(Fraction x, UnitOfMeasure.None)
    
    new(x : float32, unit : UnitOfMeasure) = Value(Fraction x, unit)
    new(x : float32) = Value(Fraction x, UnitOfMeasure.None)

    new(x : Constant) =
        let f : Fraction = x.X
        Value(f, x.Unit)
    
    override self.ToString () =
        if self.Unit <> UnitOfMeasure.None then
            string(self.X.Float) + " " + self.Unit.Symbol
        else
            string(self.X.Float)
    
    member self.HasUnitsEquivalentTo (other : Value) = self.Unit.HasUnitsEquivalentTo(other.Unit)

    member self.ConvertTo(unit : UnitOfMeasure) =
        if self.Unit.HasUnitsEquivalentTo unit then
                Value(self.X * self.Unit.Factor / unit.Factor, unit)
            else
                invalidOp (sprintf "Cannot convert (%A) to (%A)." self unit)

    static member (=>) (self : Value, unit : UnitOfMeasure) =
        if self.Unit.HasUnitsEquivalentTo unit then
                Value(self.X * self.Unit.Factor / unit.Factor, unit)
            else
                invalidOp (sprintf "Cannot convert (%A) to (%A)." self unit)

    member self.Float with get () = self.X * self.Unit.Factor

    member self.Inverse with get () = Value(self.X.Inverse, 1 / self.Unit)

    static member (*) (a : Value, b : float)    = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : float, b : Value)    = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : Value, b : int)      = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : int, b : Value)      = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : Value, b : int64)    = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : int64, b : Value)    = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : Value, b : Value)    =
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(a.X * b.X, a.Unit * b.Unit)
        | (true, false) -> Value(a.X * b.X, a.Unit)
        | (false, true) -> Value(a.X * b.X, b.Unit)
        | (false, false) -> Value(a.X * b.X, UnitOfMeasure.None)
    static member (*) (a : Value, b : Constant) =
        let f : Fraction = a.X * b.X
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(f, a.Unit * b.Unit)
        | (true, false) -> Value(f, a.Unit)
        | (false, true) -> Value(f, b.Unit)
        | (false, false) -> Value(f, UnitOfMeasure.None)
    static member (*) (a : Constant, b : Value) =
        let f : Fraction = a.X * b.X
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(f, a.Unit * b.Unit)
        | (true, false) -> Value(f, a.Unit)
        | (false, true) -> Value(f, b.Unit)
        | (false, false) -> Value(f, UnitOfMeasure.None)
    static member (*) (a : Value, b : UnitOfMeasure)    =
        match a.Unit <> UnitOfMeasure.None with
        | true -> Value(a.X, a.Unit * b)
        | false -> Value(a.X, b)
    static member (*) (a : UnitOfMeasure, b : Value)    =
        match b.Unit <> UnitOfMeasure.None with
        | true -> Value(b.X, a * b.Unit)
        | false -> Value(b.X, a)
    static member (*) (a : Value, b : UnitPrefix)    =
        match a.Unit <> UnitOfMeasure.None with
        | true -> Value(a.X, a.Unit * b)
        | false -> Value(a.X * b.Factor, UnitOfMeasure.None)
    static member (*) (a : UnitPrefix, b : Value)    =
        match b.Unit <> UnitOfMeasure.None with
        | true -> Value(b.X, a * b.Unit)
        | false -> Value(b.X * a.Factor, UnitOfMeasure.None)
        
    static member (/) (a : Value, b : float)    = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : float, b : Value)    = Value(Fraction a / b.X, b.Unit)
    static member (/) (a : Value, b : int)      = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : int, b : Value)      = Value(Fraction a / b.X, b.Unit)
    static member (/) (a : Value, b : int64)    = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : int64, b : Value)    = Value(Fraction a / b.X, b.Unit)
    static member (/) (a : Value, b : Value)    =
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(a.X / b.X, a.Unit / b.Unit)
        | (true, false) -> Value(a.X / b.X, a.Unit)
        | (false, true) -> Value(a.X / b.X, b.Unit)
        | (false, false) -> Value(a.X / b.X, UnitOfMeasure.None)
    static member (/) (a : Value, b : Constant) = a / Value(b)
    static member (/) (a : Constant, b : Value) = Value(a) / b
    static member (/) (a : Value, b : UnitOfMeasure)    =
        match a.Unit <> UnitOfMeasure.None with
        | true -> Value(a.X, a.Unit / b)
        | false -> Value(a.X, b)
    static member (/) (a : UnitOfMeasure, b : Value)    =
        match b.Unit <> UnitOfMeasure.None with
        | true -> Value(b.X, a / b.Unit)
        | false -> Value(b.X, a)

    static member (+) (a : Value, b : Value) =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
            | (true, true) -> Value(a.X + b.X * b.Unit.Factor / a.Unit.Factor, a.Unit)
            | (true, false) -> Value(a.X + b.X, a.Unit)
            | (false, true) -> Value(a.X + b.X, b.Unit)
            | (false, false) -> Value(a.X + b.X, UnitOfMeasure.None)
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)

    static member (-) (a : Value, b : Value) =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
            | (true, true) -> Value(a.X - b.X * b.Unit.Factor / a.Unit.Factor, a.Unit)
            | (true, false) -> Value(a.X - b.X, a.Unit)
            | (false, true) -> Value(a.X - b.X, b.Unit)
            | (false, false) -> Value(a.X - b.X, UnitOfMeasure.None)
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)
    
    static member inline op (a : Value) (b : Value) f =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
            | (true, true) -> f (a.X * a.Unit.Factor) (b.X * b.Unit.Factor)
            | (true, false) -> f (a.X * a.Unit.Factor) b.X
            | (false, true) -> f a.X (b.X * b.Unit.Factor)
            | (false, false) -> f a.X b.X
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)
        
    static member op_LessThan (a, b) = Value.op a b (<)
    static member op_LessThanOrEqual (a, b) = Value.op a b (<=)
    static member op_Equality (a, b) = Value.op a b (=)
    static member op_Inequality (a, b) = Value.op a b (<>)
    static member op_GreaterThanOrEqual (a, b) = Value.op a b (>=)
    static member op_GreaterThan (a, b) = Value.op a b (>)

    interface IComparable<Value> with
        member self.CompareTo other =
            if self.HasUnitsEquivalentTo other then
                match (self.Unit <> UnitOfMeasure.None, other.Unit <> UnitOfMeasure.None) with
                | (true, true) -> ((self.X * self.Unit.Factor) :> IComparable<_>).CompareTo(other.X * other.Unit.Factor)
                | (true, false) -> ((self.X * self.Unit.Factor) :> IComparable<_>).CompareTo(other.X)
                | (false, true) -> (self.X :> IComparable<_>).CompareTo(other.X * other.Unit.Factor)
                | (false, false) -> (self.X :> IComparable<_>).CompareTo(other.X)
            else
                invalidOp (sprintf "Values (%A) and (%A) have different units." self other)

    interface IComparable with
        member self.CompareTo obj =
            match obj with
                | null              -> 1
                | :? Value as other -> (self :> IComparable<_>).CompareTo(other)
                | _                 -> invalidArg "obj" "not a Value"

    interface IEquatable<Value> with
        member self.Equals other =
            if self.HasUnitsEquivalentTo other then
                match (self.Unit <> UnitOfMeasure.None, other.Unit <> UnitOfMeasure.None) with
                | (true, true) -> self.X * self.Unit.Factor = other.X * other.Unit.Factor
                | (true, false) -> self.X * self.Unit.Factor = other.X
                | (false, true) -> self.X = other.X * other.Unit.Factor
                | (false, false) -> self.X = other.X
            else
                invalidOp (sprintf "Values (%A) and (%A) have different units." self other)
    
    override self.Equals(obj) =
        match obj with
        | :? Value as other -> (self :> IEquatable<_>).Equals(other)
        | _ -> false

    override self.GetHashCode() = hash (self.X, self.Unit)

and Constant(name : string, symbol : string, x : Fraction, unit : UnitOfMeasure) =
    member self.Name = name
    member self.Symbol = symbol
    member self.X = x
    member self.Unit = unit
    
    new(name : string, symbol : string, x : Fraction) = Constant(name, symbol, x, UnitOfMeasure.None)
    
    new(name : string, symbol : string, x : bigint, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : bigint) = Constant(name, symbol, Fraction x, UnitOfMeasure.None)
    
    new(name : string, symbol : string, x : int64, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : int64) = Constant(name, symbol, Fraction x, UnitOfMeasure.None)
    
    new(name : string, symbol : string, x : int, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : int) = Constant(name, symbol, Fraction x, UnitOfMeasure.None)
    
    new(name : string, symbol : string, x : float, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : float) = Constant(name, symbol, Fraction x, UnitOfMeasure.None)
    
    new(name : string, symbol : string, x : float32, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : float32) = Constant(name, symbol, Fraction x, UnitOfMeasure.None)

    new(name : string, symbol : string, x : Value) = Constant(name, symbol, x.X, x.Unit)

    override self.ToString () =
        match self.Unit <> UnitOfMeasure.None with
        | true -> string(self.X.Float) + " " + self.Unit.Symbol
        | false -> string(self.X.Float)
    
    member self.HasUnitsEquivalentTo (other : Constant) = Value(self.X, self.Unit).HasUnitsEquivalentTo(Value(other.X, other.Unit))

    static member (=>) (self : Constant, unit : UnitOfMeasure) = Value(self.X, self.Unit) => unit

    static member (+) (a : Constant, b : Constant) = Value(a) + Value(b)

    static member (-) (a : Constant, b : Constant) = Value(a) - Value(b)

    static member (*) (a : Constant, b : Constant) = Value(a) * Value(b)
    static member (*) (a : Constant, b : UnitOfMeasure) = Value(a) * b
    static member (*) (a : UnitOfMeasure, b : Constant) = a * Value(b)
    static member (*) (a : Constant, b : UnitPrefix) = Value(a) * b
    static member (*) (a : UnitPrefix, b : Constant) = a * Value(b)
    static member (*) (a : float, b : Constant) = a * Value(b.X, b.Unit)

    static member (/) (a : Constant, b : Constant) = Value(a) / Value(b)
    static member (/) (a : Constant, b : UnitOfMeasure) = Value(a) / b
    static member (/) (a : UnitOfMeasure, b : Constant) = a / Value(b)