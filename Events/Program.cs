using System;
using System.Collections.Generic;
using System.IO;

namespace Events
{
    public class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {account.Sum}");

            account.Put(20);    // добавляем на счет 20
            void DisplayMessage(string message) => Console.WriteLine(message);

            //События можно заменить делегатами и ничего не сломается;
            //События являются приватно - ориентированной моделью делегатов.
            //И на последок, говоря простым языком аналогий, и объект-делегат и объект-событие являются некоторыми "ящиками" для методов.
            //Только ящик-делегат прозрачный и мы можем даже его открыть и посмотреть как он устроен,
            //а ящик - событие черного цвета и мы практически не можем с ним взаимодействовать.
            //https://zen.yandex.ru/media/id/5d33234f31878200acc7007f/raznica-mejdu-sobytiiami-i-delegatami-razbiraem-na-primere-5d66c593e4f39f00adc3abcb


            //example with button click
            //Button b = new Button();
            //b.Start();
        }
    }  
}

