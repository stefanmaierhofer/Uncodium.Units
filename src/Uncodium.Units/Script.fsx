#r "../../bin/Debug/Uncodium.Units.dll"
open Uncodium.Units
open SI
open Physics
open Astronomy
open Information
open International
open UK.LiquidVolume
open US.LiquidVolume

let a = 1 * Lightyear + 1 * Nanometer
let b = 1 * Lightyear
let diffExact = float(a - b)
let diffFloat = float(a) - float(b)

let SomeUnit = Unit("SomeUnit")
let Foo = Unit("Foo", "foo", SomeUnit, 1R / 3)
5 * Foo

123456789123456789R / 100000000000000000R |> float

0.123456789123

1 * Yard * 2 * Decimeter * 3 * Nano * Lightsecond => CubicFoot |> string

float(1 * Dyne * Centimeter) = 10R.Pow(-7).ToFloat()

VacuumPermeability |> string

c
c * c
c.Pow(2)

Meter
Meter*Meter
Meter.Pow(2)

e
e.Pow(2)
Zₒ
ħ
FineStructureConstant


1 * Mile.Pow(2)

1.0 * Pint + 1.0 * UsPint => Liter |> string

1 * SquareMile / (1 * Acre) |> string
SquareMile / Acre 
1 * SquareMile => SquareKilometer
Acre

1 * SquareYard => SquareFoot |> string

1 * (US.Survey.Mile * US.Survey.Mile) |> string

UsPint
(Pint / UsPint).Scale

3.6 * Kilogram * KilometersPerHour |> string

50 * Decimeter * Meter

1 / (2 * Meter)
3.6 * Kilogram * KilometersPerHour
Kilogram * KilometersPerHour
17 * Kilometer => Millimeter |> string

((1 * Meter) / (1 * Meter)).Unit

88 * Kilowatt => PS |> string
120 * PS => Kilowatt |> string

Photometry.Lux |> string
Photometry.Lumen |> string
Lumen/Watt
Lumen

Joule / (Mole * Kelvin) |> string
(Meter.Pow(3)) / (Kilogram * Second.Pow(2)) |> string
CubicMeter / (Kilogram * Second.Pow(2)) |> string

Angstrom |> string
ElectronMass |> string
VacuumPermeability |> string
VacuumPermittivity |> string
SpeedOfLight |> string
ReducedPlanckConstant |> string
FineStructureConstant |> string
CoulombConstant |> string
ElementaryCharge |> string
UnifiedAtomicMassUnit |> string
ElectronMass |> string
ProtonMass |> string
BohrMagneton |> string
ConductanceQuantum |> string
InverseConductanceQuantum |> string
MagneticFluxQuantum |> string
JosephsonConstant |> string
NuclearMagneton |> string
VonKlietzingConstant |> string
ClassicalElectronRadius |> string
RydbergConstant |> string
WBosonMass 
ZBosonMass |> string
Hartree |> string

Electronvolt/SpeedOfLight.Pow(2)

let a = 2 * Kilometer
a.Inverse |> string
1 / a |> string
1 / a

VacuumPermeability |> string
VacuumPermittivity |> string
Newton / Ampere.Pow(2) |> string
Farad / Meter |> string
Newton / (Ampere.Pow(2))
1 / (VacuumPermeability * Unit(SpeedOfLight).Pow(2))
1 / Unit(VacuumPermeability) |> string
1 / Value(VacuumPermeability) |> string

1 * Unit(International.Pound * StandardGravity) => Newton |> string

ImpedanceOfFreeSpace |> string


1 * Poundal => Newton |> string
1 * PoundForce => Newton |> string
1 * Slug => Kilogram |> string

StandardGravity |> string

(6 * International.Foot => Meter) |> string
(6 * US.Survey.Foot => Meter) |> string
(0.95 * International.Grain) |> string

1 / (2 * Meter) |> string

254R / 10_000 * 3_937R / 100

Rational.Pow(10, -3)
10R.Pow(-3)

1 * Newton

1 * SquareMillimeter + 2 * SquareCentimeter + 3 * SquareDecimeter + 4 * SquareMeter

4 * SquareMeter + 3 * SquareDecimeter + 2 * SquareCentimeter + 1 * SquareMillimeter

//1 * SquareMile + 1 * SquareKilometer

//1 * SquareKilometer + 1 * SquareMile

50 * Decimeter + 30 * Decimeter

50 * Decimeter * Decimeter
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