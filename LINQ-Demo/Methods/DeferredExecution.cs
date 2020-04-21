using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public static class DeferredExecution
    {
        public static void Demo()
        {
            Console.WriteLine("In deze laatste demo zal worden laten zien hoe Deferred Execution werkt.");
            Console.WriteLine("Deferred Execution is een methode om met LINQ te werken.");
            Console.WriteLine("Hierin wordt het uitvoeren van de query tot een later moment uitgesteld.");
            Console.WriteLine("Voordelen hiervan zijn is dat de query pas hoeft uit te voeren als je de resultaten nodig hebt en");
            Console.WriteLine("dat de reeks nog tussen de het maken en uitvoeren van de query aangepast kan worden.");
            Console.WriteLine("Zo heb je altijd de laatste data.");
            Program.WhiteLine();
            Console.WriteLine("In de eerste methode wordt deferred execution gebruikt in de tweede niet.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var products = SequenceGenerator.Products().Where(p => p.Price > 120); //query is gebouwd maar nog niet uitgevoerd
            products = products.Where(p => p.Price < 170); //query is aangepast maar not steeds niet uitgevoerd

            foreach (var product in products) //query wordt hier uitgevoerd
            {
                Console.WriteLine($"{product.Id} | {product.Price}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();
            Program.WhiteLine();
            ConsoleTableHeader();

            stopwatch.Start();
            var products2 = SequenceGenerator.Products().Where(p => p.Price > 120)
                .Where(p => p.Price < 170)
                .ToArray(); //in deze instantie wordt de query meteen uitgevoerd met de functie 'ToArray' en in een array gezet

            foreach (var product2 in products2) //loopt door de lijst heen zonder lazy evaluation
            {
                Console.WriteLine($"{product2.Id} | {product2.Price}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("id | price");
            Console.WriteLine("___|__________________________");
        }
    }
}
