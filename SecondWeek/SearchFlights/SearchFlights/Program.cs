using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure;

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
                        if (origin == splitted[1] && destination == splitted[2])
                            flights.Add(new Flights(splitted));
                    }
                }
            }
        }
        public static void PrintFlights(List<Flights> flights)
        {
            foreach (Flights flight in flights)
                Console.Write("Carrier: {0}\t Dep_Delay: {1}\t Arr_Delay: {2}\t Cancelles: {3}\t Distance: {4}\n",
                    flight.Carrier, flight.DepDelay, flight.ArrDelay, flight.Cancelled, flight.Distance);
        }
    }
}
