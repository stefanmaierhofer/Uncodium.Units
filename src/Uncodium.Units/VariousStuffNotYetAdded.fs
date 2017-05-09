namespace Uncodium.Units

module internal VariousStuffNotYetAdded =
    
    open SI
         
    // Lengths
    let Point               = U("point",                    "p",        Meter,      352_777_778 * Rational.Pow(10, -12)      )
    let Pica                = U("pica",                     "P/",       Meter,      4233333 * Rational.Pow(10, -9)           )
                                                                                                  
    let ImperialGallon      = U("imperial gallon",          "gal",      Liter,      454_609 * Rational.Pow(10, -5)           )                                                                                                                                                         
        