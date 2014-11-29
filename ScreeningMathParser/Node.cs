namespace ScreeningMathParser
{
    /// <summary>
    /// Represents a Node in and Expression Tree with Left an Right Child Nodes
    /// Inheriting Types do define the Value of the Node
    /// </summary>
    public abstract class Node
    {
        public Node LeftNode { get; protected set; }
        public Node RightNode { get; protected set; }
        public abstract decimal Value { get; }
    }
}
