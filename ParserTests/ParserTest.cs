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
            Token[] myTokens = new Token[9];
            myTokens[0] = new Token("11", 0);
            myTokens[1] = new Token("+", 2);
            myTokens[2] = new Token("2", 3);
            myTokens[3] = new Token("*", 4);
            myTokens[4] = new Token("(", 5);
            myTokens[5] = new Token("3", 6);
            myTokens[6] = new Token("+", 7);
            myTokens[7] = new Token("12", 8);
            myTokens[8] = new Token(")", 10);

            //string input = "11+2*(3+12)";

            string result=myParser.Parse(myTokens);

            Assert.True(result == "11 2 3 12 + * +");
        }
    }
}
