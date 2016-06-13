using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Digit:TokenValue
    {
        public int Value { get; private set; }
        public Digit(Token token, int value):base(token)
        {
            Value = value;
        }
    }
}
