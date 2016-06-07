using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        private Stack<TokenValue> _operators = new Stack<TokenValue>();       

        public TokenValue[] CreateObjects(Token[] tokens)
        {
            List<TokenValue> myTokenValue = new List<TokenValue> ();
            foreach(var tok in tokens)
            {
                TokenValue next=null;
                int result=0;
                if (int.TryParse(tok.Value, out result))
                {
                    next = new Digits(tok);                 
                }

                if (tok.Value == "+")
                {
                    next = new Sum(tok);
                }

                if (tok.Value == "-")
                {
                    next = new Subtraction(tok);
                }

                if (tok.Value == "*")
                {
                    next = new Multiply(tok);
                }

                if (tok.Value == "/")
                {
                    next = new Division(tok);
                }

                if (tok.Value == "(")
                {
                    next = new LeftBrace(tok);
                }

                if (tok.Value == ")")
                {
                    next = new RightBrace(tok);
                }
                myTokenValue.Add(next);
            }
            return myTokenValue.ToArray();
        }

        public TokenValue[] Parse(Token[] tokens)
        {
            var newTokens=CreateObjects(tokens);

            List<TokenValue> _result = new List<TokenValue>();
            foreach (var tok in newTokens)
            {
                if (tok.GetType() == typeof(Digits))
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

