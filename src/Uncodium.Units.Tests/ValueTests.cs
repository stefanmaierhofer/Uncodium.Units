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
    public class ValueTests
    {
        [Test]
        public void Dimensions_1()
        {
            var a = 1.0 * Meter / Second;
            var b = 3.6 * Kilometer / Hour;
            Assert.IsTrue(a == b);
        }

        [Test]
        public void Dimensions_2()
        {
            var a = 80 * Centimeter + 2 * Decimeter;
            Assert.IsTrue(a.Unit == Centimeter);
            Assert.IsTrue(a.X.Numerator == 100);
            Assert.IsTrue(a.X.Denominator == 1);
        }

        [Test]
        public void Dimensions_3()
        {
            var a = 2 * Decimeter + 80 * Centimeter;
            Assert.IsTrue(a.Unit == Decimeter);
            Assert.IsTrue(a.X.Numerator == 10);
            Assert.IsTrue(a.X.Denominator == 1);
        }

        [Test]public void Formatting_1() => Assert.IsTrue((80 * Centimeter + 2 * Decimeter).ToString() == "100 cm");
        [Test]public void Formatting_2() => Assert.IsTrue((2 * Decimeter + 80 * Centimeter).ToString() == "10 dm");
        [Test]public void Formatting_3() => Assert.IsTrue((1 * Meter / Second).ToString() == "1 m/s");
        [Test]public void Formatting_4() => Assert.IsTrue((1 * Meter / Second).ToString() == "1 m/s");
        [Test] public void Formatting_5() => Assert.IsTrue((3.6 * Kilometer / Hour).ToString() == "3.6 km/h");
        [Test] public void Formatting_6() => Assert.IsTrue((1 * International.Foot / Second).ToString() == "1 ft/s");
        [Test] public void Formatting_7() => Assert.IsTrue((new Fraction(3600, 1000) * Kilogram * KilometersPerHour).ToString() == "1 [kg^1][m^1][s^-1]");
        [Test] public void Formatting_8() => Assert.IsTrue((1 * SquareMeter + 50 * SquareDecimeter).ToString() == "1.5 m²");
        [Test] public void Formatting_9() => Assert.IsTrue((50 * SquareDecimeter + 1 * SquareMeter).ToString() == "150 dm²");
        [Test] public void Formatting_10() => Assert.IsTrue((50 * Decimeter * Decimeter + 1 * Meter * Meter).ToString() == "1.5 [m^2]");
    }
}
