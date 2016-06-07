using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserTests
{
    public class CalcTests
    {
        [Fact]
        public void calc_should_return_correct_value()
        {
            Tokenizer myTokenizer = new Tokenizer();
            Token[] myTokens = myTokenizer.SplitString("11+2*(3+12)");
            Parser myParser = new Parser();
            TokenValue[] myTokenValues = myParser.Parse(myTokens);
            Calc myCalc = new Calc();

            int result = myCalc.CalculateResult(myTokenValues);

            Assert.True(result == 41);

        }
    }
}
