namespace Uncodium.Units

open System
open System.Collections.Generic

type UnitOfMeasure(name : string, symbol : string, unit : Option<UnitPowers>, factor : Fraction) =
    member self.Name = name
    member self.Symbol = symbol
    member self.Unit = unit
    member self.Factor = factor
    
    new(name : string, symbol : string, unit : UnitOfMeasure, factor : Fraction) =
        match unit.Unit with
        | Some xs ->
            let dim = if xs.IsEmpty then None else Some xs
            UnitOfMeasure(name, symbol, dim, factor * unit.Factor)
        | None ->
            if unit.Name = "" then
                UnitOfMeasure(name, symbol, None, factor * unit.Factor)
            else
                UnitOfMeasure(name, symbol, Some (UnitPowers {Unit = unit; Power = 1}), factor * unit.Factor)

    new(name : string, symbol : string, unit : Option<UnitPowers>, factor : bigint) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)

    new(name : string, symbol : string, unit : UnitOfMeasure, factor : bigint) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)
        
    new(name : string, symbol : string, unit : Option<UnitPowers>, factor : int) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)

    new(name : string, symbol : string, unit : UnitOfMeasure, factor : int) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)

    new(name : string, symbol : string, unit : UnitOfMeasure, factor : float) =
        UnitOfMeasure(name, symbol, unit, Fraction factor)

    new(name : string, symbol : string, unit : UnitOfMeasure) =
        UnitOfMeasure(name, symbol, unit, 1)

    new(name : string, symbol : string) =
        UnitOfMeasure(name, symbol, None, 1)

    static member (*) (a : float, b : UnitOfMeasure)    = Value(Fraction a, Some b)
    static member (*) (a : UnitOfMeasure, b : float)    = Value(Fraction b, Some a)
    static member (*) (a : int, b : UnitOfMeasure)    = Value(Fraction a, Some b)
    static member (*) (a : UnitOfMeasure, b : int)    = Value(Fraction b, Some a)
    static member (*) (a : int64, b : UnitOfMeasure)    = Value(Fraction a, Some b)
    static member (*) (a : UnitOfMeasure, b : int64)    = Value(Fraction b, Some a)
    static member (*) (a : bigint, b : UnitOfMeasure)    = Value(Fraction a, Some b)
    static member (*) (a : UnitOfMeasure, b : bigint)    = Value(Fraction b, Some a)
        
    static member (*) (a : UnitOfMeasure, b : UnitOfMeasure) =
        let psa =
            match a.Unit with
            | Some ps -> ps
            | None -> UnitPowers { Unit = a; Power = 1 }
        let psb =
            match b.Unit with
            | Some ps -> ps
            | None -> UnitPowers { Unit = b; Power = 1 }
        let ps : UnitPowers = psa * psb
        let s = string ps
        match ps.Count with
        | 0 -> UnitOfMeasure(s, s, None, a.Factor * b.Factor)
        | _ -> UnitOfMeasure(s, s, Some ps, a.Factor * b.Factor)

    static member (/) (a : UnitOfMeasure, b : UnitOfMeasure) =
        let psa =
            match a.Unit with
            | Some ps -> ps
            | None -> UnitPowers { Unit = a; Power = 1 }
        let psb =
            match b.Unit with
            | Some ps -> ps
            | None -> UnitPowers { Unit = b; Power = 1 }
        let ps : UnitPowers = psa / psb
        let s = string ps
        match ps.Count with
        | 0 -> UnitOfMeasure(s, s, None, a.Factor / b.Factor)
        | _ -> UnitOfMeasure(s, s, Some ps, a.Factor / b.Factor)

    static member (/) (a : int, b : UnitOfMeasure) =
        let ps =
            match b.Unit with
            | Some ps -> ps.Inverse
            | None -> UnitPowers { Unit = b; Power = -1 }
        let s = string ps
        match ps.Count with
        | 0 -> UnitOfMeasure(s, s, None, a / b.Factor)
        | _ -> UnitOfMeasure(s, s, Some ps, a / b.Factor)

    member self.Pow (b : int) =
        if b = 0 then
            UnitOfMeasure("", "", None, Fraction.One)
        else
            let ps =
                match self.Unit with
                | Some ps -> ps.Pow(b)
                | None -> UnitPowers { Unit = self; Power = b }
            let s = string ps
            match ps.Count with
            | 0 -> UnitOfMeasure(s, s, None, self.Factor.Pow(b))
            | _ -> UnitOfMeasure(s, s, Some ps, self.Factor.Pow(b))

    member self.HasEquivalentUnits (other : UnitOfMeasure) =
        if obj.ReferenceEquals(self, other) then
            true
        else
            match (self.Unit, other.Unit) with
            | (Some u1, Some u2) -> u1.HasEquivalentUnits(u2)
            | (Some u1, None) -> u1.HasEquivalentUnits(other)
            | (None, Some u2) -> u2.HasEquivalentUnits(self)
            | _ -> false

    
    override self.ToString () = 
        match self.Unit with
        | Some u -> 
            let ps : UnitPower[] = u.Value
            if u.Count = 1 && (ps.[0].Power = 1) then
                let p = ps.[0].Unit
                sprintf "%s (%s) %s" p.Name p.Symbol (string p.Factor)
            else
                sprintf "%s (%s) %s %s" self.Name self.Symbol (string u) (string self.Factor)

        | None -> sprintf "%s (%s) %s" self.Name self.Symbol (string self.Factor)
 
    static member private normalize (powers : Dictionary<UnitOfMeasure,int>) : UnitPower[] =
        let pos = powers |> Seq.filter (fun kv -> kv.Value > 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let neg = powers |> Seq.filter (fun kv -> kv.Value < 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        Seq.append pos neg |> Seq.map (fun kv -> {Unit = kv.Key; Power = kv.Value}) |> Seq.toArray

and UnitPower = { Unit : UnitOfMeasure; Power : int }

and UnitPowers(ps : UnitPower[]) =
    
    member self.Value with get () = ps
    member self.Count with get () = ps.Length

    new(ps : seq<UnitPower>) = UnitPowers (ps |> UnitPowers.normalize)
    new(p : UnitPower) = UnitPowers [| p |]
        
    member self.Inverse
        with get () =
            let xs = self.Value |> Seq.map (fun x -> { Unit = x.Unit; Power = -x.Power }) |> UnitPowers.normalize
            UnitPowers(xs)

    member self.IsEmpty with get () = self.Value.Length = 0 || (self.Value.Length = 1 && self.Value.[0].Unit.Name = "")

    override self.ToString () = String.Join("", self.Value |> Seq.map (fun x -> "[" + x.Unit.Symbol + "^" + string(x.Power) + "]"))

    static member (*) (a : UnitPowers, b : UnitPowers) =
        if a.Value.Length = 0 then b
        elif b.Value.Length = 0 then a
        else
            let d = Dictionary<UnitOfMeasure, int>()
            for x in a.Value do d.Add(x.Unit, x.Power)
            for x in b.Value do
                match d.ContainsKey x.Unit with
                | false -> d.Add(x.Unit, x.Power)
                | true -> d.[x.Unit] <- (d.[x.Unit] + x.Power)
            
            d |> Seq.map (fun kv -> { Unit = kv.Key; Power = kv.Value }) |> UnitPowers

    static member (/) (a : UnitPowers, b : UnitPowers) =
        if a.Value.Length = 0 then b.Inverse
        elif b.Value.Length = 0 then a
        else
            let d = Dictionary<UnitOfMeasure, int>()
            for x in a.Value do d.Add(x.Unit, x.Power)
            for x in b.Value do
                match d.ContainsKey x.Unit with
                | false -> d.Add(x.Unit, -x.Power)
                | true -> d.[x.Unit] <- (d.[x.Unit] - x.Power)
            
            d |> Seq.map (fun kv -> { Unit = kv.Key; Power = kv.Value }) |> UnitPowers

    member self.Pow(b : int) =
        self.Value
        |> Seq.map (fun x -> { Unit = x.Unit; Power = x.Power * b})
        |> Seq.filter (fun x -> x.Power <> 0)
        |> Seq.toArray
        |> UnitPowers
        
    member self.HasEquivalentUnits (other : UnitPowers) =
        match self.Count = other.Count with
        | true -> Seq.zip self.Value other.Value |> Seq.forall (fun (x,y) -> x.Unit = y.Unit && x.Power = y.Power) 
        | false -> false

    member self.HasEquivalentUnits (other : UnitOfMeasure) =
        match self.Count with
        | 1 ->
            let x = self.Value.[0]
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

    static member private baseOrSelf (unit:UnitOfMeasure) : Option<UnitPowers> =
        match unit.Unit with
        | None -> Some (UnitPowers {Unit = unit; Power = 1})
        | Some x -> Some x

and Value(x : Fraction, unit : Option<UnitOfMeasure>) =
    member self.X = x
    member self.Unit = unit

    new(x : int, unit : Option<UnitOfMeasure>) = Value(Fraction x, unit)
    
    override self.ToString () =
        match self.Unit with
        | Some u -> string(self.X.Float) + " " + u.Symbol
        | None -> string(self.X.Float)
    
    member self.HasEquivalentUnits (other : Value) =
        match (self.Unit, other.Unit) with
        | (Some u1, Some u2) -> u1.HasEquivalentUnits(u2)
        | (None, None) -> true
        | _ -> false

    static member (*) (a : Value, b : float)    = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : float, b : Value)    = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : Value, b : int)      = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : int, b : Value)      = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : Value, b : int64)    = Value(a.X * Fraction b, a.Unit)
    static member (*) (a : int64, b : Value)    = Value(Fraction a * b.X, b.Unit)
    static member (*) (a : Value, b : Value)    =
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(a.X * b.X, Some (u1 * u2))
        | (Some u1, None) -> Value(a.X * b.X, Some u1)
        | (None, Some u2) -> Value(a.X * b.X, Some u2)
        | (None, None) -> Value(a.X * b.X, None)
    static member (*) (a : Value, b : Constant) =
        let f : Fraction = a.X * b.X
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(f, Some(u1 * u2))
        | (Some u1, None) -> Value(f, Some u1)
        | (None, Some u2) -> Value(f, Some u2)
        | (None, None) -> Value(f,None)
    static member (*) (a : Constant, b : Value) =
        let f : Fraction = a.X * b.X
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(f, Some(u1 * u2))
        | (Some u1, None) -> Value(f, Some u1)
        | (None, Some u2) -> Value(f, Some u2)
        | (None, None) -> Value(f,None)
    static member (*) (a : Value, b : UnitOfMeasure)    =
        match a.Unit with
        | Some u -> Value(a.X, Some (u * b))
        | None -> Value(a.X, Some b)
    static member (*) (a : UnitOfMeasure, b : Value)    =
        match b.Unit with
        | Some u -> Value(b.X, Some (a * u))
        | None -> Value(b.X, Some a)
        
    static member (/) (a : Value, b : float)    = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : float, b : Value)    = Value(Fraction a / b.X, b.Unit)
    static member (/) (a : Value, b : int)      = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : int, b : Value)      = Value(Fraction a / b.X, b.Unit)
    static member (/) (a : Value, b : int64)    = Value(a.X / Fraction b, a.Unit)
    static member (/) (a : int64, b : Value)    = Value(Fraction a / b.X, b.Unit)
    static member (/) (a : Value, b : Value)    =
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(a.X / b.X, Some (u1 / u2))
        | (Some u1, None) -> Value(a.X / b.X, Some u1)
        | (None, Some u2) -> Value(a.X / b.X, Some u2)
        | (None, None) -> Value(a.X / b.X, None)
    static member (/) (a : Value, b : Constant) =
        let f : Fraction = a.X / b.X
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(f, Some (u1 / u2))
        | (Some u1, None) -> Value(f, Some u1)
        | (None, Some u2) -> Value(f, Some u2)
        | (None, None) -> Value(f, None)
    static member (/) (a : Constant, b : Value) =
        let f : Fraction = a.X / b.X
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(f, Some (u1 / u2))
        | (Some u1, None) -> Value(f, Some u1)
        | (None, Some u2) -> Value(f, Some u2)
        | (None, None) -> Value(f, None)
    static member (/) (a : Value, b : UnitOfMeasure)    =
        match a.Unit with
        | Some u -> Value(a.X, Some (u / b))
        | None -> Value(a.X, Some b)
    static member (/) (a : UnitOfMeasure, b : Value)    =
        match b.Unit with
        | Some u -> Value(b.X, Some (a / u))
        | None -> Value(b.X, Some a)

    static member inline relation (a : Value) (b : Value) f =
        if a.HasEquivalentUnits b then
            match (a.Unit, b.Unit) with
            | (Some u1, Some u2) -> f (a.X * u1.Factor) (b.X * u2.Factor)
            | (Some u1, None) -> f (a.X * u1.Factor) b.X
            | (None, Some u2) -> f a.X (b.X * u2.Factor)
            | (None, None) -> f a.X b.X
        else
            invalidOp (sprintf "Values (%A) and (%A) have different units." a b)

    static member op_LessThan (a, b) = Value.relation a b (<)
    static member op_LessThanOrEqual (a, b) = Value.relation a b (<=)
    static member op_Equality (a, b) = Value.relation a b (=)
    static member op_Inequality (a, b) = Value.relation a b (<>)
    static member op_GreaterThanOrEqual (a, b) = Value.relation a b (>=)
    static member op_GreaterThan (a, b) = Value.relation a b (>)

    interface IComparable<Value> with
        member self.CompareTo other =
            if self.HasEquivalentUnits other then
                match (self.Unit, other.Unit) with
                | (Some u1, Some u2) -> ((self.X * u1.Factor) :> IComparable<_>).CompareTo(other.X * u2.Factor)
                | (Some u1, None) -> ((self.X * u1.Factor) :> IComparable<_>).CompareTo(other.X)
                | (None, Some u2) -> (self.X :> IComparable<_>).CompareTo(other.X * u2.Factor)
                | (None, None) -> (self.X :> IComparable<_>).CompareTo(other.X)
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
            if self.HasEquivalentUnits other then
                match (self.Unit, other.Unit) with
                | (Some u1, Some u2) -> self.X * u1.Factor = other.X * u2.Factor
                | (Some u1, None) -> self.X * u1.Factor = other.X
                | (None, Some u2) -> self.X = other.X * u2.Factor
                | (None, None) -> self.X = other.X
            else
                invalidOp (sprintf "Values (%A) and (%A) have different units." self other)

    override self.GetHashCode() = hash (self.X, self.Unit)

    override self.Equals(obj) =
        match obj with
        | :? Value as other ->
            if self.HasEquivalentUnits other then
                match (self.Unit, other.Unit) with
                | (Some u1, Some u2) -> self.X * u1.Factor = other.X * u2.Factor
                | (Some u1, None) -> self.X * u1.Factor = other.X
                | (None, Some u2) -> self.X = other.X * u2.Factor
                | (None, None) -> self.X = other.X
            else
                invalidOp (sprintf "Values (%A) and (%A) have different units." self other)
        | _ -> false

