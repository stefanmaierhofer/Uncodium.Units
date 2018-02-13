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
            let d = bigint.GreatestCommonDivisor(numerator, denominator)
            if d = 1I then
                match denominator > 0I with
                    | true -> { Numerator = numerator; Denominator = denominator }
                    | false -> { Numerator = -numerator; Denominator = -denominator }
            else
                match denominator > 0I with
                    | true -> { Numerator = numerator / d; Denominator = denominator / d }
                    | false -> { Numerator = -numerator / d; Denominator = -denominator / d }

        new(numerator: decimal, denominator: decimal)   =
            let mutable n = numerator
            let mutable d = denominator
            while Math.Truncate(n) <> n || Math.Truncate(d) <> d do
                n <- n * 10m
                d <- d * 10m
            Rational(bigint n, bigint d) 

        new(numerator: decimal) =
            let mutable n = numerator
            let mutable d = 1I
            while Math.Truncate(n) <> n do
                n <- n * 10m
                d <- d * 10I
            Rational(bigint n, d) 
            

        new(numerator: bigint, denominator: decimal)    = Rational(decimal numerator, denominator)
        new(numerator: bigint, denominator: int64)      = Rational(numerator, bigint denominator)
        new(numerator: bigint, denominator: int)        = Rational(numerator, bigint denominator)
        new(numerator : bigint, denominator : float)    = Rational(decimal numerator, decimal denominator)
        new(numerator : bigint, denominator : float32)  = Rational(decimal numerator, decimal denominator)
        new(numerator: bigint)                          = Rational(numerator, 1I)
        
        new(numerator: int64, denominator: bigint)      = Rational(bigint numerator, denominator)
        new(numerator: int64, denominator: decimal)     = Rational(decimal numerator, denominator)
        new(numerator: int64, denominator: int64)       = Rational(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: int)         = Rational(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: float)       = Rational(decimal numerator, decimal denominator)
        new(numerator: int64, denominator: float32)     = Rational(decimal numerator, decimal denominator)
        new(numerator: int64)                           = Rational(bigint numerator, 1I)

        new(numerator: uint64, denominator: bigint)      = Rational(bigint numerator, denominator)
        new(numerator: uint64, denominator: decimal)     = Rational(decimal numerator, denominator)
        new(numerator: uint64, denominator: int64)       = Rational(bigint numerator, bigint denominator)
        new(numerator: uint64, denominator: int)         = Rational(bigint numerator, bigint denominator)
        new(numerator: uint64, denominator: float)       = Rational(decimal numerator, decimal denominator)
        new(numerator: uint64, denominator: float32)     = Rational(decimal numerator, decimal denominator)
        new(numerator: uint64)                           = Rational(bigint numerator, 1I)

        new(numerator: decimal, denominator: bigint)    = Rational(numerator, decimal denominator)
        new(numerator: decimal, denominator: int64)     = Rational(numerator, decimal denominator)
        new(numerator: decimal, denominator: int)       = Rational(numerator, decimal denominator)
        new(numerator: decimal, denominator: float)     = Rational(numerator, decimal denominator)
        new(numerator: decimal, denominator: float32)   = Rational(numerator, decimal denominator)
        
        new(numerator: int, denominator: bigint)        = Rational(bigint numerator, denominator)
        new(numerator: int, denominator: decimal)       = Rational(decimal numerator, denominator)
        new(numerator: int, denominator: int64)         = Rational(bigint numerator, bigint denominator)
        new(numerator: int, denominator: int)           = Rational(bigint numerator, bigint denominator)
        new(numerator: int, denominator: float)         = Rational(decimal numerator, decimal denominator)
        new(numerator: int, denominator: float32)       = Rational(decimal numerator, decimal denominator)
        new(numerator: int)                             = Rational(bigint numerator, 1I)

        new(numerator: uint32, denominator: bigint)     = Rational(bigint numerator, denominator)
        new(numerator: uint32, denominator: decimal)    = Rational(decimal numerator, denominator)
        new(numerator: uint32, denominator: int64)      = Rational(bigint numerator, bigint denominator)
        new(numerator: uint32, denominator: int)        = Rational(bigint numerator, bigint denominator)
        new(numerator: uint32, denominator: float)      = Rational(decimal numerator, decimal denominator)
        new(numerator: uint32, denominator: float32)    = Rational(decimal numerator, decimal denominator)
        new(numerator: uint32)                          = Rational(bigint numerator, 1I)
        
        new(numerator : float, denominator : bigint)    = Rational(decimal numerator, decimal denominator)
        new(numerator : float, denominator : decimal)   = Rational(decimal numerator, denominator)
        new(numerator : float, denominator : int64)     = Rational(decimal numerator, decimal denominator)
        new(numerator : float, denominator : int)       = Rational(decimal numerator, decimal denominator)
        new(numerator : float, denominator : float)     = Rational(decimal numerator, decimal denominator)
        new(numerator : float, denominator : float32)   = Rational(decimal numerator, decimal denominator)
        new(numerator : float)                          = Rational(decimal numerator)
            
        new(numerator : float32, denominator : bigint)  = Rational(decimal numerator, decimal denominator)
        new(numerator : float32, denominator : decimal) = Rational(decimal numerator, denominator)
        new(numerator : float32, denominator : int64)   = Rational(decimal numerator, decimal denominator)
        new(numerator : float32, denominator : int)     = Rational(decimal numerator, decimal denominator)
        new(numerator : float32, denominator : float)   = Rational(decimal numerator, decimal denominator)
        new(numerator : float32, denominator : float32) = Rational(decimal numerator, decimal denominator)
        new(numerator : float32)                        = Rational(decimal numerator)

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
        static member (*) (a : Rational, b : uint64)    = Rational(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Rational, b : int)       = Rational(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Rational, b : uint32)    = Rational(a.Numerator * bigint b,      a.Denominator)
        static member (*) (a : Rational, b : float)     = a * Rational b
        static member (*) (a : Rational, b : float32)   = a * Rational b
        static member (*) (a : bigint,   b : Rational)  = Rational(a * b.Numerator,             b.Denominator)
        static member (*) (a : decimal,  b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : int64,    b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : uint64,   b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : int,      b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : uint32,   b : Rational)  = Rational(bigint a * b.Numerator,      b.Denominator)
        static member (*) (a : float,    b : Rational)  = (Rational a) * b
        static member (*) (a : float32,  b : Rational)  = (Rational a) * b

        static member (/) (a : Rational, b : Rational)  = Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator)
        static member (/) (a : Rational, b : bigint)    = Rational(a.Numerator / b,             a.Denominator)
        static member (/) (a : Rational, b : decimal)   = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : int64)     = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : uint64)    = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : int)       = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : uint32)    = Rational(a.Numerator,                 a.Denominator * bigint b)
        static member (/) (a : Rational, b : float)     = a / Rational b
        static member (/) (a : Rational, b : float32)   = a / Rational b
        static member (/) (a : bigint,   b : Rational)  = Rational(a / b.Numerator,             b.Denominator)
        static member (/) (a : decimal,  b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : int64,    b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : uint64,   b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : int,      b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : uint32,   b : Rational)  = Rational(bigint a / b.Numerator,      b.Denominator)
        static member (/) (a : float,    b : Rational)  = (Rational a) / b
        static member (/) (a : float32,  b : Rational)  = (Rational a) / b

        static member (+) (a : Rational, b : Rational)  =
            match a.Denominator = b.Denominator with
            | true  -> Rational(a.Numerator + b.Numerator, a.Denominator).Simplified
            | false -> Rational(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified
        static member (+) (a : Rational, b : bigint  )  = Rational(a.Numerator +        b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : decimal )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : int64   )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : uint64  )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : int     )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : uint32  )  = Rational(a.Numerator + bigint b * a.Denominator, a.Denominator).Simplified
        static member (+) (a : Rational, b : float   )  = a + Rational b
        static member (+) (a : Rational, b : float32 )  = a + Rational b
        static member (+) (a : bigint,   b : Rational)  = Rational(       a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : decimal,  b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : int64,    b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : uint64,   b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : int,      b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : uint32,   b : Rational)  = Rational(bigint a * b.Denominator + b.Numerator, b.Denominator).Simplified
        static member (+) (a : float,    b : Rational)  = (Rational a) + b
        static member (+) (a : float32,  b : Rational)  = (Rational a) + b
                
        static member (-) (a : Rational, b : Rational)  =
            match a.Denominator = b.Denominator with
            | true  -> Rational(a.Numerator - b.Numerator, a.Denominator).Simplified
            | false -> Rational(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator).Simplified
        static member (-) (a : Rational, b : bigint  )  = Rational(a.Numerator -        b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : decimal )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : int64   )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : uint64  )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : int     )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : uint32  )  = Rational(a.Numerator - bigint b * a.Denominator, a.Denominator).Simplified
        static member (-) (a : Rational, b : float   )  = a - Rational b
        static member (-) (a : Rational, b : float32 )  = a - Rational b
        static member (-) (a : bigint,   b : Rational)  = Rational(       a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : decimal,  b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : int64,    b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : uint64,   b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : int,      b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
        static member (-) (a : uint32,   b : Rational)  = Rational(bigint a * b.Denominator - b.Numerator, b.Denominator).Simplified
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
            
        static member Zero              = Rational(0L, 1L)
        static member One               = Rational(1L, 1L)
        static member OneHalf           = Rational(1L, 2L)
        static member OneThird          = Rational(1L, 3L)
        static member TwoThirds         = Rational(2L, 3L)
        static member OneQuarter        = Rational(1L, 4L)
        static member ThreeQuarters     = Rational(3L, 4L)

        static member Pi                = Rational(314159265358979323846264338327950288419716939937510I, bigint.Pow(10I, 50))
        static member e                 = Rational(271828182845904523536028747135266249775724709369995I, bigint.Pow(10I, 50))
            
    end
    
module NumericLiteralR = 
    let FromZero ()                 = Rational.Zero
    let FromOne  ()                 = Rational.One
    let FromBigint (a : bigint)     = Rational a
    let FromDecimal (a : decimal)   = Rational a
    let FromInt64 (a : int64)       = Rational a
    let FromUInt64 (a : uint64)     = Rational a
    let FromInt32 (a : int32)       = Rational a
    let FromUInt32 (a : uint32)     = Rational a
    let FromFloat32 (a : float32)   = Rational a
    let FromFloat (a : float)       = Rational a