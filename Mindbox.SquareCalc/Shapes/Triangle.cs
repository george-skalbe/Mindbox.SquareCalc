using Mindbox.SquareCalc.Exceptions;

namespace Mindbox.SquareCalc
{
    public class Triangle : Shape
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new BadShapeParameterException();
            }

            _a = a;
            _b = b;
            _c = c;
        }

        public double A => _a;
        public double B => _b;
        public double C => _c;
    }
}