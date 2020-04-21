using LINQ_Demo.Data;
using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public static class Joining
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
            var sequence = SequenceGenerator.Customers().Where(customer => customer.Name.Contains("M"))
                .Join(
                    SequenceGenerator.Orders(), 
                    customer => customer.Id, 
                    order => order.CustomerId, 
                    (customer, order) => new {order, customer}
                )
                .Join(
                    SequenceGenerator.Products(),
                    item => item.order.GetFirstProductId(),
                    product => product.Id,
                    (item, product) => new {description = product.Description, name = item.customer.Name}
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
                join order in orders on customer.Id equals order.CustomerId
                join product in products on order.GetFirstProductId() equals product.Id
                           where customer.Name.Contains("M")
                           select new {description = product.Description, name = customer.Name};

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.description} | {item.name}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void MethodOuterCustomerOrderProducts()
        {
            Program.IntroLine(true, "RightOuterJoin");
            Console.WriteLine("Maakt een left outer join van Orders en Products");
            Console.WriteLine("Geeft alle orders weer en geeft aan welke geen producten hebben.");
            Program.WhiteLine();
            ConsoleTableHeader(false);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Orders()
                .GroupJoin(
                    SequenceGenerator.Products(),
                    order => order.GetFirstProductId(),
                    product => product.Id,
                    (order, product) => new { product, order })
                .SelectMany(item => item.product.DefaultIfEmpty(new Product { Description = "NO PRODUCT            "}), 
                    (item, product) => new
                    {
                        description = product.Description,
                        orderid = item.order.Id
                    });

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.description} | {item.orderid}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void QueryOuterCustomerOrderProducts()
        {
            Program.IntroLine(false, "RightOuterJoin");
            Console.WriteLine("Maakt een left inner join van Orders en Products");
            Console.WriteLine("Geeft alle orders weer en geeft aan welke geen producten hebben.");
            Console.WriteLine("Vraagt eerst alle IEnumerables en voert daarna join query uit.");
            Program.WhiteLine();
            ConsoleTableHeader(false);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var orders = SequenceGenerator.Orders();
            var products = SequenceGenerator.Products();

            var sequence =
                from order in orders
                join product in products on order.GetFirstProductId() equals product.Id into productsGrouped
                from newProducts in productsGrouped.DefaultIfEmpty(new Product {Description = "NO PRODUCT            "})
                select new {orderid = order.Id, description = newProducts.Description};

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.description} | {item.orderid}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }


        public static void InnerJoinIntro()
        {
            Console.WriteLine("De join query en functie van LINQ voegt verschillende reeksen samen en geeft een aangegeven set aan attributen terug van deze reeksen.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven dat alle drie reeksen samenvoegt");
            Console.WriteLine("met een inner join om te zien welke klanten welke producten als eerste hebben besteld.");
        }

        public static void OuterJoinIntro()
        {
            Console.WriteLine("De join query en functie van LINQ voegt verschillende reeksen samen en geeft een aangegeven set aan attributen terug van deze reeksen.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven dat alle drie reeksen samenvoegt");
            Console.WriteLine("met een left outer join om te zien welke klanten welke producten klanten vermijden.");
        }

        private static void ConsoleTableHeader(bool inner = true)
        {
            if (inner)
            {
                Console.WriteLine("product name           | ordered by");
                Console.WriteLine("_______________________|________________________");
            }
            else
            {
                Console.WriteLine("product name           | order id");
                Console.WriteLine("_______________________|________________________");
            }
        }
    }
}
