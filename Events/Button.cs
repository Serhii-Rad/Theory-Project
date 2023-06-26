using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Button
    {
        public delegate void ButtonClickHandler();
        public event ButtonClickHandler ButtonClick;

        public void Start()
        {
            ButtonClick += OnClick;
            while (true)
            {
                if (string.IsNullOrEmpty(Console.ReadLine())) //press enter without any value
                    ButtonClick();
            }
        }

        private void OnClick() => Console.WriteLine("Click");
    }
}
