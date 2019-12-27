using System;

namespace Mindbox.SquareCalc.Exceptions
{
    public class ShapeNotSupportedException : ApplicationException
    {
        public ShapeNotSupportedException() : base("Square calculation for shape type is not supported yet.")
        {
        }
    }
}