using FiguresLibrary.Figures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Tests
{
    [TestFixture]
    public class AreaCalculatorTests
    {
        [Test]
        public void ThrowsIfTypeIsNotCorrect()
        {
            var message = "Тип ошибочный, но исключение не было выбрашено";
            Assert.Throws<ArgumentException>(() => AreaCalculator.CalculateArea(
                new
                {
                    figure = new Triangle(2.0, 3.0, 2.5)
                }.GetType(), 2.0, 3, 0, 2.5), message);
        }

        [Test]
        public void CalculatesAreaCorrectly()
        {
            ApproximatelyEqual(6.0, AreaCalculator.CalculateArea(typeof(Triangle), 3.0, 4.0, 5.0));
            ApproximatelyEqual(Math.PI, AreaCalculator.CalculateArea(typeof(Circle), 1.0));
        }
        
        private static void ApproximatelyEqual(double expected, double actual)
        {
            Assert.Less(Math.Abs(expected - actual), double.Epsilon);
        }
    }
}
