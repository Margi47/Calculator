using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Calculator;
using Calculator.Parsing;

namespace ParserTests
{
    public class ParserTest
    {
        Parser myParser = new Parser();
        Tokenizer myTokenizer = new Tokenizer();
        TokenValue[] correctTokens;
        TokenValue[] resultTokens;

        [Fact]
        public void parse_should_return_correct_values()
        {          
            string input="11+2*(3+12)";
            correctTokens = new TokenValue[] 
            {
                new Digit(new Token("11", 0), 11),
                new Sum(new Token("+", 2)),
                new Digit(new Token("2", 3), 2),
                new Multiply(new Token("*", 4)),
                new LeftBrace(new Token("(", 5)),
                new Digit(new Token("3", 6), 3),
                new Sum(new Token("+", 7)),
                new Digit(new Token("12", 8), 12),
                new RightBrace(new Token(")", 10))                
            };

            resultTokens = myParser.Parse(myTokenizer.SplitString(input));

            Assert.Equal<TokenValue>(resultTokens, correctTokens);
        }

        [Fact]
        public void catch_exception()
        {
            string input = "11+df-=";

            Assert.Throws<Exception>(() => myParser.Parse(myTokenizer.SplitString(input)));
        }
    }
}
