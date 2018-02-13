namespace Uncodium.Units

open System
open System.Numerics
  
module CryptoCurrency =
    open SI
    
    /// https://en.bitcoin.it/wiki/Units
    module Bitcoin =
        /// Bitcoin base unit.
        let Bitcoin         = Unit("bitcoin",           "BTC"                               )
        /// Bitcoin base unit.
        let BTC             = Bitcoin

        /// 1/1000 of a bitcoin.
        let Millibitcoin    = Unit("millibitcoin",      "mBTC",     Milli * Bitcoin         )
        /// 1/1000 of a bitcoin.
        let mBTC            = Millibitcoin
        /// 1/1000 of a bitcoin.
        let millie          = Millibitcoin

        /// 1/1000 of a millibitcoin.
        let Microbitcoin    = Unit("microbitcoin",      "μBTC",     Micro * Bitcoin         )
        /// 1/1000 of a millibitcoin.
        let μBTC            = Microbitcoin
        /// 1/1000 of a millibitcoin.
        let bit             = Microbitcoin
        
        /// 1/100 000 000 bitcoin.
        let Satoshi         = Unit("satoshi",           "sat",      Bitcoin,    1e-8        )
        /// 1/1000 of a millibitcoin.
        let sat             = Satoshi

        /// 1/100 000 000 bitcoin.
        let Millisatoshi    = Unit("millisatoshi",      "msat",     Milli * Satoshi         )
        /// 1/1000 of a millibitcoin.
        let msat            = Millisatoshi



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
    