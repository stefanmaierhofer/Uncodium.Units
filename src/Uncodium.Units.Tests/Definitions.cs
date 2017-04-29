using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Uncodium.Units.SI;
using static Uncodium.Units.Time;
using static Uncodium.Units.Physics;

namespace Uncodium.Units.Tests
{
    [TestFixture]
    public class Definitions
    {
        [Test] public void Inch_International()     => Assert.IsTrue(   1 * International.Inch      ==  Centimeter                  *    2.54                               );
        [Test] public void Foot_International_1()   => Assert.IsTrue(   1 * International.Foot      ==  International.Inch          *    12                                 );
        [Test] public void Foot_International_2()   => Assert.IsTrue(   1 * International.Foot      ==  Us.Survey.Foot              *    new Fraction(999_998, 1_000_000)   );
        [Test] public void Foot_International_3()   => Assert.IsTrue(   1 * International.Foot      ==  Meter                       *    12 * new Fraction(254, 10_000)     );
        [Test] public void Foot_International_4()   => Assert.IsTrue(   1 * International.Foot      ==  Us.Survey.Foot              *    new Fraction(254, 10_000) * new Fraction(3_937, 100) );
        [Test] public void Yard_International()     => Assert.IsTrue(   1 * International.Yard      ==  International.Foot          *    3                                  );
        [Test] public void Mile_International_1()   => Assert.IsTrue(   1 * International.Mile      ==  International.Yard          *    1_760                              );
        [Test] public void Mile_International_2()   => Assert.IsTrue(   1 * International.Mile      ==  Us.Survey.Mile              *    new Fraction(999_998, 1_000_000)   );
                                                                                                                                    
                                                                                                                                    
        [Test] public void Link_UsSurvey()          => Assert.IsTrue(   1 * Us.Survey.Link          ==  Us.Survey.Chain             *    new Fraction(1, 100)               );
        [Test] public void Foot_UsSurvey()          => Assert.IsTrue(   1 * Us.Survey.Foot          ==  Meter                       *    new Fraction(1_200, 3_937)         );
        [Test] public void Rod_UsSurvey()           => Assert.IsTrue(   1 * Us.Survey.Rod           ==  Us.Survey.Link              *    25                                 );
        [Test] public void Chain_UsSurvey()         => Assert.IsTrue(   1 * Us.Survey.Chain         ==  Us.Survey.Foot              *    66                                 );
        [Test] public void Mile_UsSurvey()          => Assert.IsTrue(   1 * Us.Survey.Mile          ==  Us.Survey.Foot              *    5_280                              );


        [Test] public void Apothecaries_1()         => Assert.IsTrue(   1 * International.Pound     ==  International.Grain         * 7_000                                 );
        [Test] public void Apothecaries_2()         => Assert.IsTrue(   1 * International.Pound     ==  International.Scruple       * 350                                   );
        [Test] public void Apothecaries_3()         => Assert.IsTrue(   1 * International.Pound     ==  International.Dram          * 256                                   );


    }
}
