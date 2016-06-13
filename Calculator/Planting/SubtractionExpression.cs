using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    class SubtractionExpression: BaseOperationExpression
    {
        public Subtraction Value { get; set; }

        public SubtractionExpression(Subtraction value)
        {
            Value = value;
        }

        public override int Calculate()
        {
            return LeftOperand.Calculate() - RightOperand.Calculate();
        }
    }
}
