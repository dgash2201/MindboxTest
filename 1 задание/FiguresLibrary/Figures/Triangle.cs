using System;
using System.IO;

namespace FiguresLibrary.Figures
{
    /// <summary>Треугольник</summary>
    public class Triangle : IFigure
    {
        private readonly double _first;
        private readonly double _second;
        private readonly double _third;

        /// <summary>
        /// Треугольник прямоугольный, если a^2 + b^2 = c^2, где c - длина наибольшой стороны треугольника
        /// </summary>
        public bool IsRight => Math.Abs(_first * _first + _second * _second - _third * _third) < double.Epsilon;

        public Triangle() {}

        /// <summary>Создать треугольник</summary>
        /// <param name="first">Длина первой стороны. Положительное число</param>
        /// <param name="second">Длина второй стороны. Положительное число</param>
        /// <param name="third">Длина третьей стороны. Положительное число</param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double first, double second, double third)
        {
            if (first <= 0 || second <= 0 || third <= 0)
            {
                throw new ArgumentException($"Невозможно создать треугольник с данными сторонами: {first}, {second}, {third} - какие-то из них неположительные");
            }

            var sides = new double[3] { first, second, third };
            Array.Sort(sides);

            if (sides[2] >= sides[0] + sides[1])
            {
                throw new ArgumentException($"Невозможно создать треугольник с данными сторонами: {first}, {second}, {third} - не соблюдено неравенство треугольника");
            }
                
            _first = sides[0];
            _second = sides[1];
            _third = sides[2];
        }
        
        /// <summary>Вычисление площади треугольника</summary>
        public double CalculateArea()
        {
            double semiperimeter = (_first + _second + _third) / 2.0;
            return Math.Sqrt(semiperimeter * (semiperimeter - _first) * (semiperimeter - _second) * (semiperimeter - _third));
        }
    }
}