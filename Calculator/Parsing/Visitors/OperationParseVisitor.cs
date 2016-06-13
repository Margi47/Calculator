using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parsing.Visitors
{
    class OperationParseVisitor : IParsingVisitor
    {
        public bool Parse(Token token, out TokenValue value)
        {
            switch (token.Value)
            {
                case "+":
                    value = new Sum(token);
                    break;
                case "-":
                    value = new Subtraction(token);
                    break;
                case "*":
                    value = new Multiply(token);
                    break;
                case "/":
                    value = new Division(token);
                    break;
                case "(":
                    value = new LeftBrace(token);
                    break;
                case ")":
                    value = new RightBrace(token);
                    break;
                default:
                    value = null;
                    return false;
            }

            return true;
        }
    }
}
