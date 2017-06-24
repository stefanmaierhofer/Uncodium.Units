[![Build status](https://ci.appveyor.com/api/projects/status/oo82mya99s390kj0?svg=true)](https://ci.appveyor.com/project/stefanmaierhofer/uncodium-units)

Install [nuget package](https://www.nuget.org/packages/Uncodium.Units).

# Get started
How many acres are in a square mile?

```C#
// C# Interactive
> Print(SquareMile / Acre);
[640]
```
```F#
// F# Interactive
> SquareMile / Acre |> float;;
val it : float = 640.0
```

What is the difference between a pint in the UK and in the US, in liters?
```C#
// C# Interactive
> Print((1 * UK.LiquidVolume.Pint - 1 * US.LiquidVolume.UsPint).ConvertTo(Liter));
[0.095084777 l]
```
```F#
// F# Interactive
> 1 * UK.LiquidVolume.Pint - 1 * US.LiquidVolume.UsPint => Liter |> string;;
val it : string = "0.095084777 l"
```

A volume of 1 yard by 2 decimeters by 3 nanolightseconds contains how many cubic feet?
```F#
> 1 * Yard * 2 * Decimeter * 3 * Nano * Lightsecond => CubicFoot |> string;;
val it : string = "5.80849049073098 ft³"
```

# Overview

*Uncodium.Units* provides
* an extensive set of units of measurement and constants
* numerical values and operators tied to units for "unit-safe" computations
* arbitrary precision arithmetic
* conversions and pretty printing

This includes
* the complete international system of units (SI),
* various systems based on imperial units (yards and pounds)
* customary units for different countries, e.g. US and GB
* astronomy, physics, math, photometry, ...


# Tutorial

All units are ultimately specified in terms of SI base units. 
Consequently, it is not possible to inadverdently mix up units when performing computations.

For example, you can add *9 square feet* and *2 square yards* and you will get a result of *27 ft²*.

If you try this in F# interactive without formatting the result as a string
```F#
> 9 * SquareFoot + 2 * SquareYard;;
```
you will see the full underlying result
```F#
val it : Value = 27 ft² {Unit = square foot (ft²) (145161/1562500)  [m^2];
                         X = (27/1);}
```
which is a `Value` tying the number `X=27/1` to `Unit=square foot (ft²)`.

If we have a closer look at the unit

```F#
> (9 * SquareFoot + 2 * SquareYard).Unit;;
val it : Unit =
  square foot (ft²) (145161/1562500)  [m^2] {BaseUnits = [m^2];
                                             Float = 0.09290304;
                                             Name = "square foot";
                                             Scale = (145161/1562500);
                                             Symbol = "ft²";}
```
you can see that its `Name`=*"square foot"* with `Symbol`=*"ft²"* and that it is defined in terms of SI `BaseUnits`=*[m^2]* (meters squared) with a conversion factor of `Scale`=*145161/1562500*.
This means that *1 ft²* is exactly *145161/1562500 square meters*, where `Float`=*0.09290304* is the 64-bit floating point representation of the exact scale.

## Conversions

You can always convert values to other units using `ConvertTo`, e.g.

```F#
> (1.5 * Minute).ConvertTo(Second) |> string;;
val it : string = "90 s"
```

In F# you can also use the more succinct `=>` operator

```F#
> 1.5 * Minute => Second |> string;;
val it : string = "90 s"
```

For example, if you want to know the average speed in *mph* of a runner completing a marathon in 2 hours and 30 minutes, and you know that the official distance of a marathon is 42.195 *km*, then you can do the following

```F#
> ((42.195 * Kilometer) / (2.5 * Hour)) => MilesPerHour |> string;;
val it : string = "10.4875 mph"
```

## Defining new units

Let's say we want to define a unit representing the speed of a snail. According to Wikipedia the garden snail (Cornu aspersum) moves at top speeds of 1.3 centimeters per second. We can define a new *snail* unit as follows

```F#
> let Snail = Unit("speed of garden snail", "snail", Centimeter/Second, 1.3);;
val Snail : Unit = speed of garden snail (snail) (13/1000)  [m^1][s^-1]
```

You can see that the base units are *[m^1][s^-1]*, i.e. *meter/second*, and *1 snail = 13/1000 m/s*.

By the way, how many days does it take a snail to complete a marathon?

```F#
> 42.195 * Kilometer / Snail => Day |> string;;
val it : string = "37.5667735042735 d"
```

This works, because our *snail* unit is defined in terms of *meter/second*. So if we divide *kilometers* (defined in terms of *1000/1 meter*), with *13/1000 meter/second*, we arrive at *meter/(meter/second) = meter (second/meter) = second*, which we can convert to *days* (defined in terms of *86400/1 second*). Combining all the conversion factors gives *1,000,000 / 1,123,200 = 625/702*
```F#
> (Kilometer / Snail => Day).Scale |> string;;
val it : string = "(625/702)"
```
therefore it takes our garden snail *625/702* days to cover *1 kilometer*.

## Arbitrary precision

Under the hood, Uncodium.Units represents all numeric values as ratios of bigint values.
This means that it can perform exact arithmetic on rational numbers - no limits or rounding involved.

For example, you can add *1 lightyear* and *1 nanometer*, then subtract again *1 lightyear*, and get a difference of *1 nanometer*.
When using floating point arithmetic, the result would be *0.0*, because of limited precision.
```F#
let a = 1 * Lightyear + 1 * Nanometer
let b = 1 * Lightyear
let diffExact = float(a - b)
let diffFloat = float(a) - float(b)

val a : Value = 9.4607304725808E+15 [m^1]
val b : Value = 9.4607304725808E+15 [m^1]
val diffExact : float = 1e-09
val diffFloat : float = 0.0
```

## Incompatible units
Expressions trying to combine incompatible units, e.g. adding meters and seconds, will throw an exception, e.g. 

```F#
> 7 * Meter + 42 * Second;;
System.InvalidOperationException: Values (7 m) and (42 s) have different units.
```


# Modules

  name                          |       description          |
----------------------------------|-------------
 SI                | The International System of Units is the most widely used system of measurement.
 International     | Yards and pounds used in US, UK, Canada, Australia, New Zealand, and South Africa.
 US                | US customary units (not contained in *International*).
 UK                | UK customary units (not contained in *International*).
 Physics           | Physics units and constants.
 Information       | Bits and bytes.
 Math              | Math constants, like π and e.
 Photometry        | Photometric units.

In F# you can open modules like this:

```F#
open Uncodium.Units
open SI
open Physics
```

In C# you can open modules like that:

```C#
using Uncodium.Units;
using static Uncodium.Units.SI;
using static Uncodium.Units.Physics;
```

# Build from source

Clone the repository:

```
git clone https://github.com/stefanmaierhofer/Uncodium.Units.git
```

Run the `build` command to install all dependencies and build the library:

```
cd Uncodium.Units
build
```


In **Visual Studio Code** you can directly open the `Uncodium.Units` directory and use *Ctrl-Shift-B* to build.

In **Visual Studio 2017** you can open `src/Uncodium.Units.sln`.

