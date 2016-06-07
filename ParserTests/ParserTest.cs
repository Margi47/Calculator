using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Calculator;

namespace ParserTests
{
    public class ParserTest
    {
        [Fact]
        public void parse_should_return_correct_string()
        {
            Parser myParser = new Parser();
            Tokenizer myTokenizer = new Tokenizer();
            Token[] myTokens = myTokenizer.SplitString("11+2*(3+12)");
            TokenValue[] expectedResult = new TokenValue[] {
                new Digits(new Token("11", 0)),
                new Digits(new Token("2", 3)),
                new Digits(new Token("3", 6)),
                new Digits(new Token("12", 8)),
                new Sum(new Token("+", 7)),
                new Multiply(new Token("*", 4)),
                new Sum(new Token("+", 2)),
                };

            TokenValue[] newTokens = myParser.Parse(myTokens);

            Validate(newTokens, expectedResult);
        }

        public void Validate(TokenValue[] valueToCheck, TokenValue[] result)
        {
            Assert.True(valueToCheck.Length == result.Length);
            for (int i = 0; i < valueToCheck.Length; i++)
            {
                Assert.True(valueToCheck[i].ParentToken.Value == result[i].ParentToken.Value);
                Assert.True(valueToCheck[i].ParentToken.Position == result[i].ParentToken.Position);
            }
        }
    }
}
