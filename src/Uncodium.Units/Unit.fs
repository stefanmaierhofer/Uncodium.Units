namespace Uncodium.Units

open System
open System.Collections.Generic

type Unit =

    val Name : string
    val Symbol : string
    val BaseUnits : UnitPowers
    val Scale : Rational
    
    new(name : string, symbol : string, baseUnits : UnitPowers, scale : Rational) =
        if name = null then invalidArg "name" "UnitOfMeasure.Name must not be null."
        if symbol = null then invalidArg "symbol" "UnitOfMeasure.Symbol must not be null."
        { Name = name; Symbol = symbol; BaseUnits = baseUnits; Scale = scale.Simplified }

    new(name : string, symbol : string, unit : Unit, scale : Rational) =
        match unit.IsDimensionLess with

        | true ->
            if unit.Name = "" then
                Unit(name, symbol, unit.BaseUnits, scale * unit.Scale)
            else
                Unit(name, symbol, UnitPowers {Unit = unit; Power = 1}, scale * unit.Scale)
        
        | false ->
            Unit(name, symbol, unit.BaseUnits, scale * unit.Scale)
                
    new(name : string, symbol : string, unit : Unit, scale : bigint) =
        Unit(name, symbol, unit, Rational scale)
        
    new(name : string, symbol : string, unit : Unit, scale : int) =
        Unit(name, symbol, unit, Rational scale)

    new(name : string, symbol : string, unit : Unit, scale : float) =
        Unit(name, symbol, unit, Rational scale)

    new(name : string, symbol : string, unit : Unit) =
        Unit(name, symbol, unit, Rational.One)

    new(name : string, symbol : string) =
        Unit(name, symbol, UnitPowers.None, Rational.One)
    
    new(name : string) =
        Unit(name, name, UnitPowers.None, Rational.One)

    new(value : Value) =
        let u : Unit = value.Unit
        Unit(u.Name, u.Symbol, u.BaseUnits, value.X * u.Scale)

    new(value : Constant) =
        let u : Unit = value.Unit
        Unit(u.Name, u.Symbol, u.BaseUnits, value.X * u.Scale)
        
    member self.IsDimensionLess with get () = self.BaseUnits.IsDimensionLess
    member internal self.HasName with get() = self.Name <> ""
    member internal self.HasSymbol with get() = self.Symbol <> ""

    static member None = Unit("dimensionless", "-")
    
    static member (*) (a : Unit, b : Unit) =
        let psa =
            match a.IsDimensionLess && a.Symbol <> "" with
            | true -> UnitPowers { Unit = a; Power = 1 }
            | false -> a.BaseUnits
        let psb =
            match b.IsDimensionLess && b.Symbol <> "" with
            | true -> UnitPowers { Unit = b; Power = 1 }
            | false -> b.BaseUnits
        let powers : UnitPowers = psa * psb
        let symbol =
            if a = b && a.HasName && a.HasSymbol then
                let p = powers.Powers.[0]
                match p.Power with
                | 0 -> ""
                | 1 -> a.Symbol
                | 2 -> a.Symbol + "²"
                | 3 -> a.Symbol + "³"
                | i -> a.Symbol + "^" + string(i)
            elif powers.Count = 1 && a <> b then
                ""
            elif a.HasName && a.HasSymbol && b.HasName && b.HasSymbol then
                a.Symbol + "*" + b.Symbol
            else
                ""
        Unit("", symbol, powers, a.Scale * b.Scale)
    static member (*) (a : Unit, b : Rational)      = Value(b, a)
    static member (*) (a : Unit, b : bigint)        = Value(Rational b, a)
    static member (*) (a : Unit, b : int64)         = Value(Rational b, a)
    static member (*) (a : Unit, b : int)           = Value(Rational b, a)
    static member (*) (a : Unit, b : float)         = Value(Rational b, a)
    static member (*) (a : Unit, b : float32)       = Value(Rational b, a)
    static member (*) (a : Rational, b : Unit)      = Value(a, b)
    static member (*) (a : bigint, b : Unit)        = Value(Rational a, b)
    static member (*) (a : int64, b : Unit)         = Value(Rational a, b)
    static member (*) (a : int, b : Unit)           = Value(Rational a, b)
    static member (*) (a : float, b : Unit)         = Value(Rational a, b)
    static member (*) (a : float32, b : Unit)       = Value(Rational a, b)

    static member (/) (a : Unit, b : Unit) =
        let psa =
            match a.IsDimensionLess && a.Symbol <> "" with
            | true -> UnitPowers { Unit = a; Power = 1 }
            | false -> a.BaseUnits
        let psb =
            match b.IsDimensionLess && b.Symbol <> "" with
            | true -> UnitPowers { Unit = b; Power = 1 }
            | false -> b.BaseUnits
        let powers : UnitPowers = psa / psb
        let symbol =
            if powers.Count = 1 && a.HasName && a.HasSymbol then
                let p = powers.Powers.[0]
                match p.Power with
                | 0 -> ""
                | 1 -> p.Unit.Symbol
                | 2 -> p.Unit.Symbol + "²"
                | 3 -> p.Unit.Symbol + "³"
                | i -> p.Unit.Symbol + "^" + string(i)
            elif powers.Count = 2 && a.HasName && a.HasSymbol && b.HasName && b.HasSymbol then
                a.Symbol + "/" + b.Symbol
            else
                ""
        Unit("", symbol, powers, (a.Scale / b.Scale).Simplified)

    static member (/) (a : int, b : Unit) =
        let powers =
            match b.IsDimensionLess with
            | true -> UnitPowers { Unit = b; Power = -1 }
            | false -> b.BaseUnits.Inverse
        Unit("", "", powers, a / b.Scale)

    member self.Pow (b : int) =
        if b = 0 then
            Unit("", "", UnitPowers.None, Rational.One)
        else
            let powers =
                match self.IsDimensionLess with
                | true -> UnitPowers { Unit = self; Power = b }
                | false -> self.BaseUnits.Pow(b)
            let symbol =
                if powers.Count = 1 && self.HasName && self.HasSymbol then
                    let p = powers.Powers.[0]
                    match p.Power with
                    | 0 -> ""
                    | 1 -> self.Symbol
                    | 2 -> self.Symbol + "²"
                    | 3 -> self.Symbol + "³"
                    | i -> self.Symbol + "^" + string(i)
                else
                    ""
            Unit("", symbol, powers, self.Scale.Pow(b))

    member inline self.Float with get () = float self.Scale

    static member inline op_Explicit(source: Unit) : float = source.Float

    member internal self.HasUnitsEquivalentTo (other : Unit) =
        if obj.ReferenceEquals(self, other) then
            true
        else
            match (self.IsDimensionLess, other.IsDimensionLess) with
            | (false, false) -> self.BaseUnits.HasUnitsEquivalentTo(other.BaseUnits)
            | (false, true) -> self.BaseUnits.HasUnitsEquivalentTo(other)
            | (true, false) -> other.BaseUnits.HasUnitsEquivalentTo(self)
            | _ -> false

    override self.ToString () = 
        let ps : UnitPower[] = self.BaseUnits.Powers
        if self.BaseUnits.Count = 1 && (ps.[0].Power = 1) then
            let p = ps.[0].Unit
            match (p.HasName, p.HasSymbol, p.Scale.Denominator <> 1I) with
            | (true, true, false) -> sprintf "%s (%s) %s" p.Name p.Symbol (string p.Scale.Numerator)
            | (false, true, true) -> sprintf "%s %s" p.Symbol (string p.Scale)
            | (false, true, false) -> sprintf "%s %s" p.Symbol (string p.Scale.Numerator)
            | (false, false, true) -> sprintf "%s" (string p.Scale)
            | (false, false, false) -> sprintf "%s" (string p.Scale.Numerator)
            | _ -> sprintf "%s (%s) %s" p.Name p.Symbol (string p.Scale)
        else
            let bu = if self.IsDimensionLess then "" else " " + (string self.BaseUnits)
            match (self.HasName, self.HasSymbol, self.Scale.Denominator <> 1I) with
            | (true, true, false) -> sprintf "%s (%s) %s%s" self.Name self.Symbol (string self.Scale.Numerator) bu
            | (false, true, true) -> sprintf "%s %s%s" self.Symbol (string self) bu
            | (false, true, false) -> sprintf "%s %s %s" self.Symbol (string self.Scale.Numerator) bu
            | (false, false, true) -> sprintf "%s%s" (string self.Scale) bu
            | (false, false, false) -> sprintf "%s%s" (string self.Scale.Numerator) bu
            | _ -> sprintf "%s (%s) %s %s" self.Name self.Symbol (string self.Scale) bu

    static member private normalize (powers : Dictionary<Unit,int>) : UnitPower[] =
        let pos = powers |> Seq.filter (fun kv -> kv.Value > 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let neg = powers |> Seq.filter (fun kv -> kv.Value < 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        Seq.append pos neg |> Seq.map (fun kv -> {Unit = kv.Key; Power = kv.Value}) |> Seq.toArray

and UnitPower = { Unit : Unit; Power : int }

and UnitPowers =

    static member None : UnitPowers = UnitPowers()
    
    val Powers : UnitPower[]
    
    member self.Count = self.Powers.Length
    
    new(powers : UnitPower[]) =
        for p in powers do
            if not p.Unit.IsDimensionLess then invalidArg (string p.Unit) (sprintf "[%A]^%A" p.Unit p.Power)
        { Powers = powers |> UnitPowers.normalize }

    new() = UnitPowers [| |]
    new(unit : Unit, power : int) = UnitPowers [| { Unit = unit; Power = power } |];
    new(power : UnitPower) = UnitPowers [| power |]
    new(powers : seq<UnitPower>) = UnitPowers (powers |> Array.ofSeq)

    member self.IsDimensionLess with get() = self.Powers.Length = 0
        
    member self.Inverse
        with get () =
            let xs = self.Powers |> Seq.map (fun x -> { Unit = x.Unit; Power = -x.Power }) |> UnitPowers.normalize
            UnitPowers(xs)
            
    override self.ToString () = String.Join("", self.Powers |> Seq.map (fun x -> "[" + x.Unit.Symbol + "^" + string(x.Power) + "]"))

    static member (*) (a : UnitPowers, b : UnitPowers) =
        if a.Powers.Length = 0 then b
        elif b.Powers.Length = 0 then a
        else
            let d = Dictionary<Unit, int>()
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
            let d = Dictionary<Unit, int>()
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
        
    member internal self.HasUnitsEquivalentTo (other : UnitPowers) =
        match self.Count = other.Count with
        | true -> Seq.zip self.Powers other.Powers |> Seq.forall (fun (x,y) -> x.Unit = y.Unit && x.Power = y.Power) 
        | false -> false

    member internal self.HasUnitsEquivalentTo (other : Unit) =
        match self.Count with
        | 1 ->
            let x = self.Powers.[0]
            x.Unit = other && x.Power = 1
        | _ -> false

    static member op_Equality (a : UnitPowers, b : UnitPowers) =
        if a.Count = b.Count then
            if a.Count = 0 then
                true
            else
                Seq.zip a.Powers b.Powers
                |> Seq.forall (fun (x, y) -> x.Unit = y.Unit && x.Power = y.Power)
        else
            false

    interface IEquatable<UnitPowers> with
        member self.Equals other = UnitPowers.op_Equality (self, other)
    
    override self.Equals(obj) =
        match obj with
        | :? UnitPowers as other -> (self :> IEquatable<_>).Equals(other)
        | _ -> false

    override self.GetHashCode() = hash (self.Powers)
        
    static member private normalize (powers : seq<UnitPower>) : UnitPower[] =
        let pos = powers |> Seq.filter (fun x -> x.Power > 0) |> Seq.sortBy (fun x -> x.Unit.Name)
        let neg = powers |> Seq.filter (fun x -> x.Power < 0) |> Seq.sortBy (fun x -> x.Unit.Name)
        Seq.append pos neg |> Seq.toArray
     
and Value(x : Rational, unit : Unit) =
    member self.X = x
    member self.Unit = unit
    
    new(x : Rational) = Value(x, Unit.None)
    
    new(x : bigint, unit : Unit) = Value(Rational x, unit)
    new(x : bigint) = Value(Rational x, Unit.None)
    
    new(x : int64, unit : Unit) = Value(Rational x, unit)
    new(x : int64) = Value(Rational x, Unit.None)
    
    new(x : int, unit : Unit) = Value(Rational x, unit)
    new(x : int) = Value(Rational x, Unit.None)
    
    new(x : float, unit : Unit) = Value(Rational x, unit)
    new(x : float) = Value(Rational x, Unit.None)
    
    new(x : float32, unit : Unit) = Value(Rational x, unit)
    new(x : float32) = Value(Rational x, Unit.None)

    new(x : Constant) =
        let f : Rational = x.X
        Value(f, x.Unit)
    
    override self.ToString () =
        match self.Unit.HasSymbol with
        | true -> string(self.X.Simplified.ToFloat()) + " " + self.Unit.Symbol
        | false ->
            let x = string((self.X * self.Unit.Scale).Simplified.ToFloat())
            let bu = self.Unit.BaseUnits
            match bu.Count with
            | 0 -> x
            | _ -> x + " " + self.Unit.BaseUnits.ToString()
    
    member self.ConvertTo(unit : Unit) =
        if self.Unit.HasUnitsEquivalentTo unit then
                Value(self.X * self.Unit.Scale / unit.Scale, unit)
            else
                invalidOp (sprintf "Cannot convert (%A) to (%A)." self unit)

    static member (=>) (self : Value, unit : Unit) =
        if self.Unit.HasUnitsEquivalentTo unit then
                Value(self.X * self.Unit.Scale / unit.Scale, unit)
            else
                invalidOp (sprintf "Cannot convert (%A) to (%A)." self unit)

    static member op_Explicit(source: Value) : float =
        match source.Unit.HasSymbol with
        | true -> source.X.ToFloat()
        | false -> (source.X * source.Unit.Scale).ToFloat()

    member self.Inverse with get () = Value(self.X.Inverse, 1 / self.Unit)
    
    member self.ToUnitOfMeasure () =
        let u = self.Unit
        let f = self.X * u.Scale
        Unit(u.Name, u.Symbol, u.BaseUnits, f) 
    
    member self.Pow (b : int) = Value(self.X.Pow(b), self.Unit.Pow(b))
         
    static member (*) (a : Value, b : Value)         =
        match (a.Unit <> Unit.None, b.Unit <> Unit.None) with
        | (true, true) -> Value(a.X * b.X, a.Unit * b.Unit)
        | (true, false) -> Value(a.X * b.X, a.Unit)
        | (false, true) -> Value(a.X * b.X, b.Unit)
        | (false, false) -> Value(a.X * b.X, Unit.None)
    static member (*) (a : Value, b : Unit) =
        match a.Unit <> Unit.None with
        | true -> Value(a.X, a.Unit * b)
        | false -> Value(a.X, b)
    static member (*) (a : Value, b : UnitPrefix)    =
        match a.Unit <> Unit.None with
        | true -> Value(a.X, a.Unit * b)
        | false ->
            let x : Rational = a.X * b.Scale
            Value(x, Unit.None)
    static member (*) (a : Value, b : Constant)      =
        let f : Rational = a.X * b.X
        match (a.Unit <> Unit.None, b.Unit <> Unit.None) with
        | (true, true) -> Value(f, a.Unit * b.Unit)
        | (true, false) -> Value(f, a.Unit)
        | (false, true) -> Value(f, b.Unit)
        | (false, false) -> Value(f, Unit.None)
    static member (*) (a : Value, b : Rational)      = Value(a.X * b, a.Unit)
    static member (*) (a : Value, b : bigint)        = Value(a.X * Rational b, a.Unit)
    static member (*) (a : Value, b : int64)         = Value(a.X * Rational b, a.Unit)
    static member (*) (a : Value, b : int)           = Value(a.X * Rational b, a.Unit)
    static member (*) (a : Value, b : float)         = Value(a.X * Rational b, a.Unit)
    static member (*) (a : Value, b : float32)       = Value(a.X * Rational b, a.Unit)
    static member (*) (a : Unit, b : Value) =
        match b.Unit <> Unit.None with
        | true -> Value(b.X, a * b.Unit)
        | false -> Value(b.X, a)
    static member (*) (a : UnitPrefix, b : Value)    =
        match b.Unit <> Unit.None with
        | true -> Value(b.X, a * b.Unit)
        | false -> Value(b.X * a.Scale, Unit.None)
    static member (*) (a : Constant, b : Value)      =
        let f : Rational = a.X * b.X
        match (a.Unit <> Unit.None, b.Unit <> Unit.None) with
        | (true, true) -> Value(f, a.Unit * b.Unit)
        | (true, false) -> Value(f, a.Unit)
        | (false, true) -> Value(f, b.Unit)
        | (false, false) -> Value(f, Unit.None)
    static member (*) (a : Rational, b : Value)      = Value(a * b.X, b.Unit)
    static member (*) (a : int64, b : Value)         = Value(Rational a * b.X, b.Unit)
    static member (*) (a : int, b : Value)           = Value(Rational a * b.X, b.Unit)
    static member (*) (a : float, b : Value)         = Value(Rational a * b.X, b.Unit)
    static member (*) (a : float32, b : Value)       = Value(Rational a * b.X, b.Unit)
        
    static member (/) (a : Value, b : Value)         =
        match (a.Unit <> Unit.None, b.Unit <> Unit.None) with
        | (true, true) -> Value(a.X / b.X, a.Unit / b.Unit)
        | (true, false) -> Value(a.X / b.X, a.Unit)
        | (false, true) -> Value(a.X / b.X, b.Unit)
        | (false, false) -> Value(a.X / b.X, Unit.None)
    static member (/) (a : Value, b : Unit) =
        match a.Unit <> Unit.None with
        | true -> Value(a.X, a.Unit / b)
        | false -> Value(a.X, b)
    static member (/) (a : Value, b : UnitPrefix)    =
        match a.Unit <> Unit.None with
        | true -> Value(a.X, a.Unit / b)
        | false -> 
            let x : Rational = a.X / b.Scale
            Value(x, Unit.None)
    static member (/) (a : Value, b : Constant)      = a / Value(b)
    static member (/) (a : Value, b : Rational)      = Value(a.X / b, a.Unit)
    static member (/) (a : Value, b : bigint)        = Value(a.X / Rational b, a.Unit)
    static member (/) (a : Value, b : int64)         = Value(a.X / Rational b, a.Unit)
    static member (/) (a : Value, b : int)           = Value(a.X / Rational b, a.Unit)
    static member (/) (a : Value, b : float)         = Value(a.X / Rational b, a.Unit)
    static member (/) (a : Value, b : float32)       = Value(a.X / Rational b, a.Unit)
    static member (/) (a : Unit, b : Value) =
        match b.Unit <> Unit.None with
        | true -> Value(b.X, a / b.Unit)
        | false -> Value(b.X, a)
    static member (/) (a : UnitPrefix, b : Value)    =
        match b.Unit <> Unit.None with
        | true -> Value(b.X, a / b.Unit)
        | false -> Value(b.X / a.Scale, Unit.None)
    static member (/) (a : Constant, b : Value)      = Value(a) / b
    static member (/) (a : int64, b : Value)         = Value(Rational a / b.X, 1 / b.Unit)
    static member (/) (a : int, b : Value)           = Value(Rational a / b.X, 1 / b.Unit)
    static member (/) (a : float, b : Value)         = Value(Rational a / b.X, 1 / b.Unit)
    static member (/) (a : float32, b : Value)       = Value(Rational a / b.X, 1 / b.Unit)

    static member (+) (a : Value, b : Value)    =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> Unit.None, b.Unit <> Unit.None) with
            | (true, true) -> Value(a.X + b.X * b.Unit.Scale / a.Unit.Scale, a.Unit)
            | (true, false) -> Value(a.X + b.X, a.Unit)
            | (false, true) -> Value(a.X + b.X, b.Unit)
            | (false, false) -> Value(a.X + b.X, Unit.None)
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)
    static member (+) (a : Value, b : Rational) = Value(a.X + b, a.Unit)
    static member (+) (a : Value, b : bigint)   = Value(a.X + Rational b, a.Unit)
    static member (+) (a : Value, b : int64)    = Value(a.X + Rational b, a.Unit)
    static member (+) (a : Value, b : int)      = Value(a.X + Rational b, a.Unit)
    static member (+) (a : Value, b : float)    = Value(a.X + Rational b, a.Unit)
    static member (+) (a : Value, b : float32)  = Value(a.X + Rational b, a.Unit)

    static member (-) (a : Value, b : Value) =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> Unit.None, b.Unit <> Unit.None) with
            | (true, true) -> Value(a.X - b.X * b.Unit.Scale / a.Unit.Scale, a.Unit)
            | (true, false) -> Value(a.X - b.X, a.Unit)
            | (false, true) -> Value(a.X - b.X, b.Unit)
            | (false, false) -> Value(a.X - b.X, Unit.None)
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)
    static member (-) (a : Value, b : Rational) = Value(a.X - b, a.Unit)
    static member (-) (a : Value, b : bigint)   = Value(a.X - Rational b, a.Unit)
    static member (-) (a : Value, b : int64)    = Value(a.X - Rational b, a.Unit)
    static member (-) (a : Value, b : int)      = Value(a.X - Rational b, a.Unit)
    static member (-) (a : Value, b : float)    = Value(a.X - Rational b, a.Unit)
    static member (-) (a : Value, b : float32)  = Value(a.X - Rational b, a.Unit)
    
    member internal self.HasUnitsEquivalentTo (other : Value) = self.Unit.HasUnitsEquivalentTo(other.Unit)
    static member inline internal op (a : Value) (b : Value) f =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> Unit.None, b.Unit <> Unit.None) with
            | (true, true) -> f (a.X * a.Unit.Scale) (b.X * b.Unit.Scale)
            | (true, false) -> f (a.X * a.Unit.Scale) b.X
            | (false, true) -> f a.X (b.X * b.Unit.Scale)
            | (false, false) -> f a.X b.X
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)
        
    static member op_LessThan (a, b) = Value.op a b (<)
    static member op_LessThanOrEqual (a, b) = Value.op a b (<=)
    static member op_Equality (a, b) = Value.op a b (=)
    static member op_Inequality (a, b) = Value.op a b (<>)
    static member op_GreaterThanOrEqual (a, b) = Value.op a b (>=)
    static member op_GreaterThan (a, b) = Value.op a b (>)

    static member inline op_Equality (a : Value, f : Rational) = a.X * a.Unit.Scale = f

    interface IComparable<Value> with
        member self.CompareTo other =
            if self.HasUnitsEquivalentTo other then
                match (self.Unit <> Unit.None, other.Unit <> Unit.None) with
                | (true, true) -> ((self.X * self.Unit.Scale) :> IComparable<_>).CompareTo(other.X * other.Unit.Scale)
                | (true, false) -> ((self.X * self.Unit.Scale) :> IComparable<_>).CompareTo(other.X)
                | (false, true) -> (self.X :> IComparable<_>).CompareTo(other.X * other.Unit.Scale)
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
                match (self.Unit <> Unit.None, other.Unit <> Unit.None) with
                | (true, true) -> self.X * self.Unit.Scale = other.X * other.Unit.Scale
                | (true, false) -> self.X * self.Unit.Scale = other.X
                | (false, true) -> self.X = other.X * other.Unit.Scale
                | (false, false) -> self.X = other.X
            else
                invalidOp (sprintf "Values (%A) and (%A) have different units." self other)
    
    override self.Equals(obj) =
        match obj with
        | :? Value as other -> (self :> IEquatable<_>).Equals(other)
        | _ -> false

    override self.GetHashCode() = hash (self.X, self.Unit)

