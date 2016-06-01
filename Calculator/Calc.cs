using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public int CalculateResult(string input)
        {
            int answer;   
            Stack<int> digits = new Stack<int>();
            for (int i=0; i<input.Length; i++)
            {
                char next = input[i];

                if (char.IsDigit(next))
                {
                    digits.Push(int.Parse(next.ToString()));
                }
                else if (next != ' ')
                {
                    if (digits.Count() >= 2)
                    {
                        int first = digits.Pop();
                        int second = digits.Pop();
                        int result = 0;
                        
                        if (next == '+')
                        {
                            result = first + second;
                        }
                        else if (next == '-')
                        {
                            result = second - first;
                        }
                        else if (next == '*')
                        {
                            result = first * second;
                        }
                        else if (next == '/')
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
