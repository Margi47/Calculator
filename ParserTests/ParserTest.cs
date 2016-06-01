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
            string input = "2+5-8*2+4/2";

            //string result=myParser.ParseInput(input);

            //Assert.True(result == "2 5 8 2 * 4 2 / + - +");
        }

        [Fact]
        public void parse_should_return_correct_string_with_parentheses()
        {
            Parser myParser = new Parser();
            string input = "2+(5-8)*2+4/2";

            //string result = myParser.ParseInput(input);

           // Assert.True(result == "2 5 8 - 2 * 4 2 / + +");
        }
    }
}
