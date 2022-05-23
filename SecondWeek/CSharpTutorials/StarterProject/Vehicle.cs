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
    internal class Vehicle
    {
        #region Constructor
        public Vehicle(int _wheels) : this(_wheels, 0, 0, false) {}
        public Vehicle(int _wheels, int _speed, int _direction, bool _engineRunning)
        {
            wheels = _wheels;
            speed = _speed;
            direction = _direction;
            engineRunning = _engineRunning;
        }
        #endregion

        //region rende il codice interno collassabile
        #region Public fields
        public int wheels;
        public float speed;
        public int direction;
        #endregion

        #region Private fields
        private bool engineRunning;
        #endregion
    }
}
