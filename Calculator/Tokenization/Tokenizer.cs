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
        private char[] _stopSymbol = new char[] { SPACE, '+', '-', '*', '/', '(', ')' };
        
        public Token[] SplitString(string input)
        {
            List<Token> tokenList = new List<Token>();           
            int tStart = 0;
            int tLength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (_stopSymbol.Contains(input[i]))
                {
                    if (tLength > 0)
                    {
                        tokenList.Add(new Token(input.Substring(tStart, tLength), tStart));
                        tStart = i;
                        tLength = 0;
                    }

                    if (tLength == 0)
                    {
                        if (input[i] == SPACE)
                        {
                            tStart++;
                        }
                        else
                        {
                            tokenList.Add(new Token(input[i].ToString(), tStart));
                            tStart++;
                        }
                    }                    
                }
                else
                {
                    tLength++;
                    if (i == input.Length - 1)
                    {
                        tokenList.Add(new Token(input.Substring(tStart, tLength), tStart));
                    }
                }                                      
            }
            return tokenList.ToArray();
        }      
    }    
}

