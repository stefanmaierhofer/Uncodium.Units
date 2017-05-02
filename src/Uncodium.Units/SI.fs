namespace Uncodium.Units

open System
open System.Numerics
   
module internal Prefix =
    
    open Fun
    let prefix (name : string) (symbol : string) (a : int) (b : int)
        = UnitPrefix(name, symbol, F.Pow(a, b))

    let Deca  = prefix "deca"   "da"     10   1
    let Hecto = prefix "hecto"  "h"      10   2
    let Kilo  = prefix "kilo"   "k"      10   3
    let Mega  = prefix "mega"   "M"    1000   2
    let Giga  = prefix "giga"   "G"    1000   3
    let Tera  = prefix "tera"   "T"    1000   4
    let Peta  = prefix "peta"   "P"    1000   5
    let Exa   = prefix "exa"    "E"    1000   6
    let Zetta = prefix "zetta"  "Z"    1000   7
    let Yotta = prefix "yotta"  "Y"    1000   8
                                            
    let Deci  = prefix "deci"   "d"      10  -1
    let Centi = prefix "centi"  "c"      10  -2
    let Milli = prefix "milli"  "m"    1000  -1
    let Micro = prefix "micro"  "µ"    1000  -2
    let Nano  = prefix "nano"   "n"    1000  -3
    let Pico  = prefix "pico"   "p"    1000  -4
    let Femto = prefix "femto"  "f"    1000  -5
    let Atto  = prefix "atto"   "a"    1000  -6
    let Zepto = prefix "zepto"  "z"    1000  -7
    let Yocto = prefix "yocto"  "y"    1000  -8
                                            
    let Kibi  = prefix "kibi"   "Ki"   1024   1
    let Mebi  = prefix "mebi"   "Mi"   1024   2
    let Gibi  = prefix "gibi"   "Gi"   1024   3
    let Tebi  = prefix "tebi"   "Ti"   1024   4
    let Pebi  = prefix "pebi"   "Pi"   1024   5
    let Exbi  = prefix "exbi"   "Ei"   1024   6
    let Zebi  = prefix "zebi"   "Zi"   1024   7
    let Yobi  = prefix "yobi"   "Yi"   1024   8
     
