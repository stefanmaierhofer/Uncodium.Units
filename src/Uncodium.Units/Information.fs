namespace Uncodium.Units

open System
open System.Numerics
  
module Information =
    
    open SI
    
    (*
        Base-2 multiples.
     *) 

    let Kibi  = prefix "kibi"   "Ki"   1024   1
    let Mebi  = prefix "mebi"   "Mi"   1024   2
    let Gibi  = prefix "gibi"   "Gi"   1024   3
    let Tebi  = prefix "tebi"   "Ti"   1024   4
    let Pebi  = prefix "pebi"   "Pi"   1024   5
    let Exbi  = prefix "exbi"   "Ei"   1024   6
    let Zebi  = prefix "zebi"   "Zi"   1024   7
    let Yobi  = prefix "yobi"   "Yi"   1024   8


    (*
        Units.
     *)

    /// The basic unit of information in computing and digital communications.
    /// A bit can have only one of two values, most commonly represented as either a 0 or 1.
    let Bit  = U("bit", "bit")

    /// 8 bits.
    let Byte = U("byte", "B", Bit, 8)
    

    (*
        Multiples (base 2).
     *)
    
    /// 1 Kibit = 1024 bits.
    let Kibibit     = Kibi * Bit
    /// 1 Kibit = 1024 bits.
    let Kibit       = Kibi * Bit

    /// 1 Mibit = 1024 bits.
    let Mebibit     = Mebi * Bit
    /// 1 Mibit = 1024 bits.
    let Mibit       = Mebi * Bit

    /// 1 Gibit = 1024 bits.
    let Gibibit     = Gibi * Bit
    /// 1 Gibit = 1024 bits.
    let Gibit       = Gibi * Bit

    /// 1 Tibit = 1024 bits.
    let Tebibit     = Tebi * Bit
    /// 1 Tibit = 1024 bits.
    let Tibit       = Tebi * Bit


    /// 1 KiB = 1024 bytes.
    let Kibibyte    = Kibi * Byte
    /// 1 KiB = 1024 bytes.
    let KiB         = Kibi * Byte

    /// 1 MiB = 1024 KiB.
    let Mebibyte    = Mebi * Byte
    /// 1 MiB = 1024 KiB.
    let MiB         = Mebi * Byte

    /// 1 GiB = 1024 MiB.
    let Gibibyte    = Gibi * Byte
    /// 1 GiB = 1024 MiB.
    let GiB         = Gibi * Byte

    /// 1 TiB = 1024 GiB.
    let Tebibyte    = Tebi * Byte
    /// 1 TiB = 1024 GiB.
    let TiB         = Tebi * Byte

    /// 1 PiB = 1024 TiB.
    let Pebibyte    = Pebi * Byte
    /// 1 PiB = 1024 TiB.
    let PiB         = Pebi * Byte

    /// 1 EiB = 1024 PiB.
    let Exbibyte    = Exbi * Byte
    /// 1 EiB = 1024 PiB.
    let EiB         = Exbi * Byte

    /// 1 ZiB = 1024 EiB.
    let Zebibyte    = Zebi * Byte
    /// 1 ZiB = 1024 EiB.
    let ZiB         = Zebi * Byte

    /// 1 YiB = 1024 ZiB.
    let Yobibyte    = Yobi * Byte
    /// 1 YiB = 1024 ZiB.
    let YiB         = Yobi * Byte


    (*
        Multiples (base 10).
     *)
    
    /// 1 kbit = 1000 bits.
    let Kilobit     = Kilo  * Bit
    /// 1 kbit = 1000 bits.
    let kbit        = Kilo  * Bit

    /// 1 Mbit = 1000 kbit.
    let Megabit     = Mega  * Bit
    /// 1 Mbit = 1000 kbit.
    let Mbit        = Mega  * Bit

    /// 1 Gbit = 1000 Mbit.
    let Gigabit     = Giga  * Bit
    /// 1 Gbit = 1000 Mbit.
    let Gbit        = Giga  * Bit

    /// 1 Tbit = 1000 Gbit.
    let Terabit     = Tera  * Bit
    /// 1 Tbit = 1000 Gbit.
    let Tbit        = Tera  * Bit


    /// 1 kB = 1000 bytes.
    let Kilobyte    = Kilo  * Byte
    /// 1 kB = 1000 bytes.
    let kB          = Kilo  * Byte

    /// 1 MB = 1000 kB.
    let Megabyte    = Mega  * Byte
    /// 1 MB = 1000 kB.
    let MB          = Mega  * Byte

    /// 1 GB = 1000 MB.
    let Gigabyte    = Giga  * Byte
    /// 1 GB = 1000 MB.
    let GB          = Giga  * Byte

    /// 1 TB = 1000 GB.
    let Terabyte    = Tera  * Byte
    /// 1 TB = 1000 GB.
    let TB          = Tera  * Byte

    /// 1 PB = 1000 TB.
    let Petabyte    = Peta  * Byte
    /// 1 PB = 1000 TB.
    let PB          = Peta  * Byte

    /// 1 EB = 1000 PB.
    let Exabyte     = Exa   * Byte
    /// 1 EB = 1000 PB.
    let EB          = Exa   * Byte

    /// 1 ZB = 1000 EB.
    let Zettabyte   = Zetta * Byte
    /// 1 ZB = 1000 EB.
    let ZB          = Zetta * Byte

    /// 1 YB = 1000 ZB.
    let Yottabyte   = Yotta * Byte
    /// 1 YB = 1000 ZB.
    let YB          = Yotta * Byte


    (*
        Rates (base 2).
     *)
    
    /// 1 Kibit/s = 1024 bit/s.
    let KibibitPerSecond    = Kibi * Bit / Second
    /// 1 Mibit/s = 1024 Kibit/s.
    let MebibitPerSecond    = Mebi * Bit / Second
    /// 1 Gibit/s = 1024 Mibit/s.
    let GibibitPerSecond    = Gibi * Bit / Second
    /// 1 Tibit/s = 1024 Gibit/s.
    let TebibitPerSecond    = Tebi * Bit / Second

    /// 1 KiB/s = 1024 byte/s.
    let KibibytePerSecond   = Kibibyte / Second
    /// 1 MiB/s = 1024 KiB/s.
    let MebibytePerSecond   = Mebibyte / Second
    /// 1 GiB/s = 1024 MiB/s.
    let GibibytePerSecond   = Gibibyte / Second
    /// 1 TiB/s = 1024 GiB/s.
    let TebibytePerSecond   = Tebibyte / Second

    (*
        Rates (base 10).
     *)

    /// 1 kbit/s = 1000 bit/s.
    let KilobitPerSecond    = Kilo * Bit / Second
    /// 1 Mbit/s = 1000 kbit/s.
    let MegabitPerSecond    = Mega * Bit / Second
    /// 1 Gbit/s = 1000 Mbit/s.
    let GigabitPerSecond    = Giga * Bit / Second
    /// 1 Tbit/s = 1000 Gbit/s.
    let TerabitPerSecond    = Giga * Bit / Second

    /// 1 kB/s = 1000 byte/s.
    let KilobytePerSecond   = Kilobyte / Second
    /// 1 MB/s = 1000 kB/s.
    let MegabytePerSecond   = Megabyte / Second
    /// 1 GB/s = 1000 MB/s.
    let GigabytePerSecond   = Gigabyte / Second
    /// 1 TB/s = 1000 GB/s.
    let TerabytePerSecond   = Terabyte / Second

    
