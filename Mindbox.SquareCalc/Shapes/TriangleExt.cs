using System;

namespace Mindbox.SquareCalc
{
    internal static class TriangleExt
    {
        /// <summary>
        /// метод вычисления прямоугольности по Пифагору;
        /// в идеале, для неканоничных/дробных значений надо использовать не Equals а что то типа c2 - (a2 + b2) <= tolerance
        /// тем более что большинство тестовых прямоугольных тр-ков генерятся методами последовательных приближений (с погрешностью)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        internal static bool IsRight(this Triangle t) => (Math.Pow(t.A, 2) + Math.Pow(t.B, 2)) == Math.Pow(t.C, 2);
        
        
        /// <summary>
        /// упорядочивание сторон A lt B lt C
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        internal static Triangle Normalize(this Triangle triangle)
        {
            var arr = new[] {triangle.A, triangle.B, triangle.C};
            Array.Sort(arr);
            var normalized = new Triangle(arr[0], arr[1], arr[2]);
            return normalized;
        }
    }
}