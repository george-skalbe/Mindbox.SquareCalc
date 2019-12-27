using System;

namespace Mindbox.SquareCalc
{
    /// <summary>
    /// стратегия вычисления площади треугольника
    /// </summary>
    public class TriangleSquareCalcStrategy : IShapeSquareCalcStrategy<Triangle>, IShapeSquareCalcStrategy
    {
        public double CalculateSquare(Triangle triangle)
        {
            double square = 0;
            triangle = triangle.Normalize();
            (double a, double b, double c) = (triangle.A, triangle.B, triangle.C);

            if (triangle.IsRight())
            {
                square = (triangle.A * triangle.B) / 2;
            }
            else
            {
                //формула Герона (незнал/загуглил)
                double p = (a + b + c) / 2;
                square = Math.Sqrt(p * (p - a) * (p - b) * (p - c)) ;
            }

            return square;
        }

        public double CalculateSquare(Shape shape)
        {
            var triangle = shape as Triangle;
            
            if(triangle == null)
                throw new ArgumentException("Wrong shape type", nameof(Shape));

            return CalculateSquare(triangle);
        }
    }
}