using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_Demo.Methods
{
    public class Partitioning
    {
        public static void TakeFive()
        {
            Program.IntroLine(true, "Take");
            Console.WriteLine("Heeft de reeks van customers en pakt de eerste 5 van deze reeks.");
            Console.WriteLine("Zal de eerste 5 Customers geven in een IEnumerable van Customers.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Customers().Take(5);

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.id} | {item.name}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void SkipFive()
        {
            Program.IntroLine(true, "Skip");
            Console.WriteLine("Heeft de reeks van customers en skipt over de eerste 5 van deze reeks.");
            Console.WriteLine("Zal de laatste 10 customers geven in een IEnumerable van Customers.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Customers().Skip(5);

            foreach (var item in sequence)
            {
                Console.WriteLine($"{item.id} | {item.name}");
            }
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void TakeSkipIntro()
        {
            Console.WriteLine("De take/skip functies van LINQ pakt een deel van de reeks om dit te partioneren.");
            Console.WriteLine("In de onderstaande queries zal er een demo wordt gegeven een reeks customers worden gepartitioneerd.");
        }

        public static void FirstOnName()
        {
            Program.IntroLine(true, "First");
            Console.WriteLine("Heeft de reeks van customers en pakt de eerste customer van");
            Console.WriteLine("deze reeks die aan de voorwaarde voldoet.");
            Console.WriteLine("Zal een Customer teruggeven met de naam 'Bram'");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var customer = SequenceGenerator.Customers().First(c => c.name.Contains("Bram"));
            Console.WriteLine($"{customer.id} | {customer.name}");
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void FirstOnNameException()
        {
            Program.IntroLine(true, "First");
            Console.WriteLine("Heeft de reeks van customers en pakt de eerste customer van");
            Console.WriteLine("Omdat de customer niet te vinden is, zal de functie een exception gooien.");
            Program.WhiteLine();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var customer = SequenceGenerator.Customers().First(c => c.name.Contains("TEST123"));
                Console.WriteLine($"{customer.id} | {customer.name}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }

            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void FirstOrDefaultOnName()
        {
            Program.IntroLine(true, "FirstOrDefault");
            Console.WriteLine("Heeft de reeks van customers en pakt de eerste customer van");
            Console.WriteLine("deze reeks die aan de voorwaarde voldoet.");
            Console.WriteLine("Zal een Customer teruggeven met de naam 'Bram'");
            Console.WriteLine("Als er geen customer kan worden gevonden zal de functie de default waarde teruggeven.");
            Console.WriteLine("In het geval van een object is dat null. Deze moet ook afgevangen worden.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var customer = SequenceGenerator.Customers().FirstOrDefault(c => c.name.Contains("Bram"));
            if (customer != null)
            {
                Console.WriteLine($"{customer.id} | {customer.name}");
            }
            
            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void FirstFirstOrDefaultIntro()
        {
            Console.WriteLine("De first/firstOrDefault functies van LINQ pakt een onderdeel van de reeks.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven");
            Console.WriteLine("hoe uit een reeks van customers een customer kan worden gehaald.");
            Console.WriteLine("Op geen van deze functies is een query expressie gemaakt.");
            Console.WriteLine("Uiteraard kan er eerst een query expressie worden gebruikt en dan deze methode worden gebruikt.");
            Console.WriteLine("Dat is de kracht van IEnumerable.");
        }

        public static void DistinctCustomers()
        {
            Program.IntroLine(true, "Distinct");
            Console.WriteLine("Pakt alle unieke customers, zodat er geen duplicaten zijn.");
            Console.WriteLine("Customer implementeerd IEquitable waardoor dit model");
            Console.WriteLine("vergelijkbaar is met het andere model.");
            Console.WriteLine("Dit is zodat er altijd unieke modellen zijn");
            Console.WriteLine("en je kan hierbij je eigen implementatie maken.");
            Console.WriteLine("Geeft 15 klanten terug omdat ze allemaal uniek zijn.");
            Program.WhiteLine();
            ConsoleTableHeader();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sequence = SequenceGenerator.Customers().Distinct();

            foreach (var customer in sequence)
            {
                Console.WriteLine($"{customer.id} | {customer.name}");
            }

            stopwatch.Stop();
            Program.WhiteLine();
            Program.StopwatchLine(stopwatch.ElapsedMilliseconds);
        }

        public static void DistinctIntro()
        {
            Console.WriteLine("De distinct functie van LINQ pakt de unieke onderdelen van een reeks.");
            Console.WriteLine("In de onderstaande queries zal er een demo worden gegeven");
            Console.WriteLine("hoe uit een reeks van customers alle unieke customers worden gehaald.");
            Console.WriteLine("Op deze functie is een query expressie gemaakt.");
            Console.WriteLine("Uiteraard kan er eerst een query expressie worden gebruikt en dan deze methode worden gebruikt.");
        }

        private static void ConsoleTableHeader()
        {
            Console.WriteLine("id | name");
            Console.WriteLine("___|__________________________");
        }
    }
}
