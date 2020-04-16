using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ_Demo.Methods
{
    public class Filtering
    {
        public static void MethodHighTierProducts()
        {
            Program.IntroLine(true, "Where");
            Console.WriteLine("Zolang de lambda van de Where functie een conditie bevalt waarin er een boolean wordt teruggegeven");
            Console.WriteLine("zal de functie Where een gefilterde IEnumerable van Products teruggeven.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Products().Where(product =>
            {
                var value = int.Parse(Regex.Match(product.description, @"\d+").Value);
                return value > 1000;
            });

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.id}         | {item.description}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryHighTierProducts()
        {
            Program.IntroLine(false, "Where");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Products opgehaald.");
            Console.WriteLine("Hierop wordt vervolgens een where query op uitgevoerd.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Products();
            var sequence = from product in collection
                where int.Parse(Regex.Match(product.description, @"\d+").Value) > 1000
                select product;

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.id}         | {item.description}");
            }
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
