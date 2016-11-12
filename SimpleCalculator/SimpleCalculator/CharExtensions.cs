using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public static class CharExtensions
    {
        public static bool IsOperator(this char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static bool IsNumber(this char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
