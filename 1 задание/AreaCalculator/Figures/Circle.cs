using System;
using System.IO;

namespace FiguresLibrary.Figures
{
    /// <summary>
    /// ����
    /// </summary>
    public class Circle : IFigure
    {
        private readonly double _radius;

        public Circle() {}

        /// <summary>
        /// ������� ����
        /// </summary>
        /// <param name="radius">����� �������. ������������� �����</param>
        /// <exception cref="ArgumentException">���� ������ ������ ��� ����� ����</exception>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException($"������ ������� ���� � ����� �������� : {radius} - ��������������� �����");
            }
                
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}