using System;
using LINQ_Demo.Methods;

namespace LINQ_Demo
{
    internal class Program
    {
        public static void Main(string[] args)
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Onderstaande functies is een filtering van de 15 producten in de interne geheugen database.");
            WhiteLine();
            Filtering.MethodLowerTierProducts();
            Breaker();
            Filtering.QueryLowerTierProducts();
            Breaker();

            Console.WriteLine("Onderstaande functies is een projecteren van 15 producten in de interne geheugen database.");
            WhiteLine();

            Breaker();

            Breaker();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Alle demo's van de standaard LINQ bibliotheek zijn we langsgegaan.");
            Console.WriteLine("In het laatste stuk van dit programma zal er extentions op de SELECT, WHERE en ANY methoden van LINQ worden gemaakt.");
            WhiteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            var input = default(string);

            while (input != "done")
            {
                input = Console.ReadLine();
            }
        }

        public static void Breaker()
        {
            WhiteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------");
            WhiteLine();
        }

        public static void WhiteLine()
        {
            Console.WriteLine("");
        }
    }
}
