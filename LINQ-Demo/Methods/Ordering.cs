using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public class Ordering
    {
        public static void MethodByTotalPrice()
        {
            Program.IntroLine(true, "OrderBy");
            Console.WriteLine("Zolang de lambda van de OrderBy functie een conditie bevalt waarin er een attribuut van Order wordt teruggegeven");
            Console.WriteLine("zal de functie Orderby een geordende IEnumerable van Orders teruggeven.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var sequence = SequenceGenerator.Orders().OrderBy(order => order.total_price - order.discount);

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.id}       | {item.total_price}");
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryByTotalPrice()
        {
            Program.IntroLine(false, "OrderBy");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Orders opgehaald.");
            Console.WriteLine("Hierop wordt vervolgens een orderby query op uitgevoerd.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Orders();
            var sequence = from order in collection
                orderby order.total_price - order.discount
                select order;

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.id}       | {item.total_price}");
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("order_id | total price");
            Console.WriteLine("_________|____________________________");
        }
    }
}
