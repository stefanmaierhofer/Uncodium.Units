#load "Fraction.fs"
#load "UnitOfMeasure.fs"
#load "Units.fs"
open Uncodium.Units
open Unit

(1.0 * Meter / Second) = (3.6 * Kilometer / Hour)

Fraction(1,2).Pow(-1)

Constants.AstronomicalUnit
Constants.Lightyear
Constants.JulianYear

Second * Kilogram
Constants.AstronomicalUnit + Constants.JulianYear

let foo1 = Constant("foo1", "foo1", 80, Centimeter)
let foo2 = Constant("foo2", "foo2", 2, Decimeter)
let r1 = foo1 + foo1
let r2 = foo1 + foo2
let r3 = foo2 + foo1
let r4 = Constants.AstronomicalUnit + Constants.Lightsecond

let foo3 = Constant("foo3", "foo3", 1, Minute)
let foo4 = Constant("foo4", "foo4", 1, Second)
let r5 = foo3 + foo4
let r6 = foo4 + foo3

Radian