and Constant(name : string, symbol : string, x : Fraction, unit : Option<UnitOfMeasure>) =
    member self.Name = name
    member self.Symbol = symbol
    member self.X = x
    member self.Unit = unit

    new(name : string, symbol : string, x : Fraction, unit : UnitOfMeasure) = Constant(name, symbol, x, Some unit)
    new(name : string, symbol : string, x : int, unit : Option<UnitOfMeasure>) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : bigint, unit : Option<UnitOfMeasure>) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : float, unit : Option<UnitOfMeasure>) = Constant(name, symbol, Fraction x, unit)
    new(name : string, symbol : string, x : int, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, Some unit)
    new(name : string, symbol : string, x : bigint, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, Some unit)
    new(name : string, symbol : string, x : float, unit : UnitOfMeasure) = Constant(name, symbol, Fraction x, Some unit)
    new(name : string, symbol : string, x : Value) = Constant(name, symbol, x.X, x.Unit)
    new(name : string, symbol : string, x : Fraction) = Constant(name, symbol, x, None)

    override self.ToString () =
        match self.Unit with
        | Some u -> string(self.X.Float) + " " + u.Symbol
        | None -> string(self.X.Float)
    
    member self.HasEquivalentUnits (other : Constant) =
        match (self.Unit, other.Unit) with
        | (Some u1, Some u2) -> u1.HasEquivalentUnits(u2)
        | (None, None) -> true
        | _ -> false

    static member (+) (a : Constant, b : Constant) =
        if (not (a.HasEquivalentUnits b)) then
            match (a.Unit, b.Unit) with
            | (Some u1, Some u2) -> failwith (sprintf "Incompatible units. Cannot add (%A) and (%A)." u1 u2)
            | (Some u1, None) -> failwith (sprintf "Incompatible units. Cannot add (%A) and ()." u1)
            | (None, Some u2) -> failwith (sprintf "Incompatible units. Cannot add () and (%A)." u2)
            | (None, None) -> failwith (sprintf "Incompatible units. Cannot add () and ().")
        else
            match (a.Unit, b.Unit) with
            | (Some u1, Some u2) ->
                //printfn "(%A %A) (%A %A)" a.X u1.Factor b.X u2.Factor
                let bx = b.X * (u2.Factor / u1.Factor)
                //printfn "(%A) + (%A) = (%A)" a.X bx (a.X + bx)
                Value(a.X + bx, Some u1)
            | _ -> Value(a.X + b.X, a.Unit)

    static member (-) (a : Constant, b : Constant) =
        if (not (a.HasEquivalentUnits b)) then
            match (a.Unit, b.Unit) with
            | (Some u1, Some u2) -> failwith (sprintf "Incompatible units. Cannot subtract (%A) and (%A)." u1 u2)
            | (Some u1, None) -> failwith (sprintf "Incompatible units. Cannot subtract (%A) and ()." u1)
            | (None, Some u2) -> failwith (sprintf "Incompatible units. Cannot subtract () and (%A)." u2)
            | (None, None) -> failwith (sprintf "Incompatible units. Cannot subtract () and ().")
        else
            match (a.Unit, b.Unit) with
            | (Some u1, Some u2) ->
                //printfn "(%A %A) (%A %A)" a.X u1.Factor b.X u2.Factor
                let bx = b.X * (u2.Factor / u1.Factor)
                //printfn "(%A) - (%A) = (%A)" a.X bx (a.X + bx)
                Value(a.X - bx, Some u1)
            | _ -> Value(a.X - b.X, a.Unit)

    static member (*) (a : Constant, b : Constant) = 
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(a.X * b.X, Some (u1 * u2))
        | (Some u1, None) -> Value(a.X * b.X, Some u1)
        | (None, Some u2) -> Value(a.X * b.X, Some u2)
        | (None, None) -> Value(a.X * b.X, None)
    static member (*) (a : Constant, b : UnitOfMeasure) =
        match a.Unit with
        | Some u -> Value(a.X, Some (u * b))
        | None -> Value(a.X, Some b)
    static member (*) (a : UnitOfMeasure, b : Constant) =
        match b.Unit with
        | Some u -> Value(b.X, Some (a * u))
        | None -> Value(b.X, Some a)

    static member (/) (a : Constant, b : Constant) = 
        match (a.Unit, b.Unit) with
        | (Some u1, Some u2) -> Value(a.X / b.X, Some (u1 * u2))
        | (Some u1, None) -> Value(a.X / b.X, Some u1)
        | (None, Some u2) -> Value(a.X / b.X, Some u2)
        | (None, None) -> Value(a.X / b.X, None)
    static member (/) (a : Constant, b : UnitOfMeasure) =
        match a.Unit with
        | Some u -> Value(a.X, Some (u / b))
        | None -> Value(a.X, Some b)
    static member (/) (a : UnitOfMeasure, b : Constant) =
        match b.Unit with
        | Some u -> Value(b.X.Inverse, Some (a / u))
        | None -> Value(b.X.Inverse, Some a)