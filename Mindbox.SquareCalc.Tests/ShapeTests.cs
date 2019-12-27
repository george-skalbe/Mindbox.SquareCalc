using Mindbox.SquareCalc.Exceptions;
using Xunit;

namespace Mindbox.SquareCalc.Tests
{
    public class ShapeTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5.13)]
        public void Circle_OnZeroAndNegativeRadius_Throw(double radius)
        {
            Assert.Throws<BadShapeParameterException>(() => new Circle(radius));
        }
        
        [Theory]
        [InlineData(0, 1.1, 5)]
        [InlineData(2, 0, 4)]
        [InlineData(6.8, 0, 0)]
        [InlineData(-1, 1.1, 5)]
        [InlineData(2, -67.4, 4)]
        [InlineData(6.8, -4, -7)]
        public void Triangle_OnZeroAndNegativeParams_Throw(double a, double b, double c)
        {
            Assert.Throws<BadShapeParameterException>(() => new Triangle(a, b, c));
        }
    }
}