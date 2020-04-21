using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public class Aggregates
    {
        public static void MethodCountByPrice()
        {
            Program.IntroLine(true, "Count");
            Console.WriteLine("Telt hoeveel producten er een prijs boven de 150 hebben.");
            Console.WriteLine("Geeft een int van hoeveel entries de query heeft gevonden.");
            Program.WhiteLine();
            ConsoleTableHeader("count");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var countedSequence = SequenceGenerator.Products().Count(p => p.price > 150);
            Console.WriteLine(countedSequence);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryCountByPrice()
        {
            Program.IntroLine(false, "Count");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Products opgehaald. ");
            Console.WriteLine("Hierop wordt vervolgens een count query op uitgevoerd en ");
            Console.WriteLine("zal er een integer van de hoeveelheid entries gevonden worden teruggegeven.");
            Console.WriteLine("Er is geen count query keyword, dus de aggregate methode zelf wordt gewoon uitgevoerd.");
            Console.WriteLine("De uiteindelijke query waar je de count op moet uitvoeren is wel een query.");
            Program.WhiteLine();
            ConsoleTableHeader("count");

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Products();
            var countedSequence = (from product in collection where product.price > 150 select product).Count();

            Console.WriteLine(countedSequence);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void CountIntro()
        {
            Console.WriteLine("De count query en functie van LINQ telt een gegeven reeks op hoeveel entries er zijn gevonden.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven waar producten worden geteld die een grotere prijs hebben dan 150.");
        }

        public static void MethodMinPrice()
        {
            Program.IntroLine(true, "Min");
            Console.WriteLine("Haalt het laagste getal van een attribuut op binnen een reeks.");
            Console.WriteLine("Geeft een double van het laagste getal dat in de query is gevonden.");
            Program.WhiteLine();
            ConsoleTableHeader("min");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var lowestPrice = SequenceGenerator.Products().Min(p => p.price);
            Console.WriteLine(lowestPrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryMinPrice()
        {
            Program.IntroLine(false, "Min");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Products opgehaald. ");
            Console.WriteLine("Hierop wordt vervolgens een min query op uitgevoerd en ");
            Console.WriteLine("zal er een integer van de laagste attribuut van de entries worden teruggegeven.");
            Console.WriteLine("Er is geen min query keyword, dus de aggregate methode zelf wordt gewoon uitgevoerd.");
            Console.WriteLine("De uiteindelijke query waar je de min op moet uitvoeren is wel een query.");
            Program.WhiteLine();
            ConsoleTableHeader("min");

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Products();
            var lowestPrice = (from product in collection select product).Min(p => p.price);
            Console.WriteLine(lowestPrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void MinIntro()
        {
            Console.WriteLine("De min query en functie van LINQ scant een gegeven attribuut van een reeks");
            Console.WriteLine("en haalt daar het laagste getal uit.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven waar productprijzen worden gescand ");
            Console.WriteLine("en de laagste prijs wordt eruit gehaald.");
        }

        public static void MethodMaxPrice()
        {
            Program.IntroLine(true, "Max");
            Console.WriteLine("Haalt het hoogste getal van een attribuut op binnen een reeks.");
            Console.WriteLine("Geeft een double van het hoogste getal dat in de query is gevonden.");
            Program.WhiteLine();
            ConsoleTableHeader("max");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var highestPrice = SequenceGenerator.Products().Max(p => p.price);
            Console.WriteLine(highestPrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryMaxPrice()
        {
            Program.IntroLine(false, "Max");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Products opgehaald. ");
            Console.WriteLine("Hierop wordt vervolgens een min query op uitgevoerd en ");
            Console.WriteLine("zal er een integer van de hoogste attribuut van de entries worden teruggegeven.");
            Console.WriteLine("Er is geen min query keyword, dus de aggregate methode zelf wordt gewoon uitgevoerd.");
            Console.WriteLine("De uiteindelijke query waar je de max op moet uitvoeren is wel een query.");
            Program.WhiteLine();
            ConsoleTableHeader("max");

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Products();
            var highestPrice = (from product in collection select product).Max(p => p.price);
            Console.WriteLine(highestPrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void MaxIntro()
        {
            Console.WriteLine("De max query en functie van LINQ scant een gegeven attribuut van een reeks");
            Console.WriteLine("en haalt daar het hoogste getal uit.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven waar productprijzen worden gescand ");
            Console.WriteLine("en de hoogste prijs wordt eruit gehaald.");
        }

        public static void MethodSumPrice()
        {
            Program.IntroLine(true, "Sum");
            Console.WriteLine("Haalt de opgetelde som van een attribuut op binnen een reeks.");
            Console.WriteLine("Geeft een double van de opgetelde som van prijzen dat in de query is gevonden.");
            Program.WhiteLine();
            ConsoleTableHeader("sum");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var summedPrice = SequenceGenerator.Products().Sum(p => p.price);
            Console.WriteLine(summedPrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QuerySumPrice()
        {
            Program.IntroLine(false, "Sum");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Products opgehaald. ");
            Console.WriteLine("Hierop wordt vervolgens een sum query op uitgevoerd en ");
            Console.WriteLine("zal er een double van alle prijzen bij elkaar opgeteld van de entries worden teruggegeven.");
            Console.WriteLine("Er is geen sum query keyword, dus de aggregate methode zelf wordt gewoon uitgevoerd.");
            Console.WriteLine("De uiteindelijke query waar je de sum op moet uitvoeren is wel een query.");
            Program.WhiteLine();
            ConsoleTableHeader("sum");

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Products();
            var summedPrice = (from product in collection select product).Sum(p => p.price);
            Console.WriteLine(summedPrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void SumIntro()
        {
            Console.WriteLine("De sum query en functie van LINQ pakt een gegeven attribuut ");
            Console.WriteLine("en somt alle attributen van de reeks bij elkaar op.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven waar productprijzen worden gescand ");
            Console.WriteLine("en alle prijzen bij elkaar worden opgeteld.");
        }

        public static void MethodAveragePrice()
        {
            Program.IntroLine(true, "Average");
            Console.WriteLine("Haalt gemiddelde van een attribuut op binnen een reeks.");
            Console.WriteLine("Geeft een double van het gemiddelde van prijzen dat in de query is gevonden.");
            Program.WhiteLine();
            ConsoleTableHeader("average");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var averagePrice = SequenceGenerator.Products().Average(p => p.price);
            Console.WriteLine(averagePrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryAveragePrice()
        {
            Program.IntroLine(false, "Average");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Products opgehaald. ");
            Console.WriteLine("Hierop wordt vervolgens een sum query op uitgevoerd en ");
            Console.WriteLine("zal er een double van alle prijzen bij elkaar opgeteld van de entries worden teruggegeven.");
            Console.WriteLine("Er is geen sum query keyword, dus de aggregate methode zelf wordt gewoon uitgevoerd.");
            Console.WriteLine("De uiteindelijke query waar je de average op moet uitvoeren is wel een query.");
            Program.WhiteLine();
            ConsoleTableHeader("average");

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Products();
            var averagePrice = (from product in collection select product).Average(p => p.price);
            Console.WriteLine(averagePrice);
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void AverageIntro()
        {
            Console.WriteLine("De average query en functie van LINQ pakt een gegeven attribuut ");
            Console.WriteLine("en somt alle attributen van de reeks bij elkaar op om er een gemiddelde uit te vinden.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven waar productprijzen worden gescand");
            Console.WriteLine("en alle prijzen bij elkaar worden opgeteld om er een gemiddelde uit te halen.");
        }

        private static void ConsoleTableHeader(string sort)
        {
            switch (sort)
            {
                case "count":
                    Console.WriteLine("entries amount |");
                    Console.WriteLine("_______________|");
                    break;
                case "min":
                    Console.WriteLine("lowest price |");
                    Console.WriteLine("_____________|");
                    break;
                case "max":
                    Console.WriteLine("highest price | ");
                    Console.WriteLine("______________|");
                    break;
                case "sum":
                    Console.WriteLine("sum of all prices |");
                    Console.WriteLine("__________________|");
                    break;
                case "average":
                    Console.WriteLine("average price |");
                    Console.WriteLine("______________|");
                    break;
            }
        }
    }
}
