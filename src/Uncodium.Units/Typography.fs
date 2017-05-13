namespace Uncodium.Units

open System
open System.Numerics
  
module Typography =

    /// 1 Point (typography) is equal to exactly 0.013 837 inches.
    let Point               = U("Point",                    "Point",    International.Inch,     13_837R / 1_000_000     )
 