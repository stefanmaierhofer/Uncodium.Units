namespace Uncodium.Units

open System
open System.Numerics
   
type internal U = UnitOfMeasure
type internal F = Fraction

module internal Fun =

    let (^^) (a : int) (b : int) : Fraction = Fraction.Pow(bigint a, b)

    let (^) (a : UnitOfMeasure) (b : int) : UnitOfMeasure = a.Pow(b)

module internal Prefix =
    
    open Fun

    let Deca  = UnitPrefix("deca",  "da",  F.Pow(  10,  1) )
    let Hecto = UnitPrefix("hecto", "h",   F.Pow(  10,  2) )
    let Kilo  = UnitPrefix("kilo",  "k",   F.Pow(  10,  3) )
    let Mega  = UnitPrefix("mega",  "M",   F.Pow(1000,  2) )
    let Giga  = UnitPrefix("giga",  "G",   F.Pow(1000,  3) )
    let Tera  = UnitPrefix("tera",  "T",   F.Pow(1000,  4) )
    let Peta  = UnitPrefix("peta",  "P",   F.Pow(1000,  5) )
    let Exa   = UnitPrefix("exa",   "E",   F.Pow(1000,  6) )
    let Zetta = UnitPrefix("zetta", "Z",   F.Pow(1000,  7) )
    let Yotta = UnitPrefix("yotta", "Y",   F.Pow(1000,  8) )

    let Deci  = UnitPrefix("deci",  "d",   F.Pow(  10, -1) )
    let Centi = UnitPrefix("centi", "c",   F.Pow(  10, -2) )
    let Milli = UnitPrefix("milli", "m",   F.Pow(1000, -1) )
    let Micro = UnitPrefix("micro", "µ",   F.Pow(1000, -2) )
    let Nano  = UnitPrefix("nano",  "n",   F.Pow(1000, -3) )
    let Pico  = UnitPrefix("pico",  "p",   F.Pow(1000, -4) )
    let Femto = UnitPrefix("femto", "f",   F.Pow(1000, -5) )
    let Atto  = UnitPrefix("atto",  "a",   F.Pow(1000, -6) )
    let Zepto = UnitPrefix("zepto", "z",   F.Pow(1000, -7) )
    let Yocto = UnitPrefix("yocto", "y",   F.Pow(1000, -8) )

    let Kibi  = UnitPrefix("kibi",  "Ki",  F.Pow(1024,  1) )
    let Mebi  = UnitPrefix("mebi",  "Mi",  F.Pow(1024,  2) )
    let Gibi  = UnitPrefix("gibi",  "Gi",  F.Pow(1024,  3) )
    let Tebi  = UnitPrefix("tebi",  "Ti",  F.Pow(1024,  4) )
    let Pebi  = UnitPrefix("pebi",  "Pi",  F.Pow(1024,  5) )
    let Exbi  = UnitPrefix("exbi",  "Ei",  F.Pow(1024,  6) )
    let Zebi  = UnitPrefix("zebi",  "Zi",  F.Pow(1024,  7) )
    let Yobi  = UnitPrefix("yobi",  "Yi",  F.Pow(1024,  8) )
     
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

