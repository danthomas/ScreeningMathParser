using System;

namespace ScreeningMathParser
{
    /// <summary>
    /// An Operator Node in an Expression Tree
    /// </summary>
    public class OperatorNode : Node
    {
        /// <summary>
        /// Constructs an Operator node with Left and Right child Nodes and an OperatorType
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="operatorType"></param>
        /// <param name="rightNode"></param>
        public OperatorNode(Node leftNode, OperatorType operatorType, Node rightNode)
        {
            LeftNode = leftNode;
            OperatorType = operatorType;
            RightNode = rightNode;
        }

        /// <summary>
        /// The OperatorType of this OperatorNode
        /// </summary>
        public OperatorType OperatorType { get; set; }

        /// <summary>
        /// The Value of an OperatorNode is the OperatorType applied to
        /// the Left and Right child Nodes
        /// </summary>
        public override decimal Value
        {
            get
            {
                switch (OperatorType)
                {
                    case OperatorType.Addition:
                        return LeftNode.Value + RightNode.Value;
                    case OperatorType.Subtraction:
                        return LeftNode.Value - RightNode.Value;
                    case OperatorType.Multiplication:
                        return LeftNode.Value * RightNode.Value;
                    case OperatorType.Division:
                        return LeftNode.Value / RightNode.Value;
                }

                throw new Exception("Failed to evaulate Value.");
            }
        }
    }
}