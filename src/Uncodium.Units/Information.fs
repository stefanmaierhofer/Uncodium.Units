namespace Uncodium.Units

open System
open System.Numerics
  
module Information =
    
    open Prefix
    open SI

    /// The basic unit of information in computing and digital communications.
    /// A bit can have only one of two values, most commonly represented as either a 0 or 1.
    let Bit  = U("bit", "bit")

    /// 8 bits.
    let Byte = U("byte", "B", Bit, 8)
    
    /// 1 KiB = 1024 bytes.
    let Kibibyte  = Kibi * Byte
    /// 1 MiB = 1024 KiB.
    let Mebibyte  = Mebi * Byte
    /// 1 GiB = 1024 MiB.
    let Gibibyte  = Gibi * Byte
    /// 1 TiB = 1024 GiB.
    let Tebibyte  = Tebi * Byte
    /// 1 PiB = 1024 TiB.
    let Pebibyte  = Pebi * Byte
    /// 1 EiB = 1024 PiB.
    let Exbibyte  = Exbi * Byte
    /// 1 ZiB = 1024 EiB.
    let Zebibyte  = Zebi * Byte
    /// 1 YiB = 1024 ZiB.
    let Yobibyte  = Yobi * Byte
    
    /// 1 kB = 1000 bytes.
    let Kilobyte  = Kilo  * Byte
    /// 1 MB = 1000 kB.
    let Megabyte  = Mega  * Byte
    /// 1 GB = 1000 MB.
    let Gigabyte  = Giga  * Byte
    /// T MB = 1000 GB.
    let Terabyte  = Tera  * Byte
    /// 1 PB = 1000 TB.
    let Petabyte  = Peta  * Byte
    /// 1 EB = 1000 PB.
    let Exabyte   = Exa   * Byte
    /// 1 ZB = 1000 EB.
    let Zettabyte = Zetta * Byte
    /// 1 YB = 1000 ZB.
    let Yottabyte = Yotta * Byte

    /// 1 KiBit/s = 1024 bit/s.
    let KibibitPerSecond = Kibi * Bit / Second
    /// 1 MiBit/s = 1024 KiBit/s.
    let MebibitPerSecond = Mebi * Bit / Second
    /// 1 GiBit/s = 1024 MiBit/s.
    let GibibitPerSecond = Gibi * Bit / Second

    /// 1 kB/s = 1000 byte/s.
    let KilobytePerSecond = Kilobyte / Second
    /// 1 MB/s = 1000 kB/s.
    let MegabytePerSecond = Megabyte / Second
    /// 1 GB/s = 1000 MB/s.
    let GigabytePerSecond = Gigabyte / Second
    /// 1 TB/s = 1000 GB/s.
    let TerabytePerSecond = Terabyte / Second

    /// 1 KiB/s = 1024 byte/s.
    let KibibytePerSecond = Kibibyte / Second
    /// 1 MiB/s = 1024 KiB/s.
    let MebibytePerSecond = Mebibyte / Second
    /// 1 GiB/s = 1024 MiB/s.
    let GibibytePerSecond = Gibibyte / Second
    /// 1 TiB/s = 1024 GiB/s.
    let TebibytePerSecond = Tebibyte / Second
