using EasyGeometry.Common;
using System;
using System.Linq;

namespace EasyGeometry.Shapes.Triangle
{
    public sealed class Triangle : IShape, IValidatable
    {
        private readonly double[] _sides;

        public Triangle(double side) : this(side, side, side)
        {
        }

        public Triangle(double side1, double side2, double side3) =>
            _sides = new double[] { side1, side2, side3 };

        public bool IsRectangular() =>
            GetLongestSide() == GetHypotenosis();

        public double GetArea() =>
            CalculateArea(GetPerimeter());

        public void Validate() =>
            CheckTriangleExist();

        private double CalculateArea(double perimeter) =>
             Math.Sqrt(perimeter * (perimeter - _sides[0]) * (perimeter - _sides[1]) * (perimeter - _sides[2]));

        private double GetPerimeter() =>
            _sides.Sum() / 2;

        private double GetLongestSide() =>
            _sides.Max();

        private double GetSideIndex(double longestSide) =>
            Array.FindIndex(_sides, side => side == longestSide);

        private double GetHypotenosis()
        {
            var index = GetSideIndex(GetLongestSide());
            double sum = 0;
            for (int i = 0; i < _sides.Length; i++)
            {
                if (i != index)
                {
                    sum += Math.Pow(_sides[i], 2);
                }
            }
            return Math.Sqrt(sum);
        }

        private void CheckTriangleExist()
        {
            var sum01 = _sides[0] + _sides[1];
            var sum02 = _sides[0] + _sides[2];
            var sum12 = _sides[1] + _sides[2];

            Validate(_sides[0], sum12);
            Validate(_sides[1], sum02);
            Validate(_sides[2], sum01);

            static void Validate(double side, double sum)
            {
                if (sum <= side)
                {
                    throw new TriangleNotExistException($"Triangle does not exist. Reason : {nameof(sum)}: {sum} <= {nameof(side)}: {side}");
                }
            }
        }
    }
}
