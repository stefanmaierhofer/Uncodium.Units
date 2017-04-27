namespace Uncodium.Units

open System
open System.Numerics

[<CustomEquality;CustomComparison>]
type Fraction =
    struct
        val Numerator : bigint
        val Denominator : bigint

        new(numerator: bigint, denominator: bigint) =
            if denominator = 0I then raise (DivideByZeroException())
            match denominator > 0I with
                | true -> { Numerator = numerator; Denominator = denominator }
                | false -> { Numerator = -numerator; Denominator = -denominator }
                
        new(numerator: bigint, denominator: int64) = Fraction(numerator, bigint denominator)
        new(numerator: bigint, denominator: int) = Fraction(numerator, bigint denominator)
        new(numerator : bigint, denominator : float) =
            let f = Fraction.scale denominator
            Fraction(numerator * f, bigint(denominator * float(f)))
        new(numerator : bigint, denominator : float32) = Fraction(numerator, float denominator)
        new(numerator: bigint) = Fraction(numerator, bigint 1)
        
        new(numerator: int64, denominator: bigint) = Fraction(bigint numerator, denominator)
        new(numerator: int64, denominator: int64) = Fraction(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: int) = Fraction(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: float) = Fraction(bigint numerator, denominator)
        new(numerator: int64, denominator: float32) = Fraction(bigint numerator, denominator)
        new(numerator: int64) = Fraction(bigint numerator, bigint 1)

        new(numerator: int, denominator: bigint) = Fraction(bigint numerator, denominator)
        new(numerator: int, denominator: int64) = Fraction(bigint numerator, bigint denominator)
        new(numerator: int, denominator: int) = Fraction(bigint numerator, bigint denominator)
        new(numerator: int, denominator: float) = Fraction(bigint numerator, denominator)
        new(numerator: int, denominator: float32) = Fraction(bigint numerator, denominator)
        new(numerator: int) = Fraction(bigint numerator, bigint 1)
        
        new(numerator : float, denominator : bigint) =
            let f = Fraction.scale numerator
            Fraction(bigint(numerator * float(f)), denominator * f)
        new(numerator : float, denominator : int64) = Fraction(numerator, bigint denominator)
        new(numerator : float, denominator : int) = Fraction(numerator, bigint denominator)
        new(numerator : float, denominator : float) =
            let f = float(bigint.Max(Fraction.scale numerator, Fraction.scale denominator))
            Fraction(bigint(numerator * f), bigint(denominator * f))
        new(numerator : float, denominator : float32) = Fraction(numerator, float denominator)
        new(numerator : float) =
            let d = Fraction.scale numerator
            let n = bigint(numerator * float(d))
            Fraction(n, d)
            
        new(numerator : float32, denominator : bigint) = Fraction(float numerator, denominator)
        new(numerator : float32, denominator : int64) = Fraction(float numerator, bigint denominator)
        new(numerator : float32, denominator : int) = Fraction(float numerator, bigint denominator)
        new(numerator : float32, denominator : float) = Fraction(float numerator, denominator)
        new(numerator : float32, denominator : float32) = Fraction(float numerator, float denominator)
        new(numerator : float32) = Fraction(float numerator)

        member self.Simplified
            with get () =
                let d = Fraction.gcd self.Numerator self.Denominator
                if d = bigint(1) then self
                else Fraction(self.Numerator / d, self.Denominator / d)

        member self.Float with get () = float self.Numerator / float self.Denominator

        member self.Inverse with get () = Fraction(self.Denominator, self.Numerator)

        member self.Pow(b : int) =
            match b >= 0 with
            | true -> Fraction(bigint.Pow(self.Numerator, b), bigint.Pow(self.Denominator, b))
            | false -> Fraction(bigint.Pow(self.Denominator, -b), bigint.Pow(self.Numerator, -b))

        member self.IsIdentical(other : Fraction) = self.Numerator = other.Numerator && self.Denominator = other.Denominator

        override self.ToString() = sprintf "(%A/%A)" self.Numerator self.Denominator

        static member (*) (a : Fraction, b : Fraction) = Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator)
        static member (*) (a : Fraction, b : bigint) = Fraction(a.Numerator * b, a.Denominator)
        static member (*) (a : bigint, b : Fraction) = Fraction(a * b.Numerator, b.Denominator)
        static member (*) (a : Fraction, b : int) = Fraction(a.Numerator * bigint b, a.Denominator)
        static member (*) (a : int, b : Fraction) = Fraction(bigint a * b.Numerator, b.Denominator)
        static member (*) (a : Fraction, b : int64) = Fraction(a.Numerator * bigint b, a.Denominator)
        static member (*) (a : int64, b : Fraction) = Fraction(bigint a * b.Numerator, b.Denominator)

        static member (/) (a : Fraction, b : Fraction) = Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator)
        static member (/) (a : Fraction, b : bigint) = Fraction(a.Numerator / b, a.Denominator)
        static member (/) (a : bigint, b : Fraction) = Fraction(a / b.Numerator, b.Denominator)
        static member (/) (a : Fraction, b : int) = Fraction(a.Numerator, a.Denominator * bigint b)
        static member (/) (a : int, b : Fraction) = Fraction(bigint a / b.Numerator, b.Denominator)
        static member (/) (a : Fraction, b : int64) = Fraction(a.Numerator, a.Denominator * bigint b)
        static member (/) (a : int64, b : Fraction) = Fraction(bigint a / b.Numerator, b.Denominator)

        static member (+) (a : Fraction, b : Fraction) =
            if a.Denominator = b.Denominator then
                Fraction(a.Numerator + b.Numerator, a.Denominator).Simplified
            else
                Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified

        static member (-) (a : Fraction, b : Fraction) =
            if a.Denominator = b.Denominator then
                Fraction(a.Numerator - b.Numerator, a.Denominator).Simplified
            else
                Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified

        static member (~-) (a : Fraction) =
            Fraction(-a.Numerator, a.Denominator)
        
        static member inline relation (a : Fraction) (b : Fraction) f =
            if a.Denominator = b.Denominator then f a.Numerator  b.Numerator
            else f (a.Numerator * b.Denominator) (b.Numerator * a.Denominator)
        static member op_LessThan (a, b) = Fraction.relation a b (<)
        static member op_LessThanOrEqual (a, b) = Fraction.relation a b (<=)
        static member op_Equality (a, b) = Fraction.relation a b (=)
        static member op_Inequality (a, b) = Fraction.relation a b (<>)
        static member op_GreaterThanOrEqual (a, b) = Fraction.relation a b (>=)
        static member op_GreaterThan (a, b) = Fraction.relation a b (>)
                  
        interface IComparable<Fraction> with
            member self.CompareTo { Numerator = numerator; Denominator = denominator } =
                if self.Denominator = denominator then
                    self.Numerator.CompareTo numerator
                else
                    (self.Numerator * denominator).CompareTo(numerator * self.Denominator)

        interface IComparable with
            member self.CompareTo obj =
                match obj with
                  | null                 -> 1
                  | :? Fraction as other -> (self :> IComparable<_>).CompareTo other
                  | _                    -> invalidArg "obj" "not a Fraction"

        interface IEquatable<Fraction> with
            member self.Equals { Numerator = numerator; Denominator = denominator } =
                if self.Denominator = denominator then
                    self.Numerator = numerator
                else
                    self.Numerator * denominator = numerator * self.Denominator

        override self.GetHashCode() =
            hash (self.Numerator, self.Denominator)

        override self.Equals(obj) =
            match obj with
            | :? Fraction as other ->
                if self.Denominator = other.Denominator then
                    self.Numerator = other.Numerator
                else
                    self.Numerator * other.Denominator = other.Numerator * self.Denominator
            | _ -> false

        static member One           = Fraction(1L, 1L)
        static member OneHalf       = Fraction(1L, 2L)
        static member OneThird      = Fraction(1L, 3L)
        static member TwoThirds     = Fraction(2L, 3L)
        static member OneQuarter    = Fraction(1L, 4L)
        static member ThreeQuarters = Fraction(3L, 4L)
        static member OneFifth      = Fraction(1L, 5L)
        static member Pi            = Fraction(314159265358979323846264338327950288419716939937510I, bigint.Pow(10I, 50))
        static member e             = Fraction(271828182845904523536028747135266249775724709369995I, bigint.Pow(10I, 50))
        
        static member private gcd a b =
            if a = 0I || b = 0I then 1I
            else
                match (a < 0I, b < 0I) with
                | (false, false) -> Fraction.gcd' a b
                | (false, true) -> -Fraction.gcd' a -b
                | (true, false) -> Fraction.gcd' -a b
                | (true, true) -> -Fraction.gcd' -a -b

        static member private gcd' a b =
            if a = b then a
            else if a > b then Fraction.gcd' (a-b) b else Fraction.gcd' a (b-a)

        static member private scale (x : float) : bigint =
            let s = string x
            match s.IndexOf('.') with
            | -1 -> 1I 
            | i -> bigint.Pow(10I, s.Length - i - 1)
            
    end
    