using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public struct Point
    {
        private double _x;
        private double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X { get => _x; }
        public double Y { get => _y; }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }
        public override bool Equals(object obj)
        {
            return obj is Point p2 && p2.X == this.X && p2.Y == this.Y;
        }
        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}
