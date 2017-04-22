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

        member this.Simplified
            with get () =
                let d = Fraction.gcd this.Numerator this.Denominator
                if d = bigint(1) then this
                else Fraction(this.Numerator / d, this.Denominator / d)

        member this.Float with get () = float this.Numerator / float this.Denominator

        member this.Inverse with get () = Fraction(this.Denominator, this.Numerator)

        override this.ToString() = sprintf "(%A/%A)" this.Numerator this.Denominator

        static member (*) (a : Fraction, b : Fraction) = Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator)
        static member (*) (a : Fraction, b : int) = Fraction(a.Numerator * bigint b, a.Denominator)
        static member (*) (a : Fraction, b : int64) = Fraction(a.Numerator * bigint b, a.Denominator)

        static member (/) (a : Fraction, b : Fraction) = Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator)
        static member (/) (a : Fraction, b : int) = Fraction(a.Numerator, a.Denominator * bigint b)
        static member (/) (a : Fraction, b : int64) = Fraction(a.Numerator, a.Denominator * bigint b)

        static member (+) (a : Fraction, b : Fraction) = Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator)
        
        static member private gcd a b =
            if a = b then a
            else if a > b then Fraction.gcd (a-b) b else Fraction.gcd a (b-a)

        static member private scale (x : float) : bigint =
            let s = string x
            let i = s.Length-s.IndexOf('.')-1
            bigint.Pow(10I, i)
    end
