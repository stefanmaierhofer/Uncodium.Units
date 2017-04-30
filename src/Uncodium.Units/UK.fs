namespace Uncodium.Units

open System
open System.Numerics
  
module UK =

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
