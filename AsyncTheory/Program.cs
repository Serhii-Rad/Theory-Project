using System;
using System.Collections.Generic;
using System.IO;

namespace AsyncTheory
{
    public class Program
    {
        // Операторы async и await используются вместе для создания асинхронного метода
        // Такой метод, определенный с помощью модификатора async и содержащий одно или несколько выражений await, называется асинхронным методом
        async static Task Main(string[] args)
        {
            #region First Part
            //PrintAsync();   // вызов асинхронного метода
            //Thread.Sleep(5000);
            //Console.WriteLine("End Main");
            ////Start PrintAsync
            ////Hello METANIT.COM
            ////End PrintAsync
            ////End Main
            ////Такой вывод будет если метод Main будет идти достаточно долго (в данном примере это достигается через Thread.Sleep(5000)), что бы в основной поток успел вернуться результат с PrintAsync

            //PrintAsync();
            //Console.WriteLine("End Main");
            ////Start PrintAsync
            ////End Main
            ////Такой вывод будет поскольку в самом методе Main нету ожидания для результата PrintAsync, а времени за которое метод Main выполняет все свои задачи не
            ////достаточно для того что бы успеть получить результат с PrintAsync

            //await PrintAsync();
            //Console.WriteLine("End Main");
            ////Start PrintAsync
            ////Hello METANIT.COM
            ////End PrintAsync
            ////End Main
            ////Такой вывод будет если в Main есть ожидание
            #endregion

            #region Second Part
            //// Отработает асинхронно
            //DisplayResultAsync();
            //// Отработает первым т.к. на асинхронный метод повлияет некоторая задержка при выполнении операций
            //Console.WriteLine("Non Async");
            //Thread.Sleep(14000);                 //если времени выполнения в методе Main не достаточно для выполнения всех действий в асинхронных методах,
            //Console.WriteLine("End main method");//то выполения задачи закончиться без вывода с асинхронного метода
            #endregion

            #region Third Part (Tasks examples)
            //Task task1 = new Task(() => { Console.WriteLine("First Task Start"); Thread.Sleep(5000); Console.WriteLine("First Task End"); });
            //Task task2 = new Task(() => { Console.WriteLine("Second Task Start"); Thread.Sleep(3000); Console.WriteLine("Second Task End"); });
            //Task task3 = new Task(() => { Console.WriteLine("Third Task Start"); Thread.Sleep(1000); Console.WriteLine("Third Task End"); });
            //task1.Start();
            //task2.Start();
            //task3.Start();

            ////Task task2 = Task.Factory.StartNew(() => { Console.WriteLine("Second Task Start"); Thread.Sleep(3000); Console.WriteLine("Second Task End"); });

            ////Task task3 = Task.Run(() => { Console.WriteLine("Third Task Start"); Thread.Sleep(1000); Console.WriteLine("Third Task End"); });

            //task1.Wait();   // ожидаем завершения задачи task1 // достаточно лишь этого ожидания, поскольку оно будет ждать самую длинную таску и остольные успеют выполниться
            //task2.Wait();   // ожидаем завершения задачи task2
            //task3.Wait();   // ожидаем завершения задачи task3
            #endregion
        }

        #region First Part
        static void Print()
        {
            Thread.Sleep(3000);     // имитация продолжительной работы
            Console.WriteLine("Hello METANIT.COM");
        }

        // определение асинхронного метода
        static async Task PrintAsync()
        {
            Console.WriteLine("Start PrintAsync"); // выполняется синхронно
            await Task.Run(() => Print());                // выполняется асинхронно
            Console.WriteLine("End PrintAsync");
        }
        #endregion

        #region Second part
        //async - указывает, что метод является асинхронными и в нем может быть использовано выражение await
        static async void DisplayResultAsync() //ждет все await внутри себя, лишь потом выходит
        {
            int num = 123;
            //await применяется к задаче в асинхронных методах, приостанавливает выполнение метода, пока задача не завершится
            //(await создает новый поток, паралельно основному)
            //Выполнение потока, в котором был вызван асинхронный метод не прервется
            //Метод AsyncMethod возвращает объект асинхронной задачи Task<int>, возможно вызвать с await
            //await-метод возвращает результат
            Console.WriteLine("Before first await");
            int result = await AsyncMethod(num);
            Console.WriteLine("Result is already done here: " + result);
            Console.WriteLine("Before second await");
            await AsyncMethodSecond();
            Console.WriteLine("After second await");
        }

        static Task<int> AsyncMethod(int x)
        {
            Thread.Sleep(5000);
            int result = 1;
            return Task.Run(() => { result *= x; return result; });
        }
        static Task AsyncMethodSecond()
        {
            Thread.Sleep(5000);
            return Task.Run(() => Console.WriteLine("Second method output"));
        }
        #endregion
    }
}

