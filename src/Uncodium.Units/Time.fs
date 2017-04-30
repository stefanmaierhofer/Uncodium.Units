namespace Uncodium.Units

open System
open System.Numerics
  
module Time =

    open Prefix
    open SI

    /// 1/1000 of a second.
    let Millisecond = Milli * Second
    /// 1/1000 of a millisecond.
    let Microsecond = Micro * Second
    /// 1/1000 of a microsecond.
    let Nanosecond  = Nano  * Second
    /// 1/1000 of a nanosecond.
    let Picosecond  = Pico  * Second
    /// 1/1000 of a picosecond.
    let Femtosecond = Femto * Second
    /// 1/1000 of a femtosecond.
    let Attosecond  = Atto  * Second

    /// 60 seconds.
    let Minute      = U("minute", "min", Second, 60)

    /// 60 minutes, or 3 600 seconds.
    let Hour        = U("hour", "h", Minute, 60)

    /// 24 hours, or 1 440 minutes, or 86 400 seconds.
    let Day         = U("day", "d", Hour, 24)