and Constant(name : string, symbol : string, x : Rational, unit : Unit) =
    member self.Name = name
    member self.Symbol = symbol
    member self.X = x
    member self.Unit = unit
    
    new(name : string, symbol : string, x : Rational) = Constant(name, symbol, x, Unit.None)
    
    new(name : string, symbol : string, x : bigint, unit : Unit) = Constant(name, symbol, Rational x, unit)
    new(name : string, symbol : string, x : bigint) = Constant(name, symbol, Rational x, Unit.None)
    
    new(name : string, symbol : string, x : decimal, unit : Unit) = Constant(name, symbol, Rational x, unit)
    new(name : string, symbol : string, x : decimal) = Constant(name, symbol, Rational x, Unit.None)
    
    new(name : string, symbol : string, x : int64, unit : Unit) = Constant(name, symbol, Rational x, unit)
    new(name : string, symbol : string, x : int64) = Constant(name, symbol, Rational x, Unit.None)
    
    new(name : string, symbol : string, x : int, unit : Unit) = Constant(name, symbol, Rational x, unit)
    new(name : string, symbol : string, x : int) = Constant(name, symbol, Rational x, Unit.None)
    
    new(name : string, symbol : string, x : float, unit : Unit) = Constant(name, symbol, Rational x, unit)
    new(name : string, symbol : string, x : float) = Constant(name, symbol, Rational x, Unit.None)
    
    new(name : string, symbol : string, x : float32, unit : Unit) = Constant(name, symbol, Rational x, unit)
    new(name : string, symbol : string, x : float32) = Constant(name, symbol, Rational x, Unit.None)

    new(name : string, symbol : string, x : Value) = Constant(name, symbol, x.X, x.Unit)

    override self.ToString () =
        match self.Unit.HasSymbol with
        | true -> string(self.X.Simplified.ToFloat()) + " " + self.Unit.Symbol
        | false ->
            let x = string((self.X * self.Unit.Scale).Simplified.ToFloat())
            let bu = self.Unit.BaseUnits
            match bu.Count with
            | 0 -> x
            | _ -> x + " " + self.Unit.BaseUnits.ToString()
    
    member self.HasUnitsEquivalentTo (other : Constant) = Value(self.X, self.Unit).HasUnitsEquivalentTo(Value(other.X, other.Unit))

    member self.Pow (b : int) = Value(self.X.Pow(b), self.Unit.Pow(b))
    
    static member op_Explicit(source: Constant) : float =
        match source.Unit.HasSymbol with
        | true -> source.X.ToFloat()
        | false -> (source.X * source.Unit.Scale).ToFloat()

    static member (=>) (self : Constant, unit : Unit) = Value(self.X, self.Unit) => unit

    static member (+) (a : Constant, b : Constant) = Value(a) + Value(b)

    static member (-) (a : Constant, b : Constant) = Value(a) - Value(b)

    static member (*) (a : Constant, b : Constant) = Value(a) * Value(b)
    static member (*) (a : Constant, b : Unit) = Value(a) * b
    static member (*) (a : Constant, b : Rational) = Value(a) * b
    static member (*) (a : Constant, b : int) = Value(a) * b
    static member (*) (a : Unit, b : Constant) = a * Value(b)
    static member (*) (a : Constant, b : UnitPrefix) = Value(a) * b
    static member (*) (a : UnitPrefix, b : Constant) = a * Value(b)
    static member (*) (a : Rational, b : Constant) = a * Value(b)
    static member (*) (a : int, b : Constant) = a * Value(b)
    static member (*) (a : float, b : Constant) = a * Value(b)

    static member (/) (a : Constant, b : Constant) = Value(a) / Value(b)
    static member (/) (a : Constant, b : Unit) = Value(a) / b
    static member (/) (a : Constant, b : Rational) = Value(a) / b
    static member (/) (a : Constant, b : int) = Value(a) / b
    static member (/) (a : Unit, b : Constant) = a / Value(b)
    static member (/) (a : int, b : Constant) = a / Value(b)

