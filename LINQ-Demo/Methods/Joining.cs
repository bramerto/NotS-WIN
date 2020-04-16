using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public class Joining
    {
        public static void MethodInnerCustomerOrderProducts()
        {
            Program.IntroLine(true, "InnerJoin");
            Console.WriteLine("Maakt een inner join van Customers, Orders en Products");
            Console.WriteLine("Geeft alle producten in orders van mensen die een 'M' in hun naam hebben weer.");
            Console.WriteLine("Geeft een object terug met de product omschrijving en naam van de klant");
            Console.WriteLine("door twee Join methodes te gebruiken.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Customers().Where(customer => customer.name.Contains("M"))
                .Join(
                    SequenceGenerator.Orders(), 
                    customer => customer.id, 
                    order => order.customer_id, 
                    (customer, order) => new {order, customer}
                )
                .Join(
                    SequenceGenerator.Products(),
                    item => item.order.product_ids.ToArray()[0],
                    product => product.id,
                    (item, product) => new {product.description, item.customer.name}
                );

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.description} | {item.name}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryInnerCustomerOrderProducts()
        {
            Program.IntroLine(false, "InnerJoin");
            Console.WriteLine("Maakt een inner join van Customers, Orders en Products");
            Console.WriteLine("Geeft alle producten in orders van mensen die een 'M' in hun naam hebben weer.");
            Console.WriteLine("Vraagt eerst alle IEnumerables en voert daarna join query uit.");
            Console.WriteLine("Geeft een object terug met de product omschrijving en naam van de klant.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var customers = SequenceGenerator.Customers();
            var orders = SequenceGenerator.Orders();
            var products = SequenceGenerator.Products();

            var sequence = from customer in customers
                join order in orders on customer.id equals order.customer_id
                join product in products on order.product_ids.ToArray()[0] equals product.id
                           where customer.name.Contains("M")
                           select new {product.description, customer.name};

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.description} | {item.name}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("product name           | ordered by");
            Console.WriteLine("_______________________|________________________");
        }
    }
}
