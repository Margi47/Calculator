using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Token
    {
        public string Value { get; private set; }
        public int Position { get; private set; }

        public Token (string value,int position)
        {
            Value = value;
            Position = position;
        }

        public static Token[] SplitString(string input)
        {
            List<Token> tokenList = new List<Token>();
            Token[] tokens = new Token[tokenList.Count];
            List<char> stopSymbol = new List<char> { ' ', '+', '-', '*', '/', '(', ')' };
            string nextToken = "";
            int positionInString = 0;
            for (int i=0; i<input.Length; i++)
            {
                if (stopSymbol.Contains(input[i]) == false)
                {
                    if (input[i] != ' ')
                    {
                        nextToken += input[i];
                    }

                }

                else if (stopSymbol.Contains(input[i]))
                {
                    Token newToken = new Token(nextToken, positionInString);
                    tokenList.Add(newToken);
                    nextToken=string.Empty;
                    Token newToken2 = new Token(input[i].ToString(), i);
                    tokenList.Add(newToken2);
                    positionInString = i + 1;
                   
                    while (input[positionInString]==' ')
                    {
                        positionInString++;
                    }

                }
            }   
                   
            tokens=tokenList.ToArray();
            return tokens;
        }
    }
}
