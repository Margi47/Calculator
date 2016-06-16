using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserTests
{
    public class TokenTests
    {

        Tokenizer myTokenizer = new Tokenizer();
        Token[] resultTokens;
        Token[] correctTokens;

        [Fact]
        public void split_should_return_correct_tokens()
        {           
            string input = "11+2*(3+12)";
            correctTokens = new Token[]
            {
                new Token("11", 0),
                new Token("+", 2),
                new Token("2", 3),
                new Token("*", 4),
                new Token("(", 5),
                new Token("3", 6),
                new Token("+", 7),
                new Token("12", 8),
                new Token(")", 10),
            };

            resultTokens = myTokenizer.SplitString(input);

            Assert.Equal<Token>(resultTokens, correctTokens); 
        }

        [Fact]
        public void split_should_return_correct_tokens2()
        {
            string input = "+  8 df";
            correctTokens = new Token[]
            {
                new Token("+", 0),
                new Token("8", 3),
                new Token("df", 5),
            };

            resultTokens = myTokenizer.SplitString(input);

            Assert.Equal<Token>(resultTokens, correctTokens);
        }

    }
}
