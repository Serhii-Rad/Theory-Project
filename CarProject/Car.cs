using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarProject.Wheeles;

namespace CarProject
{
    public class Car : IDoors
    {
        List<string> carsMarksList = new List<string> { "VAZ", "BMW", "Audi", "ZAZ", "Jeep" };

        public Car(string name, int places, decimal price, float capacity, int power)
        {
            CarName = name;
            CarPlaces = places;
            CarPrice = price;
            Engine engine = new Engine(capacity, power);
            Wheeles wheels = new Wheeles(TypeOfWheelsEnum.Universal);
            MaxPower = engine.MaxPower;
            EngineCapacity = engine.EngineCapacity;
            CurrentTypeOfWheels = wheels.TypeOfWheels;
            MaxSpeed = (float)(MaxSpeed + (CarPlaces * -1.25) + (engine.EngineCapacity / 100) + engine.MaxPower);
        }

        public float Speed { get; set; } = 0;
        public string CarName { get; }
        public int CarPlaces { get; }
        public decimal CarPrice { get; }
        public float MaxSpeed { get; } = 100;
        public int MaxPower { get; }
        public float EngineCapacity { get; }
        public string CurrentTypeOfWheels { get; set; }

        public void Move(float value)
        {
            if (Speed == 0)
            {
                SpeedUp(value);
                Console.WriteLine(CarName + " started moving");
            }
            else
            {
                Console.WriteLine(CarName + $"is already move on. Speed: {Speed}");
            }
        }

        public void SpeedUp(float a)
        {
            if (Speed + a <= MaxSpeed)
            {
                Speed += a; // Speed = Speed + a;
            }
            else
            {
                Speed = MaxSpeed;
            }
        }

        public void SpeedDown(float value)
        {
            Speed -= value; // Speed = Speed - value;
        }

        public void Stop()
        {
            Speed = 0;
        }

        public void ChangeWheelsType(TypeOfWheelsEnum newType)
        {
            if (newType == TypeOfWheelsEnum.Summer)
            {
                CurrentTypeOfWheels = "Summer";
            }
            else if (newType == TypeOfWheelsEnum.Winter)
            {
                CurrentTypeOfWheels = "Winter";
            }
            else if (newType == TypeOfWheelsEnum.Universal)
            {
                CurrentTypeOfWheels = "Universal";
            }
        }

        public void OpenDoors()
        {
            Console.WriteLine("Opening the doors");
        }
    }
}
