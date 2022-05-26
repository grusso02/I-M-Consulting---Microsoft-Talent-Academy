using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure;
using System.Linq;

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
            PrintFlights(flights);
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
        public static void PrintFlights(List<Flights> flights)
        {
            Console.WriteLine("\n1 - From lowest delay\n2 - From highest delay");
            string chose = Console.ReadLine();
            switch (chose)
            {
                case "1":
                    PrintFlightsOrdered(flights, 1);
                    break;
                case "2":
                    PrintFlightsOrdered(flights, 2);
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    PrintFlights(flights);
                    break;
            }
        }
        public static void PrintFlightsOrdered(List<Flights> flights, int chose)
        {
            List<Flights> sorted = chose == 1 ? flights.OrderBy(x => x.DepDelay).ToList() : 
                flights.OrderByDescending(x => x.DepDelay).ToList();

            foreach (Flights flight in sorted)
                Console.Write($"Carrier: {flight.Carrier}\t Dep_Delay: {flight.DepDelay}\t " +
                    $"Arr_Delay: {flight.ArrDelay}\t Cancelled: {flight.Cancelled}\t Distance: {flight.Distance}\n");
        }
        public static void PrintNumFlights(List<Flights> flights)
        {
            int delayAvarage = 0;
            foreach (Flights flight in flights)
                delayAvarage += flight.DepDelay;
            delayAvarage /= flights.Count;

            Console.WriteLine($"Founded {flights.Count} flights, with a delay avarage of {delayAvarage} minutes");
        }
    }
}
