#load "Fraction.fs"
#load "UnitOfMeasure.fs"
#load "Units.fs"
open Uncodium.Units
open Unit
open Uncodium.Units.Unit.Constants
open Uncodium.Units.Unit.Imperial.Length


(1 * Knot) => Kilometer / Hour

(8 * Decimeter + 45 * Centimeter) => Yard

(1 * Furlong) => Kilometer

1 * Meter + 1 * Decimeter + 1 * Centimeter + 1 * Millimeter

18536717372I * Byte => Gibibyte

Lightsecond => League

11.5 * Kilometer => Mile
300.0 * Mile => Kilometer