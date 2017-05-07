namespace Uncodium.Units

open System
open System.Numerics
  
module Physics =

    open Fun
    open Prefix
    open SI
    open Time
    
    let kg = Kilogram
    let m = Meter
    let s = Second
    let π = F.Pi


    (* Universal constants *)

    /// The speed of light in vacuum.
    let SpeedOfLight            = Constant("speed of light",                "c",        299_792_458,            Meter / Second                      )
    let c = SpeedOfLight
     
    /// The gravitational constant (also known as "universal gravitational constant", or as "Newton's constant"),
    /// denoted by the letter G, is an empirical physical constant involved in the calculation of gravitational effects
    /// in Sir Isaac Newton's law of universal gravitation and in Albert Einstein's general theory of relativity.
    let GravitationalConstant   = Constant("gravitational constant",        "G",        E 6.6740831 -11,        (Meter^3) / (Kilogram * (Second^2)) )
        
    /// Planck constant, h.
    let PlanckConstant          = Constant("planck constant",               "h",        E 6.6260700481 -34,     Joule * Second                      )
    let h = PlanckConstant
    /// Planck length.
    let PlanckLength            = Constant("planck length",                 "lP",       E 1.61622938 -35,       Meter                               )
    /// Planck mass.
    let PlanckMass              = Constant("planck mass",                   "mP",       E 2.1765113 -8,         Kilogram                            )
    /// Planck time.
    let PlanckTime              = Constant("planck time",                   "tP",       E 5.3910632 -44,        Second                              )
    /// Planck charge.
    let PlanckCharge            = Constant("planck charge",                 "qP",       E 1.87554595641 -18,    Coulomb                             )
    /// Planck temperature.
    let PlanckTemperature       = Constant("planck temperature",            "TP",       E 1.41683385 32,        Kelvin                              )

    /// Dirac constant or reduced Planck constant, ħ (pronounced "h-bar").
    let DiracConstant           = Constant("dirac constant",                "ħ",        E 1.05457180013 -34,    Joule * Second                      )
    /// Reduced Planck constant or Dirac constant, ħ (pronounced "h-bar").
    let ReducedPlanckConstant   = Constant("reduced planck constant",       "ħ",        E 1.05457180013 -34,    Joule * Second                      )
    let ħ = ReducedPlanckConstant

    /// The amount of energy gained (or lost) by the charge of a single electron moving across
    /// an electric potential difference of one volt (1.6021766208(98)×10^−19 joule).
    let Electronvolt            = Constant("electronvolt",                  "eV",       E 1.602176620898 -19,   Joule                               )

    /// gigaelectronvolt.
    let GeV                     = Constant("GeV",                           "GeV",      Giga * Electronvolt                                         )
    
    /// The atomic mass constant, mᵤ, is one twelfth of the mass of an unbound atom of carbon-12 at rest and in its ground state.
    let AtomicMassConstant      = Constant("atomic mass constant",          "mᵤ",       E 1.66053892173 -27,    Kilogram                            )

    /// The Avogadro constant is the number of constituent particles, usually atoms or molecules, that are contained in the amount of substance given by one mole.
    let AvogadrosNumber         = Constant("Avogadro's number",             "N_A",      E 6.02214085774 23,     1 / Mole                            )

    /// The Boltzmann constant (k_B or k), which is named after Ludwig Boltzmann, is a physical constant relating
    /// the average kinetic energy of particles in a gas with the temperature of the gas.
    /// It is the gas constant R divided by the Avogadro constant NA
    let BoltzmannConstant       = Constant("Boltzmann constant",            "k_B",      E 61.3806485279 -23,    Joule / Kelvin                      )
    let k = BoltzmannConstant

    /// The Faraday constant, denoted by the symbol F and named after Michael Faraday, is the magnitude of electric charge per mole of electrons.
    /// https://en.wikipedia.org/wiki/Faraday_constant
    let FaradayConstant         = Constant("Faraday constant",              "F",        E 96485.3328959 1,      Coulomb / Mole                      )

    /// The Loschmidt constant or Loschmidt's number (symbol: nₒ) is the number of particles (atoms or molecules) of an ideal gas in a given volume (the number density).
    /// https://en.wikipedia.org/wiki/Loschmidt_constant
    let LoschmidtConstant       = Constant("Loschmidt constant",            "nₒ",       E 2.686777447 25,       1 / CubicMeter                      )
    
    /// The gas constant (also known as the molar, universal, or ideal gas constant is equivalent to the Boltzmann constant,
    /// but expressed in units of energy (i.e. the pressure-volume product) per temperature increment per mole (rather than
    /// energy per temperature increment per particle).
    /// https://en.wikipedia.org/wiki/Gas_constant
    let GasConstant             = Constant("gas constant",                  "R",        E 8.314459848 1,        Joule / (Mole * Kelvin)             )

    /// First radiation constant c₁
    let FirstRadiationConstant  = Constant("first radiation constant",      "c₁",       2 * π * h * (c.Pow(2))                                      )

    /// First radiation constant c₁_L (for spectral radiance).
    let FirstRadiationConstantL = Constant("first radiation constant (spectral radiance)",  "c₁_L",             FirstRadiationConstant / π          )

    /// Second radiation constant c₂
    let SecondRadiationConstant = Constant("second radiation constant",     "c₂",       h * c / k                                                   )

    /// The Stefan–Boltzmann constant (also Stefan's constant), a physical constant denoted by the Greek letter σ (sigma), is the constant
    /// of proportionality in the Stefan–Boltzmann law: "the total intensity radiated over all wavelengths increases as the temperature
    /// increases", of a black body which is proportional to the fourth power of the thermodynamic temperature.
    /// https://en.wikipedia.org/wiki/Stefan%E2%80%93Boltzmann_constant
    let StefanBoltzmannConstant = Constant("Stefan-Boltzmann constant",     "σ",        (2 * π.Pow(5) * k.Pow(4)) / (15 * h.Pow(3) * c.Pow(2))      )

    /// Wien's displacement constant.
    /// https://en.wikipedia.org/wiki/Wien%27s_displacement_law
    let WiensDisplacementConstant = Constant("Wien's displacement constant", "b",       E 2.897772917 -3,       Meter * Kelvin                      )




    (* Atomic and nuclear constants *)
    
    /// The Bohr radius (aₒ or rBohr) is a physical constant, approximately equal to the most probable
    /// distance between the center of a nuclide and the electron in a hydrogen atom in its ground state.
    let BohrRadius              = Constant("bohr radius",                   "aₒ",       E 5.291772106712 -11,   Meter                               )

    /// The invariant mass of an electron is approximately 9.10938356×10−31 kilograms, or 5.489×10−4 atomic mass units.
    let ElectronMass            = Constant("electron rest mass",            "mₑ",       E 9.10938356 -31,       Kilogram                            )
    let mₑ = ElectronMass

    /// Proton mass.
    let ProtonMass              = Constant("proton mass",                   "mₚ",       E 1.67262189821 -27,    Kilogram                            )
    let mₚ = ProtonMass

    /// Mass of the W boson in GeV/c².
    let WBosonMass              = Constant("W boson mass",                  "m_Wboson", 80.385 * GeV / c.Pow(2)                                     )
    
    /// Mass of the Z boson in GeV/c².
    let ZBosonMass              = Constant("Z boson mass",                  "m_Zboson", 91.1876 * GeV / c.Pow(2)                                    )

    (* Electromagnetic constants *)

    /// Magnetic constant or vacuum permeability.
    /// https://en.wikipedia.org/wiki/Vacuum_permeability
    let VacuumPermeability      = Constant("vacuum permeability",           "μₒ",       4 * π * E 1.0 -7,   Newton / (Ampere^2)                    )
    /// Magnetic constant or vacuum permeability.
    /// https://en.wikipedia.org/wiki/Vacuum_permeability
    let μₒ = VacuumPermeability
    
    /// Electric constant or vacuum permittivity.
    /// https://en.wikipedia.org/wiki/Vacuum_permittivity.
    let VacuumPermittivity      = Constant("vacuum permittivity",           "εₒ",       1 / (μₒ * c.Pow(2))                         )
    /// Electric constant or vacuum permittivity.
    /// https://en.wikipedia.org/wiki/Vacuum_permittivity.
    let εₒ = VacuumPermittivity

    /// The impedance of free space, Zₒ, (more correctly, the wave-impedance of a plane wave in free space)
    /// equals the product of the vacuum permeability μ0 and the speed of light in vacuum cₒ.
    let ImpedanceOfFreeSpace    = Constant("impedance of free space",       "Zₒ",       μₒ * c)
    /// The impedance of free space, Zₒ, (more correctly, the wave-impedance of a plane wave in free space)
    /// equals the product of the vacuum permeability μ0 and the speed of light in vacuum cₒ.
    let Zₒ = ImpedanceOfFreeSpace

    /// The elementary charge, usually denoted as e or sometimes q, is the electric charge carried by a single proton, or equivalently,
    /// the magnitude of the electric charge carried by a single electron, which has charge −e.
    /// To avoid confusion over its sign, e is sometimes called the elementary positive charge.
    /// This charge has a measured value of approximately 1.6021766208(98)×10−19 coulombs,
    let ElementaryCharge        = Constant("elementary charge",             "e",        E 1.602176620898 -19,    Coulomb                            )
    let e = ElementaryCharge

    /// Fine-structure constant (also known as Sommerfeld's constant).
    /// https://en.wikipedia.org/wiki/Fine-structure_constant
    let FineStructureConstant   = Constant("fine-structure constant",       "α",        (e.Pow(2) * Zₒ) / (4 * π * ħ)             )
    /// Fine-structure constant (also known as Sommerfeld's constant).
    /// https://en.wikipedia.org/wiki/Fine-structure_constant
    let α = FineStructureConstant

    /// Coulomb's constant, the electric force constant, or the electrostatic constant (denoted kₑ)
    /// is a proportionality constant in electrodynamics equations.
    let CoulombConstant         = Constant("Coulomb constant",              "kₑ",       1 / (4 * π * εₒ)                                            )
    /// Coulomb's constant, the electric force constant, or the electrostatic constant (denoted kₑ)
    /// is a proportionality constant in electrodynamics equations.
    let kₑ = CoulombConstant

    /// The unified atomic mass unit (symbol: u) or dalton (symbol: Da) is a standard unit of mass that quantifies mass on an atomic or molecular scale.
    /// It is defined as one twelfth of the mass of an unbound neutral atom of carbon-12 in its nuclear and electronic ground state and at rest,
    /// and has a value of 1.660539040(20)×10−27 kg, or approximately 1.66 yoctograms.
    let UnifiedAtomicMassUnit   = Constant("unified atomic mass unit",      "u",        E 1.660539040 -27,    Kilogram                              )
    /// The unified atomic mass unit (symbol: u) or dalton (symbol: Da) is a standard unit of mass that quantifies mass on an atomic or molecular scale.
    /// It is defined as one twelfth of the mass of an unbound neutral atom of carbon-12 in its nuclear and electronic ground state and at rest,
    /// and has a value of 1.660539040(20)×10−27 kg, or approximately 1.66 yoctograms.
    let u = UnifiedAtomicMassUnit
    
    /// The dalton (symbol: Da) or unified atomic mass unit (symbol: u) is a standard unit of mass that quantifies mass on an atomic or molecular scale.
    /// It is defined as one twelfth of the mass of an unbound neutral atom of carbon-12 in its nuclear and electronic ground state and at rest,
    /// and has a value of 1.660539040(20)×10−27 kg, or approximately 1.66 yoctograms.
    let Dalton                  = Constant("dalton",                        "Da",       E 1.660539040 -27,    Kilogram                              )
    
    /// In atomic physics, the Bohr magneton (symbol μ_B) is a physical constant and the natural unit for expressing
    /// the magnetic moment of an electron caused by either its orbital or spin angular momentum.
    let BohrMagneton            = Constant("Bohr magneton",                 "μ_B",      e * ħ / (2 * mₑ)                                            )

    /// The conductance quantum, denoted by the symbol Gₒ is the quantized unit of electrical conductance.
    let ConductanceQuantum      = Constant("conductance quantum",           "Gₒ",       2 * e.Pow(2) / h                                            )
    
    /// 1 / Gₒ.
    let InverseConductanceQuantum = Constant("inverse conductance quantum", "Gₒ⁻¹", h / (2 * e.Pow(2))                                              )

    /// The conductance quantum, denoted by the symbol Gₒ is the quantized unit of electrical conductance.
    let MagneticFluxQuantum     = Constant("magnetic flux quantum",         "Φₒ",       h / (2 * e)                                                 )
    let Φₒ = MagneticFluxQuantum

    /// The inverse of the flux quantum, 1/Φₒ, is called the Josephson constant, and is denoted K_J. 
    let JosephsonConstant       = Constant("josephson quantum",             "K_J",      1 / Φₒ                                                      )

    /// The nuclear magneton is the natural unit for expressing magnetic dipole moments of heavy particles such as nucleons and atomic nuclei.
    let NuclearMagneton         = Constant("nuclear magneton",              "μ_N",      e * ħ / (2 * mₚ)                                            )

    /// von Klietzing constant.
    let VonKlietzingConstant    = Constant("von Klietzing constant",        "R_K",      h / e.Pow(2)                                                )

    /// The classical electron radius, also known as the Lorentz radius or the Thomson scattering length, is based on a classical (i.e. non-quantum) relativistic model of the electron.
    let ClassicalElectronRadius = Constant("classical electron radius",     "rₑ",       e.Pow(2) / (4 * π * εₒ * mₑ * c.Pow(2))                     )
    /// The classical electron radius, also known as the Lorentz radius or the Thomson scattering length, is based on a classical (i.e. non-quantum) relativistic model of the electron.
    let LorentzRadius           = Constant("lorentz radius",                "rₑ",       e.Pow(2) / (4 * π * εₒ * mₑ * c.Pow(2))                     )
    /// The classical electron radius, also known as the Lorentz radius or the Thomson scattering length, is based on a classical (i.e. non-quantum) relativistic model of the electron.
    let ThomsonScatteringLength = Constant("Thomson scattering length",     "rₑ",       e.Pow(2) / (4 * π * εₒ * mₑ * c.Pow(2))                     )
    
    /// Rydberg constant.
    let RydbergConstant         = Constant("rydberg constant",              "R∞",       (mₑ * e.Pow(4)) / (8 * εₒ.Pow(2) * h.Pow(3) * c)            )

    /// Hartree energy Eh.
    let HartreeEnergy           = Constant("hartree energy",                "Eₕ",       2 * RydbergConstant * h * c                                 )




    /// The ångström (or angstrom) is a unit of length equal to 10^−10 m (one ten-billionth of a meter) or 0.1 nanometer.
    /// Its symbol is Å, a letter in the Swedish alphabet.
    let Angstrom                = Constant("ångström",                      "Å",        E 1.0 -10,              Meter                                   )
    
    /// The hartree (symbol: Eh or Ha), also known as the Hartree energy,
    /// is the atomic unit of energy, named after the British physicist Douglas Hartree.
    let Hartree                 = Constant("hartree",                       "Ha",       E 4.35974465054 -18,    Joule                               )

    
    
    
    /// g0
    let StandardGravity         = Constant("standard gravity",              "g0",       E 9.80665 1,            Meter / (Second ^ 2)                )

    /// kgf
    let KilogramForce           = Constant("kilogram-force",                "kgf",      Kilogram * StandardGravity                                  )

    /// kp
    let Kilopond                = Constant("kilopond",                      "kp",       Kilogram * StandardGravity                                  )

    /// The poundal (pdl) is defined as the force necessary to accelerate 1 pound-mass at 1 foot per second per second.
    let Poundal                 = U("poundal",                  "pdl",      International.Pound * International.Foot / (Second ^ 2)                 )

    /// The pound-force (lbf) is equal to the gravitational force exerted on a mass of one avoirdupois pound on the surface of Earth.
    let PoundForce              = U("pound-force",              "lbf",      (International.Pound * StandardGravity) |> U                            )
    
    /// A slug is defined as the mass that is accelerated by 1 ft/s2 when a force of one pound (lbf) is exerted on it.
    let Slug                    = U("slug",                     "slug",     PoundForce * (Second ^ 2) / International.Foot                          )

    /// One newton meter is equal to the torque resulting from a force of one newton applied perpendicularly to a moment arm which is one meter long.
    let NewtonMeter             = U("newton meter",             "Nm",       Newton * Meter                              )

    /// Angular frequency ω (in radians per second), is larger than frequency (in cycles per second, also called Hz),
    /// by a factor of 2π, because 2π rad/s corresponds to 1 Hz.
    let RadiansPerSecond        = U("radians per second",       "ω",        Radian/Second                               )

    /// The number of rotations around a fixed axis in one minute.
    /// It is used as a measure of rotational speed of a mechanical component.
    let RevolutionsPerMinute    = U("revolutions per minute",   "rpm",      Hertz,              F(1, 60)                )
    
    /// One dyne is equal to 10 micronewtons
    let Dyne                    = U("dyne",                     "dyn",      Newton,             F.Pow(10, -5)           )

    /// The dyne per centimeter is a unit traditionally used to measure surface tension.
    /// For example, the surface tension of distilled water is 72 dyn/cm at 25 °C.
    let DynePerCentimeter       = Dyne/Centimeter

    (* Speed *)

    let MetersPerSecond         = Meter/Second
    let KilometersPerHour       = Kilometer/Hour
    let KilometersPerSecond     = Kilometer/Second
    let FeetPerSecond           = International.Foot/Second
    let MilesPerHour            = U("miles per hour",           "mph",   International.Mile/Hour                        )

    (* Energy *)

    let Kilowatt                = Kilo * Watt
    let Megawatt                = Mega * Watt
    let Gigawatt                = Giga * Watt
    
    let Kilojoule               = Kilo * Joule
    let Megajoule               = Mega * Joule
    let Gigajoule               = Giga * Joule
    
    let Watthour                = U("watt hour",                "Wh",   Watt * Hour                                     )
    let KilowattHour            = U("kilowatt hour",            "kWh",  Kilowatt * Hour                                 )
    let MegawattHour            = U("megawatt hour",            "MWh",  Megawatt * Hour                                 )
    let GigawattHour            = U("gigawatt hour",            "GWh",  Gigawatt * Hour                                 )

    /// 1 horsepower (hp) is equal to 745.7 watts.
    let HorsepowerImperial      = U("imperial horsepower",      "hp",   Watt,                   F(7457, 10)             )
    /// 1 horsepower (hp) is equal to 745.7 watts.
    let HP                      = HorsepowerImperial

    /// 1 horsepower (PS) is equal to 735.5 watts.
    let HorsepowerMetric        = U("metric horsepower",        "PS",   Watt,                   F(7_355, 10)            )
    /// 1 horsepower (PS) is equal to 735.5 watts.
    let PS                      = HorsepowerMetric

    /// 1 BTU (British Thermal Unit) is equal to 1055.06 joules.
    /// See ISO 31-4 on Quantities and units—Part 4: Heat (https://books.google.com/books?id=-ZveBwAAQBAJ&pg=PA19-IA35).
    let BTU                     = U("british thermal unit",     "BTU",  Joule,                  F(105506, 100)          )
    
    (* Pressure *)

    let Kilopascal              = Kilo * Pascal
    let Bar                     = U("bar",                      "bar",  Pascal,                 10_000                  )
    let Barye                   = U("barye",                    "Ba",   Pascal,                 F(1, 10)                )
    let PoundsPerSquareInch     = U("pounds per square inch",   "psi",  International.Pound / International.SquareInch  )
    let PSI                     = PoundsPerSquareInch
 