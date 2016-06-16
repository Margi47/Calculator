using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Parsing.Visitors;

namespace Calculator
{
    public class Parser
    {
        private List<IParsingVisitor> _visitors = new List<IParsingVisitor>()
        {
            new DigitParserVisitor(),
            new OperationParseVisitor()
        };   

        public TokenValue[] Parse(Token[] tokens)
        {
            List<TokenValue> result = new List<TokenValue> ();
            List<Token> invalidTokens = new List<Token>();
            foreach(var tok in tokens)
            {
                bool success = false;
                foreach(var visitor in _visitors)
                {
                    TokenValue tokenValue;
                    if(visitor.Parse(tok, out tokenValue))
                    {
                        result.Add(tokenValue);
                        success = true;
                        break;
                    }
                }

                if (success == false)
                {
                    invalidTokens.Add(tok);
                }
            }

            if (invalidTokens.Count != 0)
            {
                throw new Exception("invalid input string");
            }

            return result.ToArray();
        }

    }
}

