using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure;
using DataLayer;

namespace StarterProject
{
    class Program
    {
        /// <summary>
        /// Il metodo main contiene l'entry point dell'applicazione e viene chaimato dal Runtime come metodo statico
        /// </summary>
        /// <param name="args">Array di stringhe passate in input dalla rga di comando</param>
        static void Main(string[] args)
        {

            EsempioGetBooks();
            return;

            int first = new int();
            first = 0;
            int second = 0;


            second.ToString();

            string[] nomi1 = { "Antonio", "Caterina", "Manuela", "Lucia" };
            string[] nomi2 = nomi1; // La variabile nomi2 punta alla stessa area di memoria di nomi (copio la reference e non il valore)
            Console.WriteLine("Prima della modifica: elemento 0 dell'array nomi1 è: " + nomi1[0]);
            Console.WriteLine("Prima della modifica: elemento 0 dell'array nomi2 è: " + nomi2[0]);

            nomi1[0] = "Paperino";
            Console.WriteLine("Dopo la modifica: elemento 0 dell'array nomi1 è: " + nomi1[0]);
            Console.WriteLine("Dopo la modifica: elemento 0 dell'array nomi2 è: " + nomi2[0]);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("valore1");
            stringBuilder.Append(" valore2");
            stringBuilder.Append(" valore3");
            Console.WriteLine(stringBuilder.ToString());

            Console.WriteLine((int)GiorniDellaSettimana.Lunedì);

            Console.WriteLine("Per favore inserisci un numero.");
            string numero = Console.ReadLine(); // Assegnazione di variabile
            if (!Int32.TryParse(numero, out first))
                Console.WriteLine("Il numero inserito non è valido.");

            Console.WriteLine("Per favore inserisci un secondo numero.");
            string numero2 = Console.ReadLine(); // Assegnazione di variabile
            if (!Int32.TryParse(numero2, out second))
                Console.WriteLine("Il numero inserito non è valido.");

            Console.WriteLine(first >= second ? "Il primo è maggiore o uguale al secondo" : "Il secondo è maggiore del primo");

            Calculator risultato = new Calculator(first, second);
            Console.WriteLine(risultato.Somma());
            Console.ReadLine();

        }

        /// <summary>
        /// Struct è un tipo valore, a differenza delle classi che sono tipi riferimento
        /// </summary>
        public struct Calculator
        {
            public Calculator(double primo, double secondo)
            {
                Primo = primo;
                Secondo = secondo;
            }

            public double Somma()
            {
                return Primo + Secondo;
            }

            public double Primo { get; set;  }
            public double Secondo { get; set;  }
        }
        public enum GiorniDellaSettimana
        { 
            Lunedì = 1,
            Martedì = 2,
            Mercoledì = 3,
            Giovedì = 4,
            Venerdì = 5,
            Sabato = 6,
            Domenica = 7
        }

        public static void EsempioStatic()
        {
            Counter counter1 = new Counter();
            Counter counter2 = new Counter();

            Console.WriteLine(counter1.IncrementValue()); // Print 1
            Console.WriteLine(counter1.IncrementValue()); // Print 2
            Console.WriteLine(counter2.IncrementValue()); // Print 1

            Console.WriteLine(Counter.TotalCounter); // Print 2
            Counter counter3 = new Counter();
            Console.WriteLine(Counter.TotalCounter); // Print 3
        }
        public static void EsempioVehicle()
        {
            Car car = new Car();
            MotorBike bike = new MotorBike();

            Vehicle bike2 = bike;
            Console.WriteLine(object.ReferenceEquals(bike2, bike));
            Console.WriteLine("bike.Speed: " + bike.Ruote);
            Console.WriteLine("bike2.Speed: " + bike2.Ruote);
        }
        public static void EsempioByRef()
        {
            int[] arr = { 1, 2, 3 };
            int? num = null;
            bool result = Helper.GetNumElements(arr, ref num);
            //Console.WriteLine(num);
            Console.WriteLine($"Il primo elemento vale: {arr[0]}");
        }
        public static void EsempioStruttura()
        {
            Point point1 = new Point(2.5, 3.5);
            Point point2 = new Point(2.5, 3.5);
            Console.WriteLine("I punti sono uguali? " + (point2 == point1));
            Console.WriteLine("I punti sono diversi? " + (point2 != point1));
            Console.WriteLine(point1.Equals(point2));
        }
        public static void EsempioClassi()
        {
            Vehicle motorBike = new MotorBike(); // Upcast
            Console.WriteLine(motorBike.Ruote);
            motorBike.Accelera();
            motorBike.Decelera();
        }
        public static void EsempioInterfaccia()
        {
            IVehicle vehicle = new Car(); // Upcast
            Console.WriteLine(vehicle.Ruote);
            vehicle.Accelera();
            vehicle.Decelera();
        }
        public static void EsempioGetBooks()
        {
            var books = BookDAL.GetBooks();
            var myDict = new Dictionary<int, string>();
            foreach (Book book in books)
            {
                myDict.Add(book.Id, string.Concat(book.Author, " ", book.Title));
            }
            string display = null;
            if (myDict.TryGetValue(1, out display))
            {
                Console.WriteLine($"Ho trovato nel dictionary il book; {display}");
            }
            else
            {
                Console.WriteLine($"Il libro di id 1 non è statpo trovato");
            }
        }
    }
}
