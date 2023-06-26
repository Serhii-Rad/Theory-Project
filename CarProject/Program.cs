using CarProject;
using static CarProject.Wheeles;

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
//Console.WriteLine(VAZ.TypeOfWheels);
VAZ.ChangeWheelsType(TypeOfWheelsEnum.Universal);
//Console.WriteLine(VAZ.TypeOfWheels);
Console.WriteLine(VAZ.MaxPower);