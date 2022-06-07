using System;

namespace Infrastructure
{
    public abstract class Vehicle
    {
        #region Private Fields
        protected int _ruote;
        protected float _speed;
        #endregion

        #region Costruttori
        public Vehicle(int ruote) 
            : this(ruote, 0, 0)
        {
        }
        public Vehicle(int ruote, int speed, int direzione)
        {
            this._ruote = ruote;
            this._speed = speed;
            this.Direzione = direzione;
        }
        #endregion

        #region Private fields
        public bool MotoreAcceso => _speed > 0;

        public int Ruote
        {
            get { return _ruote; }
        }
        public int Direzione { get; }
        public float Speed { get => _speed; }

        #endregion

        // Distruttore
        ~Vehicle()
        {
            Clean();    
        }

        public virtual void Accelera()
        {
            Console.WriteLine("Accelera");
        }
        public virtual void Decelera()
        {
            Console.WriteLine("Decelera");
        }

        private void Clean()
        {
            //TODO: pulizia risorse unmanaged della classe (se esistenti)
        }

        private class Engine
        {
            public Engine(int giri, float CVV)
            {
                this.NumGiri = giri;
                this.CVV = CVV;
            }
            int NumGiri;
            float CVV;
            
        }
    }
    public class Car : Vehicle, IVehicle
    {
        public bool IsAutomatica { get; set; }
        public Car() 
            : base(4)
        {

        }

        public override void Accelera()
        {
           _speed++;
        }

        public override void Decelera()
        {
            _speed--;
        }
    }
    public class MotorBike : Vehicle, IVehicle
    {
        public MotorBike() : base(2)
        {
                
        }

        public override void Accelera()
        {
            Console.WriteLine("MotorBike Accelera");
        }

        public override void Decelera()
        {
            Console.WriteLine("MotorBike Decelera");
        }
    }
}
