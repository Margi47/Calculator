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
            string input = "11 2 3 12 + * +";

            int result = myCalc.CalculateResult(input);

            Assert.True(result == 41);
        }
    }
}