and UnitPrefix(name : string, symbol : string, scale : Rational) =
    member this.Name = name
    member this.Symbol = symbol
    member this.Scale = scale
    
    new(name : string, symbol : string, scale : int) = UnitPrefix(name, symbol, Rational scale)
    new(name : string, symbol : string, scale : bigint) = UnitPrefix(name, symbol, Rational scale)

    static member (*) (a : UnitPrefix, b : Unit) = Unit(a.Name + b.Name, a.Symbol + b.Symbol, UnitPrefix.baseOrSelf b, a.Scale * b.Scale)
    static member (*) (a : Unit, b : UnitPrefix) = Unit(b.Name + a.Name, b.Symbol + a.Symbol, UnitPrefix.baseOrSelf a, a.Scale * b.Scale)
    static member (/) (a : UnitPrefix, b : Unit) = Unit(a.Name + b.Name, a.Symbol + b.Symbol, UnitPrefix.baseOrSelf b, a.Scale / b.Scale)
    static member (/) (a : Unit, b : UnitPrefix) = Unit(b.Name + a.Name, b.Symbol + a.Symbol, UnitPrefix.baseOrSelf a, a.Scale / b.Scale)

    static member private baseOrSelf (unit:Unit) : UnitPowers =
        match unit.IsDimensionLess with
        | true -> UnitPowers {Unit = unit; Power = 1}
        | false -> unit.BaseUnits


type internal U = Unit

module internal Fun =

    let E (m : float) (e : int) = Rational(m) * 10R.Pow(e)

