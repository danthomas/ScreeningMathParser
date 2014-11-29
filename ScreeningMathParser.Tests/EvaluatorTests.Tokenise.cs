using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    public partial class EvaluatorTests
    {
        [TestMethod]
        public void Tokenise_Simple()
        {
            const string expression = "300a2c4";
            const string expected = "300,a,2,c,4";

            string actual = new Evaluator().Tokenise(expression).Aggregate((a, b) => a + "," + b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tokenise_Parens()
        {
            const string expression = "300ae2c44f";
            const string expected = "300,a,e,2,c,44,f";

            string actual = new Evaluator().Tokenise(expression).Aggregate((a, b) => a + "," + b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tokenise_NestedParens()
        {
            const string expression = "300aee12c4fd1f";
            const string expected = "300,a,e,e,12,c,4,f,d,1,f";

            string actual = new Evaluator().Tokenise(expression).Aggregate((a, b) => a + "," + b);

            Assert.AreEqual(expected, actual);
        }
    }
}