module International =

    open Fun
    open SI
    
    (*
        Units of length
    *)

    /// 1 inch is equal to 1/12 of a foot, and standardised as exactly 2.54 centimeters.
    let Inch                = U("inch",                 "in",       Meter,                  F(254, 10_000)                  )
    /// 1 foot is equal to 12 inches, and standardised as exactly 0.3048 meters.
    let Foot                = U("foot",                 "ft",       Inch,                   12                              )
    /// 1 yard is equal to 3 feet, or 36 inches, and standardised as exactly 0.9144 meters.
    let Yard                = U("yard",                 "yd",       Foot,                   3                               )
    /// 1 chain (UK) is equal to 22 yards. For US customary unit see Us.Survey.Chain.
    let Chain               = U("chain",                "ch",       Yard,                   22I                             )
    /// 1 furlong (UK) is equal 220 yards. For US customary unit see Us.Survey.Furlong.
    let Furlong             = U("furlong",              "fur",      Yard,                  220I                             )
    /// 1 mile is equal to 5 280 feet, or 1 760 yards, and standardised as exactly 1,609.344 meters.
    let Mile                = U("mile",                 "ml",       Yard,                   1_760                           )
    /// 1 thou (or mil) is equal to 1/1000 of an inch.
    let Thou                = U("thou",                 "th",       Inch,                   F(1, 1_000)                     )
    /// 1 mil (or thou) is equal to 1/1000 of an inch.
    let Mil                 = U("mil",                  "mil",      Inch,                   F(1, 1_000)                     )

    (*
        Units of area
    *)

    /// The area of a square whose sides measure exactly one inch.
    let SquareInch          = U("square inch",          "in²",      Inch ^ 2                                                )
    /// The area of a square whose sides measure exactly one foot.
    let SquareFoot          = U("square foot",          "ft²",      Foot ^ 2                                                )
    /// The area of a square whose sides measure exactly one yard.
    let SquareYard          = U("square yard",          "yd²",      Yard ^ 2                                                )
    /// The area of a square whose sides measure exactly one mile.
    let SquareMile          = U("square mile",          "mi²",      Mile ^ 2                                                )
    
    /// 1 perch (UK) is equal to the area of 1 rod by 1 rod.
    let Perch               = U("perch",                "perch",    Furlong ^ 2,            F(1, 16)                        )
    /// 1 rood (UK) is equal to the area of 1 furlong by 1 rod.
    let Rood                = U("rood",                 "rood",     Furlong ^ 2,            F(1, 4)                         )
    /// 1 acre (UK) is equal to 4 840 sq yd. For US customary unit see Us.Survey.Acre.
    let Acre                = U("acre",                 "ac",       Furlong * Chain                                         )

    (*
        Volume of dry goods
    *)

    /// The volume of a cube whose sides measure exactly one inch.
    let CubicInch           = U("cubic inch",           "in³",      Inch ^ 3                                               )
    /// The volume of a cube whose sides measure exactly one foot.
    let CubicFoot           = U("cubic foot",           "ft³",      Foot ^ 3                                               )
    /// The volume of a cube whose sides measure exactly one yard.
    let CubicYard           = U("cubic yard",           "yd³",      Yard ^ 3                                               )
    /// The volume of a cube whose sides measure exactly one mile.
    let CubicMile           = U("cubic mile",           "mi³",      Mile ^ 3                                               )
    
    (*
        Units of weight
    *)

    (* Avoirdupois weights (general use) *)

    /// One pound (avoirdupois) is equal to 16 ounces (avoirdupois), and standardised as exactly 0.45359237 kilograms.
    let Pound               = U("pound (avoirdupois)",  "lb",       Kilogram,               F(45_359_237, 100_000_000)      )
    /// One grain (avoirdupois) is equal to 1/7000 of an pound (avoirdupois).
    let Grain               = U("grain (avoirdupois)",  "gr",       Pound,                  F(1, 7_000)                     )
    /// One dram (avoirdupois) is equal to 27 11/32 grains (avoirdupois), or 1/16 of an ounce (avoirdupois).
    let Dram                = U("dram (avoirdupois)",   "dr",       Grain,                  27 + F(11, 32)                  )
    /// One ounce (avoirdupois) is equal to 1/16 of a pound (avoirdupois).
    let Ounce               = U("ounce (avoirdupois)",  "oz",       Pound,                  F(1, 16)                        )
    /// One stone (UK) is equal to 14 pounds (avoirdupois).
    let Stone               = U("stone",                "st",       Pound,                  14                              )
    /// One quarter (UK) is equal to 28 pounds (avoirdupois).
    let Quarter             = U("quarter",              "quarter",  Pound,                  28                              )
    /// One cental (UK) is equal to 100 pounds (avoirdupois).
    let Cental              = U("cental",               "cental",   Pound,                  100                             )
    /// One hundredweight (US) is equal to 100 pounds (avoirdupois).
    let Hundredweight       = U("short hundredweight",  "cwt",      Pound,                  100                             )
    /// One ton (US) is equal to 2000 pounds (avoirdupois).
    let ShortTon            = U("short ton",            "ton",      Pound,                  2_000                           )
    /// One ton (UK) is equal to 2240 pounds (avoirdupois).
    let LongTon             = U("long ton",             "ton",      Pound,                  2_240                           )

    (* Troy weights *)

    /// One pennyweight (troy) is equal to 24 grains (avoirdupois).
    let Pennyweight         = U("pennyweight",          "dwt",      Grain,                  24                              )
    /// One troy (or apothecaries) ounce is equal to 20 pennyweights.
    let OunceTroy           = U("troy ounce",           "oz t",     Pennyweight,            20                              )
    /// One troy (or apothecaries) pound is equal to 12 troy ounces.
    let PoundTroy           = U("troy pound",           "lb t",     OunceTroy,              12                              )
    
    (* Apothecaries weights *)
    
    /// One scruple (apothecaries) is equal to 20 grains (avoirdupois).
    let Scruple             = U("apothecaries scruple", "℈",        Grain,                  20                              )
    /// One dram (apothecaries, US) is equal to 3 scruples (apothecaries).
    let DramApothecaries    = U("apothecaries dram",    "ʒ",        Scruple,                3                               )
    /// One drachm (apothecaries, UK) is equal to 3 scruples (apothecaries).
    let Drachm              = U("apothecaries dram",    "ʒ",        Scruple,                3                               )
    /// One apothecaries (or troy) ounce is equal to 8 drams (apothecaries).
    let OunceApothecaries   = U("apothecaries ounce",   "℥",        DramApothecaries,       8                               )
    /// One apothecaries (or troy) pound is equal to 12 apothecaries (or troy) ounces.
    let PoundApothecaries   = U("apothecaries pound",   "℔",        OunceApothecaries,      12                              )
    
