using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using FiguresLibrary.Figures;

namespace FiguresLibrary.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        [TestCase(3.0)]
        public void NotThrowIfRadiusIsCorrect(double radius)
        {
            Assert.DoesNotThrow(() => new Circle(radius));
        }


        [Test]
        [TestCase(0.0)]
        [TestCase(-2.0)]
        public void ThrowsIfRadiusIsNotPositive(double radius)
        {
            var message = $"Круг с радиусом {radius} создан успешно, хотя он неположительный";
            Assert.Throws<ArgumentException>(() => new Circle(radius), message);
        }

        [Test]
        [TestCase(1.0, Math.PI)]
        public void CalculateAreaCorrectly(double radius, double expected)
        {
            var actual = new Circle(radius).CalculateArea();
            Assert.LessOrEqual(Math.Abs(expected - actual), double.Epsilon);
        }
    }
}