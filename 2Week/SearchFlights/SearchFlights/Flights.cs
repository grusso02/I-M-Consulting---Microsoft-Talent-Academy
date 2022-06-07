using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class Flights
    {
        private string _carrier;
        private string _originCyteName;
        private string _destCyteName;
        private int _depDelay;
        private int _arrDelay;
        private bool _cancelled;
        private double _distance;

        public Flights() {}
        public Flights(string[] splitted)
        {
            _carrier = splitted[0];
            _originCyteName = splitted[1];
            _destCyteName = splitted[2];
            if (!Int32.TryParse(splitted[3], out _depDelay))
                _depDelay = 0;
            if (!Int32.TryParse(splitted[4], out _arrDelay))
                _depDelay = 0;
            _cancelled = Convert.ToBoolean(Convert.ToInt32(splitted[5]));
            _distance = Convert.ToDouble(splitted[6]);
        }

        public string Carrier { get => _carrier; }
        public string OriginCyteName { get => _originCyteName; }
        public string DestCyteName { get => _destCyteName; }
        public int DepDelay { get => _depDelay; }
        public int ArrDelay { get => _arrDelay; }
        public bool Cancelled { get => _cancelled; }
        public double Distance { get => _distance; }
    }
}
