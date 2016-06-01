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
        [Fact]
        public void split_should_return_correct_tokens()
        {
            Token[] tokens;
            string input = "11+2*(3+12)";

            tokens = Token.SplitString(input);

            Assert.True(tokens.Length == 9);
           // Assert.True(tokens[0].Value == "11");
           // Assert.True(tokens[1].Value == "+");
           // Assert.True(tokens[1].Position == 2);


        }
    }
}
