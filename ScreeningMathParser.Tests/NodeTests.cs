using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScreeningMathParser.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Value_SingleValueNode()
        {
            //expression: 123
            Node node = new ValueNode(123);

            const decimal expected = 123M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_AdditionTwoValues()
        {
            //expression: 2 + 3
            Node node = new OperatorNode(new ValueNode(2), OperatorType.Addition, new ValueNode(3));

            const decimal expected = 5M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_SubtractionTwoValues()
        {
            //expression: 2 + 3
            Node node = new OperatorNode(new ValueNode(2), OperatorType.Subtraction, new ValueNode(3));

            const decimal expected = -1M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_MultiplicationTwoValues()
        {
            //expression: 2 * 3
            Node node = new OperatorNode(new ValueNode(2), OperatorType.Multiplication, new ValueNode(3));

            const decimal expected = 6M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_DivisionTwoValues()
        {
            //expression: 5 / 2
            Node node = new OperatorNode(new ValueNode(5), OperatorType.Division, new ValueNode(2));

            const decimal expected = 2.5M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_ThreeValues()
        {
            //expression: 2 + 3 * 4
            Node node = new OperatorNode(new ValueNode(2), OperatorType.Addition, new ValueNode(3));
            node = new OperatorNode(node, OperatorType.Multiplication, new ValueNode(4));

            const decimal expected = 20M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_ManyValues()
        {
            //expression: 2 + 3 * 4 / 5 - 7
            Node node = new OperatorNode(new ValueNode(2), OperatorType.Addition, new ValueNode(3));
            node = new OperatorNode(node, OperatorType.Multiplication, new ValueNode(4));
            node = new OperatorNode(node, OperatorType.Division, new ValueNode(5));
            node = new OperatorNode(node, OperatorType.Subtraction, new ValueNode(7));

            const decimal expected = -3M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_ManyValues2()
        {
            //expression: 3 * 4 - 2 + ( ( 2 + 4 * 41 ) * 4 )

            Node node1 = new OperatorNode(new ValueNode(2), OperatorType.Addition, new ValueNode(4));
            node1 = new OperatorNode(node1, OperatorType.Multiplication, new ValueNode(41));
            node1 = new OperatorNode(node1, OperatorType.Multiplication, new ValueNode(4));

            Node node2 = new OperatorNode(new ValueNode(3), OperatorType.Multiplication, new ValueNode(4));
            node2 = new OperatorNode(node2, OperatorType.Division, new ValueNode(2));
            
            Node node = new OperatorNode(node2, OperatorType.Addition, node1);
            
            const decimal expected = 990M;
            decimal actual = node.Value;

            Assert.AreEqual(expected, actual);
        }

    }
}
