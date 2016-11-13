using System;
using SimpleCalculatorLib;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressionEvaluator = new ExpressionEvaluator(" 1.1+ 3.2 *(10*(2*2+1)) /2 + 2 * 2");
            Console.WriteLine(expressionEvaluator.GetResult());
            Console.ReadKey();
        }
    }
}
