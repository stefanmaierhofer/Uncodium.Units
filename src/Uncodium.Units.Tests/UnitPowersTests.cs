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
        public void UnitWithPowerZeroWillThrow_1() => Assert.Throws<ArgumentException>(() => new UnitPowers(Meter, 0));
        [Test]
        public void UnitWithPowerZeroWillThrow_2() => Assert.Throws<ArgumentException>(() => new UnitPowers(new[] { new UnitPower(Meter, 1), new UnitPower(Second, 0) }));
        [Test]
        public void NonBaseUnitWillThrow() => Assert.Throws<ArgumentException>(() => new UnitPowers(Gram, 1));

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
