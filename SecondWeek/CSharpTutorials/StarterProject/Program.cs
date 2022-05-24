using System;
using StarterProject.Helper;
using Infrastructure;

namespace StarterProject
{
    class Program
    {
        /// <summary>
        /// Il metodo main contiene l'entry point dell'applicazione e viene chiamato a Runtime come metodo statico
        /// </summary>
        /// <param name="args">Array di stringhe passate in input dalla riga di comando</param>
        static void Main(string[] args)
        {
            staticExample();

            Vehicle vehicle = new Vehicle(4);
            vehicle.Wheels = 3;
            Console.WriteLine(vehicle.Wheels);

            Console.WriteLine("Inserisci il primo numero"); // Si Inserisce nello stream output
            string num1 = Console.ReadLine(); // Si Inserisce nello stream input

            Console.WriteLine("Inserisci il secondo numero");
            string num2 = Console.ReadLine();

            Console.WriteLine(Int32.Parse(num1) + Int32.Parse(num2));

            ConsoleKeyInfo key = Console.ReadKey(); // Prende in input un tasto premuto sulla keyboard
            Console.WriteLine(key.KeyChar); // Stamp il valore (char) del tasto premuto
        }
        public static void staticExample()
        {
            Counter counter1 = new Counter();
            Counter counter2 = new Counter();

            Console.WriteLine(counter1.incrementValue()); // Print 1
            Console.WriteLine(counter1.incrementValue()); // Print 2
            Console.WriteLine(counter2.incrementValue()); // Print 1

            Console.WriteLine(Counter.TotalCounter); // Print 2
            Counter counter3 = new Counter();
            Console.WriteLine(Counter.TotalCounter); // Print 3
        }
    }
}
