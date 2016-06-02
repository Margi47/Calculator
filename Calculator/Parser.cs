using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        private Stack<Token> _operators = new Stack<Token>();       
        private List<string> _op = new List<string> { "+", "-", "*", "/" };

        public Token[] Parse(Token[] tokens)
        {
            List<Token> _result=new List<Token>();
            if (tokens != null)
            {
                for (int i = 0; i < tokens.Length; i++)
                {
                    string next = tokens[i].Value;
                    if (_op.Contains(next))
                    {
                        if ((_operators.Count == 0) ||
                            (_operators.Peek().Value.Equals("+")) ||
                            (_operators.Peek().Value.Equals("-") ||
                            (_operators.Peek().Value.Equals("("))))
                        {
                            _operators.Push(tokens[i]);
                        }
                        else if ((_operators.Peek().Value.Equals("*")) ||
                            (_operators.Peek().Value.Equals("/")))
                        {
                            _result.Add(_operators.Pop());
                            _operators.Push(tokens[i]);
                        }
                    }
                    else if (next == "(")
                    {
                        _operators.Push(tokens[i]);
                    }
                    else if (next == ")")
                    {
                        while (_operators.Peek().Value.Equals("(") == false)
                        {
                            _result.Add(_operators.Pop());
                        }
                        _operators.Pop();                       
                    }
                    else 
                    {
                        _result.Add(tokens[i]);
                    }                                      
                } 
                while (_operators.Count() != 0)
                { 
                   _result.Add(_operators.Pop());
                }             
            }
            return _result.ToArray();
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

