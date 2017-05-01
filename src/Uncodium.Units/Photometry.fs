namespace Uncodium.Units

open System
open System.Numerics
  
module Photometry =
    
    open SI
    open Physics
    open Time

    /// Luminous flux Φᵥ or luminous power [lm]. Luminous energy per unit time.
    let LuminousFlux            = UnitOfMeasure("lumen",                    "lm",       Candela * Steradian         )       
    /// Luminous flux Φᵥ or luminous power [lm]. Luminous energy per unit time.
    let LuminousPower           = LuminousFlux
    /// Luminous flux Φᵥ or luminous power [lm]. Luminous energy per unit time.
    let Lumen                   = LuminousFlux
    /// Luminous flux Φᵥ or luminous power [lm]. Luminous energy per unit time.
    let Φᵥ                      = LuminousFlux

    /// Luminous energy Qᵥ [lm s]. Units are sometimes called talbots.
    let LuminousEnergy          = UnitOfMeasure("lumen second",             "lm s",     Lumen * Second              )     
    /// Luminous energy Qᵥ [lm s]. Units are sometimes called talbots.
    let LumenSecond             = LuminousEnergy
    /// Luminous energy Qᵥ [lm s]. Units are sometimes called talbots.
    let Qᵥ                      = LuminousEnergy

    /// Luminous intensity Iᵥ or candela (SI base unit) [cd]. Luminous flux per unit solid angle.
    let LuminousIntensity       = UnitOfMeasure("candela",                  "cd",       Candela                     )
    /// Luminous intensity Iᵥ or candela (SI base unit) [cd]. Luminous flux per unit solid angle.
    let Iᵥ                      = LuminousIntensity

    /// Luminous flux per unit solid angle per unit projected source area [cd/m²]. Units are sometimes called nits. 
    let Luminance               = UnitOfMeasure("luminance",                "cd/m²",    Candela / SquareMeter       )     
    /// Luminous flux per unit solid angle per unit projected source area [cd/m²]. Units are sometimes called nits. 
    let Lᵥ                      = Luminance

    /// Luminous flux incident on a surface [lx].
    let Illuminance             = UnitOfMeasure("illuminance",              "lx",       Lumen / SquareMeter         )     
    /// Luminous flux incident on a surface [lx].
    let Lux                     = Illuminance
    /// Luminous flux incident on a surface [lx].
    let Eᵥ                      = Illuminance

    /// Luminous exitance, or luminous emittance [lx].
    let LuminousExitance        = Illuminance
    /// Luminous exitance, or luminous emittance [lx].
    let Mᵥ                      = Illuminance

    /// Luminous exposure Hᵥ, or lux second [lx s].
    let LuminousExposure        = UnitOfMeasure("lux second",               "lx s",     Lumen / SquareMeter         )    
    /// Luminous exposure Hᵥ, or lux second [lx s].
    let LuxSecond               = LuminousExposure
    /// Luminous exposure Hᵥ, or lux second [lx s].
    let Hᵥ                      = LuminousExposure

    /// Luminous energy density ωᵥ, or lumen second per cubic metre [lm s/m³].
    let LuminousEnergyDensity   = UnitOfMeasure("luminous energy density",  "lm s/m³",  Lumen * Second / CubicMeter )    
    /// Luminous energy density ωᵥ, or lumen second per cubic metre [lm s/m³].
    let ωᵥ                      = LuminousEnergyDensity

    /// Luminous efficacy η, or lumen per watt [lm/W].
    let LuminousEfficacy        = UnitOfMeasure("luminous energy density",  "lm/W",     Lumen / Watt                )    
    /// Luminous efficacy η, or lumen per watt [lm/W].
    let η                       = LuminousEfficacy