module Uk =

    open Fun
    open SI

    module LiquidVolume =

        /// A gallon is defined as exactly 4.54609 litres.
        let Gallon          = U("gallon",               "gal",      SI.Liter,               F(454_609, 100_000)             )
        /// A bushel is equal to 8 gallons.
        let Bushel          = U("bushel",               "bushel",   Gallon,                 8                               )
        /// A peck is equal to 2 gallons.
        let Peck            = U("peck",                 "peck",     Gallon,                 2                               )
        /// A quart is equal to 1/4 gallon.
        let Quart           = U("quart",                "qt",       Gallon,                 F(1, 4)                         )
        /// A pint is equal to 1/2 quart.
        let Pint            = U("pint",                 "pt",       Quart,                  F(1, 2)                         )
        /// A gill is equal to 1/4 pint.
        let Gill            = U("gill",                 "gill",     Pint,                   F(1, 4)                         )
        /// A fluid ounce is equal to 1/5 gill.
        let FluidOunce      = U("gill",                 "fl oz",    Gill,                   F(1, 5)                         )
        /// A fluid drachm is equal to 1/8 fluid ounce.
        let FluidDrachm     = U("fluid drachm",         "fl dr",    FluidOunce,             F(1, 8)                         )
        /// A minim is equal to 1/60 fluid drachm.
        let Minim           = U("minim",                "minim",    FluidDrachm,            F(1, 60)                        )

