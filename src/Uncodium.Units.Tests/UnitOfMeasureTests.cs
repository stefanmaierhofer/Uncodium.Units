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
        [Test] public void CanCreateFraction_double() => Assert.IsTrue(1.0 * Meter / Second == 3.6 * Kilometer / Hour);
    }
}
