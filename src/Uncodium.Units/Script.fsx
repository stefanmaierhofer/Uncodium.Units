#load "Fraction.fs"
#load "UnitOfMeasure.fs"
#load "Units.fs"
open Uncodium.Units
open Unit
open Uncodium.Units.Unit.Constants

(1 * Mile).ConvertTo(Meter)
