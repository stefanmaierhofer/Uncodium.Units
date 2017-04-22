namespace Uncodium.Units

open System
open System.Collections.Generic

type UnitOfMeasure(name : string, symbol : string, dimension : Option<UnitPower[]>, factor : Fraction) =
    member this.Name = name
    member this.Symbol = symbol
    member this.Dimension = dimension
    member this.Factor = factor
    
    new(name : string, symbol : string, dimension : UnitOfMeasure, factor : Fraction) =
        match dimension.Dimension with
        | Some xs ->
            if xs.Length = 0 || (xs.Length = 1 && xs.[0].Unit.Name = "") then
                UnitOfMeasure(name, symbol, None, factor * dimension.Factor)
            else
                UnitOfMeasure(name, symbol, Some xs, factor * dimension.Factor)
        | None ->
            if dimension.Name = "" then
                UnitOfMeasure(name, symbol, None, factor * dimension.Factor)
            else
                UnitOfMeasure(name, symbol, Some [| {Unit = dimension; Power = 1} |], factor * dimension.Factor)

    new(name : string, symbol : string, dimension : Option<UnitPower[]>, factor : bigint) =
        UnitOfMeasure(name, symbol, dimension, Fraction factor)

    new(name : string, symbol : string, dimension : UnitOfMeasure, factor : bigint) =
        UnitOfMeasure(name, symbol, dimension, Fraction factor)
        
    new(name : string, symbol : string, dimension : Option<UnitPower[]>, factor : int) =
        UnitOfMeasure(name, symbol, dimension, Fraction factor)

    new(name : string, symbol : string, dimension : UnitOfMeasure, factor : int) =
        UnitOfMeasure(name, symbol, dimension, Fraction factor)

    new(name : string, symbol : string, dimension : UnitOfMeasure, factor : float) =
        UnitOfMeasure(name, symbol, dimension, Fraction factor)

    new(name : string, symbol : string, dimension : UnitOfMeasure) =
        UnitOfMeasure(name, symbol, dimension, 1)
        
    override this.ToString() = sprintf "(%A, %A)" this.Name this.Symbol

    member private this.BaseDimension
        with get () =
            match this.Dimension with
            | None -> this
            | Some xs when xs.Length = 1 ->
                let b = xs.[0]
                UnitOfMeasure(b.Unit.Name, b.Unit.Symbol, Some [| {Unit = b.Unit.BaseDimension; Power = b.Power} |], this.Factor * b.Unit.Factor)

            | Some xs -> this
    
    static member (*) (a : UnitOfMeasure, b : UnitOfMeasure) =
        let d = Dictionary<UnitOfMeasure, int>()
        
        match a.Dimension with
        | None -> d.Add(a, 1)
        | Some xs -> for x in xs do d.Add(x.Unit, x.Power)
            
        match b.Dimension with
        | None ->
            match d.ContainsKey b with
            | true ->
                match d.[b] + 1 with
                | 0 -> d.Remove b |> ignore
                | p -> d.[b] <- p
            | false -> d.[b] <- 1
        | Some xs ->
            for x in xs do
                match d.ContainsKey x.Unit with
                | true ->
                    match d.[x.Unit] + x.Power with
                    | 0 -> d.Remove(x.Unit) |> ignore
                    | p -> d.[x.Unit] <- p
                | false -> d.[x.Unit] <- x.Power

        let pos = d |> Seq.filter (fun kv -> kv.Value > 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let neg = d |> Seq.filter (fun kv -> kv.Value < 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let ps = Seq.append pos neg |> Seq.map (fun kv -> {Unit = kv.Key; Power = kv.Value}) |> Seq.toArray
        
        let dim = match ps.Length with
                  | 0 -> None
                  | _ -> Some ps

        let name = String.Join(" ", ps |> Array.map (fun x -> x.Unit.Symbol + "^" + string(x.Power)))
        UnitOfMeasure(name, name, dim, a.Factor * b.Factor)

    static member (/) (a : UnitOfMeasure, b : UnitOfMeasure) =
        let d = Dictionary<UnitOfMeasure, int>()
        
        match a.Dimension with
        | None -> d.Add(a, 1)
        | Some xs -> for x in xs do d.Add(x.Unit, x.Power)
            
        match b.Dimension with
        | None ->
            match d.ContainsKey b with
            | true ->
                match d.[b] - 1 with
                | 0 -> d.Remove b |> ignore
                | p -> d.[b] <- p
            | false -> d.[b] <- -1
        | Some xs ->
            for x in xs do
                match d.ContainsKey x.Unit with
                | true ->
                    match d.[x.Unit] - x.Power with
                    | 0 -> d.Remove(x.Unit) |> ignore
                    | p -> d.[x.Unit] <- p
                | false -> d.[x.Unit] <- -x.Power

        let pos = d |> Seq.filter (fun kv -> kv.Value > 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let neg = d |> Seq.filter (fun kv -> kv.Value < 0) |> Seq.sortBy (fun kv -> kv.Key.Name)
        let ps = Seq.append pos neg |> Seq.map (fun kv -> {Unit = kv.Key; Power = kv.Value}) |> Seq.toArray
        //printfn "ps.Length: %d" ps.Length
        let dim = match ps.Length with
                  | 0 -> None
                  | _ -> Some ps
        //printfn "dim: %A" dim
        let name = String.Join(" ", ps |> Array.map (fun x -> x.Unit.Symbol + "^" + string(x.Power)))
        UnitOfMeasure(name, name, dim, a.Factor / b.Factor)

and UnitPower = { Unit : UnitOfMeasure; Power : int }

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

    static member private baseOrSelf (unit:UnitOfMeasure) : Option<UnitPower[]> =
        match unit.Dimension with
        | None -> Some [| {Unit = unit; Power = 1} |]
        | Some x -> Some x