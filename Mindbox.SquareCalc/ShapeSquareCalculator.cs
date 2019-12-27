using System;
using Mindbox.SquareCalc.Exceptions;

namespace Mindbox.SquareCalc
{
    /// <summary>
    /// основной клиентский фасад
    /// </summary>
    public class ShapeSquareCalculator
    {
        public virtual double CalculateShapeSquare(Shape shape)
        {
            if(shape == null)
                throw new ArgumentNullException(nameof(Shape));
            
            var shapeType = shape.GetType();
            var strategy = CalcStrategies.Get(shapeType) as IShapeSquareCalcStrategy;
            
            if(strategy == null)
                throw new ShapeNotSupportedException();
            
            var square =strategy.CalculateSquare(shape);
            return square;
        }

        public double CalculateCircleSquare(Circle circle)
        {
            if(circle == null)
                throw new ArgumentNullException(nameof(Circle));

            var strategy = CalcStrategies.Get<Circle>();
            var square = strategy.CalculateSquare(circle);
            return square;
        }
        
        public double CalculateTriangleSquare(Triangle triangle)
        {
            if(triangle == null)
                throw new ArgumentNullException(nameof(Triangle));

            var strategy = CalcStrategies.Get<Triangle>();
            var square = strategy.CalculateSquare(triangle);
            return square;
        }
    }
}