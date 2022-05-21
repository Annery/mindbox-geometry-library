using System;

namespace EasyGeometry.Shapes.Circle
{
    public class CircleNotExistException : Exception
    {
        public CircleNotExistException(string message) : base(message)
        {
        }
    }
}
