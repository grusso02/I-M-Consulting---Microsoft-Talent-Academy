using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterProject.Helper
{
    /// <summary>
    /// Possiamo dichiarare una classe internal (utilizzabile solo all'interno del progetto) default
    /// o public (utilizzabile ancha da progetti esterni)
    /// </summary>
    public abstract class Vehicle
    {
        //region rende il codice interno collassabile
        #region Private fields
        private int _wheels;
        private float _speed;
        private int _direction;
        private bool _engineRunning;
        #endregion

        #region Constructor
        public Vehicle() {}
        public Vehicle(int wheels) : this(wheels, 0, 0, false) {}
        public Vehicle(int wheels, int speed, int direction, bool engineRunning)
        {
            _wheels = wheels;
            Speed = speed;
            Direction = direction;
            EngineRunning = engineRunning;
        }
        #endregion

        public int Wheels // Proprietà
        {
            get { return _wheels; }
            set
            {
                if (value < 2 || value > 4)
                    throw new ArgumentOutOfRangeException();
                _wheels = value;
            }
        }

        public float Speed { get => _speed; set => _speed = value; }
        public int Direction { get => _direction; set => _direction = value; }
        public bool EngineRunning { get => _engineRunning; set => _engineRunning = value; }

        private class Engine
        {
            public Engine() : this(0, 0) {}
            public Engine(int _engRev, float _cvv)
            {
                engRev = _engRev;
                cvv = _cvv;
            }

            int engRev;
            float cvv;
        }
    }
    public class Car : Vehicle
    {
        public Car() : base(4) {}
    }
}
