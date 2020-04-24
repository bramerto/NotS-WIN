using System;
using System.Diagnostics;

namespace LINQ_Demo.Extension
{
    public static class LinqExtension
    {
        public static void DemoWhere()
        {
            ConsoleTableHeader();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Products().Where(p => p.Id == 10);

            foreach (var product in sequence)
            {
                Console.WriteLine($"{product.Id} | {product.Description}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void DemoSelect()
        {
            ConsoleTableHeader();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Products().Select(p => p.Description);

            foreach (var productName in sequence)
            {
                Console.WriteLine($"  | {productName}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void DemoAny()
        {
            ConsoleTableHeader();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var isPresent = SequenceGenerator.Products().Any(p => p.Description.Contains("80"));

            Console.WriteLine($"{isPresent}");
            
            stopwatch.Stop(); 
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("product id | product name");
            Console.WriteLine("___________|__________________________");
        }
    } 
}
