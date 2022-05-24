using System;
using StarterProject.Helper;

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
            Vehicle vehicle = new Vehicle(4);
            Console.WriteLine(vehicle.wheels);

            Console.WriteLine("Inserisci il primo numero"); // Si Inserisce nello stream output
            string num1 = Console.ReadLine(); // Si Inserisce nello stream input

            Console.WriteLine("Inserisci il secondo numero");
            string num2 = Console.ReadLine();

            Console.WriteLine(Int32.Parse(num1) + Int32.Parse(num2));

            ConsoleKeyInfo key = Console.ReadKey(); // Prende in input un tasto premuto sulla keyboard
            Console.WriteLine(key.KeyChar); // Stamp il valore (char) del tasto premuto
        }
    }
}
