using System;
using LINQ_Demo.Data;
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

            Console.WriteLine("3). Projection: Onderstaande functies is een projectie van 15 klanten.");
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

            Console.WriteLine("4). Joining: Onderstaande functies is een joining van 15 producten, orders en klanten.");
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
            Grouping.Intro();
            WhiteLine();
            Grouping.MethodByShippingCost();
            Breaker();
            Grouping.QueryByShippingCost();
            Breaker();
        }

        private static void DemoOverviewPart2()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("We zijn langs alle demo's van de standaard LINQ bibliotheek gegaan.");
            Console.WriteLine("In het laatste stuk van dit programma zal er extentions op de SELECT, WHERE en ANY methoden van LINQ worden gemaakt.");
            WhiteLine();
        }

        private static void DemoPart2()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
