using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace SimpleCalculatorLib
{
    /// <summary>
    /// Expression Evaluator
    /// </summary>
    public class ExpressionEvaluator
    {
        private string expression;
        public ExpressionEvaluator(string expression)
        {
            Contract.EnsuresOnThrow<ArgumentException>(string.IsNullOrEmpty(expression), "expression is null or empty");
            this.expression = expression;
        }

        public double GetResult()
        {
            Stack<char> operatorStack = new Stack<char>();
            Stack<double> numberStack = new Stack<double>();
            int length = expression.Length;
            int index = 0;

            while (index < length)
            {
                switch (expression[index])
                {
                    case '.':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        string s = string.Empty;
                        while (true)
                        {
                            s += expression[index];
                            if (++index >= length || expression[index] != '.' && !expression[index].IsNumber())
                            {
                                --index;
                                break;
                            }
                        }
                        double d = 0d;
                        if (!double.TryParse(s, out d))
                            throw new Exception("Expression is invalid.");
                        numberStack.Push(d);
                        s = string.Empty;
                        break;
                    case ' ':
                        break;
                    case '+':
                    case '-':
                        if (operatorStack.Count <= 0)
                        {
                            operatorStack.Push(expression[index]);
                        }
                        else
                        {
                            while (operatorStack.Count > 0)
                            {
                                char op = operatorStack.Peek();
                                if (op == '(') break;
                                op = operatorStack.Pop();
                                var secondNumber = numberStack.Pop();
                                var firstNumber = numberStack.Pop();
                                numberStack.Push(Calculate(op, firstNumber, secondNumber));
                            }
                            operatorStack.Push(expression[index]);
                        }
                        break;
                    case '*':
                    case '/':

                        if (operatorStack.Count <= 0)
                        {
                            operatorStack.Push(expression[index]);
                        }
                        else
                        {
                            // If the current operator has a higher priority than the top operator,
                            // the current operator is pushed in stack directly.
                            // If not, doing pop stack over and over again until the current operator has a higher priority than the top operator.
                            while (operatorStack.Count > 0)
                            {
                                char op = operatorStack.Peek();
                                if (op == '+' || op == '-' || op == '(')
                                {
                                    operatorStack.Push(expression[index]);
                                    break;
                                }
                                else
                                {
                                    op = operatorStack.Pop();
                                    var secondNumber = numberStack.Pop();
                                    var firstNumber = numberStack.Pop();
                                    numberStack.Push(Calculate(op, firstNumber, secondNumber));
                                }
                            }
                        }
                        break;
                    case '(':
                        if (operatorStack.Contains(')'))
                            throw new Exception("Expression is invalid:" + (index + 1));
                        operatorStack.Push(expression[index]);
                        break;
                    case ')':
                        if (!operatorStack.Contains('('))
                            throw new Exception("Expression is invalid," + (index + 1));
                        while (operatorStack.Count > 0)
                        {
                            var op = operatorStack.Pop();
                            if (op == '(') break;
                            var secondNumber = numberStack.Pop();
                            var firstNumber = numberStack.Pop();
                            numberStack.Push(Calculate(op, firstNumber, secondNumber));
                        }
                        break;
                    default:
                        throw new Exception("Expression is invalid:" + (index + 1));
                }
                index++;
            }
            if (!operatorStack.All(c => c.IsOperator()))
                throw new Exception("Expression is invalid.");
            while (operatorStack.Count > 0)
            {
                var op = operatorStack.Pop();
                var secondNumber = numberStack.Pop();
                var firstNumber = numberStack.Pop();
                numberStack.Push(Calculate(op, firstNumber, secondNumber));
            }
            if (numberStack.Count != 1)
                throw new Exception("Expression is invalid.");
            return numberStack.Pop();
        }

        private double Calculate(char op, double firstNumber, double secondNumber)
        {
            double result = 0d;
            switch (op)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    result = firstNumber / secondNumber;
                    break;
                default:
                    throw new NotSupportedException("The operation is not supported.");
            }
            return result;
        }
    }
}
