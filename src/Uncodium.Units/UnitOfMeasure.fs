namespace Uncodium.Units

open System
open System.Collections.Generic

type UnitOfMeasure =

    val Name : string
    val Symbol : string
    val BaseUnits : UnitPowers
    val Scale : Fraction
    
    new(name : string, symbol : string, baseUnits : UnitPowers, scale : Fraction) =
        if name = null then invalidArg "name" "UnitOfMeasure.Name must not be null."
        if symbol = null then invalidArg "symbol" "UnitOfMeasure.Symbol must not be null."
        { Name = name; Symbol = symbol; BaseUnits = baseUnits; Scale = scale.Simplified }

    new(name : string, symbol : string, unit : UnitOfMeasure, scale : Fraction) =
        match unit.IsDimensionLess with

        | true ->
            if unit.Name = "" then
                UnitOfMeasure(name, symbol, unit.BaseUnits, scale * unit.Scale)
            else
                UnitOfMeasure(name, symbol, UnitPowers {Unit = unit; Power = 1}, scale * unit.Scale)
        
        | false ->
            UnitOfMeasure(name, symbol, unit.BaseUnits, scale * unit.Scale)
                
    new(name : string, symbol : string, unit : UnitOfMeasure, scale : bigint) =
        UnitOfMeasure(name, symbol, unit, Fraction scale)
        
    new(name : string, symbol : string, unit : UnitOfMeasure, scale : int) =
        UnitOfMeasure(name, symbol, unit, Fraction scale)

    new(name : string, symbol : string, unit : UnitOfMeasure, scale : float) =
        UnitOfMeasure(name, symbol, unit, Fraction scale)

    new(name : string, symbol : string, unit : UnitOfMeasure) =
        UnitOfMeasure(name, symbol, unit, Fraction.One)

    new(name : string, symbol : string) =
        UnitOfMeasure(name, symbol, UnitPowers.None, Fraction.One)
    
    new(value : Value) =
        let u : UnitOfMeasure = value.Unit
        UnitOfMeasure(u.Name, u.Symbol, u.BaseUnits, value.X * u.Scale)

    new(value : Constant) =
        let u : UnitOfMeasure = value.Unit
        UnitOfMeasure(u.Name, u.Symbol, u.BaseUnits, value.X * u.Scale)
        
    member self.IsDimensionLess with get () = self.BaseUnits.IsDimensionLess
    member internal self.HasName with get() = self.Name <> ""
    member internal self.HasSymbol with get() = self.Symbol <> ""

    static member None = UnitOfMeasure("dimensionless", "-")
    
    static member (*) (a : UnitOfMeasure, b : UnitOfMeasure) =
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
        UnitOfMeasure("", symbol, powers, a.Scale * b.Scale)
    static member (*) (a : UnitOfMeasure, b : Fraction)      = Value(b, a)
    static member (*) (a : UnitOfMeasure, b : bigint)        = Value(Fraction b, a)
    static member (*) (a : UnitOfMeasure, b : int64)         = Value(Fraction b, a)
    static member (*) (a : UnitOfMeasure, b : int)           = Value(Fraction b, a)
    static member (*) (a : UnitOfMeasure, b : float)         = Value(Fraction b, a)
    static member (*) (a : UnitOfMeasure, b : float32)       = Value(Fraction b, a)
    static member (*) (a : Fraction, b : UnitOfMeasure)      = Value(a, b)
    static member (*) (a : bigint, b : UnitOfMeasure)        = Value(Fraction a, b)
    static member (*) (a : int64, b : UnitOfMeasure)         = Value(Fraction a, b)
    static member (*) (a : int, b : UnitOfMeasure)           = Value(Fraction a, b)
    static member (*) (a : float, b : UnitOfMeasure)         = Value(Fraction a, b)
    static member (*) (a : float32, b : UnitOfMeasure)       = Value(Fraction a, b)

    static member (/) (a : UnitOfMeasure, b : UnitOfMeasure) =
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
        UnitOfMeasure("", symbol, powers, (a.Scale / b.Scale).Simplified)

    static member (/) (a : int, b : UnitOfMeasure) =
        let powers =
            match b.IsDimensionLess with
            | true -> UnitPowers { Unit = b; Power = -1 }
            | false -> b.BaseUnits.Inverse
        UnitOfMeasure("", "", powers, a / b.Scale)

    member self.Pow (b : int) =
        if b = 0 then
            UnitOfMeasure("", "", UnitPowers.None, Fraction.One)
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
            UnitOfMeasure("", symbol, powers, self.Scale.Pow(b))

    member inline self.Float with get () = float self.Scale

    static member inline op_Explicit(source: UnitOfMeasure) : float = source.Float

    member internal self.HasUnitsEquivalentTo (other : UnitOfMeasure) =
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

    static member private normalize (powers : Dictionary<UnitOfMeasure,int>) : UnitPower[] =
        let pos = powers |> Seq.filter (fun kv -> kv.Value > 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let neg = powers |> Seq.filter (fun kv -> kv.Value < 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        Seq.append pos neg |> Seq.map (fun kv -> {Unit = kv.Key; Power = kv.Value}) |> Seq.toArray

and UnitPower = { Unit : UnitOfMeasure; Power : int }

and UnitPowers =

    static member None : UnitPowers = UnitPowers()
    
    val Powers : UnitPower[]
    
    member self.Count = self.Powers.Length
    
    new(powers : UnitPower[]) =
        for p in powers do
            if not p.Unit.IsDimensionLess then invalidArg (string p.Unit) (sprintf "[%A]^%A" p.Unit p.Power)
        { Powers = powers |> UnitPowers.normalize }

    new() = UnitPowers [| |]
    new(unit : UnitOfMeasure, power : int) = UnitPowers [| { Unit = unit; Power = power } |];
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
        
    member internal self.HasUnitsEquivalentTo (other : UnitPowers) =
        match self.Count = other.Count with
        | true -> Seq.zip self.Powers other.Powers |> Seq.forall (fun (x,y) -> x.Unit = y.Unit && x.Power = y.Power) 
        | false -> false

    member internal self.HasUnitsEquivalentTo (other : UnitOfMeasure) =
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
        match self.Unit.HasSymbol with
        | true -> string(self.X.Simplified.ToFloat()) + " " + self.Unit.Symbol
        | false ->
            let x = string((self.X * self.Unit.Scale).Simplified.ToFloat())
            let bu = self.Unit.BaseUnits
            match bu.Count with
            | 0 -> x
            | _ -> x + " " + self.Unit.BaseUnits.ToString()
    
    member self.ConvertTo(unit : UnitOfMeasure) =
        if self.Unit.HasUnitsEquivalentTo unit then
                Value(self.X * self.Unit.Scale / unit.Scale, unit)
            else
                invalidOp (sprintf "Cannot convert (%A) to (%A)." self unit)

    static member (=>) (self : Value, unit : UnitOfMeasure) =
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
        UnitOfMeasure(u.Name, u.Symbol, u.BaseUnits, f) 
    
    member self.Pow (b : int) = Value(self.X.Pow(b), self.Unit.Pow(b))
         
    static member (*) (a : Value, b : Value)         =
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(a.X * b.X, a.Unit * b.Unit)
        | (true, false) -> Value(a.X * b.X, a.Unit)
        | (false, true) -> Value(a.X * b.X, b.Unit)
        | (false, false) -> Value(a.X * b.X, UnitOfMeasure.None)
    static member (*) (a : Value, b : UnitOfMeasure) =
        match a.Unit <> UnitOfMeasure.None with
        | true -> Value(a.X, a.Unit * b)
        | false -> Value(a.X, b)
    static member (*) (a : Value, b : UnitPrefix)    =
        match a.Unit <> UnitOfMeasure.None with
        | true -> Value(a.X, a.Unit * b)
        | false ->
            let x : Fraction = a.X * b.Scale
            Value(x, UnitOfMeasure.None)
    static member (*) (a : Value, b : Constant)      =
        let f : Fraction = a.X * b.X
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(f, a.Unit * b.Unit)
        | (true, false) -> Value(f, a.Unit)
        | (false, true) -> Value(f, b.Unit)
        | (false, false) -> Value(f, UnitOfMeasure.None)
    static member (*) (a : Value, b : Fraction)      = Value(a.X * b, a.Unit)
    static member (*) (a : Value, b : bigint)        = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : Value, b : int64)         = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : Value, b : int)           = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : Value, b : float)         = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : Value, b : float32)       = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : UnitOfMeasure, b : Value) =
        match b.Unit <> UnitOfMeasure.None with
        | true -> Value(b.X, a * b.Unit)
        | false -> Value(b.X, a)
    static member (*) (a : UnitPrefix, b : Value)    =
        match b.Unit <> UnitOfMeasure.None with
        | true -> Value(b.X, a * b.Unit)
        | false -> Value(b.X * a.Scale, UnitOfMeasure.None)
    static member (*) (a : Constant, b : Value)      =
        let f : Fraction = a.X * b.X
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(f, a.Unit * b.Unit)
        | (true, false) -> Value(f, a.Unit)
        | (false, true) -> Value(f, b.Unit)
        | (false, false) -> Value(f, UnitOfMeasure.None)
    static member (*) (a : Fraction, b : Value)      = Value(a * b.X, b.Unit)
    static member (*) (a : int64, b : Value)         = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : int, b : Value)           = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : float, b : Value)         = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : float32, b : Value)       = Value(Fraction a * b.X, b.Unit)
        
    static member (/) (a : Value, b : Value)         =
        match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
        | (true, true) -> Value(a.X / b.X, a.Unit / b.Unit)
        | (true, false) -> Value(a.X / b.X, a.Unit)
        | (false, true) -> Value(a.X / b.X, b.Unit)
        | (false, false) -> Value(a.X / b.X, UnitOfMeasure.None)
    static member (/) (a : Value, b : UnitOfMeasure) =
        match a.Unit <> UnitOfMeasure.None with
        | true -> Value(a.X, a.Unit / b)
        | false -> Value(a.X, b)
    static member (/) (a : Value, b : UnitPrefix)    =
        match a.Unit <> UnitOfMeasure.None with
        | true -> Value(a.X, a.Unit / b)
        | false -> 
            let x : Fraction = a.X / b.Scale
            Value(x, UnitOfMeasure.None)
    static member (/) (a : Value, b : Constant)      = a / Value(b)
    static member (/) (a : Value, b : Fraction)      = Value(a.X / b, a.Unit)
    static member (/) (a : Value, b : bigint)        = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : Value, b : int64)         = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : Value, b : int)           = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : Value, b : float)         = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : Value, b : float32)       = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : UnitOfMeasure, b : Value) =
        match b.Unit <> UnitOfMeasure.None with
        | true -> Value(b.X, a / b.Unit)
        | false -> Value(b.X, a)
    static member (/) (a : UnitPrefix, b : Value)    =
        match b.Unit <> UnitOfMeasure.None with
        | true -> Value(b.X, a / b.Unit)
        | false -> Value(b.X / a.Scale, UnitOfMeasure.None)
    static member (/) (a : Constant, b : Value)      = Value(a) / b
    static member (/) (a : int64, b : Value)         = Value(Fraction a / b.X, 1 / b.Unit)
    static member (/) (a : int, b : Value)           = Value(Fraction a / b.X, 1 / b.Unit)
    static member (/) (a : float, b : Value)         = Value(Fraction a / b.X, 1 / b.Unit)
    static member (/) (a : float32, b : Value)       = Value(Fraction a / b.X, 1 / b.Unit)

    static member (+) (a : Value, b : Value)    =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
            | (true, true) -> Value(a.X + b.X * b.Unit.Scale / a.Unit.Scale, a.Unit)
            | (true, false) -> Value(a.X + b.X, a.Unit)
            | (false, true) -> Value(a.X + b.X, b.Unit)
            | (false, false) -> Value(a.X + b.X, UnitOfMeasure.None)
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)
    static member (+) (a : Value, b : Fraction) = Value(a.X + b, a.Unit)
    static member (+) (a : Value, b : bigint)   = Value(a.X + Fraction b, a.Unit)
    static member (+) (a : Value, b : int64)    = Value(a.X + Fraction b, a.Unit)
    static member (+) (a : Value, b : int)      = Value(a.X + Fraction b, a.Unit)
    static member (+) (a : Value, b : float)    = Value(a.X + Fraction b, a.Unit)
    static member (+) (a : Value, b : float32)  = Value(a.X + Fraction b, a.Unit)

    static member (-) (a : Value, b : Value) =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
            | (true, true) -> Value(a.X - b.X * b.Unit.Scale / a.Unit.Scale, a.Unit)
            | (true, false) -> Value(a.X - b.X, a.Unit)
            | (false, true) -> Value(a.X - b.X, b.Unit)
            | (false, false) -> Value(a.X - b.X, UnitOfMeasure.None)
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)
    static member (-) (a : Value, b : Fraction) = Value(a.X - b, a.Unit)
    static member (-) (a : Value, b : bigint)   = Value(a.X - Fraction b, a.Unit)
    static member (-) (a : Value, b : int64)    = Value(a.X - Fraction b, a.Unit)
    static member (-) (a : Value, b : int)      = Value(a.X - Fraction b, a.Unit)
    static member (-) (a : Value, b : float)    = Value(a.X - Fraction b, a.Unit)
    static member (-) (a : Value, b : float32)  = Value(a.X - Fraction b, a.Unit)
    
    member internal self.HasUnitsEquivalentTo (other : Value) = self.Unit.HasUnitsEquivalentTo(other.Unit)
    static member inline internal op (a : Value) (b : Value) f =
        if a.HasUnitsEquivalentTo b then
            match (a.Unit <> UnitOfMeasure.None, b.Unit <> UnitOfMeasure.None) with
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

    static member inline op_Equality (a : Value, f : Fraction) = a.X * a.Unit.Scale = f

    interface IComparable<Value> with
        member self.CompareTo other =
            if self.HasUnitsEquivalentTo other then
                match (self.Unit <> UnitOfMeasure.None, other.Unit <> UnitOfMeasure.None) with
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
                match (self.Unit <> UnitOfMeasure.None, other.Unit <> UnitOfMeasure.None) with
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

