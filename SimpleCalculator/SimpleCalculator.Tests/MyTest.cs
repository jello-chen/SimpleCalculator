using NUnit.Framework;
using SimpleCalculatorLib;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class ExpressionEvaluatorTest
    {
        [Test]
        public void TestIntegralOperation()
        {
            var expressionEvaluator = new ExpressionEvaluator(" 1 + 2 * 2 - 1 + 4 / 2");
            Assert.AreEqual(6, expressionEvaluator.GetResult());
        }

        [Test]
        public void TestIntegralOperationWithBrackets()
        {
            var expressionEvaluator = new ExpressionEvaluator(" 1 + 2 * (2 - 1 + 4) / 2");
            Assert.AreEqual(6, expressionEvaluator.GetResult());
        }

        [Test]
        public void TestFloatingPointOperation()
        {
            var expressionEvaluator = new ExpressionEvaluator(" 1 + 2.5 * 2 - 1 + 4 / 2.0");
            Assert.AreEqual(7, expressionEvaluator.GetResult());
        }

        [Test]
        public void TestFloatingPointOperationWithBrackets()
        {
            var expressionEvaluator = new ExpressionEvaluator(" 1 + 2.5 * (2 - 1 + 4) / 2.0");
            Assert.AreEqual(7.25, expressionEvaluator.GetResult());
        }
    }
}
