namespace Uncodium.Units

open System
open System.Numerics
   
module International =

    open SI
    
    (*
        Units of length
    *)

    /// 1 inch is equal to 1/12 of a foot, and standardised as exactly 2.54 centimeters.
    let Inch                = U("inch",                 "in",       Meter,                  0.0254                          )
    /// 1 foot is equal to 12 inches, and standardised as exactly 0.3048 meters.
    let Foot                = U("foot",                 "ft",       Inch,                   12                              )
    /// 1 yard is equal to 3 feet, or 36 inches, and standardised as exactly 0.9144 meters.
    let Yard                = U("yard",                 "yd",       Foot,                   3                               )
    /// 1 chain (UK) is equal to 22 yards. For US customary unit see Us.Survey.Chain.
    let Chain               = U("chain",                "ch",       Yard,                   22                              )
    /// 1 furlong (UK) is equal 220 yards. For US customary unit see Us.Survey.Furlong.
    let Furlong             = U("furlong",              "fur",      Yard,                   220                             )
    /// 1 mile is equal to 5 280 feet, or 1 760 yards, and standardised as exactly 1,609.344 meters.
    let Mile                = U("mile",                 "ml",       Yard,                   1_760                           )
    /// 1 thou (or mil) is equal to 1/1000 of an inch.
    let Thou                = U("thou",                 "th",       Inch,                   1R / 1_000                      )
    /// 1 mil (or thou) is equal to 1/1000 of an inch.
    let Mil                 = U("mil",                  "mil",      Inch,                   1R / 1_000                      )

    (*
        Units of area
    *)

    /// The area of a square whose sides measure exactly one inch.
    let SquareInch          = U("square inch",          "in²",      Inch.Pow(2)                                             )
    /// The area of a square whose sides measure exactly one foot.
    let SquareFoot          = U("square foot",          "ft²",      Foot.Pow(2)                                             )
    /// The area of a square whose sides measure exactly one yard.
    let SquareYard          = U("square yard",          "yd²",      Yard.Pow(2)                                             )
    /// The area of a square whose sides measure exactly one mile.
    let SquareMile          = U("square mile",          "mi²",      Mile.Pow(2)                                             )
    
    /// 1 perch (UK) is equal to the area of 1 rod by 1 rod.
    let Perch               = U("perch",                "perch",    Furlong.Pow(2),            1R / 16                      )
    /// 1 rood (UK) is equal to the area of 1 furlong by 1 rod.
    let Rood                = U("rood",                 "rood",     Furlong.Pow(2),            1R / 4                       )
    /// 1 acre (UK) is equal to 4 840 sq yd. For US customary unit see Us.Survey.Acre.
    let Acre                = U("acre",                 "ac",       Furlong * Chain                                         )

    (*
        Volume of dry goods
    *)

    /// The volume of a cube whose sides measure exactly one inch.
    let CubicInch           = U("cubic inch",           "in³",      Inch.Pow(3)                                             )
    /// The volume of a cube whose sides measure exactly one foot.
    let CubicFoot           = U("cubic foot",           "ft³",      Foot.Pow(3)                                             )
    /// The volume of a cube whose sides measure exactly one yard.
    let CubicYard           = U("cubic yard",           "yd³",      Yard.Pow(3)                                             )
    /// The volume of a cube whose sides measure exactly one mile.
    let CubicMile           = U("cubic mile",           "mi³",      Mile.Pow(3)                                             )
    
    (*
        Units of weight
    *)

    (* Avoirdupois weights (general use) *)

    /// One pound (avoirdupois) is equal to 16 ounces (avoirdupois), and standardised as exactly 0.45359237 kilograms.
    let Pound               = U("pound (avoirdupois)",  "lb",       Kilogram,               45_359_237R / 100_000_000       )
    /// One grain (avoirdupois) is equal to 1/7000 of an pound (avoirdupois).
    let Grain               = U("grain (avoirdupois)",  "gr",       Pound,                  1R / 7_000                      )
    /// One dram (avoirdupois) is equal to 27 11/32 grains (avoirdupois), or 1/16 of an ounce (avoirdupois).
    let Dram                = U("dram (avoirdupois)",   "dr",       Grain,                  27 + 11R / 32                   )
    /// One ounce (avoirdupois) is equal to 1/16 of a pound (avoirdupois).
    let Ounce               = U("ounce (avoirdupois)",  "oz",       Pound,                  1R / 16                         )
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
