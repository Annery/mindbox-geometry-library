using EasyGeometry.Shapes.Triangle;
using NUnit.Framework;

namespace EasyGeometry.Tests
{
    public class TriangleTests
    {
        [Test]
        [TestCase(1, 4, 5)]
        [TestCase(4, 1, 5)]
        [TestCase(5, 4, 1)]
        [TestCase(2, 9, 5)]
        [TestCase(int.MinValue, 1, 5)]
        [TestCase(2, 7, 0)]
        public void TriangleShouldNotExist(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);
            Assert.Throws<TriangleNotExistException>(triangle.Validate);
        }

        [Test]
        public void IsRectangularShouldRetunTrueForReactanglarTriange()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.IsRectangular());
        }

        [Test]
        [TestCase(2, 4, 5)]
        [TestCase(3, 3, 3)]
        public void IsRectangularShouldRetunFalseForNotReactanglarTriange(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);
            Assert.IsFalse(triangle.IsRectangular());
        }

        [Test]
        [TestCase(3, 4, 5, ExpectedResult = 6)]
        [TestCase(4, 3, 5, ExpectedResult = 6)]
        [TestCase(5, 4, 3, ExpectedResult = 6)]
        public double AreaCalculationIndependentFromSidesOrder(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);
            return triangle.GetArea();
        }
    }
}