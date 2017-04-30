namespace Uncodium.Units

open System
open System.Numerics
  
module Physics =

    open Fun
    open Prefix
    open SI
    open Time
      
    /// c
    let SpeedOfLight            = Constant("speed of light",                "c",        299_792_458,                        Meter / Second          )
        
    /// G
    let GravitationalConstant   = Constant("gravitational constant",        "G",        66_740_831 * F.Pow(10, 18), (Meter^3) / (Kilogram * (Second^2)) )
        
    /// Planck constant, h.
    let PlanckConstant          = Constant("planck constant",               "h",        662_607_004_081I * F.Pow(10, -45),  Joule * Second          )
    /// Planck length.
    let PlanckLength            = Constant("planck length",                 "lP",       161_619_997I * F.Pow(10, -43),      Meter                   )
    /// Planck mass.
    let PlanckMass              = Constant("planck mass",                   "mP",       21_765_113I * F.Pow(10, -15),       Kilogram                )
    /// Planck time.
    let PlanckTime              = Constant("planck time",                   "tP",       53_910_632I * F.Pow(10, -51),       Second                  )
    /// Planck charge.
    let PlanckCharge            = Constant("planck charge",                 "qP",       53_910_632I * F.Pow(10, -51),       Coulomb                 )
    /// Planck temperature.
    let PlanckTemperature       = Constant("planck temperature",            "TP",       141_683_385I * F.Pow(10, 24),       Kelvin                  )

    /// The ångström (or angstrom) is a unit of length equal to 10^−10 m (one ten-billionth of a meter) or 0.1 nanometer.
    /// Its symbol is Å, a letter in the Swedish alphabet.
    let Angstrom                = Constant("ångström",                      "Å",        F.Pow(10, -10), Meter                                       )
        
    /// Dirac constant, ħ (pronounced "h-bar").
    let DiracConstant           = Constant("planck constant",               "ħ",        105_457_180_013I * F.Pow(10, -45),  Joule * Second          )

    /// Fine-structure constant (also known as Sommerfeld's constant).
    let FineStructureConstant   = Constant("fine-structure constant",       "α",        7_297_352_566_417I * F.Pow(10, 15)                          )

    /// The hartree (symbol: Eh or Ha), also known as the Hartree energy,
    /// is the atomic unit of energy, named after the British physicist Douglas Hartree.
    let Hartree                 = Constant("hartree",                       "Ha",       435_974_465_054I * F.Pow(10, 29),   Joule                   )

    /// Proton mass.
    let ProtonMass              = Constant("proton mass",                   "mp",       167_262_189_821I * F.Pow(10, 38),   Kilogram                )

    /// The amount of energy gained (or lost) by the charge of a single electron moving across
    /// an electric potential difference of one volt (1.6021766208(98)×10^−19 joule).
    let Electronvolt            = Constant("electronvolt",                  "eV",       1_602_176_620_898I * F.Pow(10, 31), Joule                   )
    
    /// g0
    let StandardGravity         = Constant("standard gravity",              "g0",       F(980_665, 100_000),            Meter / (Second ^ 2)        )

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
    let NewtonMeter             = U("newton meter",             "N·m",      Newton * Meter                              )

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
    let DynePerCentimeter       = U("dyne per centimeter",      "dyn/cm", Dyne/Centimeter                               )

    (* Speed *)

    let MetersPerSecond         = U("meters per second",        "m/s",   Meter/Second                                   )
    let FeetPerSecond           = U("feet per second",          "ft/s",  US.Survey.Foot/Second                          )
    let KilometersPerHour       = U("kilometers per hour",      "km/h",  Kilometer/Hour                                 )
    let KilometersPerSecond     = U("kilometers per second",    "km/s",  Kilometer/Second                               )
    let MilesPerHour            = U("miles per hour",           "mph",   US.Survey.Mile/Hour                            )

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
    /// 1 horsepower (PS) is equal to 735.5 watts.
    let HorsepowerMetric        = U("metric horsepower",        "PS",   Watt,                   F(7_355, 10)            )

    /// 1 BTU (British Thermal Unit) is equal to 1055.06 joules.
    /// See ISO 31-4 on Quantities and units—Part 4: Heat (https://books.google.com/books?id=-ZveBwAAQBAJ&pg=PA19-IA35).
    let BTU                     = U("british thermal unit",     "BTU",  Joule,                  F(105506, 100)          )
    
    (* Pressure *)

    let Kilopascal              = Kilo * Pascal
    let Bar                     = U("bar",                      "bar",  Pascal,                 10_000                  )
    let PoundsPerSquareInch     = U("pounds per square inch",   "psi",  International.Pound / International.SquareInch  )
    let Barye                   = U("barye",                    "Ba",   Pascal,                 F(1, 10)                )
 