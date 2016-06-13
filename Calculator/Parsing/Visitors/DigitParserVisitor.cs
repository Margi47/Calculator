using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parsing.Visitors
{
    class DigitParserVisitor : IParsingVisitor
    {
        public bool Parse(Token token, out TokenValue value)
        {
            int result;
            if(int.TryParse(token.Value, out result))
            {
                value = new Digit(token, result);
                return true;
            }

            value = null;
            return false;
        }
    }
}
