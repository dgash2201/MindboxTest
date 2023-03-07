using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using FiguresLibrary.Figures;

namespace FiguresLibrary.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        [TestCase(3.0, 4.0, 5.0)]
        public void NotThrowWithCorrectSides(double first, double second, double third)
        {
            Assert.DoesNotThrow(() => new Triangle(first, second, third));
        }

        [Test]
        [TestCase(-3.0, 4.0, 5.0)]
        [TestCase(3.0, -4.0, 5.0)]
        [TestCase(3.0, 4.0, -5.0)]
        public void ThrowsIfSideIsNegative(double first, double second, double third)
        {
            var message = $"Треугольник со сторонами {first}, {second}, {third} создан успешно, хотя некоторые из них отрицательные";
            Assert.Throws<ArgumentException>(() => new Triangle(first, second, third), message);
        }

        [Test]
        [TestCase(3.0, 4.0, 7.0)]
        public void ThrowsIfTriangleUnequalityNotMet(double first, double second, double third)
        {
            var message = $"Треугольник со сторонами {first}, {second}, {third} создан успешно, хотя не соблюдено неравенство треугольника";
            Assert.Throws<ArgumentException>(() => new Triangle(first, second, third), message);
        }

        [Test]
        [TestCase(3.0, 4.0, 5.0, 6.0)]
        public void CalculateAreaCorrectly(double first, double second, double third, double expected)
        {
            var actual = new Triangle(first, second, third).CalculateArea();
            Assert.LessOrEqual(Math.Abs(expected - actual), double.Epsilon);
        }
                
        [Test]
        [TestCase(3.0, 4.0, 5.0, true)]
        [TestCase(3.0, 4.0, 6.0, false)]
        public void IsRightWorksCorrectly(double first, double second, double third, bool expected)
        {
            var actual = new Triangle(first, second, third).IsRight;
            Assert.AreEqual(expected, actual);
        }
    }
}