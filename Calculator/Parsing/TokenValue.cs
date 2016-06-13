using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class TokenValue
    {
        public Token ParentToken { get; private set; }
        

        public TokenValue(Token token)
        {
            ParentToken = token;
        }
    }
}
