#load "Fraction.fs"
#load "UnitOfMeasure.fs"
#load "SI.fs"
#load "International.fs"
#load "UK.fs"
#load "US.fs"
#load "Typography.fs"
#load "Math.fs"
#load "Time.fs"
#load "Physics.fs"
#load "Astronomy.fs"
#load "Information.fs"
#load "Nautical.fs"
#load "Historic.fs"
#load "VariousStuffNotYetAdded.fs"
open Uncodium.Units
open SI
open Physics
open Astronomy
open Time
open Information
open International

1 * UnitOfMeasure(International.Pound * StandardGravity) => Newton |> string

1 * Poundal => Newton |> string
1 * PoundForce => Newton |> string
1 * Slug => Kilogram |> string

StandardGravity |> string

(6 * International.Foot => Meter) |> string
(6 * Us.Survey.Foot => Meter) |> string
(0.95 * International.Grain) |> string

Fraction(254, 10_000) * Fraction(3_937, 100)

1 * Newton

1 * ImperialHorsepower => MetricHorsepower

1 * SquareMillimeter + 2 * SquareCentimeter + 3 * SquareDecimeter + 4 * SquareMeter

4 * SquareMeter + 3 * SquareDecimeter + 2 * SquareCentimeter + 1 * SquareMillimeter

//1 * SquareMile + 1 * SquareKilometer

//1 * SquareKilometer + 1 * SquareMile

50 * Decimeter * Decimeter + 1 * Meter * Meter

1 * SquareMeter + 50 * SquareDecimeter
50 * SquareDecimeter + 1 * SquareMeter

Kilogram * KilometersPerHour

3.6 * Kilogram * KilometersPerHour

string (1 * (Meter / Second) + 0.4 * (Kilometer/Hour) => KilometersPerHour)

//1 * Knot => Kilometer / Hour

8 * Decimeter + 45 * Centimeter => Yard

//1 * Furlong => Meter

1 * Meter + 1 * Decimeter + 1 * Centimeter + 1 * Millimeter

18536717372I * Byte => Gibibyte

//Lightsecond => League

11.5 * Kilometer => Mile
300.0 * Mile => Kilometer

//1 * Pound => Kilogram

let s (t : float) = 0.5 * StandardGravity * t * t * Second
s 1.0

let rec sqrt' (a : bigint) (xa : bigint) (xb : bigint) (i : int) =
    printfn "%f (%A / %A)" (float xa / float xb) xa xb
    if (i > 10) then
        printfn "RESULT0: %A / %A" xa xb
        let d = bigint.GreatestCommonDivisor(xa, xb)
        let (r0, r1) = (xa / d, xb / d)
        printfn "RESULT : %A / %A" r0 r1
        printfn "RESULT : %A" (float r0 / float r1)
        (r0, r1)
    else
        let r0 = xa * xa + a * xb * xb
        let r1 = 2I * xa * xb
        sqrt' a r0 r1 (i+1)

let sqrt (a : bigint) = sqrt' a (a + 1I) 2I 0

sqrt (64I * 64I)