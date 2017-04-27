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
            Assert.IsTrue(a.X.Numerator == 100);
            Assert.IsTrue(a.X.Denominator == 1);
        }

        [Test]
        public void Dimensions_3()
        {
            var a = 2 * Decimeter + 80 * Centimeter;
            Assert.IsTrue(a.X.Numerator == 10);
            Assert.IsTrue(a.X.Denominator == 1);
        }
    }
}
