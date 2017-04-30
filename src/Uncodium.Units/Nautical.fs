namespace Uncodium.Units

open System
open System.Numerics
  
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
        let Fathom          = U("fathom (US customary)",    "ftm",  US.Survey.Foot,           6         )
        
        /// 1 cable (US customary) is equal to 120 fathoms.
        let Cable           = U("cable (US customary)",     "cb",   Fathom,                 120         )
