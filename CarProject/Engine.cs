using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    public class Engine
    {
        public Engine(float capacity, int power)
        {
            MaxPower = power;
            EngineCapacity = capacity;
        }

        public int MaxPower { get; }
        public float EngineCapacity { get; }
    }
}