module Us =

    open Fun
    open SI

    module Survey =
    
        /// 1 foot (US survey) is equal to 12 inches (US survey).
        let Foot        = U("foot (US survey)",             "ft",       Meter,              F(1_200, 3_937)                     )
        /// 1 link (US survey) is equal to 1/100 of chain (US survey).
        let Link        = U("link (US survey)",             "li",       Foot,               F(66, 100)                          )
        /// 1 rod (or pole, or perch) is equal to 25 links (US survey), or one quarter of a chain (US survey).
        let Rod         = U("rod (US survey)",              "rod",      Link,               25                                  )
        /// 1 US survey pole (or rod, or perch) is equal to 25 links (US survey), or one quarter of a chain (US survey).
        let Pole        = Rod
        /// 1 US survey perch (or rod, or pole) is equal to 25 links (US survey), or one quarter of a chain (US survey).
        let Perch       = Rod
        /// 1 chain (US survey) is equal to 100 links (US survey), or 4 US survey rods (or poles, or perches).
        let Chain       = U("chain (US survey)",            "ch",       Link,               100                                 )
        /// 1 furlong (US survey) is equal to 10 chains (US survey), or 40 rods (US survey), or 1 000 links (US survey).
        let Furlong     = U("furlong (US survey)",          "fur",      Chain,              10                                  )
        /// 1 US survey (or statute) mile is equal to 8 furlongs (US survey), or 80 chains (US survey), or 320 rods (US survey), or 5280 feet (US survey), or 8 000 links (US survey).
        let Mile        = U("mile (US survey)",             "mi",       Furlong,            8                                   )
        /// 1 statute (or US survey) mile is equal to 8 furlongs (US survey), or 80 chains (US survey), or 320 rods (US survey), or 5280 feet (US survey), or 8 000 links (US survey).
        let StatuteMile = Mile
        /// 1 international mile is equal to 5 280 feet (international), or 1 760 yards (international), and standardised as exactly 1,609.344 meters.
        let InternationalMile = International.Mile
        /// 1 league (US survey, land) is equal to exactly 3 US survey (or statute) miles.
        let League      = U("league (US survey, land)",     "lea",      Mile,               3                                   )
        
        /// The area of a square whose sides measure exactly one rod (US survey). 
        let SquareRod   = U("square rod (US survey)",       "rd²",      Rod ^ 2                                                 )
        /// 1 acre (US survey) is the area of 1 chain (US survey) by 1 furlong (66 by 660 US survey feet), which is exactly equal to 1⁄640 of a square statute mile, or 43 560 square feet (US survey).
        let Acre        = U("acre (US survey)",             "ac",       Furlong * Chain                                         )
        /// The area of a square whose sides measure exactly one US survey (or statute) mile. 
        let SquareMile  = U("square rod (US survey)",       "mi²",      StatuteMile ^ 2                                         )
        /// 1 township (US survey) is equal to 36 square miles (US survey). 
        let Township    = U("township (US survey)",         "?",        SquareMile,         36                                  )

    module DryVolume =

        open International

        /// 1 dry pint is equal to exactly 33.6003125 cubic inches.
        let DryPint             = U("pint (dry)",           "pt",       CubicInch,          F(336_003_125, 10_000_000)          )

        /// 1 dry quart is equal to 2 dry pints.
        let DryQuart            = U("quart (dry)",          "qt",       DryPint,            2I                                  )

        /// 1 dry gallon is equal to 4 dry quarts.
        let DryGallon           = U("gallon (dry)",         "gal",      DryQuart,           4I                                  )

        /// 1 peck is equal to 8 dry quarts.
        let Peck                = U("peck",                 "pk",       DryQuart,           8I                                  )
        
        /// 1 bushel is equal to 4 pecks.
        let Bushel              = U("bushel",               "bu",       Peck,               4I                                  )

        /// 1 dry barrel is equal to exactly 7 056 cubic inches.
        let DryBarrel           = U("barrel (dry)",         "bbl",      CubicInch,          7_056I                              )

    module LiquidVolume =
    
        /// A minim is equal to ~1 drop of water, and is defined as exactly 61.611519921875 μL.
        let Minim               = U("minim",                "min",      Microliter,         61_611_519_921_875I * F.Pow(10, -12))

        /// A US fluid dram is equal to 60 minim.
        let UsFluidDram         = U("U.S. fluid dram",      "fl dr",    Minim,              60                                  )

        /// A teaspoon is equal to 80 minim.
        let Teaspoon            = U("teaspoon",             "tsp",      Minim,              80                                  )

        /// A tablespoon is equal to 3 teaspoons.
        let Tablespoon          = U("tablespoon",           "Tbsp",     Teaspoon,           3                                   )

        /// A U.S. fluid ounce is equal to 2 tablespoons.
        let UsFluidOunce        = U("U.S. fluid ounce",     "fl oz",    Tablespoon,         2                                   )

        /// A U.S. shot is equal to 1.5 U.S. fluid ounces, or 3 tablespoons.
        let UsShot              = U("U.S. shot",            "jig",      Tablespoon,         3                                   )

        /// A U.S. gill is equal to 2 2⁄3 U.S. shots, or 4 U.S. fluid ounces.
        let UsGill              = U("U.S. gill",            "gi",       UsFluidOunce,       4                                   )

        /// A U.S. cup is equal to 2 U.S. gills, or 8 U.S. fluid ounces.
        let UsCup               = U("U.S. cup",             "cp",       UsGill,             2                                   )

        /// A (liquid) U.S. pint is equal to 2 U.S. cups.
        let UsPint              = U("U.S. pint (liquid)",   "pt",       UsCup,              2                                   )

        /// A (liquid) U.S. quart is equal to 2 U.S. pints.
        let UsQuart             = U("U.S. quart (liquid)",  "qt",       UsPint,             2                                   )
        
        /// A liquid U.S. gallon is equal to 4 U.S. quart, or 231 cubic inches.
        let UsGallon            = U("U.S. gallon (liquid)", "gal",      UsQuart,            4                                   )

        /// A (liquid) barrel is equal to 31.5 U.S. gallons, or 1/2 hogshead.
        let Barrel              = U("barrel (liquid)",      "bbl",      UsGallon,           F(315, 10)                          )

        /// An oil barrel is equal to 1 1/3 liquid barrels, or 42 U.S. gallons, or 2/3 hogshead.
        let OilBarrel           = U("oil barrel",           "bbl",      UsGallon,           42                                  )

        /// A hogshead is equal to 1.5 oil barrels, or 63 U.S. gallons.
        let Hogshead            = U("hogshead",             "bbl",      UsGallon,           63                                  )

module Typography =

    open Fun

    /// 1 Point (typography) is equal to exactly 0.013 837 inches.
    let Point               = U("Point",                    "Point",    International.Inch, F(13_837, 1_000_000)                )
 
module Math =

    open Fun

    /// The ratio of a circle's circumference to its diameter.
    let Pi                      = Constant("Pi", "π", Fraction.Pi)

    /// The base of the natural logarithm.
    let e                       = Constant("e", "e", Fraction.e)

    /// Angle (SI derived unit).
    let Radian                  = SI.Radian

    /// 1/180 of a radian, or 1/360 of a full circle.
    let Degree                  = U("degree",       "deg",      Radian,     Fraction.Pi / 180   )

    /// 1/60 of a degree.
    let ArcMinute               = U("arcminute",    "arcmin",   Degree,     F(1, 60)             )

    /// 1/60 of an arcminute.
    let ArcSecond               = U("arcsecond",    "arcsec",   ArcMinute,  F(1, 60)             )
   
