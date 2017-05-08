namespace Uncodium.Units

open System
open System.Numerics
  
module Math =

    open Fun

    /// The ratio of a circle's circumference to its diameter.
    let Pi                      = Constant("Pi", "π", Fraction.Pi)

    /// The base of the natural logarithm.
    let e                       = Constant("e", "e", Fraction.e)
    
    
   