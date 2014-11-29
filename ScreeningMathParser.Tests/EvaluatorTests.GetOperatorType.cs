using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    public partial class EvaluatorTests
    {
        [TestMethod]
        public void GetOpertorType_Addition()
        {
            const OperatorType expected = OperatorType.Addition;
            OperatorType actual = new Evaluator().GetOperatorType("a");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOpertorType_Subtraction()
        {
            const OperatorType expected = OperatorType.Subtraction;
            OperatorType actual = new Evaluator().GetOperatorType("b");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOpertorType_Multiplication()
        {
            const OperatorType expected = OperatorType.Multiplication;
            OperatorType actual = new Evaluator().GetOperatorType("c");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOpertorType_Division()
        {
            const OperatorType expected = OperatorType.Division;
            OperatorType actual = new Evaluator().GetOperatorType("d");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOpertorType_Unrecognised()
        {
            const string expected = "Operator e not recognised";
            string actual = null;

            try
            {
                new Evaluator().GetOperatorType("e");
            }
            catch (Exception exception)
            {
                actual = exception.Message;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
