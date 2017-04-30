namespace Uncodium.Units

open System
open System.Numerics
 
module internal VariousStuffNotYetAdded =
    
    open Fun
    open Prefix
    open SI
    open Time
         
    // Lengths
    let Point               = U("point",                    "p",        Meter,              352_777_778 * F.Pow(10, -12)      )
    let Pica                = U("pica",                     "P/",       Meter,              4233333 * F.Pow(10, -9)           )
                                                                                                  
    let ImperialGallon      = U("imperial gallon",          "gal",      Liter,              454_609 * F.Pow(10, -5)           )                                                                                                                                                         
        