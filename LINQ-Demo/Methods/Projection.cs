using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public class Projection
    {
        public static void MethodSelectCustomerName()
        {
            Program.IntroLine(true, "Select");
            Console.WriteLine("Zolang de lambda van de Select functie een return value heeft om terug te geven in de reeks");
            Console.WriteLine("zal de functie Where een gefilterde IEnumerable van strings teruggeven die uit de Customer reeks komt.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Customers().Select(customer => customer.name);

            foreach (var item in sequence)
            {
                Console.WriteLine($"   | {item}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QuerySelectCustomerName()
        {
            Program.IntroLine(false, "Select");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Customers opgehaald.");
            Console.WriteLine("Hierop wordt vervolgens een select query op uitgevoerd.");
            Console.WriteLine("zal er een geordende IEnumerable van strings worden teruggeven die uit de Customer reeks komt.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var collection = SequenceGenerator.Customers();
            var sequence = from customer in collection select customer.name;

            foreach (var item in sequence)
            {
                Console.WriteLine($"   | {item}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void MethodSelectManyProductIds()
        {
            Program.IntroLine(true, "SelectMany");
            Console.WriteLine("De lambda functie van SelectMany kan een IEnumerable ontvangen, deze kan hij verwerken.");
            Console.WriteLine("Deze functie koppelt de product_id van Order naar de products");
            Console.WriteLine("zal de functie Selectmany door projectie een IEnumerable van Products teruggeven.");
            Program.WhiteLine();
            ConsoleTableHeader(false);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Orders().SelectMany(order => order.product_ids,
                (order, id) => SequenceGenerator.Products().FirstOrDefault(product => product.id == id));

            foreach (var item in sequence)
            {
                if (item != null)
                {
                    Console.WriteLine($"{item.id}         | {item.description}");
                }
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QuerySelectManyProductIds()
        {
            Program.IntroLine(false, "SelectMany");
            Console.WriteLine("In de query methode wordt eerst de IEnumerable van Orders en Products opgehaald.");
            Console.WriteLine("Hierop wordt vervolgens een select query op uitgevoerd op de product_ids van Order.");
            Console.WriteLine("Hierop zal over geitereerd worden en bij elke id zal er een nieuw product worden gevonden die wordt getoond.");
            Program.WhiteLine();
            ConsoleTableHeader(false);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var orders = SequenceGenerator.Orders();
            var identifiers = from order in orders select order.product_ids;

            foreach (var ids in identifiers)
            {
                foreach (var id in ids)
                {
                    var product = SequenceGenerator.Products().FirstOrDefault(p => p != null && p.id == id);
                    if (product != null)
                    {
                        Console.WriteLine($"{product.id}         | {product.description}");
                    }
                }
            }
            stopwatch.Stop();

            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void SelectIntro()
        {
            Console.WriteLine("De select query en functie van LINQ selecteert een attribuut binnen de reeks en geeft dit in een soort type terug.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven dat customers selecteert en alleen de namen teruggeeft.");
        }

        public static void SelectManyIntro()
        {
            Console.WriteLine("De selectmany query en functie van LINQ selecteert een attribuut binnen de reeks en itereert op dit attribuut.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven dat orders selecteert en, de producten die onder de bestellingen staan, toont.");
        }

        private static void ConsoleTableHeader(bool customer = true)
        {
            if (customer)
            {
                Console.WriteLine("id | customer name");
                Console.WriteLine("___|__________________________");
            }
            else
            {
                Console.WriteLine("product id | product name");
                Console.WriteLine("___________|__________________________");
            }
        }
    }
}
