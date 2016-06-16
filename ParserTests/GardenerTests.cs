using Calculator;
using Calculator.Planting;
using ParserTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserTests
{
    public class GardenerTests
    {
        Tokenizer myTokenizer = new Tokenizer();
        Parser myParser = new Parser();
        Sorter mySorter = new Sorter();
        Gardener myGardener = new Gardener();

        [Fact]
        public void garden_should_create_correct_tree()
        {
            var input = "11+2*(3+12)";
            var resultTokens = mySorter.SortToRPN(myParser.Parse(myTokenizer.SplitString(input)));

            IExpression result = myGardener.PlantTree(resultTokens);

            Assert.True(result.ToString() == "[11 + [2 * [3 + 12]]]");
            Assert.True(result.Calculate() == 41);
        }

        [Fact]
        public void catch_exception()
        {
            string input = "11+8-";
            TokenValue[] resultTokens = mySorter.SortToRPN(myParser.Parse(myTokenizer.SplitString(input)));

            Assert.Throws<Exception>(() => myGardener.PlantTree(resultTokens));
        }

        [Fact]
        public void catch_exception2()
        {
            string input = "11+ -";
            TokenValue[] resultTokens = mySorter.SortToRPN(myParser.Parse(myTokenizer.SplitString(input)));

            Assert.Throws<Exception>(() => myGardener.PlantTree(resultTokens));
        }
    }
}
