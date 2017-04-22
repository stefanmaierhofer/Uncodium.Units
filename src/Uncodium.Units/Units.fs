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
    
    // SI units
    let Meter       = UnitOfMeasure("meter", "m", None, 1)
    let Kilometer   = Kilo  * Meter
    let Decimeter   = Deci  * Meter
    let Centimeter  = Centi * Meter
    let Millimeter  = Milli * Meter
    let Micrometer  = Micro * Meter
    let Nanometer   = Nano  * Meter

    let Second      = UnitOfMeasure("second", "s", None, 1)
    let Millisecond = Milli * Second
    let Microsecond = Micro * Second
    let Nanosecond  = Nano  * Second
    let Picosecond  = Pico  * Second
    let Femtosecond = Femto * Second
    let Attosecond  = Atto  * Second
    let Minute      = UnitOfMeasure("minute", "min", Second, 60)
    let Hour        = UnitOfMeasure("hour", "h", Minute, 60)
    let Day         = UnitOfMeasure("day", "d", Hour, 24)
    let JulianYear  = UnitOfMeasure("Julian year", "a", Day, Fraction(365.25))
        
    let Kilogram    = UnitOfMeasure("kilogram", "kg", None, 1)
    let Gram        = UnitOfMeasure("gram", "g", Kilogram, Fraction(1, 1000))
    let Milligram   = Milli * Gram
    
    let Ampere      = UnitOfMeasure("ampere", "A", None, 1)
    let Mole        = UnitOfMeasure("mole", "mol", None, 1)
    let Candela     = UnitOfMeasure("candela", "cd", None, 1)
    
    let Radian      = UnitOfMeasure("radian",       "rad",  Meter / Meter                               )
    let Steradian   = UnitOfMeasure("steradian",    "sr",   (Meter * Meter) / (Meter * Meter)           )
    let Newton      = UnitOfMeasure("newton",       "N",    Kilogram * Meter / (Second * Second)        )
    let Pascal      = UnitOfMeasure("pascal",       "Pa",   Newton / (Meter * Meter)                    )
    let Joule       = UnitOfMeasure("joule",        "J",    Newton * Meter                              )
    let Watt        = UnitOfMeasure("watt",         "W",    Joule / Second                              )
    let Coulomb     = UnitOfMeasure("coulomb",      "C",    Second * Ampere                             )
    let Volt        = UnitOfMeasure("volt",         "V",    Watt / Ampere                               )
    let Farad       = UnitOfMeasure("farad",        "F",    Coulomb / Volt                              )
    let Ohm         = UnitOfMeasure("ohm",          "Ω",    Volt / Ampere                               )
    let Siemens     = UnitOfMeasure("siemens",      "S",    Ampere / Volt                               )
    let Weber       = UnitOfMeasure("weber",        "Wb",   Volt * Second                               )
    let Tesla       = UnitOfMeasure("tesla",        "T",    Weber / (Meter * Meter)                     )
    let Henry       = UnitOfMeasure("henry",        "H",    Weber / Ampere                              )
    let Lumen       = UnitOfMeasure("lumen",        "lm",   Candela * Steradian                         )
    let Lux         = UnitOfMeasure("lux",          "lx",   Lumen / (Meter * Meter)                     )
    let Gray        = UnitOfMeasure("gray",         "Gy",   Joule / Kilogram                            )
    let Sievert     = UnitOfMeasure("sievert",      "Sv",   Joule / Kilogram                            )
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
    

    // Constants
    let SpeedOfLight            = UnitOfMeasure("speed of light",           "c",     Meter / Second,            299_792_458     )
    let Lightyear               = UnitOfMeasure("lightyear",                "ly",   SpeedOfLight * JulianYear                   )
    let Lightsecond             = UnitOfMeasure("lightsecond",              "ls",   SpeedOfLight * Second                       )
    let AstronomicalUnit        = UnitOfMeasure("astronomical unit",        "au",   Meter,                  149_597_870_700I    )
    let GravitationalConstant   = UnitOfMeasure("gravitational constant",   "G",    (Meter * Meter * Meter) / (Kilogram * Second * Second),  6.6740831 * 10e-11     )
    
    //  Lengths
    let Point                           = UnitOfMeasure("point",                                "p",    Meter,                      0.000352777778                  )
    let Pica                            = UnitOfMeasure("pica",                                 "P/",   Meter,                      0.004233333                     )
    let Inch                            = UnitOfMeasure("inch",                                 "in",   Meter,                      0.0254                          )
    let Foot                            = UnitOfMeasure("foot",                                 "ft",   Meter,                      0.3048                          )
    let Yard                            = UnitOfMeasure("yard",                                 "yd",   Meter,                      0.9144                          )
    let Mile                            = UnitOfMeasure("mile",                                 "mi",   Foot,                   1_280                               )
                                                                                                                               
    let Chain                           = UnitOfMeasure("chain",                                "ch",   Meter,                     20.1168                          )
    let Link                            = UnitOfMeasure("link",                                 "li",   Meter, Fraction(           20.1168        ,  100           ))
                                                                                                                               
    let Fathom                          = UnitOfMeasure("fathom",                               "ftm",  Yard,                       2                               )         
    let Cable                           = UnitOfMeasure("cable",                                "cb",   Fathom,                   120                               )
    let NauticalMile                    = UnitOfMeasure("nautical mile",                        "nmi",  Meter,                  1_852                               )
                                                                                                                                                              
    let GermanLegalMetre                = UnitOfMeasure("German legal metre",                   "m",    Meter,                      1.0000135965                    )
                                                                                                                                                              
    let UsSurveyLink                    = UnitOfMeasure("US survey link",                       "li",   Meter, Fraction(            7.92          ,   39.37        ))
    let UsSurveyFoot                    = UnitOfMeasure("US survey foot",                       "ft",   Meter, Fraction(           12             ,   39.37        ))
    let UsSurveyRod                     = UnitOfMeasure("US survey rod",                        "rd",   UsSurveyLink,              25                               )
    let UsSurveyChain                   = UnitOfMeasure("US survey chain",                      "ch",   UsSurveyRod,                4                               )
    let UsSurveyFurlong                 = UnitOfMeasure("US survey furlong",                    "fur",  UsSurveyChain,             10                               )
    let UsSurveyMile                    = UnitOfMeasure("US survey mile",                       "mi",   UsSurveyFurlong,            8                               )
    let UsSurveyLeague                  = UnitOfMeasure("US survey league",                     "lea",  UsSurveyFurlong,            3                               )
                                                                                                                                                              
    let ClarkesLink                     = UnitOfMeasure("Clarke's link",                        "li",   Meter,                      0.201166195164                  )
    let ClarkesChain                    = UnitOfMeasure("Clarke's chain",                       "ch",   Meter,                     20.1166195164                    )
    let ClarkesFoot                     = UnitOfMeasure("Clarke's foot",                        "ft",   Meter,                      0.3047972654                    )
    let ClarkesYard                     = UnitOfMeasure("Clarke's yard",                        "yd",   Meter,                      0.9143917962                    )
                                                                                                                                                              
    let BritishFoot_Sears1922           = UnitOfMeasure("British foot (Sears 1922)",            "ft",   Meter, Fraction(           12             ,   39.370147    ))
    let BritishYard_Sears1922           = UnitOfMeasure("British yard (Sears 1922)",            "yd",   Meter, Fraction(           36             ,   39.370147    ))
    let BritishLink_Sears1922           = UnitOfMeasure("British link (Sears 1922)",            "li",   Meter, Fraction(            7.92          ,   39.370147    ))
    let BritishChain_Sears1922          = UnitOfMeasure("British chain (Sears 1922)",           "ch",   Meter, Fraction(          792             ,   39.370147    ))
                                                                                                                                                              
    let BritishFoot_Benoit1895A         = UnitOfMeasure("British foot (Benoit 1895 A)",         "ft",   Meter, Fraction(            0.9143992     ,    3           ))
    let BritishYard_Benoit1895A         = UnitOfMeasure("British yard (Benoit 1895 A)",         "yd",   Meter,                      0.9143992                       )
    let BritishLink_Benoit1895A         = UnitOfMeasure("British link (Benoit 1895 A)",         "li",   Meter,                      0.201167824                     )
    let BritishChain_Benoit1895A        = UnitOfMeasure("British chain (Benoit 1895 A)",        "ch",   Meter,                     20.1167824                       )
                                                                                                                                                              
    let BritishFoot_Benoit1895B         = UnitOfMeasure("British foot (Benoit 1895 B)",         "ft",   Meter, Fraction(           12             ,   39.370113    ))
    let BritishYard_Benoit1895B         = UnitOfMeasure("British yard (Benoit 1895 B)",         "yd",   Meter, Fraction(           36             ,   39.370113    ))
    let BritishLink_Benoit1895B         = UnitOfMeasure("British link (Benoit 1895 B)",         "li",   Meter, Fraction(            7.92          ,   39.370113    ))
    let BritishChain_Benoit1895B        = UnitOfMeasure("British chain (Benoit 1895 B)",        "ch",   Meter, Fraction(          792             ,   39.370113    ))
                                                                                                                               
    let BritishFoot_1865                = UnitOfMeasure("British foot (1865)",                  "ft",   Meter, Fraction(            0.9144025     ,    3           ))
                                                                                                                                    
    let IndianFoot                      = UnitOfMeasure("Indian foot",                          "ft",   Meter, Fraction(           12             ,   39.370142    ))
    let IndianFoot_1937                 = UnitOfMeasure("Indian foot (1937)",                   "ft",   Meter,                      0.30479841                      )
    let IndianFoot_1962                 = UnitOfMeasure("Indian foot (1962)",                   "ft",   Meter,                      0.3047996                       )
    let IndianFoot_1975                 = UnitOfMeasure("Indian foot (1975)",                   "ft",   Meter,                      0.3047995                       )
                                                                                                                               
    let IndianYard                      = UnitOfMeasure("Indian yard",                          "yd",   Meter, Fraction(           36             ,       39.370142))
    let IndianYard_1937                 = UnitOfMeasure("Indian yard (1937)",                   "yd",   Meter,                      0.91439523                      )
    let IndianYard_1962                 = UnitOfMeasure("Indian yard (1962)",                   "yd",   Meter,                      0.9143988                       )
    let IndianYard_1975                 = UnitOfMeasure("Indian yard (1975)",                   "yd",   Meter,                      0.9143985                       )
                                                                                                                                                      
    let StatuteMile                     = UnitOfMeasure("Statute mile",                         "mi",   Meter,                  1_609.344                           )
    let GoldCoastFoot                   = UnitOfMeasure("Gold Coast foot",                      "ft",   Meter, Fraction(    6_378_300             , 20926201       ))
    let BritishFoot_1936                = UnitOfMeasure("British foot (1936)",                  "ft",   Meter,                      0.3048007491                    )
                                                                                                                              
    let BritishFoot_Sears1922Truncated  = UnitOfMeasure("British foot (Sears 1922 truncated)",  "ft",   Meter, Fraction(            0.914398      ,        3       ))
    let BritishYard_Sears1922Truncated  = UnitOfMeasure("British yard (Sears 1922 truncated)",  "yd",   Meter,                      0.14398                         )
    let BritishLink_Sears1922Truncated  = UnitOfMeasure("British link (Sears 1922 truncated)",  "li",   Meter, Fraction(           20.116756      ,      100       ))
    let BritishChain_Sears1922Truncated = UnitOfMeasure("British chain (Sears 1922 truncated)", "ch",   Meter,                     20.116756                        )
                                                                                                                              
    let BinWidth330UsSurveyFeet         = UnitOfMeasure("Bin width 330 US survey feet",         "?",    Meter, Fraction(        3_960             ,       39.37    ))
    let BinWidth165UsSurveyFeet         = UnitOfMeasure("Bin width 165 US survey feet",         "?",    Meter, Fraction(        1_980             ,       39.37    ))
    let BinWidth82_5UsSurveyFeet        = UnitOfMeasure("Bin width 82.5 US survey feet",        "?",    Meter, Fraction(          990             ,       39.37    ))
                                                                                                                              
    let BinWidth37_5Metres              = UnitOfMeasure("Bin width 37.5 metres",                "?",    Meter,                     37.5                             )
    let BinWidth25Metres                = UnitOfMeasure("Bin width 25 metres",                  "?",    Meter,                     25                               )
    let BinWidth12_5Metres              = UnitOfMeasure("Bin width 12.5 metres",                "?",    Meter,                     12.5                             )
    let BinWidth3_125Metres             = UnitOfMeasure("Bin width 3.125 metres",               "?",    Meter,                      3.125                           )
                                                                                                                              
    // Mass                                                                                                                   
    let Grain                           = UnitOfMeasure("avoirdupois grain",                    "gr",   Milligram,                 64.79891                         )
    let Dram                            = UnitOfMeasure("avoirdupois dram",                     "dr",   Gram,                       1.7718451953125                 )
    let Ounce                           = UnitOfMeasure("avoirdupois pound",                    "oz",   Dram,                      16                               )
    let Pound                           = UnitOfMeasure("avoirdupois pound",                    "lb",   Ounce,                     16                               )
    let UsHundredweight                 = UnitOfMeasure("avoirdupois US hundredweight",         "cwt",  Pound,                    100                               )
    let LongHundredWeight               = UnitOfMeasure("avoirdupois long hundredweight",       "?",    Pound,                   112                                )
    let UsTon                           = UnitOfMeasure("avoirdupois short ton",                "?",    UsHundredweight,          20                                )
    let LongTon                         = UnitOfMeasure("avoirdupois long ton",                 "?",    LongHundredWeight,        20                                )
                                                                                                                                  
    let TroyGrain                       = UnitOfMeasure("troy grain",                           "gr",   Milligram,                64.79891                          )
    let TroyPennyweight                 = UnitOfMeasure("troy pennyweight",                     "dwt",  TroyGrain,                24                                )
    let TroyOunce                       = UnitOfMeasure("troy ounce",                           "oz t", TroyPennyweight,          20                                )
    let TroyPound                       = UnitOfMeasure("troy pound",                           "lb t", TroyOunce,                12                                )

    // Area
    let SquareKilometer                 = Kilometer * Kilometer
    let SquareMeter                     = Meter * Meter
    let SquareDecimeter                 = Decimeter * Decimeter
    let SquareCentimeter                = Centimeter * Centimeter
    let SquareMillimeter                = Millimeter * Millimeter

    let SquareMile                      = Mile * Mile

    // Volume
    let CubicMeter                      = Meter * Meter * Meter
    let CubicDecimeter                  = Decimeter * Decimeter * Decimeter
    let CubicCentimeter                 = Centimeter * Centimeter * Centimeter
    let CubicMillimeter                 = Millimeter * Millimeter * Millimeter
                                        
    let Litre                           = UnitOfMeasure("litre",                                "l",    Decimeter * Decimeter * Decimeter                           )
    let Millilitre                      = Milli * Litre
                              
    let CubicInch                       = Inch * Inch * Inch
    let CubicFoot                       = Foot * Foot * Foot
          
    let ImperialGallon                  = UnitOfMeasure("imperial gallon",                      "gal",  Litre,                    4.54609                           )
    
    let UsGallon                        = UnitOfMeasure("US gallon",                            "gal",  CubicInch,              231                                 )
    let UsBushel                        = UnitOfMeasure("US bushel",                            "bsh",  CubicInch,            2_150.42                              )
    let UsDryGallon                     = UnitOfMeasure("US dry gallon",                        "gal",  UsBushel, Fraction(       1               ,        8       ))