using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ_Demo.Methods
{
    public class Filtering
    {
        public static void MethodLowerTierProducts()
        {
            Console.WriteLine("Hier wordt de methode gebaseerde query toegepast:");
            Console.WriteLine("Zolang de lambda van de Where functie een conditie bevalt waarin er een boolean wordt teruggegeven");
            Console.WriteLine("zal de functie Where een gefilterde IEnumerable van Products teruggeven.");
            Program.WhiteLine();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var sequence = SequenceGenerator.Products().Where(product =>
            {
                var value = int.Parse(Regex.Match(product.name, @"\d+").Value);
                return value > 1000;
            });

            foreach (var item in sequence)
            {
                Console.WriteLine(item.name);
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Console.WriteLine($"Code uitgevoerd in: {stopwatch.ElapsedTicks} ticks.");
        }

        public static void QueryLowerTierProducts()
        {
            Console.WriteLine("Hier wordt de query expressie toegepast:");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Products opgehaald.");
            Console.WriteLine("Hierop wordt vervolgens een where query uitgevoerd.");

            Program.WhiteLine();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Products();
            var sequence = from product in collection where product.name.Contains("60") select product;

            foreach (var item in sequence)
            {
                Console.WriteLine(item.name);
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Console.WriteLine($"Code uitgevoerd in: {stopwatch.ElapsedTicks} ticks.");
        }
    }
}
