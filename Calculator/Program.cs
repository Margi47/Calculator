using Calculator.Parsing;
using Calculator.Planting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter expression:");
                var inputString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    continue;
                }

                try
                {
                    var tokenizer = new Tokenizer();
                    var tokens = tokenizer.SplitString(inputString);

                    var parser = new Parser();
                    var tokenValues = parser.Parse(tokens);

                    var sorter = new Sorter();
                    tokenValues = sorter.SortToRPN(tokenValues);

                    var gardener = new Gardener();
                    var tree = gardener.PlantTree(tokenValues);

                    var result = tree.Calculate();

                    Console.WriteLine("Result is " + result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
