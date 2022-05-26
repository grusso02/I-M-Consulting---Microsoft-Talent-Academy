using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Counter
    {
        private int _counter; // Campo di istanza
        private static int _totalCounter; // Campo statico

        public static int TotalCounter { get => _totalCounter; } // Proprietà read-only

        static Counter()
        {
            _totalCounter = 0;
        }

        public Counter()
        {
            _totalCounter += 1;
        }
        // Distruttore
        ~Counter()
        {
            _totalCounter -= 1;
        }

        public int IncrementValue()
        {
            _counter += 1;
            return _counter;
        }
    }
}
