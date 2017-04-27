namespace Uncodium.Units

open System
open System.Numerics
     
module Unit =
    
    let private (^) (a : int) (b : int) = bigint.Pow(bigint a, b)

    // Prefixes
    let Deca  = UnitPrefix("deca",  "da", 10)
    let Hecto = UnitPrefix("hecto", "h",  100)
    let Kilo  = UnitPrefix("kilo",  "k",  1000)
    let Mega  = UnitPrefix("mega",  "M",  1000^2)
    let Giga  = UnitPrefix("giga",  "G",  1000^3)
    let Tera  = UnitPrefix("tera",  "T",  1000^4)
    let Peta  = UnitPrefix("peta",  "P",  1000^5)
    let Exa   = UnitPrefix("exa",   "E",  1000^6)
    let Zetta = UnitPrefix("zetta", "Z",  1000^7)
    let Yotta = UnitPrefix("yotta", "Y",  1000^8)

    let Deci  = UnitPrefix("deci",  "d",  Fraction(1, 10))
    let Centi = UnitPrefix("centi", "c",  Fraction(1, 100))
    let Milli = UnitPrefix("milli", "m",  Fraction(1, 1000))
    let Micro = UnitPrefix("micro", "µ",  Fraction(1, 1000^2))
    let Nano  = UnitPrefix("nano",  "n",  Fraction(1, 1000^3))
    let Pico  = UnitPrefix("pico",  "p",  Fraction(1, 1000^4))
    let Femto = UnitPrefix("femto", "f",  Fraction(1, 1000^5))
    let Atto  = UnitPrefix("atto",  "a",  Fraction(1, 1000^6))
    let Zepto = UnitPrefix("zepto", "z",  Fraction(1, 1000^7))
    let Yocto = UnitPrefix("yocto", "y",  Fraction(1, 1000^8))

    let Kibi = UnitPrefix("kibi",  "Ki",  1024^1)
    let Mebi = UnitPrefix("mebi",  "Mi",  1024^2)
    let Gibi = UnitPrefix("gibi",  "Gi",  1024^3)
    let Tebi = UnitPrefix("tebi",  "Ti",  1024^4)
    let Pebi = UnitPrefix("pebi",  "Pi",  1024^5)
    let Exbi = UnitPrefix("exbi",  "Ei",  1024^6)
    let Zebi = UnitPrefix("zebi",  "Zi",  1024^7)
    let Yobi = UnitPrefix("yobi",  "Yi",  1024^8)
    
    /////////////////////////////////////////////////////////////////////////
    // SI base units

    /// Length (SI base unit).
    let Meter       = UnitOfMeasure("meter", "m")
    /// Mass (SI base unit).
    let Kilogram    = UnitOfMeasure("kilogram", "kg")
    /// Time (SI base unit).
    let Second      = UnitOfMeasure("second", "s")
    /// Electric current (SI base unit).
    let Ampere      = UnitOfMeasure("ampere", "A")
    /// Thermodynamic temperature (SI base unit).
    let Kelvin      = UnitOfMeasure("kelvin", "K")
    /// Amount of substance (SI base unit).
    let Mole        = UnitOfMeasure("mole", "mol")
    /// Luminous intensity (SI base unit).
    let Candela     = UnitOfMeasure("candela", "cd")

    /////////////////////////////////////////////////////////////////////////
    // SI derived units

    /// Angle (SI derived unit).
    let Radian      = UnitOfMeasure("radian",       "rad",  Meter / Meter                               )
    /// Solid angle (SI derived unit).
    let Steradian   = UnitOfMeasure("steradian",    "sr",   (Meter * Meter) / (Meter * Meter)           )
    /// Frequency (SI derived unit).
    let Hertz       = UnitOfMeasure("hertz",        "Hz",   1 / Second                                  )
    /// Force, weight (SI derived unit).
    let Newton      = UnitOfMeasure("newton",       "N",    Kilogram * Meter / (Second * Second)        )
    /// Pressure, stress (SI derived unit).
    let Pascal      = UnitOfMeasure("pascal",       "Pa",   Newton / (Meter * Meter)                    )
    /// Energy, work, heat (SI derived unit).
    let Joule       = UnitOfMeasure("joule",        "J",    Newton * Meter                              )
    /// Power, radiant flux (SI derived unit).
    let Watt        = UnitOfMeasure("watt",         "W",    Joule / Second                              )
    /// Electric charge or quantity of electricity (SI derived unit).
    let Coulomb     = UnitOfMeasure("coulomb",      "C",    Second * Ampere                             )
    /// Voltage (electrical potential difference), electromotive force (SI derived unit).
    let Volt        = UnitOfMeasure("volt",         "V",    Watt / Ampere                               )
    /// Capacitance (SI derived unit).
    let Farad       = UnitOfMeasure("farad",        "F",    Coulomb / Volt                              )
    /// Electric resistance, impedance, reactance (SI derived unit).
    let Ohm         = UnitOfMeasure("ohm",          "Ω",    Volt / Ampere                               )
    /// Electrical conductance (SI derived unit).
    let Siemens     = UnitOfMeasure("siemens",      "S",    Ampere / Volt                               )
    /// Magnetic flux (SI derived unit).
    let Weber       = UnitOfMeasure("weber",        "Wb",   Volt * Second                               )
    /// Magnetic flux density (SI derived unit).
    let Tesla       = UnitOfMeasure("tesla",        "T",    Weber / (Meter * Meter)                     )
    /// Inductance (SI derived unit).
    let Henry       = UnitOfMeasure("henry",        "H",    Weber / Ampere                              )
    /// Luminous flux (SI derived unit).
    let Lumen       = UnitOfMeasure("lumen",        "lm",   Candela * Steradian                         )
    /// Illuminance (SI derived unit).
    let Lux         = UnitOfMeasure("lux",          "lx",   Lumen / (Meter * Meter)                     )
    /// Radioactivity (decays per unit time) (SI derived unit).
    let Becquerel   = UnitOfMeasure("becquerel",    "Bq",   1 / Second                                  )
    /// Absorbed dose (of ionizing radiation) (SI derived unit).
    let Gray        = UnitOfMeasure("gray",         "Gy",   Joule / Kilogram                            )
    /// Equivalent dose (of ionizing radiation) (SI derived unit).
    let Sievert     = UnitOfMeasure("sievert",      "Sv",   Joule / Kilogram                            )
    /// Catalytic activity (SI derived unit).
    let Katal       = UnitOfMeasure("katal",        "kat",  Mole / Second                               )
    
    // Information
    let Bit  = UnitOfMeasure("bit", "bit", None, 1)
    let Byte = UnitOfMeasure("byte", "B", Bit, 8)
    
    let Kibibyte  = Kibi * Byte
    let Mebibyte  = Mebi * Byte
    let Gibibyte  = Gibi * Byte
    let Tebibyte  = Tebi * Byte
    let Pebibyte  = Pebi * Byte
    let Exbibyte  = Exbi * Byte
    let Zebibyte  = Zebi * Byte
    let Yobibyte  = Yobi * Byte
                                                                           
    let Kilobyte  = Kilo  * Byte
    let Megabyte  = Mega  * Byte
    let Gigabyte  = Giga  * Byte
    let Terabyte  = Tera  * Byte
    let Petabyte  = Peta  * Byte
    let Exabyte   = Exa   * Byte
    let Zettabyte = Zetta * Byte
    let Yottabyte = Yotta * Byte

    let KibibitPerSecond = Kibi * Bit / Second
    let MebibitPerSecond = Mebi * Bit / Second
    let GibibitPerSecond = Gibi * Bit / Second

    let KilobytePerSecond = Kilobyte / Second
    let MegabytePerSecond = Megabyte / Second
    let GigabytePerSecond = Gigabyte / Second

    let KibibytePerSecond = Kibibyte / Second
    let MebibytePerSecond = Mebibyte / Second
    let GibibytePerSecond = Gibibyte / Second
    
    // Time
    let Millisecond = Milli * Second
    let Microsecond = Micro * Second
    let Nanosecond  = Nano  * Second
    let Picosecond  = Pico  * Second
    let Femtosecond = Femto * Second
    let Attosecond  = Atto  * Second
    let Minute      = UnitOfMeasure("minute", "min", Second, 60)
    let Hour        = UnitOfMeasure("hour", "h", Minute, 60)
    let Day         = UnitOfMeasure("day", "d", Hour, 24)
        
    // Lengths
    let Kilometer   = Kilo  * Meter
    let Decimeter   = Deci  * Meter
    let Centimeter  = Centi * Meter
    let Millimeter  = Milli * Meter
    let Micrometer  = Micro * Meter
    let Nanometer   = Nano  * Meter

    let Point                           = UnitOfMeasure("point",                                "p",     Meter,                      0.000352777778                  )
    let Pica                            = UnitOfMeasure("pica",                                 "P/",    Meter,                      0.004233333                     )
    let Inch                            = UnitOfMeasure("inch",                                 "in",    Meter,                      0.0254                          )
    let Foot                            = UnitOfMeasure("foot",                                 "ft",    Inch,                      12                               )
    let Yard                            = UnitOfMeasure("yard",                                 "yd",    Foot,                       3                               )
    let Mile                            = UnitOfMeasure("mile",                                 "mi",    Foot,                   5_280                               )
                                                                                                                                
    let Chain                           = UnitOfMeasure("chain",                                "ch",    Meter,                     20.1168                          )
    let Link                            = UnitOfMeasure("link",                                 "li",    Meter, Fraction(           20.1168        ,  100           ))
                                                                                                                                
    let Fathom                          = UnitOfMeasure("fathom",                               "ftm",   Yard,                       2                               )         
    let Cable                           = UnitOfMeasure("cable",                                "cb",    Fathom,                   120                               )
    let NauticalMile                    = UnitOfMeasure("nautical mile",                        "nmi",   Meter,                  1_852                               )
                                                                                                                                                             
    let UsSurveyLink                    = UnitOfMeasure("US survey link",                       "li",    Meter, Fraction(            7.92          ,   39.37        ))
    let UsSurveyFoot                    = UnitOfMeasure("US survey foot",                       "ft",    Meter, Fraction(           12             ,   39.37        ))
    let UsSurveyRod                     = UnitOfMeasure("US survey rod",                        "rd",    UsSurveyLink,              25                               )
    let UsSurveyChain                   = UnitOfMeasure("US survey chain",                      "ch",    UsSurveyRod,                4                               )
    let UsSurveyFurlong                 = UnitOfMeasure("US survey furlong",                    "fur",   UsSurveyChain,             10                               )
    let UsSurveyMile                    = UnitOfMeasure("US survey mile",                       "mi",    UsSurveyFurlong,            8                               )
    let UsSurveyLeague                  = UnitOfMeasure("US survey league",                     "lea",   UsSurveyFurlong,            3                               )
           
                                                                                                                                                       
           
    let ClarkesLink                     = UnitOfMeasure("Clarke's link",                        "li",    Meter,                      0.201166195164                  )
    let ClarkesChain                    = UnitOfMeasure("Clarke's chain",                       "ch",    Meter,                     20.1166195164                    )
    let ClarkesFoot                     = UnitOfMeasure("Clarke's foot",                        "ft",    Meter,                      0.3047972654                    )
    let ClarkesYard                     = UnitOfMeasure("Clarke's yard",                        "yd",    Meter,                      0.9143917962                    )
                                                                                                                                                               
    let BritishFoot_Sears1922           = UnitOfMeasure("British foot (Sears 1922)",            "ft",    Meter, Fraction(           12             ,   39.370147    ))
    let BritishYard_Sears1922           = UnitOfMeasure("British yard (Sears 1922)",            "yd",    Meter, Fraction(           36             ,   39.370147    ))
    let BritishLink_Sears1922           = UnitOfMeasure("British link (Sears 1922)",            "li",    Meter, Fraction(            7.92          ,   39.370147    ))
    let BritishChain_Sears1922          = UnitOfMeasure("British chain (Sears 1922)",           "ch",    Meter, Fraction(          792             ,   39.370147    ))
                                                                                                                                                               
    let BritishFoot_Benoit1895A         = UnitOfMeasure("British foot (Benoit 1895 A)",         "ft",    Meter, Fraction(            0.9143992     ,    3           ))
    let BritishYard_Benoit1895A         = UnitOfMeasure("British yard (Benoit 1895 A)",         "yd",    Meter,                      0.9143992                       )
    let BritishLink_Benoit1895A         = UnitOfMeasure("British link (Benoit 1895 A)",         "li",    Meter,                      0.201167824                     )
    let BritishChain_Benoit1895A        = UnitOfMeasure("British chain (Benoit 1895 A)",        "ch",    Meter,                     20.1167824                       )
                                                                                                                                                               
    let BritishFoot_Benoit1895B         = UnitOfMeasure("British foot (Benoit 1895 B)",         "ft",    Meter, Fraction(           12             ,   39.370113    ))
    let BritishYard_Benoit1895B         = UnitOfMeasure("British yard (Benoit 1895 B)",         "yd",    Meter, Fraction(           36             ,   39.370113    ))
    let BritishLink_Benoit1895B         = UnitOfMeasure("British link (Benoit 1895 B)",         "li",    Meter, Fraction(            7.92          ,   39.370113    ))
    let BritishChain_Benoit1895B        = UnitOfMeasure("British chain (Benoit 1895 B)",        "ch",    Meter, Fraction(          792             ,   39.370113    ))
                                                                                                                                
    let BritishFoot_1865                = UnitOfMeasure("British foot (1865)",                  "ft",    Meter, Fraction(            0.9144025     ,    3           ))
    
    let GermanLegalMetre                = UnitOfMeasure("German legal metre",                   "m",     Meter,                      1.0000135965                    )
                                                                                                                                
    let IndianFoot                      = UnitOfMeasure("Indian foot",                          "ft",    Meter, Fraction(           12             ,   39.370142    ))
    let IndianFoot_1937                 = UnitOfMeasure("Indian foot (1937)",                   "ft",    Meter,                      0.30479841                      )
    let IndianFoot_1962                 = UnitOfMeasure("Indian foot (1962)",                   "ft",    Meter,                      0.3047996                       )
    let IndianFoot_1975                 = UnitOfMeasure("Indian foot (1975)",                   "ft",    Meter,                      0.3047995                       )
                                                                                                                                
    let IndianYard                      = UnitOfMeasure("Indian yard",                          "yd",    Meter, Fraction(           36             ,       39.370142))
    let IndianYard_1937                 = UnitOfMeasure("Indian yard (1937)",                   "yd",    Meter,                      0.91439523                      )
    let IndianYard_1962                 = UnitOfMeasure("Indian yard (1962)",                   "yd",    Meter,                      0.9143988                       )
    let IndianYard_1975                 = UnitOfMeasure("Indian yard (1975)",                   "yd",    Meter,                      0.9143985                       )
                                                                                                                                                       
    let StatuteMile                     = UnitOfMeasure("Statute mile",                         "mi",    Meter,                  1_609.344                           )
    let GoldCoastFoot                   = UnitOfMeasure("Gold Coast foot",                      "ft",    Meter, Fraction(    6_378_300             , 20926201       ))
    let BritishFoot_1936                = UnitOfMeasure("British foot (1936)",                  "ft",    Meter,                      0.3048007491                    )
                                                                                                                               
    let BritishFoot_Sears1922Truncated  = UnitOfMeasure("British foot (Sears 1922 truncated)",  "ft",    Meter, Fraction(            0.914398      ,        3       ))
    let BritishYard_Sears1922Truncated  = UnitOfMeasure("British yard (Sears 1922 truncated)",  "yd",    Meter,                      0.14398                         )
    let BritishLink_Sears1922Truncated  = UnitOfMeasure("British link (Sears 1922 truncated)",  "li",    Meter, Fraction(           20.116756      ,      100       ))
    let BritishChain_Sears1922Truncated = UnitOfMeasure("British chain (Sears 1922 truncated)", "ch",    Meter,                     20.116756                        )
                                                                                                                               
    let BinWidth330UsSurveyFeet         = UnitOfMeasure("Bin width 330 US survey feet",         "?",     Meter, Fraction(        3_960             ,       39.37    ))
    let BinWidth165UsSurveyFeet         = UnitOfMeasure("Bin width 165 US survey feet",         "?",     Meter, Fraction(        1_980             ,       39.37    ))
    let BinWidth82_5UsSurveyFeet        = UnitOfMeasure("Bin width 82.5 US survey feet",        "?",     Meter, Fraction(          990             ,       39.37    ))
                                                                                                                               
    let BinWidth37_5Metres              = UnitOfMeasure("Bin width 37.5 metres",                "?",     Meter,                     37.5                             )
    let BinWidth25Metres                = UnitOfMeasure("Bin width 25 metres",                  "?",     Meter,                     25                               )
    let BinWidth12_5Metres              = UnitOfMeasure("Bin width 12.5 metres",                "?",     Meter,                     12.5                             )
    let BinWidth3_125Metres             = UnitOfMeasure("Bin width 3.125 metres",               "?",     Meter,                      3.125                           )
           
    // Angles
    let Degree                          = UnitOfMeasure("degree",       "deg",      Radian,     Fraction.Pi / 180   )
    let ArcMinute                       = UnitOfMeasure("arcminute",    "arcmin",   Degree,     Fraction(1, 60)     )
    let ArcSecond                       = UnitOfMeasure("arcsecond",    "arcsec",   ArcMinute,  Fraction(1, 60)     )
    
    // Mass
    let Gram                            = UnitOfMeasure("gram",                                 "g",     Kilogram, Fraction(1, 1000))
    let Milligram                       = Milli * Gram
    let Microgram                       = Micro * Gram
    
    let Grain                           = UnitOfMeasure("avoirdupois grain",                    "gr",    Milligram,                 64.79891            )
    let Dram                            = UnitOfMeasure("avoirdupois dram",                     "dr",    Gram,                       1.7718451953125    )
    let Ounce                           = UnitOfMeasure("avoirdupois pound",                    "oz",    Dram,                      16                  )
    let Pound                           = UnitOfMeasure("avoirdupois pound",                    "lb",    Ounce,                     16                  )
    let UsHundredweight                 = UnitOfMeasure("avoirdupois US hundredweight",         "cwt",   Pound,                    100                  )
    let LongHundredWeight               = UnitOfMeasure("avoirdupois long hundredweight",       "?",     Pound,                   112                   )
    let UsTon                           = UnitOfMeasure("avoirdupois short ton",                "?",     UsHundredweight,          20                   )
    let LongTon                         = UnitOfMeasure("avoirdupois long ton",                 "?",     LongHundredWeight,        20                   )
                                                                                                                                   
    let TroyGrain                       = UnitOfMeasure("troy grain",                           "gr",    Milligram,                64.79891             )
    let TroyPennyweight                 = UnitOfMeasure("troy pennyweight",                     "dwt",   TroyGrain,                24                   )
    let TroyOunce                       = UnitOfMeasure("troy ounce",                           "oz t",  TroyPennyweight,          20                   )
    let TroyPound                       = UnitOfMeasure("troy pound",                           "lb t",  TroyOunce,                12                   )
    
    // Force
    let Dyne                            = UnitOfMeasure("dyne",                     "dyn",  Newton,                        1e-5                 )
    
    // Area
    let SquareKilometer                 = Kilometer.Pow(2)
    let SquareMeter                     = Meter.Pow(2)
    let SquareDecimeter                 = Decimeter.Pow(2)
    let SquareCentimeter                = Centimeter.Pow(2)
    let SquareMillimeter                = Millimeter.Pow(2)

    let Are                             = UnitOfMeasure("are",       "a",      SquareMeter,     100     )
    let Hectare                         = UnitOfMeasure("hectare",   "ha",     SquareMeter,     10_000  )

    let SquareInch                      = Inch.Pow(2)
    let SquareMile                      = Mile.Pow(2)

    let UsSurveyAcre                    = UsSurveyChain.Pow(2)

    // Volume
    let CubicMeter                      = Meter.Pow(3)
    let CubicDecimeter                  = Decimeter.Pow(3)
    let CubicCentimeter                 = Centimeter.Pow(3)
    let CubicMillimeter                 = Millimeter.Pow(3)
                                        
    let Litre                           = UnitOfMeasure("litre",                                "l",     CubicDecimeter                                              )
    let Decilitre                       = Deci * Litre
    let Centilitre                      = Centi * Litre
    let Millilitre                      = Milli * Litre
    
    let CubicInch                       = Inch.Pow(3)                                           
    let CubicFoot                       = Foot.Pow(3)                                             
                                                                                                         
    let ImperialGallon                  = UnitOfMeasure("imperial gallon",                      "gal",   Litre,                    4.54609                           )
                                                                                                         
    let UsGallon                        = UnitOfMeasure("US gallon",                            "gal",   CubicInch,              231                                 )
    let UsBushel                        = UnitOfMeasure("US bushel",                            "bsh",   CubicInch,            2_150.42                              )
    let UsDryGallon                     = UnitOfMeasure("US dry gallon",                        "gal",   UsBushel, Fraction(       1               ,        8       ))

    let Minim                           = UnitOfMeasure("~1 drop of water",                     "min",   Grain,                    0.95                              )
    let UsFluidDram                     = UnitOfMeasure("US fluid dram",                        "fl dr", Minim,                   60                                 )
    let Teaspoon                        = UnitOfMeasure("teaspoon",                             "tsp",   Minim,                   80                                 )
    let Tablespoon                      = UnitOfMeasure("tablespoon",                           "Tbsp",  Teaspoon,                 3                                 )
    let UsFluidOunce                    = UnitOfMeasure("US fluid ounce",                       "fl oz", Tablespoon,               2                                 )
    let UsShot                          = UnitOfMeasure("US shot",                              "jig",   Tablespoon,               3                                 )
    let UsGill                          = UnitOfMeasure("US gill",                              "gi",    UsFluidOunce,             4                                 )
    let UsCup                           = UnitOfMeasure("US cup",                               "cp",    UsGill,                   2                                 )
    let UsPint                          = UnitOfMeasure("US pint",                              "pt",    UsCup,                    2                                 )
    let UsQuart                         = UnitOfMeasure("US quart",                             "pt",    UsPint,                   2                                 )
    let Barrel                          = UnitOfMeasure("barrel",                               "bbl",   UsGallon,                31.5                               )
    let OilBarrel                       = UnitOfMeasure("oil barrel",                           "bbl",   UsGallon,                42                                 )
    let Hogshead                        = UnitOfMeasure("hogshead",                             "bbl",   UsGallon,                63                                 )
    
    let AcreFoot                        = UnitOfMeasure("acre-foot",                            "acre-foot",  UsSurveyAcre * UsSurveyFoot                            )
                                                                                                       
    // Speed                                                                                             
    let MetersPerSecond                 = UnitOfMeasure("meters per second",                    "m/s",   Meter/Second                                                )
    let FeetPerSecond                   = UnitOfMeasure("feet per second",                      "ft/s",  Foot/Second                                                 )
    let KilometersPerHour               = UnitOfMeasure("kilometers per hour",                  "km/h",  Kilometer/Hour                                              )
    let MilesPerHour                    = UnitOfMeasure("miles per hour",                       "mph",   Mile/Hour                                                   )
    let Knot                            = UnitOfMeasure("international knot",                   "kn",    NauticalMile/Hour                                           )

    let RadiansPerSecond                = UnitOfMeasure("radians per second",                   "rad/s", Radian/Second                                               )
    let RevolutionsPerMinute            = UnitOfMeasure("revolutions per minute",               "rpm",   Hertz   , Fraction(       1               ,       60       ))
    
    // Energy
    let Kilowatt                        = Kilo * Watt
    let Megawatt                        = Mega * Watt
    let Gigawatt                        = Giga * Watt
    
    let Kilojoule                       = Kilo * Joule
    let Megajoule                       = Mega * Joule
    let Gigajoule                       = Giga * Joule
    
    let Electronvolt                    = UnitOfMeasure("electronvolt",             "eV",   Joule,              Fraction(1602176620898I, 10^31)  )
    
    let Watthour                        = UnitOfMeasure("watt hour",                "Wh",   Watt * Hour                                         )
    let KilowattHour                    = UnitOfMeasure("kilowatt hour",            "kWh",  Kilowatt * Hour                                     )
    let MegawattHour                    = UnitOfMeasure("megawatt hour",            "MWh",  Megawatt * Hour                                     )
    let GigawattHour                    = UnitOfMeasure("gigawatt hour",            "GWh",  Gigawatt * Hour                                     )

    let ImperialHorsepower              = UnitOfMeasure("imperial horsepower",      "hp",   Watt,                           746                 )
    let MetricHorsepower                = UnitOfMeasure("metric horsepower",        "PS",   Watt,                           735.5               )
    
    // Pressure
    let Kilopascal                      = Kilo * Pascal
    let Bar                             = UnitOfMeasure("bar",                                  "bar",  Pascal,               10_000                                 )
    let PoundsPerSquareInch             = UnitOfMeasure("pounds per square inch",               "psi",  Pound / SquareInch                                           )
    let Barye                           = UnitOfMeasure("barye",                                "Ba",   Pascal,                    0.1                               )
    
    module Imperial =
        
        module Length =
            let Yard            = UnitOfMeasure("yard",             "yd",       Meter,      Fraction(9_144, 10_000) )
            let Foot            = UnitOfMeasure("foot",             "ft",       Yard,       Fraction.OneThird       )

            let Thou            = UnitOfMeasure("thou",             "th",       Foot,       Fraction(1, 12_000)     )
            let Inch            = UnitOfMeasure("thou",             "th",       Foot,       Fraction(1, 12)         )
            let Chain           = UnitOfMeasure("chain",            "ch",       Yard,       22                      )
            let Furlong         = UnitOfMeasure("furlong",          "fur",      Chain,      10                      )
            let Mile            = UnitOfMeasure("mile",             "ml",       Furlong,     8                      )
            let League          = UnitOfMeasure("league",           "lea",      Mile,        3                      )
        
            let Fathom          = UnitOfMeasure("fathom",           "ftm",      Yard,        2.02667                )
            let Cable           = UnitOfMeasure("cable",            "cable",    Fathom,    100                      )
            let NauticalMile    = UnitOfMeasure("nautical mile",    "nmi",      Cable,      10                      )

            let Link            = UnitOfMeasure("link",             "l.",       Chain,      Fraction(1, 100)        )
            let Rod             = UnitOfMeasure("rod",              "rod.",     Link,       25                      )
            let Pole            = Rod
            let Perch           = Rod

        module Area =
            let Perch           = UnitOfMeasure("perch",            "perch",     Length.Rod * Length.Rod             )
            let Rood            = UnitOfMeasure("rood",             "rood",      Length.Furlong * Length.Rod         )
            let Acre            = UnitOfMeasure("acre",             "acre",      Length.Furlong * Length.Chain       )

        module Volume =
            let FluidOunce      = UnitOfMeasure("fluid ounce",      "fl oz",    Millilitre,     28.4130625          )
            let Gill            = UnitOfMeasure("gill",             "gi",       FluidOunce,      5                  )
            let Pint            = UnitOfMeasure("pint",             "pt",       FluidOunce,     20                  )
            let Quart           = UnitOfMeasure("quart",            "qt",       FluidOunce,     40                  )
            let Gallon          = UnitOfMeasure("gallon",           "gal",      FluidOunce,    160                  )

        module Mass =
            let Pound           = UnitOfMeasure("pound",            "lb",       Gram,          453.59237            )
            let Grain           = UnitOfMeasure("grain",            "gr",       Pound,  Fraction(1, 7_000)          )
            let Drachm          = UnitOfMeasure("drachm",           "dr",       Pound,  Fraction(1,   256)          )
            let Ounce           = UnitOfMeasure("ounce",            "oz",       Pound,  Fraction(1,    16)          )
            let Stone           = UnitOfMeasure("stone",            "st",       Pound,          14                  )
            let Quarter         = UnitOfMeasure("quarter",          "qr",       Pound,          28                  )
            let Hundredweight   = UnitOfMeasure("hundredweight",    "cwt",      Pound,         112                  )
            let Ton             = UnitOfMeasure("ton",              "t",        Pound,        2240                  )
            let Slug            = UnitOfMeasure("slug",             "slug",     Kilogram,       14.59390294         )

    module Constants =
    
        /// The ratio of a circle's circumference to its diameter.
        let Pi                      = Constant("Pi", "π", Fraction.Pi)

        /// The base of the natural logarithm.
        let e                       = Constant("e", "e", Fraction.e)

        /// a
        let JulianYear              = Constant("Julian year",               "a",    Fraction(36525, 100), Day           )

        /// c
        let SpeedOfLight            = Constant("speed of light",            "c",    299_792_458, Meter / Second         )
        /// ly
        let Lightyear               = Constant("lightyear",                 "ly",   SpeedOfLight * JulianYear           )
        /// ls
        let Lightsecond             = Constant("lightsecond",               "ls",   SpeedOfLight * Second               )
        /// au
        let AstronomicalUnit        = Constant("astronomical unit",         "au",   149_597_870_700I, Meter             )

        /// G
        let GravitationalConstant   = Constant("gravitational constant",    "G",    Fraction(6.6740831, 10^11), Meter.Pow(3) / (Kilogram * Second.Pow(2))     )
        
        /// Planck constant, h.
        let PlanckConstant          = Constant("planck constant",           "h",    6.62607004081e-34, Joule * Second)
        /// Planck length.
        let PlanckLength            = Constant("planck length",             "lP",   1.61619997e-35, Meter)
        /// Planck mass.
        let PlanckMass              = Constant("planck mass",               "mP",   2.1765113e-8, Kilogram)
        /// Planck time.
        let PlanckTime              = Constant("planck time",               "tP",   5.3910632e-44, Second)
        /// Planck charge.
        let PlanckCharge            = Constant("planck charge",             "qP",   5.3910632e-44, Coulomb)
        /// Planck temperature.
        let PlanckTemperature       = Constant("planck temperature",        "TP",   1.41683385e32, Kelvin)
        
        /// Dirac constant, ħ (pronounced "h-bar").
        let DiracConstant           = Constant("planck constant",            "ħ",   1.05457180013e-34, Joule * Second)

        /// Fine-structure constant (also known as Sommerfeld's constant).
        let FineStructureConstant   = Constant("fine-structure constant",    "α",   Fraction(7297352566417I, 10^15))

        /// The hartree (symbol: Eh or Ha), also known as the Hartree energy,
        /// is the atomic unit of energy, named after the British physicist Douglas Hartree.
        let Hartree                 = Constant("hartree",    "Ha",    Fraction(435974465054I, 10^29), Joule)

        /// Proton mass.
        let ProtonMass              = Constant("proton mass",    "mp",    Fraction(167262189821I, 10^38), Kilogram)


        /// g0
        let StandardGravity         = Constant("standard gravity",          "g0",   9.80665, Meter / (Second * Second)  )
        /// kgf
        let KilogramForce           = Constant("kilogram-force",            "kgf",  Kilogram * StandardGravity          )
        /// kp
        let Kilopond                = Constant("kilopond",                  "kp",   Kilogram * StandardGravity          )
        /// lbf
        let PoundForce              = Constant("pound-force",               "lbf",  Pound * StandardGravity             )