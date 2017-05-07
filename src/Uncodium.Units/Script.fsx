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
#load "Photometry.fs"
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
open Uncodium.Units.UK.LiquidVolume
open Uncodium.Units.US.LiquidVolume

SquareMeter / SquareDecimeter

Pint
UsPint
(Pint / UsPint).Scale

3.6 * Kilogram * KilometersPerHour |> string

50 * Decimeter * Meter

1 / (2 * Meter)
3.6 * Kilogram * KilometersPerHour
Kilogram * KilometersPerHour
17 * Kilometer => Millimeter |> string

((1 * Meter) / (1 * Meter)).Unit

(88 * Kilowatt => PS)
(88 * Kilowatt => PS) |> string
(88 * Kilowatt => PS).X
(88 * Kilowatt => PS).ToFloat()

120 * PS => Kilowatt

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
HartreeEnergy |> string

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
1 / (VacuumPermeability * U(SpeedOfLight).Pow(2))
1 / U(VacuumPermeability) |> string
1 / Value(VacuumPermeability) |> string

1 * UnitOfMeasure(International.Pound * StandardGravity) => Newton |> string

ImpedanceOfFreeSpace |> string


1 * Poundal => Newton |> string
1 * PoundForce => Newton |> string
1 * Slug => Kilogram |> string

StandardGravity |> string

(6 * International.Foot => Meter) |> string
(6 * US.Survey.Foot => Meter) |> string
(0.95 * International.Grain) |> string

1 / (2 * Meter) |> string

Fraction(254, 10_000) * Fraction(3_937, 100)

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