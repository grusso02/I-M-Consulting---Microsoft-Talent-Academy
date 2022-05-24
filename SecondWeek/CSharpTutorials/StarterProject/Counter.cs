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

        public Counter()
        {
            _totalCounter++;
        }

        public static int TotalCounter { get => _totalCounter; }

        public int incrementValue()
        {
            _counter++;
            return _counter;
        }
    }
}
