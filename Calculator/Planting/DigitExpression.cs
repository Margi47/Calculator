using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    class DigitExpression : IExpression
    {
        public Digit Value { get; set; }

        public bool Complete
        {
            get
            {
                return false;
            }
        }

        public DigitExpression(Digit value)
        {
            Value = value;
        }

        public int Calculate()
        {
            return Value.Value;
        }

    }
}
