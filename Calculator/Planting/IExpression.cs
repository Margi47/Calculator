using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    interface IExpression
    {
        int Calculate();
        bool Complete { get; }
    }
}
