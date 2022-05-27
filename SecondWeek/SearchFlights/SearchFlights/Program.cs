using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SearchFlights
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Flights> flights = new List<Flights>();

            Console.WriteLine("Please insert Origin");
            string origin = Console.ReadLine();
            Console.WriteLine("Please insert Destination");
            string destination = Console.ReadLine();

            ReadFile(flights, origin, destination);
            PrintNumFlights(flights);
            SortFlights(flights);
            return;
        }
        public static void ReadFile(List<Flights> flights, string origin, string destination)
        {
            string filepath = @"C:\Microsoft-Talent-Academy\SecondWeek\SearchFlights\SearchFlights\flights.csv";

            if (File.Exists(filepath))
            {
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string s;
                    sr.ReadLine(); //skip the first line
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] splitted = s.Split(",");
                        if (origin.ToLower() == splitted[1].ToLower() &&
                            destination.ToLower() == splitted[2].ToLower())
                            flights.Add(new Flights(splitted));
                    }
                }
            }
        }
        public static void PrintNumFlights(List<Flights> flights)
        {
            double delayAvarage = flights.Average(a => a.DepDelay);
            Console.WriteLine($"Founded {flights.Count} flights, with a delay avarage of {delayAvarage} minutes");
        }
        public static void SortFlights(List<Flights> flights)
        {
            Console.WriteLine("\n1 - From lowest delay\n2 - From highest delay");
            string chose = Console.ReadLine();
            List<Flights> sorted = null;
            switch (chose)
            {
                case "1":
                    sorted = flights.OrderBy(x => x.DepDelay).ToList();
                    break;
                case "2":
                    sorted = flights.OrderByDescending(x => x.DepDelay).ToList();
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    SortFlights(flights);
                    break;
            }
            PrintFlights(sorted, 1);
            /*#region QUERY
            foreach (Flights flight in flights)
                if (flight.ArrDelay > 300)                  // If else statement
                    Console.WriteLine(flight.Carrier);
            IEnumerable<string> matches = from flight in flights where flight.ArrDelay > 0 select flight.Carrier; //LINQ
            var matches2 = flights
                .Where(flight => flight.ArrDelay > 0)
                .Select(filtered => filtered.Carrier); // Come viene risolto a Runtimeg

            foreach (string carrier in matches)
                Console.WriteLine(carrier);
            #endregion*/
        }
        public static void PrintFlights(List<Flights> flights, int page)
        {
            if (page > flights.Count / 10)
                return;
            var pageditems = flights.Skip(10 * (page - 1)).Take(10);

            Console.WriteLine($"{page}/{flights.Count / 10}");
            foreach (var flight in pageditems)
                Console.Write($"Carrier: {flight.Carrier}\t Dep_Delay: {flight.DepDelay}\t " +
                    $"Arr_Delay: {flight.ArrDelay}\t Cancelled: {flight.Cancelled}\t Distance: {flight.Distance}\n");
            Console.WriteLine("Press 'Enter' for next page\nPress 'Esc' to exit\n");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Enter)
                PrintFlights(flights, ++page);
            else if (key == ConsoleKey.Escape)
                return;
        }
    }
}
