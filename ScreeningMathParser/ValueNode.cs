namespace ScreeningMathParser
{
    /// <summary>
    /// Represents a Value Leaf Node in an Expression Tree
    /// </summary>
    public class ValueNode : Node
    {
        private readonly int _value;

        /// <summary>
        /// Constructs a Value Leaf Node with the specified Value
        /// </summary>
        /// <param name="value"></param>
        public ValueNode(int value)
        {
            _value = value;
        }

        /// <summary>
        /// Value of a Leaf Node is the Value passed to the Constructor
        /// </summary>
        public override decimal Value
        {
            get { return _value; }
        }
    }
}