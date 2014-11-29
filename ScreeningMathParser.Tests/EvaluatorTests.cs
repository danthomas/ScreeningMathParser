using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    public partial class EvaluatorTests
    {
        [TestMethod]
        public void Evaluate_3a2c4()
        {
            const string expression = "3a2c4";

            const decimal expected = 20M;
            decimal actual = new Evaluator().Evaluate(expression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_32a2d2()
        {
            const string expression = "32a2d2";

            const decimal expected = 17M;
            decimal actual = new Evaluator().Evaluate(expression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_500a10b66c32()
        {
            const string expression = "500a10b66c32";

            const decimal expected = 14208M;
            decimal actual = new Evaluator().Evaluate(expression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_3ae4c66fb32()
        {
            const string expression = "3ae4c66fb32";

            const decimal expected = 235M;
            decimal actual = new Evaluator().Evaluate(expression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Evaluate_3c4d2aee2a4c41fc4f()
        {
            const string expression = "3c4d2aee2a4c41fc4f";

            const decimal expected = 990M;
            decimal actual = new Evaluator().Evaluate(expression);

            Assert.AreEqual(expected, actual);
        }
    }
}
