using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    public partial class EvaluatorTests
    {
        [TestMethod]
        public void ValidateTokens_EvenNoOfTokens_ReturnsFalse()
        {
            string[] tokens = { "", "" };

            bool actual = new Evaluator().ValidateTokens(tokens);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateTokens_SingleInt_ReturnsTrue()
        {
            string[] tokens = { Int32.MaxValue.ToString() };

            bool actual = new Evaluator().ValidateTokens(tokens);

            Assert.IsTrue(actual);
        }
    }
}
