using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserTests
{
    public class SorterTests
    {
        Tokenizer myTokenizer = new Tokenizer();
        Parser myParser = new Parser();
        Sorter mySorter = new Sorter();
        TokenValue[] correctTokens;
        TokenValue[] resultTokens;

        [Fact]
        public void parse_should_return_correct_string()
        {
            string input = "11+2*(3+12)";
            correctTokens = new TokenValue[]
            {
                new Digit(new Token("11", 0), 11),
                new Digit(new Token("2", 3), 2),
                new Digit(new Token("3", 6), 3),
                new Digit(new Token("12", 8), 12),
                new Sum(new Token("+", 7)),
                new Multiply(new Token("*", 4)),
                new Sum(new Token("+", 2)),
            };

            resultTokens = mySorter.SortToRPN(myParser.Parse(myTokenizer.SplitString(input)));

            Assert.Equal<TokenValue>(resultTokens, correctTokens);
        }
    }
}