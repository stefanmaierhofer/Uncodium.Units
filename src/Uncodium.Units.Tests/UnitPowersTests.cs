using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Uncodium.Units.Tests
{
    using static SI;

    [TestFixture]
    public class UnitPowersTests
    {
        [Test]
        public void NonBaseUnitWillThrow() => Assert.Throws<ArgumentException>(() => new UnitPowers(Gram, 1));

        #region Equality

        [Test]
        public void Equality1() => Assert.IsTrue(new UnitPowers() == new UnitPowers());
        [Test]
        public void Equality2() => Assert.IsTrue(new UnitPowers(Meter, 1) == new UnitPowers(Meter, 1));
        [Test]
        public void Equality3() => Assert.IsTrue(new UnitPowers(Meter, 2) != new UnitPowers(Meter, 1));
        [Test]
        public void Equality4() => Assert.IsTrue(new UnitPowers(Meter, 1) != new UnitPowers(Meter, 2));
        [Test]
        public void Equality5() => Assert.IsTrue(new UnitPowers(Meter, 1) != new UnitPowers(Second, 1));
        [Test]
        public void Equality6()
        {
            var a = new UnitPowers(new[] { new UnitPower(Meter, 1) });
            var b = new UnitPowers(new[] { new UnitPower(Meter, 1), new UnitPower(Second, 1) });
            
            Assert.IsTrue(a != b);
        }
        [Test]
        public void Equality7()
        {
            var a = new UnitPowers(new[] { new UnitPower(Meter, 1), new UnitPower(Second, 1) });
            var b = new UnitPowers(new[] { new UnitPower(Meter, 1), new UnitPower(Second, 1) });

            Assert.IsTrue(a == b);
        }
        [Test]
        public void Equality8()
        {
            var a = new UnitPowers(new[] { new UnitPower(Meter, 1), new UnitPower(Second, 1) });
            var b = new UnitPowers(new[] { new UnitPower(Second, 1), new UnitPower(Meter, 1) });

            Assert.IsTrue(a == b);
        }
        [Test]
        public void Equality9()
        {
            var a = new UnitOfMeasure("meter", "m");
            var b = new UnitOfMeasure("meter", "m");

            Assert.IsTrue(a.BaseUnits == b.BaseUnits);
        }

        #endregion

        #region Pow

        [Test]
        public void Pow1()
        {
            var a = new UnitPowers(new[] { new UnitPower(Meter, 1), new UnitPower(Second, 2) });
            Assert.IsTrue(a * a == a.Pow(2));
            Assert.IsTrue(a * a * a == a.Pow(3));
            Assert.IsTrue(a * a * a * a == a.Pow(4));
        }

        [Test]
        public void Pow2()
        {
            var a = new UnitPowers(new[] { new UnitPower(Meter, 1), new UnitPower(Second, 2) });
            var r = a.Pow(2);

            Assert.IsTrue(r.Powers[0].Unit == Meter && r.Powers[0].Power == 2);
            Assert.IsTrue(r.Powers[1].Unit == Second && r.Powers[1].Power == 4);
        }

        [Test]
        public void Pow3()
        {
            var a = new UnitPowers(new[] { new UnitPower(Meter, 2), new UnitPower(Second, -5) });
            var r = a.Pow(-3);

            // different order! (positive powers first, then negative)
            Assert.IsTrue(r.Powers[0].Unit == Second && r.Powers[0].Power == 15);
            Assert.IsTrue(r.Powers[1].Unit == Meter && r.Powers[1].Power == -6);
        }

        #endregion

        [Test]
        public void Dimensionless()
        {
            var x = new UnitPowers();
            Assert.IsTrue(x.IsDimensionLess == true);
            Assert.IsTrue(x.Count == 0);
        }

        [Test]
        public void DimensionSingle()
        {
            var x = new UnitPowers(Meter, 1);
            Assert.IsTrue(x.IsDimensionLess == false);
            Assert.IsTrue(x.Count == 1);
        }

        [Test]
        public void MeterTimesMeter()
        {
            var a = new UnitPowers(Meter, 1);
            var x = a * a;
            Assert.IsTrue(x.IsDimensionLess == false);
            Assert.IsTrue(x.Count == 1);
            Assert.IsTrue(x.Powers[0].Unit == Meter);
            Assert.IsTrue(x.Powers[0].Power == 2);
        }

        [Test]
        public void DimensionlessTimesDimensionless()
        {
            var a = new UnitPowers();
            var x = a * a;
            Assert.IsTrue(x.IsDimensionLess == true);
            Assert.IsTrue(x.Count == 0);
        }

        [Test]
        public void DimensionlessPerDimensionless()
        {
            var a = new UnitPowers();
            var x = a / a;
            Assert.IsTrue(x.IsDimensionLess == true);
            Assert.IsTrue(x.Count == 0);
        }

        [Test]
        public void MeterPerMeter()
        {
            var a = new UnitPowers(Meter, 1);
            var x = a / a;
            Assert.IsTrue(x.IsDimensionLess == true);
            Assert.IsTrue(x.Count == 0);
        }

        [Test]
        public void MeterTimesSecond()
        {
            var a = new UnitPowers(Meter, 1);
            var b = new UnitPowers(Second, 1);
            var x = a * b;
            Assert.IsTrue(x.IsDimensionLess == false);
            Assert.IsTrue(x.Count == 2);
            Assert.IsTrue(x.Powers[0].Unit == Meter);
            Assert.IsTrue(x.Powers[0].Power == 1);
            Assert.IsTrue(x.Powers[1].Unit == Second);
            Assert.IsTrue(x.Powers[1].Power == 1);
        }

        [Test]
        public void SecondTimesMeter_Sorting()
        {
            var a = new UnitPowers(Meter, 1);
            var b = new UnitPowers(Second, 1);
            var x = b * a;
            Assert.IsTrue(x.IsDimensionLess == false);
            Assert.IsTrue(x.Count == 2);
            Assert.IsTrue(x.Powers[0].Unit == Meter);
            Assert.IsTrue(x.Powers[0].Power == 1);
            Assert.IsTrue(x.Powers[1].Unit == Second);
            Assert.IsTrue(x.Powers[1].Power == 1);
        }

        [Test]
        public void MeterPerSecond()
        {
            var a = new UnitPowers(Meter, 1);
            var b = new UnitPowers(Second, 1);
            var x = a / b;
            Assert.IsTrue(x.IsDimensionLess == false);
            Assert.IsTrue(x.Count == 2);
            Assert.IsTrue(x.Powers[0].Unit == Meter);
            Assert.IsTrue(x.Powers[0].Power == 1);
            Assert.IsTrue(x.Powers[1].Unit == Second);
            Assert.IsTrue(x.Powers[1].Power == -1);
        }

        [Test]
        public void SecondPerMeter_Sorting()
        {
            var a = new UnitPowers(Meter, 1);
            var b = new UnitPowers(Second, 1);
            var x = b / a;
            Assert.IsTrue(x.IsDimensionLess == false);
            Assert.IsTrue(x.Count == 2);
            Assert.IsTrue(x.Powers[0].Unit == Second);
            Assert.IsTrue(x.Powers[0].Power == 1);
            Assert.IsTrue(x.Powers[1].Unit == Meter);
            Assert.IsTrue(x.Powers[1].Power == -1);
        }

        [Test]
        public void DimensionlessToStringIsEmpty()
        {
            var a = new UnitPowers();
            Assert.IsTrue(a.ToString() == "");
        }
    }
}
