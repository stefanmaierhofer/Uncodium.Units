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
        public void CanCreateBaseUnit()
        {
            var m = new UnitOfMeasure("meter", "m");
            Assert.IsTrue(m.Name == "meter");
            Assert.IsTrue(m.Symbol == "m");
            Assert.IsTrue(m.Factor == Fraction.One);
            Assert.IsTrue(m.IsBaseUnit == true);
            Assert.IsTrue(m.BaseUnits.Count == 0);
        }

        [Test]
        public void CanCreateScaledUnit()
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

        [Test] public void NullNameWillThrow() => Assert.Throws<ArgumentException>(() => new UnitOfMeasure(null, "foo"));
        [Test] public void NullSymbolWillThrow() => Assert.Throws<ArgumentException>(() => new UnitOfMeasure("foo", null));
        [Test] public void EmptyNameWillNotThrow() => new UnitOfMeasure("", "foo");
        [Test] public void EmptySymbolWillNotThrow() => new UnitOfMeasure("foo", "");

        [Test]
        public void UnitPerSameUnitYieldsDimensionlessUnit()
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
        public void CanCombineBaseUnits1()
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
        public void CanCombineBaseUnits2()
        {
            var x = Meter / Meter;

            Assert.IsTrue(x.Factor == new Fraction(1, 1));
            Assert.IsTrue(x.IsBaseUnit == true);

            Assert.IsTrue(x.BaseUnits.Count == 0);
        }

        [Test]
        public void CanCombineBaseUnits3()
        {
            var a = Meter / Meter;
            var b = Meter / Meter;
            var x = a / b;

            Assert.IsTrue(x.Factor == new Fraction(1, 1));
            Assert.IsTrue(x.IsBaseUnit == true);

            Assert.IsTrue(x.BaseUnits.Count == 0);
        }

        [Test]
        public void CanCombineBaseUnits4()
        {
            var a = Meter / Meter;
            var b = Meter / Meter;
            var x = a * b;

            Assert.IsTrue(x.Factor == new Fraction(1, 1));
            Assert.IsTrue(x.IsBaseUnit == true);

            Assert.IsTrue(x.BaseUnits.Count == 0);
        }

        [Test]
        public void CanCombineDifferentScaledUnits()
        {
            var x = Kilometer / Hour;

            Assert.IsTrue(x.Factor == new Fraction(1000, 3600));
            Assert.IsTrue(x.IsBaseUnit == false);

            Assert.IsTrue(x.BaseUnits.Count == 2);
            Assert.IsTrue(x.BaseUnits.Powers[0].Unit == Meter);
            Assert.IsTrue(x.BaseUnits.Powers[0].Power == 1);
            Assert.IsTrue(x.BaseUnits.Powers[1].Unit == Second);
            Assert.IsTrue(x.BaseUnits.Powers[1].Power == -1);
        }

        [Test]
        public void CanCombineSameScaledUnits_1()
        {
            var x = Kilometer * Centimeter;

            Assert.IsTrue(x.Factor == new Fraction(1000, 100));
            Assert.IsTrue(x.IsBaseUnit == false);

            Assert.IsTrue(x.BaseUnits.Count == 1);
            Assert.IsTrue(x.BaseUnits.Powers[0].Unit == Meter);
            Assert.IsTrue(x.BaseUnits.Powers[0].Power == 2);
        }

        [Test]
        public void CanCombineSameScaledUnits_2()
        {
            var x = Centimeter * Kilometer;

            Assert.IsTrue(x.Factor == new Fraction(1000, 100));
            Assert.IsTrue(x.IsBaseUnit == false);

            Assert.IsTrue(x.BaseUnits.Count == 1);
            Assert.IsTrue(x.BaseUnits.Powers[0].Unit == Meter);
            Assert.IsTrue(x.BaseUnits.Powers[0].Power == 2);
        }

        [Test]
        public void CombinedUnit_Symbol_1()
        {
            var x = Meter / Second;

            Assert.IsTrue(x.Name == "[m^1][s^-1]");
            Assert.IsTrue(x.Symbol == "m/s");
        }

        [Test]
        public void CombinedUnit_Symbol_2()
        {
            var x = Meter * Second;

            Assert.IsTrue(x.Name == "[m^1][s^1]");
            Assert.IsTrue(x.Symbol == "m*s");
        }

        [Test]
        public void CombinedUnit_Symbol_3()
        {
            var x = Kilometer / Hour;

            Assert.IsTrue(x.Factor == new Fraction(1000, 3600));
            Assert.IsTrue(x.Name == "[m^1][s^-1]");
            Assert.IsTrue(x.Symbol == "km/h");
        }

        [Test]
        public void CombinedUnit_Symbol_4()
        {
            var x = Kilometer * Hour;

            Assert.IsTrue(x.Factor == new Fraction(1000 * 3600));
            Assert.IsTrue(x.Name == "[m^1][s^1]");
            Assert.IsTrue(x.Symbol == "km*h");
        }

        [Test]
        public void CombinedUnit_Symbol_5()
        {
            var x = Kilometer * Centimeter;

            Assert.IsTrue(x.Factor == new Fraction(1000, 100));
            Assert.IsTrue(x.Name == "[m^2]");
            Assert.IsTrue(x.Symbol == "[m^2]");
        }

        [Test]
        public void CombinedUnit_Symbol_6()
        {
            var x = Centimeter * Kilometer;

            Assert.IsTrue(x.Factor == new Fraction(1000, 100));
            Assert.IsTrue(x.Name == "[m^2]");
            Assert.IsTrue(x.Symbol == "[m^2]");
        }

        [Test]
        public void CombinedUnit_Symbol_7()
        {
            var x = Foot / Second;

            Assert.IsTrue(x.Name == "[m^1][s^-1]");
            Assert.IsTrue(x.Symbol == "ft/s");
        }

        [Test]
        public void CombinedUnit_Symbol_8()
        {
            var x = MilesPerHour * Kilogram;

            Assert.IsTrue(x.Name == "[kg^1][m^1][s^-1]");
            Assert.IsTrue(x.Symbol == "[kg^1][m^1][s^-1]");
        }

        [Test]
        public void CombinedUnit_Symbol_9()
        {
            var a = Kilogram * Meter / Second;
            var x = a / Kilogram;

            Assert.IsTrue(x.Name == "[m^1][s^-1]");
            Assert.IsTrue(x.Symbol == "[m^1][s^-1]");
        }

        [Test]
        public void CombinedUnit_Symbol_10()
        {
            var x = Meter / Meter;

            Assert.IsTrue(x.Name == "");
            Assert.IsTrue(x.Symbol == "");
        }

        [Test]
        public void CombinedUnit_Symbol_11()
        {
            var x = Kilometer / Kilometer;

            Assert.IsTrue(x.Name == "");
            Assert.IsTrue(x.Symbol == "");
        }

        [Test]
        public void CombinedUnit_Symbol_12()
        {
            var x = (Meter / Meter) * (Meter / Meter);

            Assert.IsTrue(x.Name == "");
            Assert.IsTrue(x.Symbol == "");
        }

        [Test]
        public void CombinedUnit_Symbol_13()
        {
            var x = (Meter / Meter) / (Meter / Meter);

            Assert.IsTrue(x.Name == "");
            Assert.IsTrue(x.Symbol == "");
        }

        [Test]
        public void CombinedUnit_Symbol_14()
        {
            var x = 1 / Meter;

            Assert.IsTrue(x.Name == "[m^-1]");
            Assert.IsTrue(x.Symbol == "1/m");
        }

        [Test]
        public void CombinedUnit_Symbol_15()
        {
            var x = 1 / Kilometer;

            Assert.IsTrue(x.Name == "[m^-1]");
            Assert.IsTrue(x.Symbol == "1/km");
        }

        [Test]
        public void CombinedUnit_Symbol_16()
        {
            var x = 1 / MetersPerSecond;

            Assert.IsTrue(x.Name == "[s^1][m^-1]");
            Assert.IsTrue(x.Symbol == "[s^1][m^-1]");
        }

        [Test]
        public void CombinedUnit_Symbol_17()
        {
            var x = 1 / (Meter / Second);

            Assert.IsTrue(x.Name == "[s^1][m^-1]");
            Assert.IsTrue(x.Symbol == "[s^1][m^-1]");
        }

        [Test]
        public void CombinedUnit_Symbol_18()
        {
            var x = 1 / KilometersPerHour;

            Assert.IsTrue(x.Name == "[s^1][m^-1]");
            Assert.IsTrue(x.Symbol == "[s^1][m^-1]");
        }

        [Test]
        public void CombinedUnit_Symbol_19()
        {
            var x = 1 / (Kilometer / Hour);

            Assert.IsTrue(x.Name == "[s^1][m^-1]");
            Assert.IsTrue(x.Symbol == "[s^1][m^-1]");
        }

        [Test]
        public void CombinedUnit_Symbol_20()
        {
            var x = 1 / MetersPerSecond;

            Assert.IsTrue(x.Name == "[s^1][m^-1]");
            Assert.IsTrue(x.Symbol == "[s^1][m^-1]");
        }
    }
}
