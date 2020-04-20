using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public class Grouping
    {
        public static void MethodByShippingCost()
        {
            Program.IntroLine(true, "GroupBy");
            Console.WriteLine("Groupeert orders bij shipping costs en laat zien hoeveel er in dezelfde groepering zitten.");
            Console.WriteLine("Zal een gegroepeerd IEnumerable van objecten teruggeven.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Orders().GroupBy(order => order.shipping_cost, order => order.id, 
                (shippingCost, orders) => new { Key = shippingCost, amount = orders.Count() }).OrderBy(item => item.Key);

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.amount}      | {item.Key}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryByShippingCost()
        {
            Program.IntroLine(false, "GroupBy");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Orders opgehaald. ");
            Console.WriteLine("Hierop wordt vervolgens een group by query op uitgevoerd en ");
            Console.WriteLine("zal er een gegroepeerd IEnumerable van objecten worden teruggeven.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var collection = SequenceGenerator.Orders();
            var sequence = from order in collection
                group order by order.shipping_cost
                into orderedOrder
                orderby orderedOrder.Key
                select new {orderedOrder.Key, amount = orderedOrder.Count()};

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.amount}      | {item.Key}");
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void Intro()
        {
            Console.WriteLine("De groupby query en functie van LINQ groupeert een gegeven reeks op een attribuut.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven waar orders worden gegroepeerd op verzendkosten.");
        }

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("amount | shipping cost");
            Console.WriteLine("_______|__________________________");
        }
    }
}
