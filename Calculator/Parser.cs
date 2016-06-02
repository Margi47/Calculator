using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        private Stack<string> _operators = new Stack<string>();
        private string _result = string.Empty;
        private List<string> _op = new List<string> { "+", "-", "*", "/" };

        public string Parse(Token[] tokenstoParse)
        {
            if (tokenstoParse != null)
            {
                for (int i = 0; i < tokenstoParse.Length; i++)
                {
                    string next = tokenstoParse[i].Value;
                    int nextInt;
                    if (_op.Contains(next))
                    {
                        if ((_operators.Count == 0) ||
                            (_operators.Peek().Equals("+")) ||
                            (_operators.Peek().Equals("-") ||
                            (_operators.Peek().Equals("("))))
                        {
                            _operators.Push(next);
                        }
                        else if ((_operators.Peek().Equals("*")) ||
                            (_operators.Peek().Equals("/")))
                        {
                            _result += (" " + _operators.Pop());
                            _operators.Push(next);
                        }
                    }
                    else if (next == "(")
                    {
                        _operators.Push(next);
                    }
                    else if (next == ")")
                    {
                        while (_operators.Peek().Equals("(") == false)
                        {
                            _result += (" " + _operators.Pop());
                        }

                        _operators.Pop();                       
                    }
                    else if (int.TryParse(next, out nextInt))
                    {
                        _result += (" " + nextInt);
                    }    
                                    
                } 
                while (_operators.Count() != 0)
                { 
                   _result += (" " + _operators.Pop());
                }             
            }
            return _result.TrimStart();
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

