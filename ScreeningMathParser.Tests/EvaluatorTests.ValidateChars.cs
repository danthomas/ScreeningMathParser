using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    [TestClass]
    public partial class EvaluatorTests
    {
        [TestMethod]
        public void ValidateChars_AllAllowedChars_ReturnsTrue()
        {
            const string expression = "0123456789abcdef";

            bool actual = new Evaluator().ValidateChars(expression);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateChars_DisallowedChar_ReturnsFalse()
        {
            const string expression = "01234567g89abcdef";

            bool actual = new Evaluator().ValidateChars(expression);

            Assert.IsFalse(actual);
        }
    }
}