and Constant(name : string, symbol : string, x : Fraction, unit : UnitOfMeasure) =
    member self.Name = name
    member self.Symbol = symbol
    member self.X = x
    member self.Unit = unit
    
    new(name : string, symbol : string, x : Fraction) = Constant(name, symbol, x, UnitOfMeasure.None)
    
    new(name : string, symbol : string, x : bigint, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : bigint) = Constant(name, symbol, Fraction x, UnitOfMeasure.None)
    
    new(name : string, symbol : string, x : decimal, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : decimal) = Constant(name, symbol, Fraction x, UnitOfMeasure.None)
    
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

    static member (=>) (self : Constant, unit : UnitOfMeasure) = Value(self.X, self.Unit) => unit

    static member (+) (a : Constant, b : Constant) = Value(a) + Value(b)

    static member (-) (a : Constant, b : Constant) = Value(a) - Value(b)

    static member (*) (a : Constant, b : Constant) = Value(a) * Value(b)
    static member (*) (a : Constant, b : UnitOfMeasure) = Value(a) * b
    static member (*) (a : Constant, b : Fraction) = Value(a) * b
    static member (*) (a : Constant, b : int) = Value(a) * b
    static member (*) (a : UnitOfMeasure, b : Constant) = a * Value(b)
    static member (*) (a : Constant, b : UnitPrefix) = Value(a) * b
    static member (*) (a : UnitPrefix, b : Constant) = a * Value(b)
    static member (*) (a : Fraction, b : Constant) = a * Value(b)
    static member (*) (a : int, b : Constant) = a * Value(b)
    static member (*) (a : float, b : Constant) = a * Value(b)

    static member (/) (a : Constant, b : Constant) = Value(a) / Value(b)
    static member (/) (a : Constant, b : UnitOfMeasure) = Value(a) / b
    static member (/) (a : Constant, b : Fraction) = Value(a) / b
    static member (/) (a : Constant, b : int) = Value(a) / b
    static member (/) (a : UnitOfMeasure, b : Constant) = a / Value(b)
    static member (/) (a : int, b : Constant) = a / Value(b)

