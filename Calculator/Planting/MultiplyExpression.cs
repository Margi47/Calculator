using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    class MultiplyExpression: BaseOperationExpression
    {
        public Multiply Value { get; set; }
      
        public MultiplyExpression(Multiply value)
        {
            Value = value;
        }

        public override int Calculate()
        {
            return LeftOperand.Calculate() * RightOperand.Calculate();
        }
    }
}
