using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FiguresLibrary.Figures;

namespace FiguresLibrary
{
    /// <summary>
    /// Класс для вычисления площади фигуры без знания типа в compile-time
    /// </summary>
    public static class AreaCalculator
    {
        /// <summary>
        /// Вычисление площади фигуры
        /// </summary>
        /// <param name="type">Тип, который реализует IFigure</param>
        /// <param name="args">Аргументы для конструктора</param>
        /// <exception cref="ArgumentException"></exception>
        public static double CalculateArea(Type type, params double[] args)
        {
            if (!type.GetInterfaces().Contains(typeof(IFigure)))
            {
                throw new ArgumentException($"{type} не реализует IFigure");
            }

            var argsTypes = new Type[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                argsTypes[i] = typeof(double);
            }
            
            var ctor = type.GetConstructor(argsTypes);

            var parameters = new object[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                parameters[i] = args[i];
            }

            var figure = ctor?.Invoke(parameters);

            return (double)type
                .GetMethod("CalculateArea", BindingFlags.Instance | BindingFlags.Public)
                .Invoke(figure, null);
        }
    }
}