module Time =

    open Prefix
    open SI

    /// 1/1000 of a second.
    let Millisecond = Milli * Second
    /// 1/1000 of a millisecond.
    let Microsecond = Micro * Second
    /// 1/1000 of a microsecond.
    let Nanosecond  = Nano  * Second
    /// 1/1000 of a nanosecond.
    let Picosecond  = Pico  * Second
    /// 1/1000 of a picosecond.
    let Femtosecond = Femto * Second
    /// 1/1000 of a femtosecond.
    let Attosecond  = Atto  * Second

    /// 60 seconds.
    let Minute      = U("minute", "min", Second, 60)

    /// 60 minutes, or 3 600 seconds.
    let Hour        = U("hour", "h", Minute, 60)

    /// 24 hours, or 1 440 minutes, or 86 400 seconds.
    let Day         = U("day", "d", Hour, 24)

module Physics =

    open Fun
    open Prefix
    open SI
    open Time
      
    /// c
    let SpeedOfLight            = Constant("speed of light",                "c",        299_792_458,                        Meter / Second          )
        
    /// G
    let GravitationalConstant   = Constant("gravitational constant",        "G",        66_740_831 * F.Pow(10, 18), (Meter^3) / (Kilogram * (Second^2)) )
        
    /// Planck constant, h.
    let PlanckConstant          = Constant("planck constant",               "h",        662_607_004_081I * F.Pow(10, -45),  Joule * Second          )
    /// Planck length.
    let PlanckLength            = Constant("planck length",                 "lP",       161_619_997I * F.Pow(10, -43),      Meter                   )
    /// Planck mass.
    let PlanckMass              = Constant("planck mass",                   "mP",       21_765_113I * F.Pow(10, -15),       Kilogram                )
    /// Planck time.
    let PlanckTime              = Constant("planck time",                   "tP",       53_910_632I * F.Pow(10, -51),       Second                  )
    /// Planck charge.
    let PlanckCharge            = Constant("planck charge",                 "qP",       53_910_632I * F.Pow(10, -51),       Coulomb                 )
    /// Planck temperature.
    let PlanckTemperature       = Constant("planck temperature",            "TP",       141_683_385I * F.Pow(10, 24),       Kelvin                  )

    /// The ångström (or angstrom) is a unit of length equal to 10^−10 m (one ten-billionth of a meter) or 0.1 nanometer.
    /// Its symbol is Å, a letter in the Swedish alphabet.
    let Angstrom                = Constant("ångström",                      "Å",        F.Pow(10, -10), Meter                                       )
        
    /// Dirac constant, ħ (pronounced "h-bar").
    let DiracConstant           = Constant("planck constant",               "ħ",        105_457_180_013I * F.Pow(10, -45),  Joule * Second          )

    /// Fine-structure constant (also known as Sommerfeld's constant).
    let FineStructureConstant   = Constant("fine-structure constant",       "α",        7_297_352_566_417I * F.Pow(10, 15)                          )

    /// The hartree (symbol: Eh or Ha), also known as the Hartree energy,
    /// is the atomic unit of energy, named after the British physicist Douglas Hartree.
    let Hartree                 = Constant("hartree",                       "Ha",       435_974_465_054I * F.Pow(10, 29),   Joule                   )

    /// Proton mass.
    let ProtonMass              = Constant("proton mass",                   "mp",       167_262_189_821I * F.Pow(10, 38),   Kilogram                )

    /// The amount of energy gained (or lost) by the charge of a single electron moving across
    /// an electric potential difference of one volt (1.6021766208(98)×10^−19 joule).
    let Electronvolt            = Constant("electronvolt",                  "eV",       1_602_176_620_898I * F.Pow(10, 31), Joule                   )
    
    /// g0
    let StandardGravity         = Constant("standard gravity",              "g0",       F(980_665, 100_000),            Meter / (Second ^ 2)        )

    /// kgf
    let KilogramForce           = Constant("kilogram-force",                "kgf",      Kilogram * StandardGravity                                  )

    /// kp
    let Kilopond                = Constant("kilopond",                      "kp",       Kilogram * StandardGravity                                  )

    /// The poundal (pdl) is defined as the force necessary to accelerate 1 pound-mass at 1 foot per second per second.
    let Poundal                 = U("poundal",                  "pdl",      International.Pound * International.Foot / (Second ^ 2)                 )

    /// The pound-force (lbf) is equal to the gravitational force exerted on a mass of one avoirdupois pound on the surface of Earth.
    let PoundForce              = U("pound-force",              "lbf",      (International.Pound * StandardGravity) |> U                            )
    
    /// A slug is defined as the mass that is accelerated by 1 ft/s2 when a force of one pound (lbf) is exerted on it.
    let Slug                    = U("slug",                     "slug",     PoundForce * (Second ^ 2) / International.Foot                          )

    /// One newton meter is equal to the torque resulting from a force of one newton applied perpendicularly to a moment arm which is one meter long.
    let NewtonMeter             = U("newton meter",             "N·m",      Newton * Meter                              )

    /// Angular frequency ω (in radians per second), is larger than frequency (in cycles per second, also called Hz),
    /// by a factor of 2π, because 2π rad/s corresponds to 1 Hz.
    let RadiansPerSecond        = U("radians per second",       "ω",        Radian/Second                               )

    /// The number of rotations around a fixed axis in one minute.
    /// It is used as a measure of rotational speed of a mechanical component.
    let RevolutionsPerMinute    = U("revolutions per minute",   "rpm",      Hertz,              F(1, 60)                )
    
    /// One dyne is equal to 10 micronewtons
    let Dyne                    = U("dyne",                     "dyn",      Newton,             F.Pow(10, -5)           )

    /// The dyne per centimeter is a unit traditionally used to measure surface tension.
    /// For example, the surface tension of distilled water is 72 dyn/cm at 25 °C.
    let DynePerCentimeter       = U("dyne per centimeter",      "dyn/cm", Dyne/Centimeter                               )

    (* Speed *)

    let MetersPerSecond         = U("meters per second",        "m/s",   Meter/Second                                   )
    let FeetPerSecond           = U("feet per second",          "ft/s",  Us.Survey.Foot/Second                          )
    let KilometersPerHour       = U("kilometers per hour",      "km/h",  Kilometer/Hour                                 )
    let KilometersPerSecond     = U("kilometers per second",    "km/s",  Kilometer/Second                               )
    let MilesPerHour            = U("miles per hour",           "mph",   Us.Survey.Mile/Hour                            )

    (* Energy *)

    let Kilowatt                = Kilo * Watt
    let Megawatt                = Mega * Watt
    let Gigawatt                = Giga * Watt
    
    let Kilojoule               = Kilo * Joule
    let Megajoule               = Mega * Joule
    let Gigajoule               = Giga * Joule
    
    let Watthour                = U("watt hour",                "Wh",   Watt * Hour                                     )
    let KilowattHour            = U("kilowatt hour",            "kWh",  Kilowatt * Hour                                 )
    let MegawattHour            = U("megawatt hour",            "MWh",  Megawatt * Hour                                 )
    let GigawattHour            = U("gigawatt hour",            "GWh",  Gigawatt * Hour                                 )

    /// 1 horsepower (hp) is equal to 745.7 watts.
    let HorsepowerImperial      = U("imperial horsepower",      "hp",   Watt,                   F(7457, 10)             )
    /// 1 horsepower (PS) is equal to 735.5 watts.
    let HorsepowerMetric        = U("metric horsepower",        "PS",   Watt,                   F(7_355, 10)            )

    /// 1 BTU (British Thermal Unit) is equal to 1055.06 joules.
    /// See ISO 31-4 on Quantities and units—Part 4: Heat (https://books.google.com/books?id=-ZveBwAAQBAJ&pg=PA19-IA35).
    let BTU                     = U("british thermal unit",     "BTU",  Joule,                  F(105506, 100)          )
    
    (* Pressure *)

    let Kilopascal              = Kilo * Pascal
    let Bar                     = U("bar",                      "bar",  Pascal,                 10_000                  )
    let PoundsPerSquareInch     = U("pounds per square inch",   "psi",  International.Pound / International.SquareInch  )
    let Barye                   = U("barye",                    "Ba",   Pascal,                 F(1, 10)                )
 
