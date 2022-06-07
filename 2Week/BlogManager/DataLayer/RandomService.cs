using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RandomService : IRandomService
    {
        int _counter = 0;
        public RandomService()
        {
            Random random = new Random();
            _counter = random.Next(1000000);
        }
        public int GenerateNumber()
        {
            return _counter;
        }
    }
    public class WrapperClass : IRandomWrapper
    {
        private readonly IRandomService _randomService;

        public WrapperClass(IRandomService randomService)
        {
            this._randomService = randomService;
        }
        public int GenerateNumber()
        {
            return _randomService.GenerateNumber();
        }
    }
}
