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
            Calc myCalc = new Calc();
            Token[] myTokens = new Token[7];
            myTokens[0] = new Token("11", 0);
            myTokens[1] = new Token("2", 3);
            myTokens[2] = new Token("3", 6);
            myTokens[3] = new Token("12", 8);
            myTokens[4] = new Token("+", 7);
            myTokens[5] = new Token("*", 4);
            myTokens[6] = new Token("+", 2);

            int result = myCalc.CalculateResult(myTokens);

            Assert.True(result == 41);

        }
    }
}
