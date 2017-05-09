namespace Uncodium.Units

module Physics =

    open Fun
    open SI
    
    let private kg = Kilogram
    let private m  = Meter
    let private s  = Second
    let private π  = Rational.Pi
    
    /// The speed of light in vacuum (c).
    let SpeedOfLight            = Constant("speed of light",                "c",        299_792_458,            Meter / Second                      )
    /// The speed of light in vacuum (c).
    let c = SpeedOfLight
     
    /// The gravitational constant (also known as "universal gravitational constant", or as "Newton's constant"),
    /// denoted by the letter G, is an empirical physical constant involved in the calculation of gravitational effects
    /// in Sir Isaac Newton's law of universal gravitation and in Albert Einstein's general theory of relativity.
    /// https://en.wikipedia.org/wiki/Gravitational_constant.
    let GravitationalConstant   = Constant("gravitational constant",        "G",        E 6.674_08 -11,         (Meter.Pow(3)) / (Kilogram * (Second.Pow(2))) )
        
    /// Planck constant, h.
    /// https://en.wikipedia.org/wiki/Planck_constant.
    let PlanckConstant          = Constant("planck constant",               "h",        E 6.626_070_040 -34,    Joule * Second                      )
    /// Planck constant, h.
    /// https://en.wikipedia.org/wiki/Planck_constant.
    let h = PlanckConstant
    
    /// Planck length.
    /// https://en.wikipedia.org/wiki/Planck_units
    /// http://physics.nist.gov/cgi-bin/cuu/Value?plkl
    let PlanckLength            = Constant("planck length",                 "l_P",      E 1.616_229 -35,        Meter                               )
    
    /// Planck mass.
    /// https://en.wikipedia.org/wiki/Planck_units
    /// http://physics.nist.gov/cgi-bin/cuu/Value?plkm
    let PlanckMass              = Constant("planck mass",                   "m_P",      E 2.176_470 -8,         Kilogram                            )
    
    /// Planck time.
    /// https://en.wikipedia.org/wiki/Planck_units
    /// http://physics.nist.gov/cgi-bin/cuu/Value?plkt
    let PlanckTime              = Constant("planck time",                   "t_P",      E 5.391_16 -44,         Second                              )
    
    /// Planck charge.
    /// https://en.wikipedia.org/wiki/Planck_units
    let PlanckCharge            = Constant("planck charge",                 "q_P",      E 1.875_545_956 -18,    Coulomb                             )
    
    /// Planck temperature.
    /// https://en.wikipedia.org/wiki/Planck_units
    /// http://physics.nist.gov/cgi-bin/cuu/Value?plktmp
    let PlanckTemperature       = Constant("planck temperature",            "T_P",      E 1.416_808 32,         Kelvin                              )

    /// Dirac constant or reduced Planck constant, ħ (pronounced "h-bar").
    /// https://en.wikipedia.org/wiki/Planck_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?hbar
    let DiracConstant           = Constant("dirac constant",                "ħ",        E 1.054_571_800 -34,    Joule * Second                      )
    /// Reduced Planck constant or Dirac constant, ħ (pronounced "h-bar").
    /// https://en.wikipedia.org/wiki/Planck_constant.
    /// http://physics.nist.gov/cgi-bin/cuu/Value?hbar
    let ReducedPlanckConstant   = Constant("reduced planck constant",       "ħ",        E 1.054_571_800 -34,    Joule * Second                      )
    /// Reduced Planck constant or Dirac constant, ħ (pronounced "h-bar").
    /// https://en.wikipedia.org/wiki/Planck_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?hbar
    let ħ = ReducedPlanckConstant

    /// The amount of energy gained (or lost) by the charge of a single electron moving across
    /// an electric potential difference of one volt (1.6021766208×10^−19 joule).
    /// https://en.wikipedia.org/wiki/Electronvolt
    /// http://physics.nist.gov/cgi-bin/cuu/Value?tevj
    let Electronvolt            = Constant("electron volt",                 "eV",       E 1.602_176_6208 -19,  Joule                               )
    /// The amount of energy gained (or lost) by the charge of a single electron moving across
    /// an electric potential difference of one volt (1.6021766208×10^−19 joule).
    /// https://en.wikipedia.org/wiki/Electronvolt.
    /// http://physics.nist.gov/cgi-bin/cuu/Value?tevj
    let eV = Electronvolt

    /// Gigaelectronvolt (GeV). See ElectronVolt (eV).
    let GeV                     = Constant("GeV",                           "GeV",      Giga * Electronvolt                                         )
    
    /// The atomic mass constant, mᵤ, is one twelfth of the mass of an unbound atom of
    /// carbon-12 at rest and in its ground state.
    /// https://en.wikipedia.org/wiki/Atomic_mass_constant.
    /// http://physics.nist.gov/cgi-bin/cuu/Value?u.
    let AtomicMassConstant      = Constant("atomic mass constant",          "mᵤ",       E 1.660_538_921 -27,    Kilogram                            )
    /// The atomic mass constant, mᵤ, is one twelfth of the mass of an unbound atom of
    /// carbon-12 at rest and in its ground state.
    /// https://en.wikipedia.org/wiki/Atomic_mass_constant.
    /// http://physics.nist.gov/cgi-bin/cuu/Value?u.
    let mᵤ = AtomicMassConstant

    /// The Avogadro constant (N_A, or L) is the number of constituent particles, usually
    /// atoms or molecules, that are contained in the amount of substance given by one mole.
    /// https://en.wikipedia.org/wiki/Avogadro_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?na
    let AvogadrosNumber         = Constant("Avogadro's number",             "N_A",      E 6.022_140_857 23,     1 / Mole                            )

    /// The Boltzmann constant (k_B or k), which is named after Ludwig Boltzmann, is a physical
    /// constant relating the average kinetic energy of particles in a gas with the temperature of the gas.
    /// It is the gas constant R divided by the Avogadro constant N_A.
    /// https://en.wikipedia.org/wiki/Boltzmann_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?k
    let BoltzmannConstant       = Constant("Boltzmann constant",            "k_B",      E 1.380_648_52 -23,     Joule / Kelvin                      )
    /// The Boltzmann constant (k_B or k), which is named after Ludwig Boltzmann, is a physical
    /// constant relating the average kinetic energy of particles in a gas with the temperature of the gas.
    /// It is the gas constant R divided by the Avogadro constant N_A.
    /// https://en.wikipedia.org/wiki/Boltzmann_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?k
    let k = BoltzmannConstant

    /// The Faraday constant, denoted by the symbol F and named after Michael Faraday,
    /// is the magnitude of electric charge per mole of electrons.
    /// https://en.wikipedia.org/wiki/Faraday_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?f
    let FaradayConstant         = Constant("Faraday constant",              "F",        E 96_485.332_89 1,      Coulomb / Mole                      )

    /// The Loschmidt constant or Loschmidt's number (symbol: nₒ) is the number of particles
    /// (atoms or molecules) of an ideal gas in a given volume (the number density).
    /// https://en.wikipedia.org/wiki/Loschmidt_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?n0std
    let LoschmidtConstant       = Constant("Loschmidt constant",            "nₒ",       E 2.686_7811 25,        1 / CubicMeter                      )
    /// The Loschmidt constant or Loschmidt's number (symbol: nₒ) is the number of particles
    /// (atoms or molecules) of an ideal gas in a given volume (the number density).
    /// https://en.wikipedia.org/wiki/Loschmidt_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?n0std
    let nₒ = LoschmidtConstant

    /// The gas constant (also known as the molar, universal, or ideal gas constant is equivalent to the Boltzmann constant,
    /// but expressed in units of energy (i.e. the pressure-volume product) per temperature increment per mole (rather than
    /// energy per temperature increment per particle).
    /// https://en.wikipedia.org/wiki/Gas_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?r
    let GasConstant             = Constant("gas constant",                  "R",        E 8.314_4598_1 1,       Joule / (Mole * Kelvin) )
    /// The gas constant (also known as the molar, universal, or ideal gas constant is equivalent to the Boltzmann constant,
    /// but expressed in units of energy (i.e. the pressure-volume product) per temperature increment per mole (rather than
    /// energy per temperature increment per particle).
    /// https://en.wikipedia.org/wiki/Gas_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?r
    let MolarGasConstant = GasConstant
    /// The gas constant (also known as the molar, universal, or ideal gas constant is equivalent to the Boltzmann constant,
    /// but expressed in units of energy (i.e. the pressure-volume product) per temperature increment per mole (rather than
    /// energy per temperature increment per particle).
    /// https://en.wikipedia.org/wiki/Gas_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?r
    let R = GasConstant

    /// First radiation constant c₁
    let FirstRadiationConstant  = Constant("first radiation constant",      "c₁",                   2 * π * h * (c.Pow(2))              )

    /// First radiation constant c₁_L (for spectral radiance).
    let FirstRadiationConstantL = Constant("first radiation constant (spectral radiance)",  "c₁_L", FirstRadiationConstant / π          )

    /// Second radiation constant c₂
    let SecondRadiationConstant = Constant("second radiation constant",     "c₂",                   h * c / k                           )

    /// The Stefan–Boltzmann constant (also Stefan's constant), a physical constant denoted by the Greek letter σ (sigma), is the constant
    /// of proportionality in the Stefan–Boltzmann law: "the total intensity radiated over all wavelengths increases as the temperature
    /// increases", of a black body which is proportional to the fourth power of the thermodynamic temperature.
    /// https://en.wikipedia.org/wiki/Stefan%E2%80%93Boltzmann_constant
    let StefanBoltzmannConstant = Constant("Stefan-Boltzmann constant",     "σ", (2 * π.Pow(5) * k.Pow(4)) / (15 * h.Pow(3) * c.Pow(2)) )

    /// Wien's wavelength displacement constant.
    /// https://en.wikipedia.org/wiki/Wien%27s_displacement_law
    /// http://physics.nist.gov/cgi-bin/cuu/Value?bwien
    let WiensWavelengthDisplacementConstant = Constant("Wien's wavelength displacement constant", "b", E 2.897_7729 -3, Meter * Kelvin)
    /// Wien's displacement constant.
    /// https://en.wikipedia.org/wiki/Wien%27s_displacement_law
    /// http://physics.nist.gov/cgi-bin/cuu/Value?bwien
    let b = WiensWavelengthDisplacementConstant
    
    /// Wien's frequency displacement constant.
    /// https://en.wikipedia.org/wiki/Wien%27s_displacement_law
    /// http://physics.nist.gov/cgi-bin/cuu/Value?bpwien
    let WiensFrequencyDisplacementConstant = Constant("Wien's frequency displacement constant", "b'", E 5.878_9238 10, Hertz / Kelvin)
    /// Wien's frequency displacement constant.
    /// https://en.wikipedia.org/wiki/Wien%27s_displacement_law
    /// http://physics.nist.gov/cgi-bin/cuu/Value?bpwien
    let b' = WiensFrequencyDisplacementConstant
    
    /// The Bohr radius (aₒ or r_Bohr) is a physical constant, approximately equal to the most probable
    /// distance between the center of a nuclide and the electron in a hydrogen atom in its ground state.
    /// https://en.wikipedia.org/wiki/Bohr_radius
    /// http://physics.nist.gov/cgi-bin/cuu/Value?bohrrada0
    let BohrRadius              = Constant("bohr radius",                   "aₒ",       E 0.529_177_210_67 -10, Meter                               )
    /// The Bohr radius (aₒ or r_Bohr) is a physical constant, approximately equal to the most probable
    /// distance between the center of a nuclide and the electron in a hydrogen atom in its ground state.
    /// https://en.wikipedia.org/wiki/Bohr_radius
    /// http://physics.nist.gov/cgi-bin/cuu/Value?bohrrada0
    let aₒ = BohrRadius

    /// The invariant mass (or rest mass) of an electron is approximately
    /// 9.109 383 56×10−31 kilograms, or 5.489×10−4 atomic mass units.
    /// https://en.wikipedia.org/wiki/Electron_rest_mass
    /// http://physics.nist.gov/cgi-bin/cuu/Value?me
    let ElectronMass            = Constant("electron rest mass",            "mₑ",       E 9.109_383_56 -31,     Kilogram                            )
    /// The invariant mass (or rest mass) of an electron is approximately
    /// 9.109 383 56×10−31 kilograms, or 5.489×10−4 atomic mass units.
    /// https://en.wikipedia.org/wiki/Electron_rest_mass
    /// http://physics.nist.gov/cgi-bin/cuu/Value?me
    let mₑ = ElectronMass

    /// Proton mass.
    /// https://en.wikipedia.org/wiki/Proton
    /// http://physics.nist.gov/cgi-bin/cuu/Value?mp
    let ProtonMass              = Constant("proton mass",                   "mₚ",       E 1.672_621_898 -27,    Kilogram                            )
    /// Proton mass.
    /// https://en.wikipedia.org/wiki/Proton
    /// http://physics.nist.gov/cgi-bin/cuu/Value?mp
    let mₚ = ProtonMass

    /// Mass of the W boson in GeV/c².
    /// https://en.wikipedia.org/wiki/W_and_Z_bosons
    let WBosonMass              = Constant("W boson mass",                  "m_Wboson", 80.385 * GeV / c.Pow(2)                                     )
    
    /// Mass of the Z boson in GeV/c².
    /// https://en.wikipedia.org/wiki/W_and_Z_bosons
    let ZBosonMass              = Constant("Z boson mass",                  "m_Zboson", 91.1876 * GeV / c.Pow(2)                                    )

    (* Electromagnetic constants *)

    /// Magnetic constant or vacuum permeability.
    /// https://en.wikipedia.org/wiki/Vacuum_permeability
    /// http://physics.nist.gov/cgi-bin/cuu/Value?mu0
    let MagneticConstant        = Constant("magnetic constant",             "μₒ",       4 * π * E 1.0 -7,   Newton / (Ampere.Pow(2))                )
    /// Magnetic constant or vacuum permeability.
    /// https://en.wikipedia.org/wiki/Vacuum_permeability
    /// http://physics.nist.gov/cgi-bin/cuu/Value?mu0
    let VacuumPermeability = MagneticConstant
    /// Magnetic constant or vacuum permeability.
    /// https://en.wikipedia.org/wiki/Vacuum_permeability
    /// http://physics.nist.gov/cgi-bin/cuu/Value?mu0
    let μₒ = MagneticConstant
    
    /// Electric constant or vacuum permittivity.
    /// https://en.wikipedia.org/wiki/Vacuum_permittivity
    /// http://physics.nist.gov/cgi-bin/cuu/Value?ep0
    let ElectricConstant      = Constant("electric constant",               "εₒ",       1 / (μₒ * c.Pow(2))                                         )
    /// Electric constant or vacuum permittivity.
    /// https://en.wikipedia.org/wiki/Vacuum_permittivity
    /// http://physics.nist.gov/cgi-bin/cuu/Value?ep0
    let VacuumPermittivity = ElectricConstant
    /// Electric constant or vacuum permittivity.
    /// https://en.wikipedia.org/wiki/Vacuum_permittivity
    /// http://physics.nist.gov/cgi-bin/cuu/Value?ep0
    let εₒ = ElectricConstant

    /// The impedance of free space, Zₒ, (more correctly, the wave-impedance of a plane wave in free space)
    /// equals the product of the vacuum permeability (magnetic constant) μₒ and the speed of light in vacuum.
    /// https://en.wikipedia.org/wiki/Impedance_of_free_space
    let ImpedanceOfFreeSpace    = Constant("impedance of free space",       "Zₒ",       μₒ * c)
    /// The impedance of free space, Zₒ, (more correctly, the wave-impedance of a plane wave in free space)
    /// equals the product of the vacuum permeability (magnetic constant) μₒ and the speed of light in vacuum.
    /// https://en.wikipedia.org/wiki/Impedance_of_free_space
    let Zₒ = ImpedanceOfFreeSpace

    /// The elementary charge, usually denoted as e or sometimes q, is the electric charge carried by a single proton, or equivalently,
    /// the magnitude of the electric charge carried by a single electron, which has charge −e.
    /// To avoid confusion over its sign, e is sometimes called the elementary positive charge.
    /// This charge has a measured value of approximately 1.6021766208(98)×10−19 coulombs.
    /// https://en.wikipedia.org/wiki/Elementary_charge
    /// http://physics.nist.gov/cgi-bin/cuu/Value?e
    let ElementaryCharge        = Constant("elementary charge",             "e",        E 1.602_176_6208 -19,   Coulomb                            )
    /// The elementary charge, usually denoted as e or sometimes q, is the electric charge carried by a single proton, or equivalently,
    /// the magnitude of the electric charge carried by a single electron, which has charge −e.
    /// To avoid confusion over its sign, e is sometimes called the elementary positive charge.
    /// This charge has a measured value of approximately 1.6021766208(98)×10−19 coulombs.
    /// https://en.wikipedia.org/wiki/Elementary_charge
    /// http://physics.nist.gov/cgi-bin/cuu/Value?e
    let e = ElementaryCharge

    /// Fine-structure constant (also known as Sommerfeld's constant).
    /// https://en.wikipedia.org/wiki/Fine-structure_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?alph
    let FineStructureConstant   = Constant("fine-structure constant",       "α",        (e.Pow(2) / (4 * π)) * (Zₒ / ħ)     )
    /// Fine-structure constant (also known as Sommerfeld's constant).
    /// https://en.wikipedia.org/wiki/Fine-structure_constant
    /// http://physics.nist.gov/cgi-bin/cuu/Value?alph
    let α = FineStructureConstant

    /// Coulomb's constant, the electric force constant, or the electrostatic constant (denoted kₑ)
    /// is a proportionality constant in electrodynamics equations.
    let CoulombConstant         = Constant("Coulomb constant",              "kₑ",       1 / (4 * π * εₒ)                                            )
    /// Coulomb's constant, the electric force constant, or the electrostatic constant (denoted kₑ)
    /// is a proportionality constant in electrodynamics equations.
    let kₑ = CoulombConstant

    /// The unified atomic mass unit (symbol: u) or dalton (symbol: Da) is a standard unit of mass
    /// that quantifies mass on an atomic or molecular scale.
    /// It is defined as one twelfth of the mass of an unbound neutral atom of carbon-12 in its
    /// nuclear and electronic ground state and at rest,
    /// and has a value of 1.660539040(20)×10−27 kg, or approximately 1.66 yoctograms.
    /// https://en.wikipedia.org/wiki/Unified_atomic_mass_unit
    /// http://physics.nist.gov/cgi-bin/cuu/Value?tukg
    let UnifiedAtomicMassUnit   = Constant("unified atomic mass unit",      "u",        E 1.660_539_040 -27,    Kilogram                              )
    /// The unified atomic mass unit (symbol: u) or dalton (symbol: Da) is a standard unit of mass
    /// that quantifies mass on an atomic or molecular scale.
    /// It is defined as one twelfth of the mass of an unbound neutral atom of carbon-12 in its
    /// nuclear and electronic ground state and at rest,
    /// and has a value of 1.660539040(20)×10−27 kg, or approximately 1.66 yoctograms.
    /// https://en.wikipedia.org/wiki/Unified_atomic_mass_unit
    /// http://physics.nist.gov/cgi-bin/cuu/Value?tukg
    let u = UnifiedAtomicMassUnit
    /// The unified atomic mass unit (symbol: u) or dalton (symbol: Da) is a standard unit of mass
    /// that quantifies mass on an atomic or molecular scale.
    /// It is defined as one twelfth of the mass of an unbound neutral atom of carbon-12 in its
    /// nuclear and electronic ground state and at rest,
    /// and has a value of 1.660539040(20)×10−27 kg, or approximately 1.66 yoctograms.
    /// https://en.wikipedia.org/wiki/Unified_atomic_mass_unit
    /// http://physics.nist.gov/cgi-bin/cuu/Value?tukg
    let Dalton = UnifiedAtomicMassUnit
    
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
    
    /// The ångström (or angstrom) is a unit of length equal to 10^−10 m (one ten-billionth of a meter) or 0.1 nanometer.
    /// Its symbol is Å, a letter in the Swedish alphabet.
    let Angstrom                = Constant("ångström",                      "Å",        E 1.0 -10,              Meter                               )
    
    /// The hartree (symbol: Eₕ or Ha), also known as the Hartree energy,
    /// is the atomic unit of energy, named after the British physicist Douglas Hartree.
    /// https://en.wikipedia.org/wiki/Hartree
    /// http://physics.nist.gov/cgi-bin/cuu/Value?hr
    let Hartree                 = Constant("hartree",                       "Eₕ",       E 4.359_744_650 -18,    Joule                               )
    //let Hartree               = Constant("hartree",                       "Eₕ",       2 * RydbergConstant * h * c)
    /// The hartree (symbol: Eₕ or Ha), also known as the Hartree energy,
    /// is the atomic unit of energy, named after the British physicist Douglas Hartree.
    /// https://en.wikipedia.org/wiki/Hartree
    /// http://physics.nist.gov/cgi-bin/cuu/Value?hr
    let Eₕ = Hartree
    
    /// The standard acceleration due to gravity (or standard acceleration of free fall),
    /// sometimes abbreviated as standard gravity, usually denoted by ɡₒ or ɡₙ, is the nominal
    /// gravitational acceleration of an object in a vacuum near the surface of the Earth.
    /// It is defined by standard as 9.80665 m/s2, which is exactly 35.30394 km/(h·s)
    /// (about 32.174 ft/s2, or 21.937 mph/s).
    /// https://en.wikipedia.org/wiki/Standard_gravity
    /// http://physics.nist.gov/cgi-bin/cuu/Value?gn
    let StandardGravity         = Constant("standard gravity",              "gₙ",       9.806_65,            Meter / (Second.Pow(2))                )
    /// The standard acceleration due to gravity (or standard acceleration of free fall),
    /// sometimes abbreviated as standard gravity, usually denoted by ɡₒ or ɡₙ, is the nominal
    /// gravitational acceleration of an object in a vacuum near the surface of the Earth.
    /// It is defined by standard as 9.80665 m/s2, which is exactly 35.30394 km/(h·s)
    /// (about 32.174 ft/s2, or 21.937 mph/s).
    /// https://en.wikipedia.org/wiki/Standard_gravity
    /// http://physics.nist.gov/cgi-bin/cuu/Value?gn
    let ɡₒ = StandardGravity
    /// The standard acceleration due to gravity (or standard acceleration of free fall),
    /// sometimes abbreviated as standard gravity, usually denoted by ɡₒ or ɡₙ, is the nominal
    /// gravitational acceleration of an object in a vacuum near the surface of the Earth.
    /// It is defined by standard as 9.80665 m/s2, which is exactly 35.30394 km/(h·s)
    /// (about 32.174 ft/s2, or 21.937 mph/s).
    /// https://en.wikipedia.org/wiki/Standard_gravity
    /// http://physics.nist.gov/cgi-bin/cuu/Value?gn
    let gₙ = StandardGravity

    /// The kilogram-force (kgf or kgF), or kilopond (kp, from Latin pondus meaning weight),
    /// is a gravitational metric unit of force. It is equal to the magnitude of the force
    /// exerted by one kilogram of mass in a 9.80665 m/s2 gravitational field (standard gravity,
    /// a conventional value approximating the average magnitude of gravity on Earth).
    /// Therefore, one kilogram-force is by definition equal to 9.80665 N.
    /// https://en.wikipedia.org/wiki/Kilogram-force
    let KilogramForce           = Constant("kilogram-force",    "kgf",      Kilogram * StandardGravity                                  )
    /// The kilogram-force (kgf or kgF), or kilopond (kp, from Latin pondus meaning weight),
    /// is a gravitational metric unit of force. It is equal to the magnitude of the force
    /// exerted by one kilogram of mass in a 9.80665 m/s2 gravitational field (standard gravity,
    /// a conventional value approximating the average magnitude of gravity on Earth).
    /// Therefore, one kilogram-force is by definition equal to 9.80665 N.
    /// https://en.wikipedia.org/wiki/Kilogram-force
    let Kilopond                = Constant("kilopond",          "kp",       Kilogram * StandardGravity                                  )

    /// The poundal (pdl) is defined as the force necessary to accelerate 1 pound-mass
    /// at 1 foot per second per second.
    /// 1 pdl = 0.138254954376 N exactly.
    /// https://en.wikipedia.org/wiki/Poundal
    let Poundal                 = U("poundal",                  "pdl",      International.Pound * International.Foot / (Second.Pow(2))  )

    /// The pound-force (lbf) is equal to the gravitational force exerted on
    /// a mass of one avoirdupois pound on the surface of Earth.
    /// The acceleration of the standard gravitational field (gn) and the
    /// international avoirdupois pound (lb) define the pound-force as 4.4482216152605 N
    /// https://en.wikipedia.org/wiki/Pound_(force)
    let PoundForce              = U("pound-force",              "lbf",      (International.Pound * StandardGravity) |> U                )
    
    /// A slug is defined as the mass that is accelerated by 1 ft/s2 when
    /// a force of one pound (lbf) is exerted on it.
    /// https://en.wikipedia.org/wiki/Slug_(mass)
    let Slug                    = U("slug",                     "slug",     PoundForce * (Second.Pow(2)) / International.Foot           )

    /// One newton meter is equal to the torque resulting from a force of
    /// one newton applied perpendicularly to a moment arm which is one meter long.
    /// https://en.wikipedia.org/wiki/Newton_metre
    let NewtonMeter             = U("newton meter",             "Nm",       Newton * Meter                                              )

    /// Angular frequency ω (in radians per second), is larger than frequency
    /// (in cycles per second, also called Hz),
    /// by a factor of 2π, because 2π rad/s corresponds to 1 Hz.
    /// https://en.wikipedia.org/wiki/Radian_per_second
    let RadiansPerSecond        = U("radians per second",       "ω",        Radian/Second                                               )

    /// The number of rotations around a fixed axis in one minute.
    /// It is used as a measure of rotational speed of a mechanical component.
    /// https://en.wikipedia.org/wiki/Revolutions_per_minute
    let RevolutionsPerMinute    = U("revolutions per minute",   "rpm",      Hertz,              1R / 60                                 )
    
    /// One dyne is equal to 10 micronewtons.
    /// https://en.wikipedia.org/wiki/Dyne
    let Dyne                    = U("dyne",                     "dyn",      Newton,             E 1.0 -5                                )

    /// The dyne per centimeter is a unit traditionally used to measure surface tension.
    /// For example, the surface tension of distilled water is 72 dyn/cm at 25 °C.
    let DynePerCentimeter       = Dyne/Centimeter
    
    let MetersPerSecond         = Meter/Second
    let KilometersPerHour       = Kilometer/Hour
    let KilometersPerSecond     = Kilometer/Second
    let FeetPerSecond           = International.Foot/Second
    let MilesPerHour            = U("miles per hour",           "mph",      International.Mile/Hour                     )
    
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
    /// https://en.wikipedia.org/wiki/Horsepower
    let HorsepowerImperial      = U("imperial horsepower",      "hp",   Watt,                   745.7                   )
    /// 1 horsepower (hp) is equal to 745.7 watts.
    /// https://en.wikipedia.org/wiki/Horsepower
    let HP                      = HorsepowerImperial

    /// 1 horsepower (PS) is equal to 735.5 watts.
    /// https://en.wikipedia.org/wiki/Horsepower
    let HorsepowerMetric        = U("metric horsepower",        "PS",   Watt,                   735.5                   )
    /// 1 horsepower (PS) is equal to 735.5 watts.
    /// https://en.wikipedia.org/wiki/Horsepower
    let PS                      = HorsepowerMetric

    /// 1 BTU (British Thermal Unit) is equal to 1055.06 joules.
    /// See ISO 31-4 on Quantities and units—Part 4: Heat (https://books.google.com/books?id=-ZveBwAAQBAJ&pg=PA19-IA35).
    /// https://en.wikipedia.org/wiki/British_thermal_unit
    let BTU                     = U("british thermal unit",     "BTU",  Joule,                  1055.06                 )
    
    /// Pressure, stress (SI derived unit).
    let Kilopascal              = Kilo * Pascal

    /// The standard atmosphere (symbol: atm) is a unit of pressure defined as 101325 Pa (1.01325 bar).
    /// It is sometimes used as a reference or standard pressure.
    /// https://en.wikipedia.org/wiki/Atmosphere_(unit)
    let Atmosphere              = Constant("standard atmosphere",   "atm",      101_325,        Pascal                  )
    /// The standard atmosphere (symbol: atm) is a unit of pressure defined as 101325 Pa (1.01325 bar).
    /// It is sometimes used as a reference or standard pressure.
    /// https://en.wikipedia.org/wiki/Atmosphere_(unit)
    let atm = Atmosphere

    /// The bar is a metric unit of pressure, but is not approved as part of the International System of Units (SI).
    /// It is defined as exactly equal to 100,000 Pa, which is slightly less than the
    /// current average atmospheric pressure on Earth at sea level.
    /// https://en.wikipedia.org/wiki/Bar_(unit)
    let Bar                     = U("bar",                      "bar",  Pascal,                 10_000                  )
    
    /// The barye (symbol: Ba), or sometimes barad, barrie, bary, baryd, baryed, or barie,
    /// is the centimetre–gram–second (CGS) unit of pressure. It is equal to 1 dyne per square centimetre.
    /// https://en.wikipedia.org/wiki/Barye
    let Barye                   = U("barye",                    "Ba",   Pascal,                 0.1                     )
    
    /// The pound per square inch or, more accurately, pound-force per square inch (symbol: lbf/in2; abbreviation: psi)
    /// is a unit of pressure or of stress based on avoirdupois units.
    /// It is the pressure resulting from a force of one pound-force applied to an area of one square inch.
    /// Therefore, one pound per square inch is approximately 6894.757 Pascal.
    /// https://en.wikipedia.org/wiki/Pounds_per_square_inch
    let PoundsPerSquareInch     = U("pounds per square inch",   "psi",  International.Pound / International.SquareInch  )
    /// The pound per square inch or, more accurately, pound-force per square inch (symbol: lbf/in2; abbreviation: psi)
    /// is a unit of pressure or of stress based on avoirdupois units.
    /// It is the pressure resulting from a force of one pound-force applied to an area of one square inch.
    /// Therefore, one pound per square inch is approximately 6894.757 Pascal.
    /// https://en.wikipedia.org/wiki/Pounds_per_square_inch
    let PSI                     = PoundsPerSquareInch
 