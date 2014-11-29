using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    public partial class EvaluatorTests
    {
        [TestMethod]
        public void BuildExpressionTree_SingleValue()
        {
            string[] tokens = { "456" };

            const decimal expected = 456M;
            decimal actual = new Evaluator().BuildExpressionTree(tokens).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildExpressionTree_TwoValues()
        {
            string[] tokens = { "456", "a", "789" };

            const decimal expected = 1245M;
            decimal actual = new Evaluator().BuildExpressionTree(tokens).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildExpressionTree_ManyValuesNoParens()
        {
            string[] tokens = { "12", "c", "3", "c", "2", "d", "10" };

            const decimal expected = 7.2M;
            decimal actual = new Evaluator().BuildExpressionTree(tokens).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildExpressionTree_ManyValuesWithParens()
        {
            string[] tokens = { "3", "a", "e", "4", "c", "66", "f", "b", "32" };

            const decimal expected = 235M;
            decimal actual = new Evaluator().BuildExpressionTree(tokens).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuildExpressionTree_ManyValuesWithNestedParens()
        {
            string[] tokens = { "3", "c", "4", "d", "2", "a", "e", "e", "2", "a", "4", "c", "41", "f", "c", "4", "f" };

            const decimal expected = 990M;
            decimal actual = new Evaluator().BuildExpressionTree(tokens).Value;

            Assert.AreEqual(expected, actual);
        }
    }
}
