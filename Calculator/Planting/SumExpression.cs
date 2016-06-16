using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    class SumExpression : BaseOperationExpression
    {
        public Sum Value { get; set; }
 
        public SumExpression(Sum value)
        {
            Value = value;
        }

        public override int Calculate()
        {
            return LeftOperand.Calculate() + RightOperand.Calculate();
        }

        public override string ToString()
        {
            return ("[" + LeftOperand.ToString() + " + " + RightOperand.ToString() + "]");
        }
    }
}
