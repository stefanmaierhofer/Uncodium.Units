using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Uncodium.Units.Unit;

namespace Uncodium.Units.Tests
{
    [TestFixture]
    public class UnitOfMeasureTests
    {
        [Test]
        public void Dimensions_CanCreateBaseUnit()
        {
            var m = new UnitOfMeasure("meter", "m");
            Assert.IsTrue(m.Name == "meter");
            Assert.IsTrue(m.Symbol == "m");
            Assert.IsTrue(m.Factor == Fraction.One);
            Assert.IsTrue(m.IsBaseUnit == true);
            Assert.IsTrue(m.BaseUnits.Count == 0);
        }

        [Test]
        public void Dimensions_CanCreateScaledUnit()
        {
            var m = new UnitOfMeasure("meter", "m");
            var cm = new UnitOfMeasure("centimeter", "cm", m, new Fraction(1, 100));
            Assert.IsTrue(cm.Name == "centimeter");
            Assert.IsTrue(cm.Symbol == "cm");
            Assert.IsTrue(cm.Factor == new Fraction(1, 100));
            Assert.IsTrue(cm.IsBaseUnit == false);
            Assert.IsTrue(cm.BaseUnits.Count == 1);
            Assert.IsTrue(cm.BaseUnits.Powers[0].Unit == m);
            Assert.IsTrue(cm.BaseUnits.Powers[0].Power == 1);
        }

        [Test]
        public void Dimensions_UnitPerSameUnitYieldsDimensionlessUnit()
        {
            var m = new UnitOfMeasure("meter", "m");
            var u = m / m;

            Assert.IsTrue(u.Name == "");
            Assert.IsTrue(u.Symbol == "");
            Assert.IsTrue(u.Factor == new Fraction(1, 1));
            Assert.IsTrue(u.IsBaseUnit == true);

            Assert.IsTrue(u.BaseUnits.Count == 0);
        }

        [Test]
        public void CanCombineBaseUnits()
        {
            var m = new UnitOfMeasure("meter", "m");
            var s = new UnitOfMeasure("second", "s");
            var x = m / s;

            Assert.IsTrue(x.Factor == new Fraction(1, 1));
            Assert.IsTrue(x.IsBaseUnit == false);

            Assert.IsTrue(x.BaseUnits.Count == 2);
            Assert.IsTrue(x.BaseUnits.Powers[0].Unit == m);
            Assert.IsTrue(x.BaseUnits.Powers[0].Power == 1);
            Assert.IsTrue(x.BaseUnits.Powers[1].Unit == s);
            Assert.IsTrue(x.BaseUnits.Powers[1].Power == -1);
        }

        [Test]
        public void CanCombineDifferentScaledUnits()
        {
            var x = Kilometer / Hour;

            Assert.IsTrue(x.Factor == new Fraction(1, 1));
            Assert.IsTrue(x.IsBaseUnit == false);

            Assert.IsTrue(x.BaseUnits.Count == 2);
            Assert.IsTrue(x.BaseUnits.Powers[0].Unit == Kilometer);
            Assert.IsTrue(x.BaseUnits.Powers[0].Power == 1);
            Assert.IsTrue(x.BaseUnits.Powers[1].Unit == Hour);
            Assert.IsTrue(x.BaseUnits.Powers[1].Power == -1);
        }

        [Test]
        public void CanCombineSameScaledUnits_1()
        {
            var x = Kilometer * Centimeter;

            Assert.IsTrue(x.Factor == new Fraction(1, 100));
            Assert.IsTrue(x.IsBaseUnit == false);

            Assert.IsTrue(x.BaseUnits.Count == 1);
            Assert.IsTrue(x.BaseUnits.Powers[0].Unit == Kilometer);
            Assert.IsTrue(x.BaseUnits.Powers[0].Power == 2);
        }

        [Test]
        public void CanCombineSameScaledUnits_2()
        {
            var x = Centimeter * Kilometer;

            Assert.IsTrue(x.Factor == new Fraction(100, 1));
            Assert.IsTrue(x.IsBaseUnit == false);

            Assert.IsTrue(x.BaseUnits.Count == 1);
            Assert.IsTrue(x.BaseUnits.Powers[0].Unit == Centimeter);
            Assert.IsTrue(x.BaseUnits.Powers[0].Power == 2);
        }

        [Test]
        public void CombinedUnit_Symbol_1()
        {
            var m = new UnitOfMeasure("meter", "m");
            var s = new UnitOfMeasure("second", "s");
            var meterPerSecond = m / s;

            Assert.IsTrue(meterPerSecond.Name == "[m^1][s^-1]");
            Assert.IsTrue(meterPerSecond.Symbol == "m/s");
        }
        
        [Test]
        public void CombinedUnit_Symbol_2()
        {
            var m = new UnitOfMeasure("meter", "m");
            var s = new UnitOfMeasure("second", "s");
            var meterPerSecond = m * s;

            Assert.IsTrue(meterPerSecond.Name == "[m^1][s^1]");
            Assert.IsTrue(meterPerSecond.Symbol == "m*s");
        }

        [Test]
        public void CombinedUnit_Symbol_3()
        {
            var x = Kilometer / Hour;

            Assert.IsTrue(x.Name == "[km^1][h^-1]");
            Assert.IsTrue(x.Symbol == "km/h");
        }

        [Test]
        public void CombinedUnit_Symbol_4()
        {
            var x = Kilometer * Hour;

            Assert.IsTrue(x.Name == "[km^1][h^1]");
            Assert.IsTrue(x.Symbol == "km*h");
        }

        [Test]
        public void CombinedUnit_Symbol_5()
        {
            var x = Kilometer * Centimeter;

            Assert.IsTrue(x.Name == "[km^2]");
            Assert.IsTrue(x.Symbol == "km^2");
        }

        [Test]
        public void CombinedUnit_Symbol_6()
        {
            var x = Centimeter * Kilometer;

            Assert.IsTrue(x.Name == "[cm^2]");
            Assert.IsTrue(x.Symbol == "cm^2");
        }

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
    }
}
