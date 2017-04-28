#load "Fraction.fs"
#load "UnitOfMeasure.fs"
#load "Units.fs"
open Uncodium.Units
open Unit
open Uncodium.Units.Unit.Constants
open Uncodium.Units.Unit.Imperial.Length


(1 * Knot) => Kilometer / Hour

(8 * Decimeter + 45 * Centimeter) => Yard

(1 * Furlong) => Meter

1 * Meter + 1 * Decimeter + 1 * Centimeter + 1 * Millimeter

18536717372I * Byte => Gibibyte

Lightsecond => League

11.5 * Kilometer => Mile
300.0 * Mile => Kilometer

1 * Pound => Kilogram

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