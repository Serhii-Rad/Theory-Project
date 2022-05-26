using System;
using System.Collections.Generic;
using System.IO;
using static Theory_Project.Wheeles;

namespace Theory_Project
{
    public delegate void MyDelegate(string text);
    public class Program
    {
        static void Main(string[] args)
        {
            string s = "Раз два три четыре пять";
            string[] array = s.Split(" ");
            //EventClass ev = new EventClass();
            //ev.CreateCarEvent += MethodForEvent;

            Car VAZ = new Car("VAZ", 4, 3000, 1500, 50);
            Car BMW = new Car("BMW", 2, 10000, 2600, 100);
            Console.WriteLine(VAZ.MaxSpeed);
            Console.WriteLine(BMW.MaxSpeed);
            VAZ.Move(15);
            Console.WriteLine(VAZ.Speed);
            VAZ.SpeedUp(50);
            Console.WriteLine(VAZ.Speed);
            VAZ.SpeedUp(50);
            Console.WriteLine(VAZ.Speed);
            Console.WriteLine(VAZ.TypeOfWheels);
            VAZ.ChangeWheelsType(TypeOfWheelsEnum.Universal);
            Console.WriteLine(VAZ.TypeOfWheels);
            Console.WriteLine(VAZ.MaxPower);

            //using StreamWriter sw = new StreamWriter(@"C:\Users\radch\OneDrive\Рабочий стол\CarLog.txt", true);
            //sw.WriteLine(VAZ.CarName + " - " + VAZ.CarPrice);
            //sw.WriteLine($"Купи тачку {VAZ.CarName}");
            //sw.Close();

        }

        public static void CreateTextFileAndWriteText(string filePath, string text)
        {
            using StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine(text);
            sw.Close();
        }


    }

    public class EventClass
    {
        public event MyDelegate CreateCarEvent;

        public void InvokeEvent(string text)
        {
            CreateCarEvent?.Invoke(text);
        }

        public static void MethodForEvent(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"New {text} is created");
            Console.ResetColor();
        }
    }

    public class Car : Interface1
    {
        private readonly string carName;
        private readonly int carPlaces;
        private readonly decimal carPrice;
        private readonly float maxSpeed = 100;
        private readonly int maxPower;
        private readonly float engineCapacity;
        private string typeOfWheels;
        List<string> carsMarksList = new List<string> { "VAZ", "BMW", "Audi", "ZAZ", "Jeep" };

        public Car(string name, int places, decimal price, float capacity, int power)
        {
            carName = name;
            carPlaces = places;
            carPrice = price;
            Engine engine = new Engine(capacity, power);
            Wheeles wheels = new Wheeles(TypeOfWheelsEnum.Universal);
            maxPower = engine.MaxPower;
            engineCapacity = engine.EngineCapacity;
            typeOfWheels = wheels.TypeOfWheels;
            maxSpeed = (float)(maxSpeed + (carPlaces * -1.25) + (engine.EngineCapacity / 100) + engine.MaxPower);

            EventClass ev = new EventClass();
            ev.CreateCarEvent += EventClass.MethodForEvent;
            ev.InvokeEvent(name);

        }

        public float Speed { get; set; } = 0;
        public string CarName
        {
            get
            {
                return carName;
            }
        }
        public int CarPlaces
        {
            get
            {
                return carPlaces;
            }
        }
        public decimal CarPrice
        {
            get
            {
                return carPrice;
            }
        }
        public float MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
        }
        public int MaxPower
        {
            get
            {
                return maxPower;
            }
        }
        public float EngineCapacity
        {
            get
            {
                return engineCapacity;
            }
        }
        public string TypeOfWheels
        {
            get
            {
                return typeOfWheels;
            }
        }

        public void Move(float value)
        {
            if (Speed == 0)
            {
                SpeedUp(value);
                Console.WriteLine(carName + " started moving");
            }
            else
            {
                Console.WriteLine(carName + $"is already move on. Speed: {Speed}");
            }
        }

        public void SpeedUp(float a)
        {
            if (Speed + a <= maxSpeed)
            {
                Speed += a; // Speed = Speed + a;
            }
            else
            {
                Speed = maxSpeed;
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
                typeOfWheels = "Summer";
            }
            else if (newType == TypeOfWheelsEnum.Winter)
            {
                typeOfWheels = "Winter";
            }
            else if (newType == TypeOfWheelsEnum.Universal)
            {
                typeOfWheels = "Universal";
            }
        }

        public void OpenDoors()
        {
            Console.WriteLine("Opening the doors");
        }
    }

    public class Engine
    {
        private readonly int engineMaxPower;
        private readonly float engineCapacity;

        public Engine(float capacity, int power)
        {
            engineMaxPower = power;
            engineCapacity = capacity;
        }

        public int MaxPower
        {
            get
            {
                return engineMaxPower;
            }
        }
        public float EngineCapacity
        {
            get
            {
                return engineCapacity;
            }
        }

    }

    public class Wheeles
    {
        private string typeOfWheels;
        public Wheeles(TypeOfWheelsEnum type)
        {
            if (type == TypeOfWheelsEnum.Summer)
            {
                typeOfWheels = "Summer";
            }
            else if (type == TypeOfWheelsEnum.Winter)
            {
                typeOfWheels = "Winter";
            }
            else if (type == TypeOfWheelsEnum.Universal)
            {
                typeOfWheels = "Universal";
            }
        }
        public enum TypeOfWheelsEnum
        {
            Winter, Summer, Universal
        }
        public string TypeOfWheels
        {
            get
            {
                return typeOfWheels;
            }
        }
        public void ChangeWheelsType(TypeOfWheelsEnum newType)
        {
            if (newType == TypeOfWheelsEnum.Summer)
            {
                typeOfWheels = "Summer";
            }
            else if (newType == TypeOfWheelsEnum.Winter)
            {
                typeOfWheels = "Winter";
            }
            else if (newType == TypeOfWheelsEnum.Universal)
            {
                typeOfWheels = "Universal";
            }
        }
    }
}

