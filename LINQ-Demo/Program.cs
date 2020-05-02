using System;
using LINQ_Demo.Data;
using LINQ_Demo.Extension;
using LINQ_Demo.Methods;

namespace LINQ_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Set data in internal memory database
            SequenceGenerator.database = new InternalDatabase();

            DemoOverviewPart1();
            DemoPart1();

            DemoOverviewPart2();
            DemoPart2();
            CollectionVsSequence();

            Console.ReadLine();
        }

        private static void Breaker()
        {
            WhiteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------");
            WhiteLine();
        }

        public static void WhiteLine()
        {
            Console.WriteLine("");
        }

        public static void StopwatchLine(long milliseconds)
        {
            Console.WriteLine(milliseconds > 0
                ? $"LINQ query uitgevoerd in: {milliseconds}ms."
                : "LINQ query uitgevoerd tussen de 0ms en 1ms.");
        }

        public static void IntroLine(bool method, string name)
        {
            Console.WriteLine(method
                ? $"METHOD BASED '{name}' QUERY:"
                : $"'{name}' QUERY BASED EXPRESSION:");
        }

        private static void DemoOverviewPart1()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Onderstaande onderwerpen zullen ingaan op de LINQ standaard bibliotheek en de methoden.");
            Console.WriteLine("Er is data aangemaakt door de LINQ_Demo-Data.InternalDatabase class. Hier zal mee worden gewerkt.");
            Console.WriteLine("In de methoden waarvoor een demo wordt gegeven zijn twee query methoden gebruikt:");
            Console.WriteLine("     - methode gebaseerde query");
            Console.WriteLine("     - query expressie");
            Console.WriteLine("Beide methodes hebben voordelen, maar het komt vooral neer op ease-of-use.");
            Console.WriteLine("Ook werken beide methodes met IEnumerables en zijn daarmee intern hetzelfde.");
            Console.WriteLine("De query expressie methode kan worden toegepast als je bekend bent met SQL en graag daarmee werkt.");
            WhiteLine();
        }

        private static void DemoPart1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1). Filtering: Onderstaande functies is een filtering van de 15 producten.");
            WhiteLine();
            Filtering.Intro();
            WhiteLine();
            Filtering.MethodHighTierProducts();
            Breaker();
            Filtering.QueryHighTierProducts();
            Breaker();

            Console.WriteLine("2). Ordering: Onderstaande functies is een ordering van 15 orders.");
            WhiteLine();
            Ordering.Intro();
            WhiteLine();
            Ordering.MethodByTotalPrice();
            Breaker();
            Ordering.QueryByTotalPrice();
            Breaker();

            Console.WriteLine("3). Projection: Onderstaande functies is een projectie van 15 customers.");
            WhiteLine();
            Projection.SelectIntro();
            WhiteLine();
            Projection.MethodSelectCustomerName();
            Breaker();
            Projection.QuerySelectCustomerName();
            Breaker();

            Projection.SelectManyIntro();
            WhiteLine();
            Projection.MethodSelectManyProductIds();
            Breaker();
            Projection.QuerySelectManyProductIds();
            Breaker();

            Console.WriteLine("4). Joining: Onderstaande functies is een joining van 15 producten, orders en customers.");
            WhiteLine();
            Joining.InnerJoinIntro();
            WhiteLine();
            Joining.MethodInnerCustomerOrderProducts();
            Breaker();
            Joining.QueryInnerCustomerOrderProducts();
            Breaker();

            Joining.OuterJoinIntro();
            WhiteLine();
            Joining.MethodOuterCustomerOrderProducts();
            Breaker();
            Joining.QueryOuterCustomerOrderProducts();
            Breaker();

            Console.WriteLine("5). Grouping: Onderstaande functies is een groupering van 15 orders.");
            WhiteLine();
            Grouping.Intro();
            WhiteLine();
            Grouping.MethodByShippingCost();
            Breaker();
            Grouping.QueryByShippingCost();
            Breaker();

            Console.WriteLine("6). Aggregates: Onderstaande functies zijn aggregates van 15 producten.");
            WhiteLine();
            Aggregates.CountIntro();
            WhiteLine();
            Aggregates.MethodCountByPrice();
            Breaker();
            Aggregates.QueryCountByPrice();
            Breaker();

            Aggregates.MinIntro();
            WhiteLine();
            Aggregates.MethodMinPrice();
            Breaker();
            Aggregates.QueryMinPrice();
            Breaker();

            Aggregates.MaxIntro();
            WhiteLine();
            Aggregates.MethodMaxPrice();
            Breaker();
            Aggregates.QueryMaxPrice();
            Breaker();

            Aggregates.SumIntro();
            WhiteLine();
            Aggregates.MethodSumPrice();
            Breaker();
            Aggregates.QuerySumPrice();
            Breaker();

            Aggregates.AverageIntro();
            WhiteLine();
            Aggregates.MethodAveragePrice();
            Breaker();
            Aggregates.QueryAveragePrice();
            Breaker();

            Console.WriteLine("7). Partitioning: Onderstaande functies zijn partitioning van 15 customers.");
            WhiteLine();
            Partitioning.TakeSkipIntro();
            WhiteLine();
            Partitioning.TakeFive();
            Breaker();
            Partitioning.SkipFive();
            Breaker();

            Partitioning.FirstFirstOrDefaultIntro();
            WhiteLine();
            Partitioning.FirstOnName();
            Breaker();
            Partitioning.FirstOnNameException();
            Breaker();
            Partitioning.FirstOrDefaultOnName();
            Breaker();

            Partitioning.DistinctIntro();
            WhiteLine();
            Partitioning.DistinctCustomers();
            Breaker();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("8). Deferred Execution: Onderstaande functies is het uitvoeren van deferred execution.");
            WhiteLine();
            DeferredExecution.Demo();
            Breaker();
        }

        private static void DemoOverviewPart2()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("We zijn langs alle demo's van de standaard LINQ bibliotheek gegaan.");
            Console.WriteLine("In het laatste stuk van dit programma zal er extentions op de SELECT, WHERE en ANY methoden van LINQ worden gemaakt.");
            WhiteLine();
        }

        private static void CollectionVsSequence()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Er is een verschil tussen een reeks en een collectie binnen LINQ.");
            Console.WriteLine("Reeks:");
            Console.WriteLine("Is een IEnumerable, en kan alleen het volgende element ophalen.");
            Console.WriteLine("Een IEnumerable houdt dus niet de hele lijst in het geheugen");
            Console.WriteLine("en kan hier dus ook niks in aanpassen of dynamiek inlezen of schrijven.");
            Console.WriteLine("Dit heeft een aantal voordelen:");
            Console.WriteLine(" - Er wordt minder geheugen gebruikt.");
            Console.WriteLine(" - Bij grootte reeksen wordt deze niet in een keer opgehaald.");
            Console.WriteLine(" - Zorgt ervoor dat LINQ queries logisch kunnen worden gebouwd.");
            Console.WriteLine("Reeksen hebben dus positieve impact op geheugen omdat het niet een hele array op hoeft te halen");
            Console.WriteLine("om een LINQ query uit te voeren. Dit maakt het efficient voor de software.");
            WhiteLine();
            Console.WriteLine("Collectie:");
            Console.WriteLine("Is een array die wordt geladen in het geheugen.");
            Console.WriteLine("Dit kunnen verschillende soorten collecties zijn waaronder:");
            Console.WriteLine(" - List");
            Console.WriteLine(" - Collection");
            Console.WriteLine(" - HashTable");
            Console.WriteLine(" - Dictionary");
            Console.WriteLine("Het voordeel hiervan is dat deze collecties kunnen");
            Console.WriteLine("worden ingelezen en er kunnen ook elementen aan toegevoegd worden.");
            Console.WriteLine("Dit neemt uiteraard meer geheugen in voor het systeem");
            Console.WriteLine("en kan dus voor grote collecties een performance hit geven.");
            Console.WriteLine("Op collecties kunnen ook LINQ queries uitgevoerd worden.");
        }

        private static void DemoPart2()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1). WHERE Extension: Onderstaande functie is een aangepaste extension van Where in LINQ.");
            WhiteLine();
            LinqExtension.DemoWhere();
            Breaker();
            Console.Write("2). SELECT Extension: Onderstaande functie is een aangepaste extension van Select in LINQ.");
            WhiteLine();
            LinqExtension.DemoSelect();
            Breaker();
            Console.Write("3). ANY Extension: Onderstaande functie is een aangepaste extension van Any in LINQ.");
            WhiteLine();
            LinqExtension.DemoAny();
            Breaker();
        }
    }
}
