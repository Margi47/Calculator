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
            Tokenizer myTokenizer = new Tokenizer();
            string input = "11+2*(3+12)";

            Token[] tokens = myTokenizer.SplitString(input);

            Assert.True(tokens.Length == 9);
            Assert.True(tokens[0].Value == "11");
            Assert.True(tokens[1].Value == "+");
            Assert.True(tokens[1].Position == 2);
            Assert.True(tokens[8].Value == ")");
            Assert.True(tokens[8].Position == 10);
        }
    }
}
