using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRandomService
    {
        int GenerateNumber();
    }
    public interface IRandomWrapper
    {
        int GenerateNumber();
    }
}
