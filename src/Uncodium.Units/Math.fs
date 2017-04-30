namespace Uncodium.Units

open System
open System.Numerics
  
module Math =

    open Fun

    /// The ratio of a circle's circumference to its diameter.
    let Pi                      = Constant("Pi", "π", Fraction.Pi)

    /// The base of the natural logarithm.
    let e                       = Constant("e", "e", Fraction.e)

    /// Angle (SI derived unit).
    let Radian                  = SI.Radian

    /// 1/180 of a radian, or 1/360 of a full circle.
    let Degree                  = U("degree",       "deg",      Radian,     Fraction.Pi / 180   )

    /// 1/60 of a degree.
    let ArcMinute               = U("arcminute",    "arcmin",   Degree,     F(1, 60)             )

    /// 1/60 of an arcminute.
    let ArcSecond               = U("arcsecond",    "arcsec",   ArcMinute,  F(1, 60)             )
   