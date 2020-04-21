using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public static class Ordering
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
            var sequence = SequenceGenerator.Orders().OrderBy(order => order.TotalPrice - order.Discount);

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.Id}       | {item.TotalPrice}");
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryByTotalPrice()
        {
            Program.IntroLine(false, "OrderBy");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Orders opgehaald.");
            Console.WriteLine("Hierop wordt vervolgens een orderby query op uitgevoerd en");
            Console.WriteLine("zal er een geordende IEnumerable van Orders worden teruggeven.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Orders();
            var sequence = from order in collection
                orderby order.TotalPrice - order.Discount
                select order;

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.Id}       | {item.TotalPrice}");
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void Intro()
        {
            Console.WriteLine("De orderby query en functie van LINQ ordend een gegeven reeks op een attribuut van een object.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven dat orders ordend op de totale prijs minus de korting.");
        }

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("order_id | total price");
            Console.WriteLine("_________|____________________________");
        }
    }
}
