using System;
using System.Collections.Generic;
using System.IO;

namespace Theory_Project
{
    public delegate void MyDelegate(string text);
    public class Program
    {
        static void Main(string[] args)
        {
            EventClass ev = new EventClass();
            ev.CreateCarEvent += MethodForEvent;

            CreateTextFileAndWriteText(@"C:\Users\radch\OneDrive\Рабочий стол\CarLog.txt", "Some actions");
        }

        public static void CreateTextFileAndWriteText(string filePath, string text, bool append = true)
        {
            using StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine(text);
            sw.Close();
        }
        public static void MethodForEvent(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"New {text} is created");
            Console.ResetColor();
        }
    }
    public class EventClass
    {
        public event MyDelegate CreateCarEvent;

        public void InvokeEvent(string text)
        {
            CreateCarEvent?.Invoke(text);
        }
    }
}

