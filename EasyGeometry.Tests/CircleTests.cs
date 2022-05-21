using EasyGeometry.Shapes.Circle;
using NUnit.Framework;

namespace EasyGeometry.Tests
{
    public class CircleTests
    {
        [Test]
        public void CircleShouldNotExist([Values(int.MinValue, 0, -1)] double radius)
        {
            var circle = new Circle(radius);
            Assert.Throws<CircleNotExistException>(circle.Validate);
        }

        [Test]
        [TestCase(1, ExpectedResult = 3.141592653589793)]
        [TestCase(3.1, ExpectedResult = 30.190705400997917)]
        public double AreaIsCalculatedCorrectly(double radius)
        {
            var circle = new Circle(radius);
            return circle.GetArea();
        }
    }
}
