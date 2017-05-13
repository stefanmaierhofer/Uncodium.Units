namespace Uncodium.Units

open System
open System.Numerics
  
module UK =

    open SI

    module LiquidVolume =

        /// A gallon is defined as exactly 4.54609 liters.
        let Gallon          = U("gallon",               "gal",      SI.Liter,               454_609R / 100_000  )
        /// A bushel is equal to 8 gallons.
        let Bushel          = U("bushel",               "bushel",   Gallon,                 8                   )
        /// A peck is equal to 2 gallons.
        let Peck            = U("peck",                 "peck",     Gallon,                 2                   )
        /// A quart is equal to 1/4 gallon.
        let Quart           = U("quart",                "qt",       Gallon,                 1R / 4              )
        /// A pint is equal to 1/2 quart.
        let Pint            = U("pint",                 "pt",       Quart,                  1R / 2              )
        /// A gill is equal to 1/4 pint.
        let Gill            = U("gill",                 "gill",     Pint,                   1R / 4              )
        /// A fluid ounce is equal to 1/5 gill.
        let FluidOunce      = U("gill",                 "fl oz",    Gill,                   1R / 5              )
        /// A fluid drachm is equal to 1/8 fluid ounce.
        let FluidDrachm     = U("fluid drachm",         "fl dr",    FluidOunce,             1R / 8              )
        /// A minim is equal to 1/60 fluid drachm.
        let Minim           = U("minim",                "minim",    FluidDrachm,            1R / 60             )
