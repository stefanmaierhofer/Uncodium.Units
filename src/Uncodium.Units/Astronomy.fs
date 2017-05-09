namespace Uncodium.Units

open System
open System.Numerics
  
module Astronomy =
    
    open SI
    open Physics

    /// A Julian year (symbol: a) is a unit of measurement of time defined as exactly 365.25 days of 86400 SI seconds each.
    let JulianYear              = Constant("Julian year",               "a",    Rational(36_525, 100), Day              )

    /// ly
    let Lightyear               = Constant("lightyear",                 "ly",   SpeedOfLight * JulianYear               )

    /// ls
    let Lightsecond             = Constant("lightsecond",               "ls",   SpeedOfLight * Second                   )

    /// au
    let AstronomicalUnit        = Constant("astronomical unit",         "au",   149_597_870_700I, Meter                 )
