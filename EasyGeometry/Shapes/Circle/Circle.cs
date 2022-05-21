using EasyGeometry.Common;
using System;

namespace EasyGeometry.Shapes.Circle
{
    public sealed class Circle : IShape, IValidatable
    {
        private readonly double _radius;

        public Circle(double radius) =>
            _radius = radius;

        public double GetArea() =>
            Math.PI * Math.Pow(_radius, 2);

        public void Validate() =>
            CheckCircleExist();

        private void CheckCircleExist()
        {
            if (_radius <= 0)
            {
                throw new CircleNotExistException($"Circle does not exist. Reason : {nameof(_radius)}: {_radius} <= 0");
            }
        }
    }
}
