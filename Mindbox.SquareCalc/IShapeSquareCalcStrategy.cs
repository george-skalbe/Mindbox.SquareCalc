namespace Mindbox.SquareCalc
{
    
    /// <summary>
    /// интерфейс 
    /// </summary>
    public interface IShapeSquareCalcStrategy
    {
        double CalculateSquare(Shape shape);
    }

    public interface IShapeSquareCalcStrategy<TShape> where TShape : Shape
    {
        double CalculateSquare(TShape shape);
    }
}