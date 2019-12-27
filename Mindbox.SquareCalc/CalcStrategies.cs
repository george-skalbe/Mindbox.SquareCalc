using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mindbox.SquareCalc
{
    /// <summary>
    /// контейнер стратегий "из-коробки", простой статический локатор
    /// загружает все стратегии один раз, при загрузке типа
    /// </summary>
    internal static class CalcStrategies
    {
        private static Dictionary<Type, object> _strategies;
        
        static CalcStrategies()
        {
            _strategies = Assembly.GetExecutingAssembly().GetTypes()
                .Where(IsCalcStrategy)
                .ToDictionary(GetStrategyShapeType, Activator.CreateInstance);
        }

        private static bool IsCalcStrategy(Type type)
        {
            return type.GetInterfaces()
                .Any(i => i.IsGenericType
                                      && i.GetGenericTypeDefinition() == typeof(IShapeSquareCalcStrategy<>));
        }

        private static Type GetStrategyShapeType(Type strategyType)
        {
            return strategyType.GetInterfaces()
                .Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IShapeSquareCalcStrategy<>))
                .GetGenericArguments()[0];
        }

        public static IShapeSquareCalcStrategy<TShape> Get<TShape>() where TShape : Shape
        {
            return Get(typeof(TShape)) as IShapeSquareCalcStrategy<TShape>;
        }
        
        public static object Get(Type shapeType)
        {
            _strategies.TryGetValue(shapeType, out var strategy);
            return strategy;
        }
    }
}