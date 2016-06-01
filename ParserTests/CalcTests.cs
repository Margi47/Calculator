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
            string input = "2 5 3 - 2 * 4 2 / + +";

            int result = myCalc.CalculateResult(input);

            Assert.True(result == 8);
        }
    }
}
