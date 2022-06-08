using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_Project
{
    public class DelegateClass
    {
        delegate void Message(); // 1. Объявляем делегат

        Message mes;            // 2. Создаем переменную делегата

        mes = Hello;            // 3. Присваиваем этой переменной адрес метода
        mes();                  // 4. Вызываем метод

        void Hello() => Console.WriteLine("Hello METANIT.COM");

    }
}
