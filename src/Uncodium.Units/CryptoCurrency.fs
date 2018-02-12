namespace Uncodium.Units

open System
open System.Numerics
  
module CryptoCurrency =
    open SI
    
    /// http://ethdocs.org/en/latest/ether.html
    module Ethereum =
        /// Smallest denomination in Ethereum blockchain.
        let Wei         = Unit("wei",           "wei"                   )
    
        /// Denomination in Ethereum blockchain (1e18 Wei)
        let Ether       = Unit("ether",         "ether",    Exa * Wei   )

        /// Denomination in Ethereum blockchain (1e3 Wei)
        let Kwei        = Kilo * Wei
        /// Denomination in Ethereum blockchain (1e3 Wei)
        let Babbage     = Kwei

        /// Denomination in Ethereum blockchain (1e6 Wei)
        let Mwei        = Mega * Wei
        /// Denomination in Ethereum blockchain (1e6 Wei)
        let Lovelace    = Mwei

        /// Denomination in Ethereum blockchain (1e9 Wei)
        let Gwei        = Giga * Wei
        /// Denomination in Ethereum blockchain (1e9 Wei)
        let Shannon     = Gwei

        /// Denomination in Ethereum blockchain (1e12 Wei)
        let MicroEther  = Micro * Ether
        /// Denomination in Ethereum blockchain (1e12 Wei)
        let Szabo       = MicroEther

        /// Denomination in Ethereum blockchain (1e15 Wei)
        let MilliEther  = Milli * Ether
        /// Denomination in Ethereum blockchain (1e15 Wei)
        let Finney      = MilliEther
    