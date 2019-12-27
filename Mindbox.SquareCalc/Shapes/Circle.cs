using Mindbox.SquareCalc.Exceptions;

namespace Mindbox.SquareCalc
{
    public class Circle : Shape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new BadShapeParameterException();
            }
            _radius = radius;
        }

        public double Radius => _radius;
    }
}