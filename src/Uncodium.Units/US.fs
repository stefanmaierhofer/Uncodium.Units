namespace Uncodium.Units

open System
open System.Numerics
  
module US =

    open Fun
    open SI

    module Survey =
    
        /// 1 foot (US survey) is equal to 12 inches (US survey).
        let Foot        = U("foot (US survey)",             "ft",       Meter,              Rational(1_200, 3_937)              )
        /// 1 link (US survey) is equal to 1/100 of chain (US survey).
        let Link        = U("link (US survey)",             "li",       Foot,               Rational(66, 100)                   )
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
        let SquareRod   = U("square rod (US survey)",       "rd²",      Rod.Pow(2)                                              )
        /// 1 acre (US survey) is the area of 1 chain (US survey) by 1 furlong (66 by 660 US survey feet), which is exactly equal to 1⁄640 of a square statute mile, or 43 560 square feet (US survey).
        let Acre        = U("acre (US survey)",             "ac",       Furlong * Chain                                         )
        /// The area of a square whose sides measure exactly one US survey (or statute) mile. 
        let SquareMile  = U("square rod (US survey)",       "mi²",      StatuteMile.Pow(2)                                      )
        /// 1 township (US survey) is equal to 36 square miles (US survey). 
        let Township    = U("township (US survey)",         "?",        SquareMile,         36                                  )

    module DryVolume =

        open International

        /// 1 dry pint is equal to exactly 33.6003125 cubic inches.
        let DryPint             = U("pint (dry)",           "pt",       CubicInch,          Rational(336_003_125, 10_000_000)   )

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
        let Minim               = U("minim",                "min",      Microliter,         61_611_519_921_875I * Rational.Pow(10, -12))

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
        let Barrel              = U("barrel (liquid)",      "bbl",      UsGallon,           Rational(315, 10)                   )

        /// An oil barrel is equal to 1 1/3 liquid barrels, or 42 U.S. gallons, or 2/3 hogshead.
        let OilBarrel           = U("oil barrel",           "bbl",      UsGallon,           42                                  )

        /// A hogshead is equal to 1.5 oil barrels, or 63 U.S. gallons.
        let Hogshead            = U("hogshead",             "bbl",      UsGallon,           63                                  )
