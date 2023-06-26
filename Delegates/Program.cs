using System;
using System.Collections.Generic;
using System.IO;

namespace Delegates
{
    delegate void Message(); // 1. Объявляем делегат
    delegate int Operation(int x, int y);
    public class Program
    {
        static void Main(string[] args)
        {
            Message mes;            // 2. Создаем переменную делегата
            mes = Hello;            // 3. Присваиваем этой переменной адрес метода
            mes();                  // 4. Вызываем метод


            Operation operation = Add;      // делегат указывает на метод Add
            int result = operation(4, 5);   // фактически Add(4, 5)
            operation = Multiply;           // теперь делегат указывает на метод Multiply
            result = operation(4, 5);       // фактически Multiply(4, 5)

            mes += Hi; // доприсваеваем еще один метод к делегату
            mes(); // вызывает двы метода "Hello" и "Hi"

            // если делегату присвоено несколько методов которые возвращают значения то выполниться лишь последний метод
            Operation operation2 = new Operation(Add); // другой вариант присваивания метода через конструктор
            operation2 += Multiply;
            Console.WriteLine(operation2(2, 5)); // будет 10, поскольку выполниться метод Multiply


            // делегаты как параметры методов
            DoOperation(5, 4, Add);         // 9
            DoOperation(5, 4, Multiply);    // 20


            //Также делегаты можно возвращать из методов. То есть мы можем возвращать из метода какое-то действие в виде другого метода!
            Operation operation3 = SelectOperation(OperationType.Add);
            Console.WriteLine(operation3(10, 4));    // 14
            operation3 = SelectOperation(OperationType.Multiply);
            Console.WriteLine(operation3(10, 4));    // 40


            #region Account Example
            Account account = new Account(200);
            // Добавляем в делегат ссылку на методы
            account.RegisterHandler(PrintSimpleMessage);
            account.RegisterHandler(PrintColorMessage);
            // Два раза подряд пытаемся снять деньги
            account.Take(100);
            account.Take(150);

            // Удаляем делегат
            account.UnregisterHandler(PrintColorMessage);
            // снова пытаемся снять деньги
            account.Take(50);

            void PrintSimpleMessage(string message) => Console.WriteLine(message);
            void PrintColorMessage(string message)
            {
                // Устанавливаем красный цвет символов
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                // Сбрасываем настройки цвета
                Console.ResetColor();
            }
            #endregion
        }

        static private void Hello() => Console.WriteLine("Hello");
        static private void Hi() => Console.WriteLine("Hi");
        static int Add(int x, int y) => x + y;
        static int Multiply(int x, int y) => x * y;
        static void DoOperation(int a, int b, Operation op)
        {
            Console.WriteLine(op(a, b));
        }
        static Operation SelectOperation(OperationType opType)
        {
            switch (opType)
            {
                case OperationType.Add: return Add;
                default: return Multiply;
            }
        }
    }
    enum OperationType
    {
        Add, Multiply
    }
}

