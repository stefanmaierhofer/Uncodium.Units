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
        new(numerator: bigint, denominator: decimal)    = Fraction(numerator, bigint denominator)
        new(numerator: bigint, denominator: int64)      = Fraction(numerator, bigint denominator)
        new(numerator: bigint, denominator: int)        = Fraction(numerator, bigint denominator)
        new(numerator : bigint, denominator : float)    =
            let f = Fraction.scale denominator
            Fraction(numerator * f, bigint(denominator * float(f)))
        new(numerator : bigint, denominator : float32)  = Fraction(numerator, float denominator)
        new(numerator: bigint)                          = Fraction(numerator, 1I)
        
        new(numerator: int64, denominator: bigint)      = Fraction(bigint numerator, denominator)
        new(numerator: int64, denominator: decimal)     = Fraction(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: int64)       = Fraction(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: int)         = Fraction(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: float)       = Fraction(bigint numerator, denominator)
        new(numerator: int64, denominator: float32)     = Fraction(bigint numerator, denominator)
        new(numerator: int64)                           = Fraction(bigint numerator, 1I)

        new(numerator: decimal, denominator: bigint)    = Fraction(bigint numerator, denominator)
        new(numerator: decimal, denominator: decimal)   = Fraction(bigint numerator, bigint denominator)
        new(numerator: decimal, denominator: int64)     = Fraction(bigint numerator, bigint denominator)
        new(numerator: decimal, denominator: int)       = Fraction(bigint numerator, bigint denominator)
        new(numerator: decimal, denominator: float)     = Fraction(bigint numerator, denominator)
        new(numerator: decimal, denominator: float32)   = Fraction(bigint numerator, denominator)
        new(numerator: decimal)                         = Fraction(bigint numerator, 1I)

        new(numerator: int, denominator: bigint)        = Fraction(bigint numerator, denominator)
        new(numerator: int, denominator: decimal)       = Fraction(bigint numerator, bigint denominator)
        new(numerator: int, denominator: int64)         = Fraction(bigint numerator, bigint denominator)
        new(numerator: int, denominator: int)           = Fraction(bigint numerator, bigint denominator)
        new(numerator: int, denominator: float)         = Fraction(bigint numerator, denominator)
        new(numerator: int, denominator: float32)       = Fraction(bigint numerator, denominator)
        new(numerator: int)                             = Fraction(bigint numerator, 1I)
        
        new(numerator : float, denominator : bigint)    =
            let f = Fraction.scale numerator
            Fraction(bigint(numerator * float(f)), denominator * f)
        new(numerator : float, denominator : decimal)   = Fraction(numerator, bigint denominator)
        new(numerator : float, denominator : int64)     = Fraction(numerator, bigint denominator)
        new(numerator : float, denominator : int)       = Fraction(numerator, bigint denominator)
        new(numerator : float, denominator : float)     =
            let f = float(bigint.Max(Fraction.scale numerator, Fraction.scale denominator))
            Fraction(bigint(numerator * f), bigint(denominator * f))
        new(numerator : float, denominator : float32)   = Fraction(numerator, float denominator)
        new(numerator : float)                          =
            let d = Fraction.scale numerator
            let n = bigint(numerator * float(d))
            Fraction(n, d)
            
        new(numerator : float32, denominator : bigint)  = Fraction(float numerator, denominator)
        new(numerator : float32, denominator : decimal) = Fraction(float numerator, bigint denominator)
        new(numerator : float32, denominator : int64)   = Fraction(float numerator, bigint denominator)
        new(numerator : float32, denominator : int)     = Fraction(float numerator, bigint denominator)
        new(numerator : float32, denominator : float)   = Fraction(float numerator, denominator)
        new(numerator : float32, denominator : float32) = Fraction(float numerator, float denominator)
        new(numerator : float32)                        = Fraction(float numerator)

        member self.Inverse with get () = Fraction(self.Denominator, self.Numerator)

        member self.Pow(b : int) =
            match b >= 0 with
            | true -> Fraction(bigint.Pow(self.Numerator, b), bigint.Pow(self.Denominator, b))
            | false -> Fraction(bigint.Pow(self.Denominator, -b), bigint.Pow(self.Numerator, -b))

        member self.Abs with get () = Fraction(abs(self.Numerator), abs(self.Denominator))

        member self.Simplified
            with get () =
                let d = bigint.GreatestCommonDivisor(self.Numerator, self.Denominator)
                if d = 1I then self
                else Fraction(self.Numerator / d, self.Denominator / d)

        member self.Decimal
            with get () =
                let x = self.Simplified
                decimal x.Numerator / decimal x.Denominator
                
        override self.ToString() = sprintf "(%A/%A)" self.Numerator self.Denominator

        static member (*) (a : Fraction, b : Fraction)  = Fraction(a.Numerator * b.Numerator,   a.Denominator * b.Denominator)
        static member (*) (a : Fraction, b : bigint)    = Fraction(a.Numerator * b,             a.Denominator)
        static member (*) (a : Fraction, b : decimal)   = Fraction(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Fraction, b : int64)     = Fraction(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Fraction, b : int)       = Fraction(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Fraction, b : float)     = a * Fraction b
        static member (*) (a : Fraction, b : float32)   = a * Fraction b
        static member (*) (a : bigint,   b : Fraction)  = Fraction(a * b.Numerator,             b.Denominator)
        static member (*) (a : decimal,  b : Fraction)  = Fraction(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : int64,    b : Fraction)  = Fraction(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : int,      b : Fraction)  = Fraction(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : float,    b : Fraction)  = (Fraction a) * b
        static member (*) (a : float32,  b : Fraction)  = (Fraction a) * b

        static member (/) (a : Fraction, b : Fraction)  = Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator)
        static member (/) (a : Fraction, b : bigint)    = Fraction(a.Numerator / b,             a.Denominator)
        static member (/) (a : Fraction, b : decimal)   = Fraction(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Fraction, b : int64)     = Fraction(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Fraction, b : int)       = Fraction(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Fraction, b : float)     = a / Fraction b
        static member (/) (a : Fraction, b : float32)   = a / Fraction b
        static member (/) (a : bigint,   b : Fraction)  = Fraction(a / b.Numerator,             b.Denominator)
        static member (/) (a : decimal,  b : Fraction)  = Fraction(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : int64,    b : Fraction)  = Fraction(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : int,      b : Fraction)  = Fraction(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : float,    b : Fraction)  = (Fraction a) / b
        static member (/) (a : float32,  b : Fraction)  = (Fraction a) / b

        static member (+) (a : Fraction, b : Fraction)  =
            match a.Denominator = b.Denominator with
            | true  -> Fraction(a.Numerator + b.Numerator, a.Denominator).Simplified
            | false -> Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified
        static member (+) (a : Fraction, b : bigint  )  = Fraction(a.Numerator +        b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Fraction, b : decimal )  = Fraction(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Fraction, b : int64   )  = Fraction(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Fraction, b : int     )  = Fraction(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Fraction, b : float   )  = a + Fraction b
        static member (+) (a : Fraction, b : float32 )  = a + Fraction b
        static member (+) (a : bigint,   b : Fraction)  = Fraction(       a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : decimal,  b : Fraction)  = Fraction(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : int64,    b : Fraction)  = Fraction(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : int,      b : Fraction)  = Fraction(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : float,    b : Fraction)  = (Fraction a) + b
        static member (+) (a : float32,  b : Fraction)  = (Fraction a) + b
                
        static member (-) (a : Fraction, b : Fraction)  =
            match a.Denominator = b.Denominator with
            | true  -> Fraction(a.Numerator - b.Numerator, a.Denominator).Simplified
            | false -> Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified
        static member (-) (a : Fraction, b : bigint  )  = Fraction(a.Numerator -        b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Fraction, b : decimal )  = Fraction(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Fraction, b : int64   )  = Fraction(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Fraction, b : int     )  = Fraction(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Fraction, b : float   )  = a - Fraction b
        static member (-) (a : Fraction, b : float32 )  = a - Fraction b
        static member (-) (a : bigint,   b : Fraction)  = Fraction(       a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : decimal,  b : Fraction)  = Fraction(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : int64,    b : Fraction)  = Fraction(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : int,      b : Fraction)  = Fraction(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : float,    b : Fraction)  = (Fraction a) - b
        static member (-) (a : float32,  b : Fraction)  = (Fraction a) - b

        static member (~-) (a : Fraction) = Fraction(-a.Numerator, a.Denominator)
        
        static member inline relation (a : Fraction) (b : Fraction) f =
            match a.Denominator = b.Denominator with
            | true  -> f a.Numerator  b.Numerator
            | false -> f (a.Numerator * b.Denominator) (b.Numerator * a.Denominator)
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
        
        static member Pow (a : int, e : int) = Fraction.Pow(bigint a, e)
        static member Pow (a : bigint, e : int) =
            match e with
            | 0 -> Fraction.One
            | x when x > 0 -> Fraction(bigint.Pow(a, x), 1I)
            | x when x < 0 -> Fraction(1I, bigint.Pow(a, -x))
            | _ -> invalidOp "must not happen"

        static member One               = Fraction(1L, 1L)
        static member OneHalf           = Fraction(1L, 2L)
        static member OneThird          = Fraction(1L, 3L)
        static member TwoThirds         = Fraction(2L, 3L)
        static member OneQuarter        = Fraction(1L, 4L)
        static member ThreeQuarters     = Fraction(3L, 4L)

        static member Pi                = Fraction(314159265358979323846264338327950288419716939937510I, bigint.Pow(10I, 50))
        static member e                 = Fraction(271828182845904523536028747135266249775724709369995I, bigint.Pow(10I, 50))
        
        static member private scale (x : float) : bigint =
            let s = string x
            match s.IndexOf('.') with
            | -1 -> 1I 
            | i -> bigint.Pow(10I, s.Length - i - 1)
            
    end
    