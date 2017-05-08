namespace Uncodium.Units

/// http://www.bipm.org/utils/common/pdf/si_brochure_8_en.pdf
module SI =

    open Fun
	
    let internal prefix (name : string) (symbol : string) (a : int) (b : int)
        = UnitPrefix(name, symbol, F.Pow(a, b))


    (*
        Decimal multiples and submultiples of SI units.
     *)
    let Deca  = prefix "deca"   "da"     10   1
    let Hecto = prefix "hecto"  "h"      10   2
    let Kilo  = prefix "kilo"   "k"      10   3
    let Mega  = prefix "mega"   "M"    1000   2
    let Giga  = prefix "giga"   "G"    1000   3
    let Tera  = prefix "tera"   "T"    1000   4
    let Peta  = prefix "peta"   "P"    1000   5
    let Exa   = prefix "exa"    "E"    1000   6
    let Zetta = prefix "zetta"  "Z"    1000   7
    let Yotta = prefix "yotta"  "Y"    1000   8

	
    let Deci  = prefix "deci"   "d"      10  -1
    let Centi = prefix "centi"  "c"      10  -2
    let Milli = prefix "milli"  "m"    1000  -1
    let Micro = prefix "micro"  "µ"    1000  -2
    let Nano  = prefix "nano"   "n"    1000  -3
    let Pico  = prefix "pico"   "p"    1000  -4
    let Femto = prefix "femto"  "f"    1000  -5
    let Atto  = prefix "atto"   "a"    1000  -6
    let Zepto = prefix "zepto"  "z"    1000  -7
    let Yocto = prefix "yocto"  "y"    1000  -8
    
    
    (*
        SI base units.
     *)

    /// Length (SI base unit).
    /// The metre is the length of the path travelled by light in
    /// vacuum during a time interval of 1/299 792 458 of a second.
    let Meter       = U("meter", "m")

    /// Mass (SI base unit).
    /// The kilogram is the unit of mass; it is equal to the mass
    /// of the international prototype of the kilogram.
    let Kilogram    = U("kilogram", "kg")

    /// Time (SI base unit).
    /// The second is the duration of 9 192 631 770 periods of the
    /// radiation corresponding to the transition between the two
    /// hyperfine levels of the ground state of the caesium 133 atom.
    let Second      = U("second", "s")

    /// Electric current (SI base unit).
    /// The ampere is that constant current which, if maintained in
    /// two straight parallel conductors of infinite length, of negligible
    /// circular cross-section, and placed 1 m apart in vacuum, would
    /// produce between these conductors a force equal to 2 x 10–7
    /// newton per metre of length.
    let Ampere      = U("ampere", "A")

    /// Thermodynamic temperature (SI base unit).
    /// The kelvin, unit of thermodynamic temperature, is the
    /// fraction 1/273.16 of the thermodynamic temperature of the
    /// triple point of water.
    let Kelvin      = U("kelvin", "K")

    /// Amount of substance (SI base unit).
    /// The mole is the amount of substance of a system which contains
    /// as many elementary entities as there are atoms in 0.012 kilogram
    /// of carbon 12.
    /// When the mole is used, the elementary entities must be specified
    /// and may be atoms, molecules, ions, electrons, other particles, or
    /// specified groups of such particles.
    let Mole        = U("mole", "mol")

    /// Luminous intensity (SI base unit).
    /// The candela is the luminous intensity, in a given direction, of a
    /// source that emits monochromatic radiation of frequency 540 x 1012
    /// hertz and that has a radiant intensity in that direction of 1/683
    /// watt per steradian.
    let Candela     = U("candela", "cd")
    

    (*
         Examples of coherent derived units in the SI expressed in terms of base units.
     *)

    /// Area, square meter (SI derived unit).
    let Area                    = U("area",                     "A",        Meter.Pow(2)                        )
    /// Volume, cubic meter (SI derived unit).
    let Volume                  = U("volume",                   "V",        Meter.Pow(3)                        )
    /// Speed, velocity (SI derived unit).
    let Speed                   = U("speed",                    "v",        Meter / Second                      )
    /// Speed, velocity (SI derived unit).
    let Velocity                = U("velocity",                 "v",        Meter / Second                      )
    /// Acceleration (SI derived unit).
    let Acceleration            = U("acceleration",             "a",        Meter / Second.Pow(2)               )
    /// Wavenumber (SI derived unit).
    let Wavenumber              = U("wavenumber",               "σ",        1 / Meter                           )
    /// Density, mass density (SI derived unit).        
    let Density                 = U("density",                  "ρ",        Kilogram / Meter.Pow(3)             )
    /// Surface density (SI derived unit).
    let SurfaceDensity          = U("surface density",          "ρ_A",      Kilogram / Meter.Pow(2)             )
    /// Specific volume         (SI derived unit).
    let SpecificVolume          = U("specific volume",          "v",        Meter.Pow(3) / Kilogram             )
    /// Current density         (SI derived unit).
    let CurrentDensity          = U("current density",          "j",        Ampere / Meter.Pow(2)               )
    /// Magnetic field strength (SI derived unit).
    let MagneticFieldStrength   = U("magnetic field strength",  "j",        Ampere / Meter                      )
    /// Amount concentration, substance concentration, concentration (SI derived unit).
    let AmountConcentration     = U("amount concentration",     "c",        Mole / Meter.Pow(3)                 )
    /// Amount concentration, substance concentration, concentration (SI derived unit).
    let SubstanceConcentration  = U("substance concentration",  "c",        Mole / Meter.Pow(3)                 )
    /// Amount concentration, substance concentration, concentration (SI derived unit).
    let Concentration           = U("concentration",            "c",        Mole / Meter.Pow(3)                 )
    /// Mass concentration (SI derived unit).
    let MassConcentration       = U("mass concentration",       "γ",        Kilogram / Meter.Pow(3)             )
    /// Refractive index (SI derived unit).
    let RefractiveIndex         = U("refractive index",         "n"                                             )
    /// Relative permeability (SI derived unit).
    let RelativePermeability    = U("relative permeability",    "µᵣ"                                            )


    (*
        Coherent derived units in the SI with special names and symbols.    
     *)

    /// Plane angle (SI derived unit).
    let Radian                  = U("radian",                   "rad",      Meter / Meter                       )
    /// Solid angle (SI derived unit).
    let Steradian               = U("steradian",                "sr",       Meter.Pow(2) / Meter.Pow(2)         )
    /// Frequency (SI derived unit).
    let Hertz                   = U("hertz",                    "Hz",       1 / Second                          )
    /// Force, weight (SI derived unit).
    let Newton                  = U("newton",                   "N",        Kilogram * Meter / Second.Pow(2)    )
    /// Pressure, stress (SI derived unit).
    let Pascal                  = U("pascal",                   "Pa",       Newton / Meter.Pow(2)               )
    /// Energy, work, amount of heat (SI derived unit).
    let Joule                   = U("joule",                    "J",        Newton * Meter                      )
    /// Power, radiant flux (SI derived unit).
    let Watt                    = U("watt",                     "W",        Joule / Second                      )
    /// Electric charge, amount of electricity (SI derived unit).
    let Coulomb                 = U("coulomb",                  "C",        Ampere * Second                     )
    /// Voltage (electric potential difference), electromotive force (SI derived unit).
    let Volt                    = U("volt",                     "V",        Watt / Ampere                       )
    /// Capacitance (SI derived unit).
    let Farad                   = U("farad",                    "F",        Coulomb / Volt                      )
    /// Electric resistance, impedance, reactance (SI derived unit).
    let Ohm                     = U("ohm",                      "Ω",        Volt / Ampere                       )
    /// Electrical conductance (SI derived unit).
    let Siemens                 = U("siemens",                  "S",        Ampere / Volt                       )
    /// Magnetic flux (SI derived unit).
    let Weber                   = U("weber",                    "Wb",       Volt * Second                       )
    /// Magnetic flux density (SI derived unit).
    let Tesla                   = U("tesla",                    "T",        Weber / Meter.Pow(2)                )
    /// Inductance (SI derived unit).
    let Henry                   = U("henry",                    "H",        Weber / Ampere                      )
    /// Luminous flux (SI derived unit).
    let Lumen                   = U("lumen",                    "lm",       Candela * Steradian                 )
    /// Illuminance (SI derived unit).
    let Lux                     = U("lux",                      "lx",       Lumen / Meter.Pow(2)                )
    /// Radioactivity (decays per unit time), activity referred to a radionuclide (SI derived unit).
    let Becquerel               = U("becquerel",                "Bq",       1 / Second                          )
    /// Absorbed dose (of ionizing radiation), specific energy (imparted), kerma (SI derived unit).
    let Gray                    = U("gray",                     "Gy",       Joule / Kilogram                    )
    /// Dose equivalent, ambient dose equivalent, directional dose equivalent, personal dose equivalent (SI derived unit).
    let Sievert                 = U("sievert",                  "Sv",       Joule / Kilogram                    )
    /// Catalytic activity (SI derived unit).
    let Katal                   = U("katal",                    "kat",      Mole / Second                       )


    (*
        Examples of SI coherent derived units whose names and symbols include
        SI coherent derived units with special names and symbols.
     *)

    /// Dynamic viscosity (SI derived unit).
    let DynamicViscosity        = U("dynamic viscosity",        "Pa s",     Pascal * Second                     )
    /// Moment of force (SI derived unit).
    let MomentOfForce           = U("moment of force",          "N m",      Newton * Meter                      )
    /// surface tension (SI derived unit).
    let SurfaceTension          = U("surface tension",          "N/m",      Newton / Meter                      )
    /// Angular velocity (SI derived unit).
    let AngularVelocity         = U("angular velocity",         "rad/s",    Radian / Second                     )
    /// Angular acceleration (SI derived unit).
    let AngularAcceleration     = U("angular acceleration",     "rad/s²",   Radian / Second.Pow(2)              )
    /// Heat flux density, irradiance (SI derived unit).
    let HeatFluxDensity         = U("heat flux density",        "W/m²",     Watt / Meter.Pow(2)                 )
    /// Heat capacity, entropy (SI derived unit).
    let HeatCapacity            = U("heat capacity",            "J/K",      Joule / Kelvin                      )
    /// Heat capacity, entropy (SI derived unit).
    let Entropy                 = U("entropy",                  "J/K",      Joule / Kelvin                      )
    /// Specific heat capacity, specific entropy (SI derived unit).
    let SpecificHeatCapacity    = U("specific heat capacity",   "J/(kg K)", Joule / (Kilogram * Kelvin)         )
    /// Specific heat capacity, specific entropy (SI derived unit).
    let SpecificEntropy         = U("specific entropy",         "J/(kg K)", Joule / (Kilogram * Kelvin)         )
    /// Specific energy (SI derived unit).
    let SpecificEnergy          = U("specific energy",          "J/kg",     Joule / Kilogram                    )
    /// Thermal conductivity (SI derived unit).
    let ThermalConductivity     = U("thermal conductivity",     "W/(m K)",  Watt / (Meter * Kelvin)             )
    /// Energy density (SI derived unit).
    let EnergyDensity           = U("energy density",           "J/m³",     Joule / Meter.Pow(3)                )
    /// Electric field strength (SI derived unit).
    let ElectricFieldStrength   = U("electric field strength",  "V/m",      Volt / Meter                        )
    /// Electric charge density (SI derived unit).
    let ElectricChargeDensity   = U("electric charge density",  "C/m³",     Coulomb / Meter.Pow(3)              )
    /// Surface charge density (SI derived unit).
    let SurfaceChargeDensity    = U("surface charge density",   "C/m²",     Coulomb / Meter.Pow(2)              )
    /// Electric flux density, electric displacement (SI derived unit).
    let ElectricFluxDensity     = U("electric flux density",    "C/m²",     Coulomb / Meter.Pow(2)              )
    /// Electric flux density, electric displacement (SI derived unit).
    let ElectricDisplacement    = U("electric displacement",    "C/m²",     Coulomb / Meter.Pow(2)              )
    /// Permittivity (SI derived unit).
    let Permittivity            = U("permittivity",             "F/m",      Farad / Meter                       )
    /// Permeability (SI derived unit).
    let Permeability            = U("permeability",             "H/m",      Henry / Meter                       )
    /// Molar energy (SI derived unit).
    let MolarEnergy             = U("molar energy",             "J/mol",    Joule / Mole                        )
    /// Molar entropy, molar heat capacity (SI derived unit).
    let MolarEntropy            = U("molar entropy",            "J/(mol K)",Joule / (Mole * Kelvin)             )
    /// Molar entropy, molar heat capacity (SI derived unit).
    let MolarHeatCapacity       = U("molar heat capacity",      "J/(mol K)",Joule / (Mole * Kelvin)             )
    /// Exposure (x- and γ-rays) (SI derived unit).
    let Exposure                = U("exposure (x- and γ-rays)", "C/kg",     Coulomb / Kilogram                  )
    /// Absorbed dose rate (SI derived unit).
    let AbsorbedDoseRate        = U("absorbed dose rate",       "Gy/s",     Gray / Second                       )
    /// Radiant intensity (SI derived unit).
    let RadiantIntensity        = U("radiant intensity",        "W/sr",     Watt / Steradian                    )
    /// Radiance (SI derived unit).
    let Radiance                = U("radiance",                 "W/(m2 sr)",Watt / (Meter.Pow(2) * Steradian)   )


    (*
        Non-SI units accepted for use with the International System of Units.
     *)

    /// 1 minute = 60 seconds.
    let Minute                  = U("minute",                   "min",      Second,         60                  )
    /// 1 hour = 60 minutes = 3 600 seconds.                                                                 
    let Hour                    = U("hour",                     "h",        Minute,         60                  )
    /// 1 day = 24 hours = 1 440 minutes = 86 400 seconds.                                                   
    let Day                     = U("day",                      "d",        Hour,           24                  )
    /// 1 degree = 1/180 radian = 1/360 of a full circle.                                                    
    let Degree                  = U("degree",                   "°",        Radian,         F.Pi / 180          )
    /// 1 minute = 1/60 degree.                                                                              
    let ArcMinute               = U("arcminute",                "′",        Degree,         F(1, 60)            )
    /// 1 second = 1/60 minute = 1/3600 degree.                                                              
    let ArcSecond               = U("arcsecond",                "″",        ArcMinute,      F(1, 60)            )
    /// 1 ha = 1 hm² = 10⁴ m2.
    let Hectare                 = U("hectare",                  "ha",       Meter.Pow(2),   10_000              )
    /// 1 L = 1 l = 1 dm³ = 10³ cm³ = 10⁻³ m³.
    let Liter                   = U("liter",                    "l",        Meter.Pow(3),   F(1, 1_000)         )
    /// 1 t = 10³ kg.
    let Tonne                   = U("tonne",                    "t",        Kilogram,       1_000               )


    /// 1 000 meters.
    let Kilometer   = Kilo  * Meter
    /// 1/10 of a meter.
    let Decimeter   = Deci  * Meter
    /// 1/100 of a meter.
    let Centimeter  = Centi * Meter
    /// 1/1000 of a meter.
    let Millimeter  = Milli * Meter
    /// 1/1000 of a millimeter.
    let Micrometer  = Micro * Meter
    /// 1/1000 of a micrometer.
    let Nanometer   = Nano  * Meter
    

    /// 1/1000 of a kilogram.
    let Gram                            = UnitOfMeasure("gram",                 "g",        Kilogram,       F.Pow(10, -3)   )
    /// 1/1000 of a gram.
    let Milligram                       = Milli * Gram
    /// 1/1000 of a milligram.
    let Microgram                       = Micro * Gram


    /// The area of a square whose sides measure exactly one kilometer.
    let SquareKilometer                 = UnitOfMeasure("square kilometer",     "km²",      Kilometer^2                     )
    /// The area of a square whose sides measure exactly one meter.
    let SquareMeter                     = UnitOfMeasure("square meter",         "m²",       Meter^2                         )
    /// The area of a square whose sides measure exactly one decimeter.
    let SquareDecimeter                 = UnitOfMeasure("square decimeter",     "dm²",      Decimeter^2                     )
    /// The area of a square whose sides measure exactly one centimeter.
    let SquareCentimeter                = UnitOfMeasure("square centimeter",    "cm²",      Centimeter^2                    )
    /// The area of a square whose sides measure exactly one millimeter.
    let SquareMillimeter                = UnitOfMeasure("square millimeter",    "mm²",      Millimeter^2                    )
    /// 100 m² (10m · 10m).
    let Are                             = UnitOfMeasure("are",                  "a",        SquareMeter,            100     )
    /// 10 000 m² (100m · 100m), or 100 are.
    


    /// The volume of a cube whose sides measure exactly one kilometer.
    let CubicKilometer                  = UnitOfMeasure("cubic kilometer",      "km³",      Kilometer^3                     )
    /// The volume of a cube whose sides measure exactly one meter.                                                         
    let CubicMeter                      = UnitOfMeasure("cubic meter",          "m³",       Meter^3                         )
    /// The volume of a cube whose sides measure exactly one decimeter.                                                     
    let CubicDecimeter                  = UnitOfMeasure("cubic decimeter",      "dm³",      Decimeter^3                     )
    /// The volume of a cube whose sides measure exactly one centimeter.                                                    
    let CubicCentimeter                 = UnitOfMeasure("cubic centimeter",     "cm³",      Centimeter^3                    )
    /// The volume of a cube whose sides measure exactly one millimeter.                                                    
    let CubicMillimeter                 = UnitOfMeasure("cubic millimeter",     "mm³",      Millimeter^3                    )
    /// Unit of volume equal to 1 cubic decimeter.
    
    
    
    /// 1/10 of a liter.
    let Deciliter                       = Deci * Liter
    /// 1/100 of a liter.
    let Centiliter                      = Centi * Liter
    /// 1/1000 of a liter, or one cubic centimeter.
    let Milliliter                      = Milli * Liter
    /// 1/1000 of a milliliter, or one cubic millimeter.
    let Microliter                      = Micro * Liter


    /// 1/1000 of a second.
    let Millisecond                     = Milli * Second
    /// 1/1000 of a millisecond.
    let Microsecond                     = Micro * Second
    /// 1/1000 of a microsecond.
    let Nanosecond                      = Nano  * Second
    /// 1/1000 of a nanosecond.
    let Picosecond                      = Pico  * Second
    /// 1/1000 of a picosecond.
    let Femtosecond                     = Femto * Second
    /// 1/1000 of a femtosecond.
    let Attosecond                      = Atto  * Second