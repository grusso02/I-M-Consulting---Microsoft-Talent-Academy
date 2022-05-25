using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IVehicle
    {
        void Accelera();
        void Decelera();
        int Ruote { get; }
    }
}
