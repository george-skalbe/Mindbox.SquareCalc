using System;

namespace Mindbox.SquareCalc
{
    /// <summary>
    /// стратегия вычисления площади круга
    /// </summary>
    public class CircleSquareCalcStrategy : IShapeSquareCalcStrategy<Circle>, IShapeSquareCalcStrategy
    {
        public double CalculateSquare(Circle circle)
        {
            return Math.PI * Math.Pow(circle.Radius, 2);
        }
        
        public double CalculateSquare(Shape shape)
        {
            var circle = shape as Circle;
            
            if(circle == null)
                throw new ArgumentException("Wrong shape type", nameof(Shape));

            return CalculateSquare(circle);
        }
    }
}