module Astronomy =
    
    open SI
    open Physics
    open Time

    /// A Julian year (symbol: a) is a unit of measurement of time defined as exactly 365.25 days of 86400 SI seconds each.
    let JulianYear              = Constant("Julian year",               "a",    F(36_525, 100), Day                     )

    /// ly
    let Lightyear               = Constant("lightyear",                 "ly",   SpeedOfLight * JulianYear               )

    /// ls
    let Lightsecond             = Constant("lightsecond",               "ls",   SpeedOfLight * Second                   )

    /// au
    let AstronomicalUnit        = Constant("astronomical unit",         "au",   149_597_870_700I, Meter                 )

module Information =
    
    open Prefix
    open SI

    /// The basic unit of information in computing and digital communications.
    /// A bit can have only one of two values, most commonly represented as either a 0 or 1.
    let Bit  = U("bit", "bit")

    /// 8 bits.
    let Byte = U("byte", "B", Bit, 8)
    
    /// 1 KiB = 1024 bytes.
    let Kibibyte  = Kibi * Byte
    /// 1 MiB = 1024 KiB.
    let Mebibyte  = Mebi * Byte
    /// 1 GiB = 1024 MiB.
    let Gibibyte  = Gibi * Byte
    /// 1 TiB = 1024 GiB.
    let Tebibyte  = Tebi * Byte
    /// 1 PiB = 1024 TiB.
    let Pebibyte  = Pebi * Byte
    /// 1 EiB = 1024 PiB.
    let Exbibyte  = Exbi * Byte
    /// 1 ZiB = 1024 EiB.
    let Zebibyte  = Zebi * Byte
    /// 1 YiB = 1024 ZiB.
    let Yobibyte  = Yobi * Byte
    
    /// 1 kB = 1000 bytes.
    let Kilobyte  = Kilo  * Byte
    /// 1 MB = 1000 kB.
    let Megabyte  = Mega  * Byte
    /// 1 GB = 1000 MB.
    let Gigabyte  = Giga  * Byte
    /// T MB = 1000 GB.
    let Terabyte  = Tera  * Byte
    /// 1 PB = 1000 TB.
    let Petabyte  = Peta  * Byte
    /// 1 EB = 1000 PB.
    let Exabyte   = Exa   * Byte
    /// 1 ZB = 1000 EB.
    let Zettabyte = Zetta * Byte
    /// 1 YB = 1000 ZB.
    let Yottabyte = Yotta * Byte

    /// 1 KiBit/s = 1024 bit/s.
    let KibibitPerSecond = Kibi * Bit / Second
    /// 1 MiBit/s = 1024 KiBit/s.
    let MebibitPerSecond = Mebi * Bit / Second
    /// 1 GiBit/s = 1024 MiBit/s.
    let GibibitPerSecond = Gibi * Bit / Second

    /// 1 kB/s = 1000 byte/s.
    let KilobytePerSecond = Kilobyte / Second
    /// 1 MB/s = 1000 kB/s.
    let MegabytePerSecond = Megabyte / Second
    /// 1 GB/s = 1000 MB/s.
    let GigabytePerSecond = Gigabyte / Second
    /// 1 TB/s = 1000 GB/s.
    let TerabytePerSecond = Terabyte / Second

    /// 1 KiB/s = 1024 byte/s.
    let KibibytePerSecond = Kibibyte / Second
    /// 1 MiB/s = 1024 KiB/s.
    let MebibytePerSecond = Mebibyte / Second
    /// 1 GiB/s = 1024 MiB/s.
    let GibibytePerSecond = Gibibyte / Second
    /// 1 TiB/s = 1024 GiB/s.
    let TebibytePerSecond = Tebibyte / Second

