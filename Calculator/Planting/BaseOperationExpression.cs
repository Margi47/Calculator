using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    abstract class BaseOperationExpression : IExpression
    {
        public IExpression LeftOperand { get; set; }
        public IExpression RightOperand { get; set; }

        public bool Complete
        {
            get
            {
                return LeftOperand != null && RightOperand != null;
            }
        }

        public abstract int Calculate();
    }
}