module SI =

    open Fun
    open Prefix
    

    /// Length (SI base unit).
    let Meter       = U("meter", "m")
    /// Mass (SI base unit).
    let Kilogram    = U("kilogram", "kg")
    /// Time (SI base unit).
    let Second      = U("second", "s")
    /// Electric current (SI base unit).
    let Ampere      = U("ampere", "A")
    /// Thermodynamic temperature (SI base unit).
    let Kelvin      = U("kelvin", "K")
    /// Amount of substance (SI base unit).
    let Mole        = U("mole", "mol")
    /// Luminous intensity (SI base unit).
    let Candela     = U("candela", "cd")
    

    /// Angle (SI derived unit).
    let Radian      = U("radian",       "rad",  Meter / Meter                               )
    /// Solid angle (SI derived unit).
    let Steradian   = U("steradian",    "sr",   (Meter * Meter) / (Meter * Meter)           )
    /// Frequency (SI derived unit).
    let Hertz       = U("hertz",        "Hz",   1 / Second                                  )
    /// Force, weight (SI derived unit).
    let Newton      = U("newton",       "N",    Kilogram * Meter / (Second * Second)        )
    /// Pressure, stress (SI derived unit).
    let Pascal      = U("pascal",       "Pa",   Newton / (Meter * Meter)                    )
    /// Energy, work, heat (SI derived unit).
    let Joule       = U("joule",        "J",    Newton * Meter                              )
    /// Power, radiant flux (SI derived unit).
    let Watt        = U("watt",         "W",    Joule / Second                              )
    /// Electric charge or quantity of electricity (SI derived unit).
    let Coulomb     = U("coulomb",      "C",    Second * Ampere                             )
    /// Voltage (electrical potential difference), electromotive force (SI derived unit).
    let Volt        = U("volt",         "V",    Watt / Ampere                               )
    /// Capacitance (SI derived unit).
    let Farad       = U("farad",        "F",    Coulomb / Volt                              )
    /// Electric resistance, impedance, reactance (SI derived unit).
    let Ohm         = U("ohm",          "Ω",    Volt / Ampere                               )
    /// Electrical conductance (SI derived unit).
    let Siemens     = U("siemens",      "S",    Ampere / Volt                               )
    /// Magnetic flux (SI derived unit).
    let Weber       = U("weber",        "Wb",   Volt * Second                               )
    /// Magnetic flux density (SI derived unit).
    let Tesla       = U("tesla",        "T",    Weber / (Meter * Meter)                     )
    /// Inductance (SI derived unit).
    let Henry       = U("henry",        "H",    Weber / Ampere                              )
    /// Luminous flux (SI derived unit).
    let Lumen       = U("lumen",        "lm",   Candela * Steradian                         )
    /// Illuminance (SI derived unit).
    let Lux         = U("lux",          "lx",   Lumen / (Meter * Meter)                     )
    /// Radioactivity (decays per unit time) (SI derived unit).
    let Becquerel   = U("becquerel",    "Bq",   1 / Second                                  )
    /// Absorbed dose (of ionizing radiation) (SI derived unit).
    let Gray        = U("gray",         "Gy",   Joule / Kilogram                            )
    /// Equivalent dose (of ionizing radiation) (SI derived unit).
    let Sievert     = U("sievert",      "Sv",   Joule / Kilogram                            )
    /// Catalytic activity (SI derived unit).
    let Katal       = U("katal",        "kat",  Mole / Second                               )

    
    /// 1 000 meters.
    let Kilometer   = Kilo  * Meter
    /// 1/10 of a meter.
    let Decimeter   = Deci  * Meter
    /// 1/100 of a meter.
    let Centimeter  = Centi * Meter
    /// 1/1000 of a meter.
    let Millimeter  = Milli * Meter
    /// 1/1000 of a millimeter.
    let Micrometer  = Micro * Meter
    /// 1/1000 of a micrometer.
    let Nanometer   = Nano  * Meter
    

    /// 1/1000 of a kilogram.
    let Gram                            = UnitOfMeasure("gram",                 "g",        Kilogram,       F.Pow(10, -3)   )
    /// 1/1000 of a gram.
    let Milligram                       = Milli * Gram
    /// 1/1000 of a milligram.
    let Microgram                       = Micro * Gram


    /// The area of a square whose sides measure exactly one kilometer.
    let SquareKilometer                 = UnitOfMeasure("square kilometer",     "km²",      Kilometer^2                     )
    /// The area of a square whose sides measure exactly one meter.
    let SquareMeter                     = UnitOfMeasure("square meter",         "m²",       Meter^2                         )
    /// The area of a square whose sides measure exactly one decimeter.
    let SquareDecimeter                 = UnitOfMeasure("square decimeter",     "dm²",      Decimeter^2                     )
    /// The area of a square whose sides measure exactly one centimeter.
    let SquareCentimeter                = UnitOfMeasure("square centimeter",    "cm²",      Centimeter^2                    )
    /// The area of a square whose sides measure exactly one millimeter.
    let SquareMillimeter                = UnitOfMeasure("square millimeter",    "mm²",      Millimeter^2                    )
    /// 100 m² (10m · 10m).
    let Are                             = UnitOfMeasure("are",                  "a",        SquareMeter,            100     )
    /// 10 000 m² (100m · 100m), or 100 are.
    let Hectare                         = UnitOfMeasure("hectare",              "ha",       SquareMeter,         10_000     )


    /// The volume of a cube whose sides measure exactly one kilometer.
    let CubicKilometer                  = UnitOfMeasure("cubic kilometer",      "km³",      Kilometer^3                     )
    /// The volume of a cube whose sides measure exactly one meter.                                                         
    let CubicMeter                      = UnitOfMeasure("cubic meter",          "m³",       Meter^3                         )
    /// The volume of a cube whose sides measure exactly one decimeter.                                                     
    let CubicDecimeter                  = UnitOfMeasure("cubic decimeter",      "dm³",      Decimeter^3                     )
    /// The volume of a cube whose sides measure exactly one centimeter.                                                    
    let CubicCentimeter                 = UnitOfMeasure("cubic centimeter",     "cm³",      Centimeter^3                    )
    /// The volume of a cube whose sides measure exactly one millimeter.                                                    
    let CubicMillimeter                 = UnitOfMeasure("cubic millimeter",     "mm³",      Millimeter^3                    )
    /// Unit of volume equal to 1 cubic decimeter.
    
    
    let Liter                           = UnitOfMeasure("liter",                "l",        CubicDecimeter                  )
    /// 1/10 of a liter.
    let Deciliter                       = Deci * Liter
    /// 1/100 of a liter.
    let Centiliter                      = Centi * Liter
    /// 1/1000 of a liter, or one cubic centimeter.
    let Milliliter                      = Milli * Liter
    /// 1/1000 of a milliliter, or one cubic millimeter.
    let Microliter                      = Micro * Liter
