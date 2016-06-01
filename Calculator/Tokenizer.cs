using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Tokenizer
    {
        private const char SPACE = ' ';
        char[] stopSymbol = new char[] { SPACE, '+', '-', '*', '/', '(', ')' };
        
        public Token[] SplitString(string input)
        {
            List<Token> tokenList = new List<Token>();           
            string nextToken = string.Empty;
            int positionInString = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (stopSymbol.Contains(input[i]) == false)
                {
                    if (input[i] != SPACE)
                    {
                        nextToken += input[i];
                    }
                }
                else if (stopSymbol.Contains(input[i]))
                {
                    Token newToken = new Token(nextToken, positionInString);
                    tokenList.Add(newToken);
                    nextToken = string.Empty;
                    Token newToken2 = new Token(input[i].ToString(), i);
                    tokenList.Add(newToken2);
                    positionInString = i + 1;

                    while (input[positionInString] == SPACE)
                    {
                        positionInString++;
                    }
                }
            }

            return tokenList.ToArray();
        }
    
    }
}
