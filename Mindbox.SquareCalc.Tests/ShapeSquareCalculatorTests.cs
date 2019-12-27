using System;
using System.Linq;
using Mindbox.SquareCalc.Exceptions;
using Xunit;

namespace Mindbox.SquareCalc.Tests
{
    /// <summary>
    /// я ограничился функциональными тестами, хотя при полноценном тестировании нужно тестировать отдельно
    /// стратегии, механизм контейнера стратегий и сам клиентский фасад с использованием заглушек и моков.
    /// если это потребуется - скажите
    /// </summary>
    public class ShapeSquareCalculatorTests
    {
        [Theory]
        [InlineData(15.4, 745.0601)]
        [InlineData(135.7346, 57880.3312)]
        [InlineData(0.815, 2.0867)]
        public void CalculateCircleSquare_Ok(double radius, double expectedSquare)
        {
            var calculator = new ShapeSquareCalculator();
            var square = calculator.CalculateCircleSquare(new Circle(radius));
            square = Math.Round(square, 4);
            Assert.Equal(expectedSquare, square);
        }

        [Theory]
        [InlineData(3, 5, 4, 6)]//Right
        [InlineData(195.16069, 173.563, 89.2389, 7744.2856)]
        public void CalculateTriangleSquare_Ok(double a, double b, double c, double expectedSquare)
        {
            var calculator = new ShapeSquareCalculator();
            var square = calculator.CalculateTriangleSquare(new Triangle(a, b, c));
            square = Math.Round(square, 4);
            Assert.Equal(expectedSquare, square);
        }
        
        //Общий случай, неизвестный тип форм
        [Fact]
        public void CalculateShapeSquare_Ok()
        {
            var arr = new Shape[] {new Circle(0.815), new Triangle(3,5,4)};
            var calculator = new ShapeSquareCalculator();
            var res = arr.Select(i => calculator.CalculateShapeSquare(i))
                .Select(i => Math.Round(i, 4))
                .ToArray();
            Assert.Equal(new double[]{2.0867, 6} , res);
        }
        
        [Fact]
        public void CalculateShapeSquare_UnsupportedShape_Throws()
        {
            Assert.Throws<ShapeNotSupportedException>(() => new ShapeSquareCalculator()
                .CalculateShapeSquare(new Rectangle()));
        }
    }

    public class Rectangle : Shape
    {
    }
}