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
            Console.WriteLine("zal de functie Where een gefilterde IEnumerable van Customers teruggeven.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Customers().Select(customer => customer.name);

            foreach (var item in sequence)
            {
                Console.WriteLine($"           | {item}");
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
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var collection = SequenceGenerator.Customers();
            var sequence = from customer in collection select customer.name;

            foreach (var item in sequence)
            {
                Console.WriteLine($"           | {item}");
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
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Orders().SelectMany(order => order.product_ids, (order, id) =>
            {
                return SequenceGenerator.Products().FirstOrDefault(product => product.id == id);
            }).OrderBy(product => product?.id); //orderby to compare with query expression

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
            Console.WriteLine("Hierop wordt vervolgens een select query op uitgevoerd op dezelfde manier van selectmany.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var orders = SequenceGenerator.Orders();
            var products = SequenceGenerator.Products();
            var sequence = from product in products
                from id in 
                (
                    from ids in 
                    (
                        from order in orders select order.product_ids
                    ) select ids.ToArray()
                )
                where id[0] == product.id || id[1] == product.id && product != null
                //orderby to compare with method expression
                orderby product.id
                select product;

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

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("product id | product name");
            Console.WriteLine("___________|__________________________");
        }
    }
}
