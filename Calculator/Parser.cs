using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        private Stack<string> operators = new Stack<string>();
        private string result = "";
        private List<string> op = new List<string> { "+", "-", "*", "/" };

        public string Parse(Token[] tokenstoParse)
        {
            if (tokenstoParse != null)
            {
                for (int i = 0; i < tokenstoParse.Length; i++)
                {
                    string next = tokenstoParse[i].Value;
                    if (op.Contains(next))
                    {
                        int nextInt;
                        if (int.TryParse(next, out nextInt))
                        {
                            next += (" " + nextInt);
                        }
                        else if ((operators.Count == 0) ||
                            (operators.Peek().Equals("+")) ||
                            (operators.Peek().Equals("-") ||
                            (operators.Peek().Equals("("))))
                        {
                            operators.Push(next);
                        }
                        else if ((operators.Peek().Equals("*")) ||
                            (operators.Peek().Equals("/")))
                        {
                            result += (" " + operators.Pop());
                            operators.Push(next);
                        }

                    }
                    else if (next == "(")
                    {
                        operators.Push(next);
                    }

                    else if (next == ")")
                    {
                        while (operators.Peek().Equals("(") == false)
                        {
                            result += (" " + operators.Pop());
                        }

                        operators.Pop();
                    }
                }

                while (operators.Count() != 0)
                {
                    result += (" " + operators.Pop());
                }
            }
            return result.TrimStart();
        }

        public void CheckValidity(Token[] tokenstoCheck)
        {
            List<char> correctTypes = new List<char>
            { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '*', '/', '(', ')' };
             
            for (int i=0; i< tokenstoCheck.Length; i++)
            {
                for (int j=0; j<tokenstoCheck[i].Value.Length; j++)
                if (correctTypes.Contains(tokenstoCheck[i].Value[j]) ==false)
                {
                    throw new Exception("irrelevant expression");
                }
            }
        }

        public void CheckResult(string input)
        {
            int digits = 0;
            int operators = 0;
            for (int i=0; i<input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    digits++;
                }
                else
                {
                    operators++;
                }
            }

            if (digits > operators + 1)
            {
                throw new Exception("Not enough operators");
            }

            if (digits < operators + 1)
            {
                throw new Exception("Not enough operands");
            }
        }
    }
}

