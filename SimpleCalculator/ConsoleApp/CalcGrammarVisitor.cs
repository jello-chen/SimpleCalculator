using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace ConsoleApp
{
    public class CalcGrammarVisitor: CalculatorBaseVisitor<int>
    {
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        public override int VisitParenthesis([NotNull] CalculatorParser.ParenthesisContext context)
        {
            return Visit(context.expression());
        }

        public override int VisitMultiplyDivide([NotNull] CalculatorParser.MultiplyDivideContext context)
        {
            int left = Convert.ToInt32(Visit(context.expression(0)));
            int right = Convert.ToInt32(Visit(context.expression(1)));

            if(context.operate.Type == CalculatorParser.MUL)
            {
                return left * right;
            }
            else
            {
                return left / right;
            }
        }

        public override int VisitAddSubtraction([NotNull] CalculatorParser.AddSubtractionContext context)
        {
            int left = Convert.ToInt32(Visit(context.expression(0)));
            int right = Convert.ToInt32(Visit(context.expression(1)));

            if (context.operate.Type == CalculatorParser.ADD)
            {
                return left + right;
            }
            else
            {
                return left - right;
            }
        }

        public override int VisitNumber([NotNull] CalculatorParser.NumberContext context)
        {
            return Convert.ToInt32(context.GetText());
        }
    }
}
