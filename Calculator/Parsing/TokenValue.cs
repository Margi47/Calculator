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

        public override bool Equals(object obj)
        {
            var value = obj as TokenValue;
            return (ParentToken.Value.Equals(value.ParentToken.Value)&&(ParentToken.Position.Equals(value.ParentToken.Position)));
        }
    }
}
