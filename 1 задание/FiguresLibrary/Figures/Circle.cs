using System;
using System.IO;

namespace FiguresLibrary.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : IFigure
    {
        private readonly double _radius;

        public Circle() {}

        /// <summary>
        /// Создать круг
        /// </summary>
        /// <param name="radius">Длина радиуса. Положительное число</param>
        /// <exception cref="ArgumentException">Если радиус меньше или равен нулю</exception>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException($"Нельзя создать круг с таким радиусом : {radius} - неположительное число");
            }
                
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}