using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "(2 + 1) * (9 - 1)";
            Console.WriteLine(Evaluate(input));

            Console.Read();
        }

        static int Evaluate(string input)
        {
            var stream = new AntlrInputStream(input);
            var lexer = new CalculatorLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);
            var program = parser.program();
            var visitor = new CalcGrammarVisitor();
            var result = visitor.Visit(program);
            return result;
        }
    }
}
