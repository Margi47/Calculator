using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Token
    {
        public string Value { get; private set; }
        public int Position { get; private set; }

        public Token(string value, int position)
        {
            Value = value;
            Position = position;
        }
    }
}