using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressionEvaluator = new ExpressionEvaluator(" 1+ 3 *(12-(1+1)) /2 + 2 * 2");
            Console.WriteLine(expressionEvaluator.GetResult());
            Console.ReadKey();
        }
    }
}
