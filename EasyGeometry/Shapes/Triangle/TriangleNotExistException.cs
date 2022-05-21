using System;

namespace EasyGeometry.Shapes.Triangle
{
    public sealed class TriangleNotExistException : Exception
    {
        public TriangleNotExistException(string message) : base(message)
        {
        }
    }
}
