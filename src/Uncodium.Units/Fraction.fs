namespace Uncodium.Units

open System
open System.Numerics

type Fraction =
    struct
        val Numerator : bigint
        val Denominator : bigint

        new(numerator: bigint, denominator: bigint) = { Numerator = numerator; Denominator = denominator }
        new(numerator: bigint, denominator: int) = Fraction(numerator, bigint denominator)
        new(numerator: int, denominator: bigint) = Fraction(bigint numerator, denominator)
        new(numerator: int, denominator: int) = Fraction(bigint numerator, bigint denominator)
        new(numerator: int64, denominator: int64) = Fraction(bigint numerator, bigint denominator)
        new(numerator: bigint) = Fraction(numerator, bigint 1)
        new(numerator: int) = Fraction(bigint numerator, bigint 1)
        new(numerator: int64) = Fraction(bigint numerator, bigint 1)
        new(numerator : float) =
            let d = Fraction.scale numerator
            let n = bigint(numerator * float(d))
            Fraction(n, d)
        new(numerator : bigint, denominator : float) =
            let f = Fraction.scale denominator
            Fraction(numerator * f, bigint(denominator * float(f)))
        new(numerator : int, denominator : float) = Fraction(bigint numerator, denominator)
        new(numerator : int64, denominator : float) = Fraction(bigint numerator, denominator)
        new(numerator : float, denominator : bigint) =
            let f = Fraction.scale numerator
            Fraction(bigint(numerator * float(f)), denominator * f)
        new(numerator : float, denominator : int) = Fraction(numerator, bigint denominator)
        new(numerator : float, denominator : int64) = Fraction(numerator, bigint denominator)
        new(numerator : float, denominator : float) =
            let f = float(bigint.Max(Fraction.scale numerator, Fraction.scale denominator))
            Fraction(bigint(numerator * f), bigint(denominator * f))

        member self.Simplified
            with get () =
                let d = Fraction.gcd self.Numerator self.Denominator
                if d = bigint(1) then self
                else Fraction(self.Numerator / d, self.Denominator / d)

        member self.Float with get () = float self.Numerator / float self.Denominator

        member self.Inverse with get () = Fraction(self.Denominator, self.Numerator)

        member self.Pow(b : int) = Fraction(bigint.Pow(self.Numerator, b), bigint.Pow(self.Denominator, b))

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

        static member (+) (a : Fraction, b : Fraction) = Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator)
        static member (-) (a : Fraction, b : Fraction) = Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator)
        
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
            if a = b then a
            else if a > b then Fraction.gcd (a-b) b else Fraction.gcd a (b-a)

        static member private scale (x : float) : bigint =
            let s = string x
            let i = s.Length-s.IndexOf('.')-1
            bigint.Pow(10I, i)
    end
