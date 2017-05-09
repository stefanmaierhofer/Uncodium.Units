namespace Uncodium.Units

open System
open System.Numerics

[<CustomEquality;CustomComparison>]
type Rational =
    struct
        val Numerator : bigint
        val Denominator : bigint

        new(numerator: bigint, denominator: bigint) =
            if denominator = 0I then raise (DivideByZeroException())
            match denominator > 0I with
                | true -> { Numerator = numerator; Denominator = denominator }
                | false -> { Numerator = -numerator; Denominator = -denominator }      
        new(numerator: bigint, denominator: decimal)    = Rational(numerator, bigint denominator)
        new(numerator: bigint, denominator: int64)      = Rational(numerator, bigint denominator)
        new(numerator: bigint, denominator: int)        = Rational(numerator, bigint denominator)
        new(numerator : bigint, denominator : float)    =
            let f = Rational.scale denominator
            Rational(numerator * f, bigint(denominator * float(f)))
        new(numerator : bigint, denominator : float32)  = Rational(numerator, float denominator)
        new(numerator: bigint)                          = Rational(numerator, 1I)
        
        new(numerator: int64, denominator: bigint)      = Rational(bigint numerator, denominator)
        new(numerator: int64, denominator: decimal)     = Rational(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: int64)       = Rational(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: int)         = Rational(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: float)       = Rational(bigint numerator, denominator)
        new(numerator: int64, denominator: float32)     = Rational(bigint numerator, denominator)
        new(numerator: int64)                           = Rational(bigint numerator, 1I)

        new(numerator: decimal, denominator: bigint)    = Rational(bigint numerator, denominator)
        new(numerator: decimal, denominator: decimal)   = Rational(bigint numerator, bigint denominator)
        new(numerator: decimal, denominator: int64)     = Rational(bigint numerator, bigint denominator)
        new(numerator: decimal, denominator: int)       = Rational(bigint numerator, bigint denominator)
        new(numerator: decimal, denominator: float)     = Rational(bigint numerator, denominator)
        new(numerator: decimal, denominator: float32)   = Rational(bigint numerator, denominator)
        new(numerator: decimal)                         = Rational(bigint numerator, 1I)

        new(numerator: int, denominator: bigint)        = Rational(bigint numerator, denominator)
        new(numerator: int, denominator: decimal)       = Rational(bigint numerator, bigint denominator)
        new(numerator: int, denominator: int64)         = Rational(bigint numerator, bigint denominator)
        new(numerator: int, denominator: int)           = Rational(bigint numerator, bigint denominator)
        new(numerator: int, denominator: float)         = Rational(bigint numerator, denominator)
        new(numerator: int, denominator: float32)       = Rational(bigint numerator, denominator)
        new(numerator: int)                             = Rational(bigint numerator, 1I)
        
        new(numerator : float, denominator : bigint)    =
            let f = Rational.scale numerator
            Rational(bigint(numerator * float(f)), denominator * f)
        new(numerator : float, denominator : decimal)   = Rational(numerator, bigint denominator)
        new(numerator : float, denominator : int64)     = Rational(numerator, bigint denominator)
        new(numerator : float, denominator : int)       = Rational(numerator, bigint denominator)
        new(numerator : float, denominator : float)     =
            let f = float(bigint.Max(Rational.scale numerator, Rational.scale denominator))
            Rational(bigint(numerator * f), bigint(denominator * f))
        new(numerator : float, denominator : float32)   = Rational(numerator, float denominator)
        new(numerator : float)                          =
            let d = Rational.scale numerator
            let n = bigint(numerator * float(d))
            Rational(n, d)
            
        new(numerator : float32, denominator : bigint)  = Rational(float numerator, denominator)
        new(numerator : float32, denominator : decimal) = Rational(float numerator, bigint denominator)
        new(numerator : float32, denominator : int64)   = Rational(float numerator, bigint denominator)
        new(numerator : float32, denominator : int)     = Rational(float numerator, bigint denominator)
        new(numerator : float32, denominator : float)   = Rational(float numerator, denominator)
        new(numerator : float32, denominator : float32) = Rational(float numerator, float denominator)
        new(numerator : float32)                        = Rational(float numerator)

        member self.Inverse with get () = Rational(self.Denominator, self.Numerator)

        member self.Pow(b : int) =
            match b >= 0 with
            | true -> Rational(bigint.Pow(self.Numerator, b), bigint.Pow(self.Denominator, b))
            | false -> Rational(bigint.Pow(self.Denominator, -b), bigint.Pow(self.Numerator, -b))

        member self.Abs with get () = Rational(abs(self.Numerator), abs(self.Denominator))

        member self.Simplified
            with get () =
                let d = bigint.GreatestCommonDivisor(self.Numerator, self.Denominator)
                if d = 1I then self
                else Rational(self.Numerator / d, self.Denominator / d)

        member self.ToFloat () =
            let x = self.Simplified
            float x.Numerator / float x.Denominator
        
        static member inline op_Explicit(source: Rational) : float = source.ToFloat()

        override self.ToString() = sprintf "(%A/%A)" self.Numerator self.Denominator

        static member (*) (a : Rational, b : Rational)  = Rational(a.Numerator * b.Numerator,   a.Denominator * b.Denominator)
        static member (*) (a : Rational, b : bigint)    = Rational(a.Numerator * b,             a.Denominator)
        static member (*) (a : Rational, b : decimal)   = Rational(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Rational, b : int64)     = Rational(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Rational, b : int)       = Rational(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Rational, b : float)     = a * Rational b
        static member (*) (a : Rational, b : float32)   = a * Rational b
        static member (*) (a : bigint,   b : Rational)  = Rational(a * b.Numerator,             b.Denominator)
        static member (*) (a : decimal,  b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : int64,    b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : int,      b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : float,    b : Rational)  = (Rational a) * b
        static member (*) (a : float32,  b : Rational)  = (Rational a) * b

        static member (/) (a : Rational, b : Rational)  = Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator)
        static member (/) (a : Rational, b : bigint)    = Rational(a.Numerator / b,             a.Denominator)
        static member (/) (a : Rational, b : decimal)   = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : int64)     = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : int)       = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : float)     = a / Rational b
        static member (/) (a : Rational, b : float32)   = a / Rational b
        static member (/) (a : bigint,   b : Rational)  = Rational(a / b.Numerator,             b.Denominator)
        static member (/) (a : decimal,  b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : int64,    b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : int,      b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : float,    b : Rational)  = (Rational a) / b
        static member (/) (a : float32,  b : Rational)  = (Rational a) / b

        static member (+) (a : Rational, b : Rational)  =
            match a.Denominator = b.Denominator with
            | true  -> Rational(a.Numerator + b.Numerator, a.Denominator).Simplified
            | false -> Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified
        static member (+) (a : Rational, b : bigint  )  = Rational(a.Numerator +        b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : decimal )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : int64   )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : int     )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : float   )  = a + Rational b
        static member (+) (a : Rational, b : float32 )  = a + Rational b
        static member (+) (a : bigint,   b : Rational)  = Rational(       a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : decimal,  b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : int64,    b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : int,      b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : float,    b : Rational)  = (Rational a) + b
        static member (+) (a : float32,  b : Rational)  = (Rational a) + b
                
        static member (-) (a : Rational, b : Rational)  =
            match a.Denominator = b.Denominator with
            | true  -> Rational(a.Numerator - b.Numerator, a.Denominator).Simplified
            | false -> Rational(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified
        static member (-) (a : Rational, b : bigint  )  = Rational(a.Numerator -        b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : decimal )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : int64   )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : int     )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : float   )  = a - Rational b
        static member (-) (a : Rational, b : float32 )  = a - Rational b
        static member (-) (a : bigint,   b : Rational)  = Rational(       a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : decimal,  b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : int64,    b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : int,      b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : float,    b : Rational)  = (Rational a) - b
        static member (-) (a : float32,  b : Rational)  = (Rational a) - b

        static member (~-) (a : Rational) = Rational(-a.Numerator, a.Denominator)
        
        static member inline relation (a : Rational) (b : Rational) f =
            match a.Denominator = b.Denominator with
            | true  -> f a.Numerator  b.Numerator
            | false -> f (a.Numerator * b.Denominator) (b.Numerator * a.Denominator)
        static member op_LessThan (a, b) = Rational.relation a b (<)
        static member op_LessThanOrEqual (a, b) = Rational.relation a b (<=)
        static member op_Equality (a, b) = Rational.relation a b (=)
        static member op_Inequality (a, b) = Rational.relation a b (<>)
        static member op_GreaterThanOrEqual (a, b) = Rational.relation a b (>=)
        static member op_GreaterThan (a, b) = Rational.relation a b (>)
        
        interface IComparable<Rational> with
            member self.CompareTo { Numerator = numerator; Denominator = denominator } =
                if self.Denominator = denominator then
                    self.Numerator.CompareTo numerator
                else
                    (self.Numerator * denominator).CompareTo(numerator * self.Denominator)

        interface IComparable with
            member self.CompareTo obj =
                match obj with
                  | null                 -> 1
                  | :? Rational as other -> (self :> IComparable<_>).CompareTo other
                  | _                    -> invalidArg "obj" "not a Fraction"

        interface IEquatable<Rational> with
            member self.Equals { Numerator = numerator; Denominator = denominator } =
                if self.Denominator = denominator then
                    self.Numerator = numerator
                else
                    self.Numerator * denominator = numerator * self.Denominator

        override self.GetHashCode() =
            hash (self.Numerator, self.Denominator)

        override self.Equals(obj) =
            match obj with
            | :? Rational as other ->
                if self.Denominator = other.Denominator then
                    self.Numerator = other.Numerator
                else
                    self.Numerator * other.Denominator = other.Numerator * self.Denominator
            | _ -> false
        
        static member Pow (a : int, e : int) = Rational.Pow(bigint a, e)
        static member Pow (a : bigint, e : int) =
            match e with
            | 0 -> Rational.One
            | x when x > 0 -> Rational(bigint.Pow(a, x), 1I)
            | x when x < 0 -> Rational(1I, bigint.Pow(a, -x))
            | _ -> invalidOp "must not happen"

        static member One               = Rational(1L, 1L)
        static member OneHalf           = Rational(1L, 2L)
        static member OneThird          = Rational(1L, 3L)
        static member TwoThirds         = Rational(2L, 3L)
        static member OneQuarter        = Rational(1L, 4L)
        static member ThreeQuarters     = Rational(3L, 4L)

        static member Pi                = Rational(314159265358979323846264338327950288419716939937510I, bigint.Pow(10I, 50))
        static member e                 = Rational(271828182845904523536028747135266249775724709369995I, bigint.Pow(10I, 50))
        
        static member private scale (x : float) : bigint =
            let s = string x
            match s.IndexOf('.') with
            | -1 -> 1I 
            | i -> bigint.Pow(10I, s.Length - i - 1)
            
    end
    