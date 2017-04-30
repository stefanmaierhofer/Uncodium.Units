namespace Uncodium.Units

open System
open System.Numerics
 
 module Historic =

    open SI
    
    let GermanLegalMeter                = U("German legal meter",                   "m",    Meter, F(  10_000_135_965I,     10_000_000_000I  )   )

    let ClarkesLink                     = U("Clarke's link",                        "li",   Meter, F( 201_166_195_164I,  1_000_000_000_000I  )   )
    let ClarkesChain                    = U("Clarke's chain",                       "ch",   Meter, F( 201_166_195_164I,     10_000_000_000I  )   )
    let ClarkesFoot                     = U("Clarke's foot",                        "ft",   Meter, F(   3_047_972_654I,     10_000_000_000I  )   )
    let ClarkesYard                     = U("Clarke's yard",                        "yd",   Meter, F(   9_143_917_962I,     10_000_000_000I  )   )
                                                                                                                                                                      
    let BritishFoot_Sears1922           = U("British foot (Sears 1922)",            "ft",   Meter, F(      12_000_000I,         39_370_147I  )   )
    let BritishYard_Sears1922           = U("British yard (Sears 1922)",            "yd",   Meter, F(      36_000_000I,         39_370_147I  )   )
    let BritishLink_Sears1922           = U("British link (Sears 1922)",            "li",   Meter, F(       7_920_000I,         39_370_147I  )   )
    let BritishChain_Sears1922          = U("British chain (Sears 1922)",           "ch",   Meter, F(     792_000_000I,         39_370_147I  )   )
                                                                                                                                                            
    let BritishFoot_Benoit1895A         = U("British foot (Benoit 1895 A)",         "ft",   Meter, F(       9_143_992I,         30_000_000I  )   )
    let BritishYard_Benoit1895A         = U("British yard (Benoit 1895 A)",         "yd",   Meter, F(       9_143_992I,         10_000_000I  )   )
    let BritishLink_Benoit1895A         = U("British link (Benoit 1895 A)",         "li",   Meter, F(     201_167_824I,      1_000_000_000I  )   )
    let BritishChain_Benoit1895A        = U("British chain (Benoit 1895 A)",        "ch",   Meter, F(     201_167_824I,         10_000_000I  )   )
                                                                                                                                                            
    let BritishFoot_Benoit1895B         = U("British foot (Benoit 1895 B)",         "ft",   Meter, F(      12_000_000I,         39_370_113I  )   )
    let BritishYard_Benoit1895B         = U("British yard (Benoit 1895 B)",         "yd",   Meter, F(      36_000_000I,         39_370_113I  )   )
    let BritishLink_Benoit1895B         = U("British link (Benoit 1895 B)",         "li",   Meter, F(       7_920_000I,         39_370_113I  )   )
    let BritishChain_Benoit1895B        = U("British chain (Benoit 1895 B)",        "ch",   Meter, F(     792_000_000I,         39_370_113I  )   )
                                                                                                                                                            
    let BritishFoot_1865                = U("British foot (1865)",                  "ft",   Meter, F(       9_144_025I,         30_000_000I  )   )
                                                                                                                                                            
    let IndianFoot                      = U("Indian foot",                          "ft",   Meter, F(      12_000_000I,         39_370_142I  )   )
    let IndianFoot_1937                 = U("Indian foot (1937)",                   "ft",   Meter, F(      30_479_841I,        100_000_000I  )   )
    let IndianFoot_1962                 = U("Indian foot (1962)",                   "ft",   Meter, F(       3_047_996I,         10_000_000I  )   )
    let IndianFoot_1975                 = U("Indian foot (1975)",                   "ft",   Meter, F(       3_047_995I,         10_000_000I  )   )
    
    let IndianYard                      = U("Indian yard",                          "yd",   Meter, F(      36_000_000I,         39_370_142I  )   )
    let IndianYard_1937                 = U("Indian yard (1937)",                   "yd",   Meter, F(      91_439_523I,        100_000_000I  )   )
    let IndianYard_1962                 = U("Indian yard (1962)",                   "yd",   Meter, F(       9_143_988I,         10_000_000I  )   )
    let IndianYard_1975                 = U("Indian yard (1975)",                   "yd",   Meter, F(       9_143_985I,         10_000_000I  )   )
    
    let StatuteMile                     = U("Statute mile",                         "mi",   Meter, F(       1_609_344I,              1_000I  )   )
    let GoldCoastFoot                   = U("Gold Coast foot",                      "ft",   Meter, F(       6_378_300I,         20_926_201I  )   )
    let BritishFoot_1936                = U("British foot (1936)",                  "ft",   Meter, F(   3_048_007_491I,     10_000_000_000I  )   )
    
    let BritishFoot_Sears1922Truncated  = U("British foot (Sears 1922 truncated)",  "ft",   Meter, F(         914_398I,          3_000_000I  )   )
    let BritishYard_Sears1922Truncated  = U("British yard (Sears 1922 truncated)",  "yd",   Meter, F(          14_398I,            100_000I  )   )
    let BritishLink_Sears1922Truncated  = U("British link (Sears 1922 truncated)",  "li",   Meter, F(      20_116_756I,        100_000_000I  )   )
    let BritishChain_Sears1922Truncated = U("British chain (Sears 1922 truncated)", "ch",   Meter, F(      20_116_756I,          1_000_000I  )   )
                                                                                                                                                                
    let BinWidth330UsSurveyFeet         = U("Bin width 330 U.S. survey feet",        "?",   Meter, F(         396_000I,              3_937I  )   )
    let BinWidth165UsSurveyFeet         = U("Bin width 165 U.S. survey feet",        "?",   Meter, F(         198_000I,              3_937I  )   )
    let BinWidth82_5UsSurveyFeet        = U("Bin width 82.5 U.S. survey feet",       "?",   Meter, F(          99_000I,              3_937I  )   )
    
    let BinWidth37_5Metres              = U("Bin width 37.5 metres",          "Bin37.5m",   Meter, F(             375I,                 10I  )   )
    let BinWidth25Metres                = U("Bin width 25 metres",              "Bin25m",   Meter, F(              25I,                  1I  )   )
    let BinWidth12_5Metres              = U("Bin width 12.5 metres",          "Bin12.5m",   Meter, F(             125I,                 10I  )   )
    let BinWidth3_125Metres             = U("Bin width 3.125 metres",        "Bin3.125m",   Meter, F(           3_125I,              1_000I  )   )
 