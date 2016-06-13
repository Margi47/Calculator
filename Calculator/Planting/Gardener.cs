using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    class Gardener
    {
        public IExpression PlantTree(TokenValue[] tokens)
        {
            Stack<IExpression> digits = new Stack<IExpression>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] is Digit)
                {
                    digits.Push(new DigitExpression((Digit)tokens[i]));
                }
                else if (digits.Count >= 2)
                {
                    var first = digits.Pop();
                    var second = digits.Pop();
                
                    if (tokens[i] is Sum)
                    {
                        digits.Push(new SumExpression((Sum)tokens[i]) { RightOperand = first, LeftOperand = second });
                    }
                    else if (tokens[i] is Division)
                    {
                        digits.Push(new DivisionExpression((Division)tokens[i]) { RightOperand = first, LeftOperand = second });
                    }
                    else if (tokens[i] is Subtraction)
                    {
                        digits.Push(new SubtractionExpression((Subtraction)tokens[i]) { RightOperand = first, LeftOperand = second });
                    }
                    else if (tokens[i] is Multiply)
                    {
                        digits.Push(new MultiplyExpression((Multiply)tokens[i]) { RightOperand = first, LeftOperand = second });
                    }
                }
                else
                {
                    throw new Exception("Not enough operands");
                }
            }

            var answerExpression = digits.Pop();
            if (digits.Count != 0)
            {
                throw new Exception("Not enough operators");
            }

            return answerExpression;
        }
    }
}
