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
which is a `Value` tying the the number `X=27/1` to the `Unit=square foot (ft²)`.

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
you can see that the its `Name`=*"square foot"* with `Symbol`=*"ft²"* and that it is defined in terms of SI `BaseUnits`=*[m^2]* with a conversion factor `Scale`=*145161/1562500*.
This means that *1 ft²* is exactly *145161/1562500 square meters*, where `Float`=*0.09290304* is the 64-bit floating point representation of the exact scale.

## Conversions

You can always convert values to another unit using `ConvertTo`, e.g.

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
val it : string = "10.4875029825817 mph"
```

## Defining new units

Let's say we want to define a unit representing the speed of a snail. According to Wikipedia the garden snail (Cornu aspersum) moves at top speeds of 1.3 centimeters per second. We can define this new *snail* unit as follows

```F#
> let Snail = Unit("speed of garden snail", "snail", Centimeter/Second, 1.3);;
val Snail : Unit = speed of garden snail (snail) (13/1000)  [m^1][s^-1]
```

And how many days does it take a snail to complete a marathon?

```F#
> 42.195 * Kilometer / Snail => Day;;
val it : Value = 37.5667735042735 d {Inverse = 0 [s^-1];
                                     Unit = day (d) 86400 [s^1];
                                     X = (70325/1872);}
```


## Incompatible units
Expressions trying to combine incompatible units, e.g. adding meters and seconds, will throw an exception, e.g. 

```F#
> 7 * Meter + 42 * Second;;
System.InvalidOperationException: Values (7 m) and (42 s) have different units.
```


# Modules

  |                          |                 |
----------------------------------|-------------
 Uncodium.Units.SI                | The International System of Units is the most widely used system of measurement.
 Uncodium.Units.International     | Yards and pounds used in US, UK, Canada, Australia, New Zealand, and South Africa.
 Uncodium.Units.US                | Customary units used in the US, not contained in Uncodium.Units.International.
 Uncodium.Units.UK                | Customary units used in the UK, not contained in Uncodium.Units.International.
 Uncodium.Units.Physics           | Physics units and constants.
 Uncodium.Units.Information       | Bit and bytes.
 Uncodium.Units.Math              | Math constants, like π and e.
 Uncodium.Units.Photometry        | Photometric units.

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