and UnitPrefix(name : string, symbol : string, scale : Fraction) =
    member this.Name = name
    member this.Symbol = symbol
    member this.Scale = scale
    
    new(name : string, symbol : string, scale : int) = UnitPrefix(name, symbol, Fraction scale)
    new(name : string, symbol : string, scale : bigint) = UnitPrefix(name, symbol, Fraction scale)

    static member (*) (a : UnitPrefix, b : UnitOfMeasure) = UnitOfMeasure(a.Name + b.Name, a.Symbol + b.Symbol, UnitPrefix.baseOrSelf b, a.Scale * b.Scale)
    static member (*) (a : UnitOfMeasure, b : UnitPrefix) = UnitOfMeasure(b.Name + a.Name, b.Symbol + a.Symbol, UnitPrefix.baseOrSelf a, a.Scale * b.Scale)
    static member (/) (a : UnitPrefix, b : UnitOfMeasure) = UnitOfMeasure(a.Name + b.Name, a.Symbol + b.Symbol, UnitPrefix.baseOrSelf b, a.Scale / b.Scale)
    static member (/) (a : UnitOfMeasure, b : UnitPrefix) = UnitOfMeasure(b.Name + a.Name, b.Symbol + a.Symbol, UnitPrefix.baseOrSelf a, a.Scale / b.Scale)

    static member private baseOrSelf (unit:UnitOfMeasure) : UnitPowers =
        match unit.IsDimensionLess with
        | true -> UnitPowers {Unit = unit; Power = 1}
        | false -> unit.BaseUnits


type internal U = UnitOfMeasure
type internal F = Fraction

module internal Fun =

    let (^^) (a : int) (b : int) : Fraction = Fraction.Pow(bigint a, b)

    let (^) (a : UnitOfMeasure) (b : int) : UnitOfMeasure = a.Pow(b)

    let E (m : float) (e : int) = F(m) * F.Pow(10, e)

