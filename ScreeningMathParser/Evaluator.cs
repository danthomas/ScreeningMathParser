using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScreeningMathParser
{
    /// <summary>
    /// Evaluates mathematical expressions of the type
    /// 3c4d2aee2a4c41fc4f
    /// where a = '+', b = '-', c = '*', d = '/', e = '(', f = ')'
    /// </summary>
    public class Evaluator
    {
        private readonly string[] _operatorChars = {"a", "b", "c", "d"};
        private const string leftParen = "e";
        private const string rightParen = "f";

        /// <summary>
        /// Returns try if the specified expression contains only 
        /// digits and the letters a-f, return false otherwise
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        internal bool ValidateChars(string expression)
        {
            return Regex.IsMatch(expression, "^[abcdef0-9]+$");
        }

        /// <summary>
        /// Splits the specified expression into numeric values and single chars
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        internal string[] Tokenise(string expression)
        {
            return Regex.Matches(expression, @"[a]|[b]|[c]|[d]|[e]|[f]|\d+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray(); 
        }

        /// <summary>
        /// Builds an Expression Tree from the specified tokens
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        internal Node BuildExpressionTree(string[] tokens)
        {
            int index = 0;
            return BuildExpressionTree(tokens, ref index);
        }

        private Node BuildExpressionTree(string[] tokens, ref int index)
        {
            Node node = null;
            OperatorType operatorType = OperatorType.Addition;

            while (index < tokens.Length)
            {
                int value;
                if (Int32.TryParse(tokens[index], out value))
                {
                    index++;
                    if (node == null)
                    {
                        node = new ValueNode(value);
                    }
                    else
                    {
                        node = new OperatorNode(node, operatorType, new ValueNode(value));
                    }
                }
                else if (_operatorChars.Contains(tokens[index]))
                {
                    operatorType = GetOperatorType(tokens[index++]);
                }
                else if (tokens[index] == leftParen)
                {
                    index++;
                    if (node == null)
                    {
                        node = BuildExpressionTree(tokens, ref index);
                    }
                    else
                    {
                        node = new OperatorNode(node, operatorType, BuildExpressionTree(tokens, ref index));
                    }
                }
                else if (tokens[index] == rightParen)
                {
                    index++;
                    return node;
                }
            }
            
            return node;
        }

        /// <summary>
        /// Gets the OperatorType for the specifed @operator
        /// </summary>
        /// <param name="operator"></param>
        /// <returns></returns>
        internal OperatorType GetOperatorType(string @operator)
        {
            switch (@operator)
            {
                case "a":
                    return OperatorType.Addition;
                case "b":
                    return OperatorType.Subtraction;
                case "c":
                    return OperatorType.Multiplication;
                case "d":
                    return OperatorType.Division;
            }

            throw new Exception(String.Format("Operator {0} not recognised", @operator));
        }

        /// <summary>
        /// Evaluates the specified expression and returns the calculated value.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public decimal Evaluate(string expression)
        {
            if (!ValidateChars(expression))
            {
                throw new Exception("Invalid chars found.");
            }

            string[] tokens = Tokenise(expression);

            if (!ValidateTokens(tokens))
            {
                throw new Exception("Invalid tokens found.");
            }

            Node node = BuildExpressionTree(tokens);

            return node.Value;
        }

        /// <summary>
        /// Validates that the tokens in the specified array
        /// are odd in number
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        internal bool ValidateTokens(string[] tokens)
        {
            //Must have an odd number of tokens
            if ((tokens.Length % 2) != 1)
            {
                return false;
            }

            return true;
        }
    }
}