module Nautical =

    open Fun
    open Time

    /// 1 nautical mile (NM or nmi) is equal to 1 852 meters.
    let NauticalMile        = U("nautical mile",            "nmi",  SI.Meter,             1_852         )
    
    /// 1 knot is equal to 1 nautical mile per hour.
    let Knot                = U("international knot",       "kn",   NauticalMile/Hour                   ) 
    
    /// 1 cable is equal to 1/10 of a nautical mile.
    let Cable               = U("cable",                    "cb",   NauticalMile,       F(    1,   10)  )
    
    module UsCustomary =

        /// 1 fathom is equal to 2 yards.
        let Fathom          = U("fathom (US customary)",    "ftm",  Us.Survey.Foot,           6         )
        
        /// 1 cable (US customary) is equal to 120 fathoms.
        let Cable           = U("cable (US customary)",     "cb",   Fathom,                 120         )

module Unit =
    
    open Fun
    open Prefix
    open SI
    open Time
         
    // Lengths
    let Point               = U("point",                    "p",        Meter,              352_777_778 * F.Pow(10, -12)      )
    let Pica                = U("pica",                     "P/",       Meter,              4233333 * F.Pow(10, -9)           )
                                                                                                  
    let ImperialGallon      = U("imperial gallon",          "gal",      Liter,              454_609 * F.Pow(10, -5)           )                                                                                                                                                         
    
 module Historic =

    open SI
    
    let GermanLegalMeter                = U("German legal meter",                   "m",    Meter, F(  10_000_135_965I,     10_000_000_000I  )   )

    let ClarkesLink                     = U("Clarke's link",                        "li",   Meter, F( 201_166_195_164I,  1_000_000_000_000I  )   )
    let ClarkesChain                    = U("Clarke's chain",                       "ch",   Meter, F( 201_166_195_164I,     10_000_000_000I  )   )
    let ClarkesFoot                     = U("Clarke's foot",                        "ft",   Meter, F(   3_047_972_654I,     10_000_000_000I  )   )
    let ClarkesYard                     = U("Clarke's yard",                        "yd",   Meter, F(   9_143_917_962I,     10_000_000_000I  )   )
                                                                                                                                                                      
    let BritishFoot_Sears1922           = U("British foot (Sears 1922)",            "ft",   Meter, F(      12_000_000I,         39_370_147I  )   )
    let BritishYard_Sears1922           = U("British yard (Sears 1922)",            "yd",   Meter, F(      36_000_000I,         39_370_147I  )   )
    let BritishLink_Sears1922           = U("British link (Sears 1922)",            "li",   Meter, F(       7_920_000I,         39_370_147I  )   )
    let BritishChain_Sears1922          = U("British chain (Sears 1922)",           "ch",   Meter, F(     792_000_000I,         39_370_147I  )   )
                                                                                                                                                            
    let BritishFoot_Benoit1895A         = U("British foot (Benoit 1895 A)",         "ft",   Meter, F(       9_143_992I,         30_000_000I  )   )
    let BritishYard_Benoit1895A         = U("British yard (Benoit 1895 A)",         "yd",   Meter, F(       9_143_992I,         10_000_000I  )   )
    let BritishLink_Benoit1895A         = U("British link (Benoit 1895 A)",         "li",   Meter, F(     201_167_824I,      1_000_000_000I  )   )
    let BritishChain_Benoit1895A        = U("British chain (Benoit 1895 A)",        "ch",   Meter, F(     201_167_824I,         10_000_000I  )   )
                                                                                                                                                            
    let BritishFoot_Benoit1895B         = U("British foot (Benoit 1895 B)",         "ft",   Meter, F(      12_000_000I,         39_370_113I  )   )
    let BritishYard_Benoit1895B         = U("British yard (Benoit 1895 B)",         "yd",   Meter, F(      36_000_000I,         39_370_113I  )   )
    let BritishLink_Benoit1895B         = U("British link (Benoit 1895 B)",         "li",   Meter, F(       7_920_000I,         39_370_113I  )   )
    let BritishChain_Benoit1895B        = U("British chain (Benoit 1895 B)",        "ch",   Meter, F(     792_000_000I,         39_370_113I  )   )
                                                                                                                                                            
    let BritishFoot_1865                = U("British foot (1865)",                  "ft",   Meter, F(       9_144_025I,         30_000_000I  )   )
                                                                                                                                                            
    let IndianFoot                      = U("Indian foot",                          "ft",   Meter, F(      12_000_000I,         39_370_142I  )   )
    let IndianFoot_1937                 = U("Indian foot (1937)",                   "ft",   Meter, F(      30_479_841I,        100_000_000I  )   )
    let IndianFoot_1962                 = U("Indian foot (1962)",                   "ft",   Meter, F(       3_047_996I,         10_000_000I  )   )
    let IndianFoot_1975                 = U("Indian foot (1975)",                   "ft",   Meter, F(       3_047_995I,         10_000_000I  )   )
    
    let IndianYard                      = U("Indian yard",                          "yd",   Meter, F(      36_000_000I,         39_370_142I  )   )
    let IndianYard_1937                 = U("Indian yard (1937)",                   "yd",   Meter, F(      91_439_523I,        100_000_000I  )   )
    let IndianYard_1962                 = U("Indian yard (1962)",                   "yd",   Meter, F(       9_143_988I,         10_000_000I  )   )
    let IndianYard_1975                 = U("Indian yard (1975)",                   "yd",   Meter, F(       9_143_985I,         10_000_000I  )   )
    
    let StatuteMile                     = U("Statute mile",                         "mi",   Meter, F(       1_609_344I,              1_000I  )   )
    let GoldCoastFoot                   = U("Gold Coast foot",                      "ft",   Meter, F(       6_378_300I,         20_926_201I  )   )
    let BritishFoot_1936                = U("British foot (1936)",                  "ft",   Meter, F(   3_048_007_491I,     10_000_000_000I  )   )
    
    let BritishFoot_Sears1922Truncated  = U("British foot (Sears 1922 truncated)",  "ft",   Meter, F(         914_398I,          3_000_000I  )   )
    let BritishYard_Sears1922Truncated  = U("British yard (Sears 1922 truncated)",  "yd",   Meter, F(          14_398I,            100_000I  )   )
    let BritishLink_Sears1922Truncated  = U("British link (Sears 1922 truncated)",  "li",   Meter, F(      20_116_756I,        100_000_000I  )   )
    let BritishChain_Sears1922Truncated = U("British chain (Sears 1922 truncated)", "ch",   Meter, F(      20_116_756I,          1_000_000I  )   )
                                                                                                                                                                
    let BinWidth330UsSurveyFeet         = U("Bin width 330 U.S. survey feet",        "?",   Meter, F(         396_000I,              3_937I  )   )
    let BinWidth165UsSurveyFeet         = U("Bin width 165 U.S. survey feet",        "?",   Meter, F(         198_000I,              3_937I  )   )
    let BinWidth82_5UsSurveyFeet        = U("Bin width 82.5 U.S. survey feet",       "?",   Meter, F(          99_000I,              3_937I  )   )
    
    let BinWidth37_5Metres              = U("Bin width 37.5 metres",          "Bin37.5m",   Meter, F(             375I,                 10I  )   )
    let BinWidth25Metres                = U("Bin width 25 metres",              "Bin25m",   Meter, F(              25I,                  1I  )   )
    let BinWidth12_5Metres              = U("Bin width 12.5 metres",          "Bin12.5m",   Meter, F(             125I,                 10I  )   )
    let BinWidth3_125Metres             = U("Bin width 3.125 metres",        "Bin3.125m",   Meter, F(           3_125I,              1_000I  )   )
           
    