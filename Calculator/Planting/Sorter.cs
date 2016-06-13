using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Planting
{
    class Sorter
    {
        /*public IExpression PlantTree(IEnumerable<TokenValue> tokens)
        {
            return Plant(tokens.GetEnumerator());
          
        }

        private IExpression Plant(IEnumerator<TokenValue> tokenValueEnumerator)
        {
            var tok = tokenValueEnumerator.Current;

            if (tok.GetType() == typeof(Digit))
            {
                var digit = new DigitExpression((Digit)tok);
                if (tokenValueEnumerator.MoveNext())
                {

                }
                else
                {
                    return digit;
                }
            }
            else if (tok.GetType() == typeof(Sum))
            {
                var sum = new SumExpression((Sum)tok);
                sum.LeftOperand = stack.Pop();

            }
        }*/


        public TokenValue[] SortToRPN(TokenValue[] tokens)
        {
            var _operators = new Stack<TokenValue>();        
            var _result = new List<TokenValue>();

            foreach (var tok in tokens)
            {
                if (tok.GetType() == typeof(Digit))
                {

                    _result.Add(tok);
                }
                else if (tok.GetType() == typeof(LeftBrace))
                {
                    _operators.Push(tok);
                }
                else if (tok.GetType() == typeof(RightBrace))
                {
                    while (_operators.Peek().GetType() != typeof(LeftBrace))
                    {
                        _result.Add(_operators.Pop());
                    }
                    _operators.Pop();
                }
                else if ((_operators.Count == 0)
                        || (_operators.Peek().GetType() == typeof(Sum))
                        || (_operators.Peek().GetType() == typeof(Subtraction))
                        || (_operators.Peek().GetType() == typeof(LeftBrace)))
                {
                    _operators.Push(tok);
                }
                else if ((_operators.Peek().GetType() == typeof(Multiply)) ||
                    (_operators.Peek().GetType() == typeof(Division)))
                {
                    _result.Add(_operators.Pop());
                    _operators.Push(tok);
                }
            }

            while (_operators.Count() != 0)
            {
                _result.Add(_operators.Pop());
            }

            return  _result.ToArray();
        }
    }
}
