using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expression = "3a2c4";
            decimal expected = 20M;
            decimal actual = new Evaluator().Evaluate();
        }
    }
}
