using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public int CalculateResult(Token[] tokens)
        {
            int answer;   
            Stack<int> digits = new Stack<int>();

            for (int i=0; i<tokens.Count(); i++)
            {
                string next = tokens[i].Value;
                int nextDigit = 0;

                if (int.TryParse(next, out nextDigit))
                {
                    digits.Push(nextDigit);
                }
                else if (digits.Count() >= 2)
                {
                    int first = digits.Pop();
                    int second = digits.Pop();
                    int result = 0;
                        
                    if (next == "+")
                    {
                        result = first + second;
                    }
                    else if (next == "-")
                    {
                        result = second - first;
                    }
                    else if (next == "*")
                    {
                        result = first * second;
                    }
                    else if (next == "/")
                    {
                        result = second / first;
                    }
                    digits.Push(result);
                }
                else
                {
                    throw new Exception("Not enough operands");
                }                
            }
            answer = digits.Pop();
            if(digits.Count != 0)
            {
                throw new Exception("Not enough operators");
            }

            return answer;
        }
    }
}
