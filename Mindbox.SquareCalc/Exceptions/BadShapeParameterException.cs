using System;

namespace Mindbox.SquareCalc.Exceptions
{
    public class BadShapeParameterException : ApplicationException
    {
        public BadShapeParameterException() : base("Bad shape parameter.")
        {
        }
    }
}