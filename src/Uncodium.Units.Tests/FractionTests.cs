using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Uncodium.Units.Tests
{
    [TestFixture]
    public class FractionTests
    {
        #region Create

        [Test] public void CannotCreateDivisionByZero_1() => Assert.Throws<DivideByZeroException>(() => new Fraction(1, 0));
        [Test] public void CannotCreateDivisionByZero_2() => Assert.Throws<DivideByZeroException>(() => new Fraction(1, -0));
        [Test] public void CannotCreateDivisionByZero_3() => Assert.Throws<DivideByZeroException>(() => new Fraction(-1, 0));
        [Test] public void CannotCreateDivisionByZero_4() => Assert.Throws<DivideByZeroException>(() => new Fraction(-1, -0));
        [Test] public void CannotCreateDivisionByZero_5() => Assert.Throws<DivideByZeroException>(() => new Fraction(0.123, 0));
        [Test] public void CannotCreateDivisionByZero_6() => Assert.Throws<DivideByZeroException>(() => new Fraction(0.123, 0.0));

        [Test]
        public void CanCreateFraction_double()
        {
            var x = new Fraction(3.1415);
            Assert.IsTrue(x.ToFloat() == 3.1415);
            Assert.IsTrue(x.Numerator == 31415 && x.Denominator == 10000);
        }

        [Test]
        public void CanCreateFraction_int()
        {
            var x = new Fraction(7);
            Assert.IsTrue(x.Numerator == 7 && x.Denominator == 1);
        }

        [Test]
        public void CanCreateFraction_long()
        {
            var x = new Fraction(5L);
            Assert.IsTrue(x.Numerator == 5 && x.Denominator == 1);
        }

        [Test]
        public void CanCreateFraction_bigint()
        {
            var x = new Fraction(new BigInteger(42));
            Assert.IsTrue(x.Numerator == 42 && x.Denominator == 1);
        }

        [Test]
        public void CanCreateFraction_bigint_bigint()
        {
            var x = new Fraction(new BigInteger(42), new BigInteger(11));
            Assert.IsTrue(x.Numerator == 42 && x.Denominator == 11);
        }

        [Test]
        public void CanCreateFraction_bigint_double()
        {
            var x = new Fraction(new BigInteger(8), 0.5); 
            Assert.IsTrue(x.Numerator == 80 && x.Denominator == 5);
        }

        [Test]
        public void CanCreateFraction_bigint_int()
        {
            var x = new Fraction(new BigInteger(2), -2);
            Assert.IsTrue(x.Numerator == -2 && x.Denominator == 2);
        }

        [Test]
        public void CanCreateFraction_double_bigint()
        {
            var x = new Fraction(0.123, new BigInteger(456));
            Assert.IsTrue(x.Numerator == 123 && x.Denominator == 456000);
        }

        [Test]
        public void CanCreateFraction_double_double_1()
        {
            var x = new Fraction(0.123, 45.6);
            Assert.IsTrue(x.Numerator == 123 && x.Denominator == 45600);
        }
        [Test]
        public void CanCreateFraction_double_double_2()
        {
            var x = new Fraction(0.0123, 0.000456);
            Assert.IsTrue(x.Numerator == 12300 && x.Denominator == 456);
        }

        [Test]
        public void CanCreateFraction_double_int()
        {
            var x = new Fraction(12.34, 10);
            Assert.IsTrue(x.Numerator == 1234 && x.Denominator == 1000);
        }

        [Test]
        public void CanCreateFraction_double_long()
        {
            var x = new Fraction(0.0123, 456L);
            Assert.IsTrue(x.Numerator == 123 && x.Denominator == 4560000);
        }

        [Test]
        public void CanCreateFraction_int_bigint()
        {
            var x = new Fraction(-1, new BigInteger(-3));
            Assert.IsTrue(x.Numerator == 1 && x.Denominator == 3);
        }

        [Test]
        public void CanCreateFraction_int_double()
        {
            var x = new Fraction(123, 456.0);
            Assert.IsTrue(x.Numerator == 123 && x.Denominator == 456);
        }

        [Test]
        public void CanCreateFraction_int_int()
        {
            var x = new Fraction(17, 42);
            Assert.IsTrue(x.Numerator == 17 && x.Denominator == 42);
        }

        [Test]
        public void CanCreateFraction_long_double()
        {
            var x = new Fraction(123L, 45600.789);
            Assert.IsTrue(x.Numerator == 123000 && x.Denominator == 45600789);
        }

        [Test]
        public void CanCreateFraction_long_long()
        {
            var x = new Fraction(long.MaxValue, long.MinValue);
            Assert.IsTrue(x.Numerator == -long.MaxValue && x.Denominator == -new BigInteger(long.MinValue));
        }

        [Test]
        public void FractionIsNotSimplifiedOnCreation()
        {
            var x = new Fraction(2, 4);
            Assert.IsTrue(x.Numerator == 2 && x.Denominator == 4);
        }

        #endregion

        #region Simplify

        [Test]
        public void FractionCanBeSimplifed_1()
        {
            var x = new Fraction(2, 4).Simplified;
            Assert.IsTrue(x.Numerator == 1 && x.Denominator == 2);
        }

        [Test]
        public void FractionCanBeSimplifed_2()
        {
            var x = new Fraction(-10, 5).Simplified;
            Assert.IsTrue(x.Numerator == -2 && x.Denominator == 1);
        }

        [Test]
        public void FractionCanBeSimplifed_3()
        {
            var x = new Fraction(3, -9).Simplified;
            Assert.IsTrue(x.Numerator == -1 && x.Denominator == 3);
        }

        [Test]
        public void FractionCanBeSimplifed_4()
        {
            var x = new Fraction(-4, -12).Simplified;
            Assert.IsTrue(x.Numerator == 1 && x.Denominator == 3);
        }

        #endregion

        #region Comparison

        [Test] public void Equality_1() => Assert.IsTrue(new Fraction(2, 3) == new Fraction(2, 3));
        [Test] public void Equality_2() => Assert.IsTrue(new Fraction(2, 3) == new Fraction(4, 6));
        [Test] public void Equality_3() => Assert.IsTrue(new Fraction(-3, 4) == new Fraction(3, -4));
        [Test] public void Equality_4() => Assert.IsTrue(new Fraction(-3, 4) == new Fraction(6, -8));

        [Test] public void Inequality_1() => Assert.IsTrue(new Fraction(-3, 4) != new Fraction(3, 4));
        [Test] public void Inequality_2() => Assert.IsTrue(new Fraction(3, -4) != new Fraction(3, 4));
        [Test] public void Inequality_3() => Assert.IsFalse(new Fraction(-3, 4) != new Fraction(-3, 4));
        [Test] public void Inequality_4() => Assert.IsFalse(new Fraction(3, -4) != new Fraction(-3, 4));

        [Test] public void LessThan_1() => Assert.IsTrue(new Fraction(2, 7) < new Fraction(3, 7));
        [Test] public void LessThan_2() => Assert.IsFalse(new Fraction(2, 7) < new Fraction(2, 7));
        [Test] public void LessThan_3() => Assert.IsFalse(new Fraction(2, 7) < new Fraction(1, 7));

        [Test] public void LessThanOrEqual_1() => Assert.IsTrue(new Fraction(2, 7) <= new Fraction(3, 7));
        [Test] public void LessThanOrEqual_2() => Assert.IsTrue(new Fraction(2, 7) <= new Fraction(2, 7));
        [Test] public void LessThanOrEqual_3() => Assert.IsFalse(new Fraction(2, 7) <= new Fraction(1, 7));

        [Test] public void GreaterThanOrEqual_1() => Assert.IsFalse(new Fraction(2, 7) >= new Fraction(3, 7));
        [Test] public void GreaterThanOrEqual_2() => Assert.IsTrue(new Fraction(2, 7) >= new Fraction(2, 7));
        [Test] public void GreaterThanOrEqual_3() => Assert.IsTrue(new Fraction(2, 7) >= new Fraction(1, 7));

        [Test] public void GreaterThan_1() => Assert.IsFalse(new Fraction(2, 7) > new Fraction(3, 7));
        [Test] public void GreaterThan_2() => Assert.IsFalse(new Fraction(2, 7) > new Fraction(2, 7));
        [Test] public void GreaterThan_3() => Assert.IsTrue(new Fraction(2, 7) > new Fraction(1, 7));

        #endregion

        #region Arithmetic

        [Test] public void Multiply_1() => Assert.IsTrue(new Fraction(1, 2) * new Fraction(1, 2) == new Fraction(1, 4));
        [Test] public void Multiply_2() => Assert.IsTrue(new Fraction(2, 3) * new Fraction(1, 1) == new Fraction(2, 3));
        [Test] public void Multiply_3() => Assert.IsTrue(new Fraction(-2, 3) * new Fraction(1, 1) == new Fraction(-2, 3));
        [Test] public void Multiply_4() => Assert.IsTrue(new Fraction(2, -3) * new Fraction(1, 1) == new Fraction(-2, 3));
        [Test] public void Multiply_5() => Assert.IsTrue(new Fraction(2, 3) * new Fraction(-1, 1) == new Fraction(-2, 3));
        [Test] public void Multiply_6() => Assert.IsTrue(new Fraction(2, 3) * new Fraction(1, -1) == new Fraction(-2, 3));
        [Test] public void Multiply_7() => Assert.IsTrue(new Fraction(10, 1) * new Fraction(1, 100) == new Fraction(1, 10));

        [Test] public void Divide_1() => Assert.IsTrue(new Fraction(123, 456) / new Fraction(123, 456) == Fraction.One);
        [Test] public void Divide_2() => Assert.IsTrue(new Fraction(-123, 456) / new Fraction(123, 456) == -Fraction.One);
        [Test] public void Divide_3() => Assert.IsTrue(new Fraction(123, -456) / new Fraction(123, 456) == -Fraction.One);
        [Test] public void Divide_4() => Assert.IsTrue(new Fraction(-123, -456) / new Fraction(123, 456) == Fraction.One);
        [Test] public void Divide_5() => Assert.IsTrue(new Fraction(123, 456) / new Fraction(-123, 456) == -Fraction.One);
        [Test] public void Divide_6() => Assert.IsTrue(new Fraction(123, 456) / new Fraction(123, -456) == -Fraction.One);
        [Test] public void Divide_7() => Assert.IsTrue(new Fraction(123, 456) / new Fraction(-123, -456) == Fraction.One);

        [Test] public void Add_1() => Assert.IsTrue(new Fraction(2, 7) + new Fraction(3, 7) ==new Fraction(5, 7));
        [Test] public void Add_2() => Assert.IsTrue(new Fraction(2, -7) + new Fraction(3, 7) == new Fraction(1, 7));
        [Test] public void Add_3() => Assert.IsTrue(new Fraction(1, 2) + new Fraction(1, 4) == new Fraction(3, 4));
        [Test] public void Add_4() => Assert.IsTrue(new Fraction(1, 4) + new Fraction(1, 2) == new Fraction(3, 4));
        [Test] public void Add_5() => Assert.IsTrue(new Fraction(5, 10) + new Fraction(2, 10) == new Fraction(7, 10));
        [Test] public void Add_6() => Assert.IsTrue(new Fraction(9, 10) + new Fraction(1, 10) == new Fraction(10, 10));

        [Test] public void Subtract_1() => Assert.IsTrue(new Fraction(2, 7) - new Fraction(3, 7) == new Fraction(-1, 7));
        [Test] public void Subtract_2() => Assert.IsTrue(new Fraction(2, -7) - new Fraction(3, 7) == new Fraction(-5, 7));
        [Test] public void Subtract_3() => Assert.IsTrue(new Fraction(1, 2) - new Fraction(1, 4) == new Fraction(1, 4));
        [Test] public void Subtract_4() => Assert.IsTrue(new Fraction(1, 4) - new Fraction(1, 2) == new Fraction(-1, 4));
        [Test] public void Subtract_5() => Assert.IsTrue(new Fraction(5, 10) - new Fraction(2, 10) == new Fraction(3, 10));
        [Test] public void Subtract_6() => Assert.IsTrue(new Fraction(11, 10) - new Fraction(1, 10) == new Fraction(10, 10));
        
        [Test] public void Power_1() => Assert.IsTrue(new Fraction(0, 1).Pow(0) == new Fraction(1, 1));
        [Test] public void Power_2() => Assert.IsTrue(new Fraction(3, 4).Pow(0) == new Fraction(1, 1));
        [Test] public void Power_2b() => Assert.IsTrue(new Fraction(-3, 4).Pow(0) == new Fraction(1, 1));
        [Test] public void Power_3() => Assert.IsTrue(new Fraction(3, 4).Pow(1) == new Fraction(3, 4));
        [Test] public void Power_4() => Assert.IsTrue(new Fraction(3, 4).Pow(2) == new Fraction(9, 16));
        [Test] public void Power_5() => Assert.IsTrue(new Fraction(2, 4).Pow(2) == new Fraction(4, 16));
        [Test] public void Power_6() => Assert.IsTrue(new Fraction(-1, 2).Pow(2) == new Fraction(1, 4));
        [Test] public void Power_7() => Assert.IsTrue(new Fraction(-1, 2).Pow(3) == new Fraction(-1, 8));
        [Test] public void Power_8() => Assert.IsTrue(new Fraction(3, 4).Pow(-1) == new Fraction(4, 3));
        [Test] public void Power_9() => Assert.IsTrue(new Fraction(3, 4).Pow(-2) == new Fraction(16, 9));
        [Test] public void Power_10() => Assert.IsTrue(new Fraction(2, 4).Pow(-2) == new Fraction(16, 4));
        [Test] public void Power_11() => Assert.IsTrue(new Fraction(-1, 2).Pow(-2) == new Fraction(4, 1));
        [Test] public void Power_12() => Assert.IsTrue(new Fraction(-1, 2).Pow(-3) == new Fraction(-8, 1));

        [Test] public void Negate_1() => Assert.IsTrue(-new Fraction(0, 1) == new Fraction(0, 1));
        [Test] public void Negate_2() => Assert.IsTrue(-new Fraction(1, 2) == new Fraction(-1, 2));
        [Test] public void Negate_3() => Assert.IsTrue(-new Fraction(-2, 3) == new Fraction(2, 3));

        #endregion
    }
}
