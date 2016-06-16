using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    class DivisionExpression: BaseOperationExpression
    {
        public Division Value { get; set; }

        public DivisionExpression(Division value)
        {
            Value = value;
        }

        public override int Calculate()
        {
            return LeftOperand.Calculate() / RightOperand.Calculate();
        }

        public override string ToString()
        {
            return ("[" + LeftOperand.ToString() + " / " + RightOperand.ToString() + "]");
        }
    }
}
