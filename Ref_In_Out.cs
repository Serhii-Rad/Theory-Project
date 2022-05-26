using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_Project
{
    public class Ref_In_Out
    {
        public void VariablesByValue()
        {
            void Increment(int n)
            {
                n++;
                Console.WriteLine($"Число в методе Increment: {n}"); 
            }

            int number = 5;
            Console.WriteLine($"Число до метода Increment: {number}");
            Increment(number);
            Console.WriteLine($"Число после метода Increment: {number}");
            //Число до метода Increment: 5
            //исло в методе Increment: 6
            //Число после метода Increment: 5

            //При передаче аргументов параметрам по значению параметр метода получает не саму переменную,
            //а ее копию и далее работает с этой копией независимо от самой переменной.
            //Так, выше при вызове метод Increment получает копию переменной number и увеличивает значение этой копии.
            //Поэтому в самом методе Increment мы видим, что значение параметра n увеличилось на 1,
            //но после выполнения метода переменная number имеет прежнее значение - 5.То есть изменяется копия, а сама переменная не изменяется.
        }

        public void VariablesByRef()
        {
            void Increment(ref int n)
            {
                n++;
                Console.WriteLine($"Число в методе Increment: {n}");
            }

            int number = 5;
            Console.WriteLine($"Число до метода Increment: {number}");
            Increment(ref number);
            Console.WriteLine($"Число после метода Increment: {number}");
            //Число до метода Increment: 5
            //исло в методе Increment: 6
            //Число после метода Increment: 6

            //При передаче значений параметрам по ссылке метод получает адрес переменной в памяти.
            //И, таким образом, если в методе изменяется значение параметра, передаваемого по ссылке,
            //то также изменяется и значение переменной, которая передается на его место..
            //Так, в метод Increment передается ссылка на саму переменную number в памяти.
            //И если значение параметра n в Increment изменяется, то это приводит и к изменению переменной number,
            //так как и параметр n и переменная number указывают на один и тот же адрес в памяти.
        }

        public void VariablesWithOut()
        {
            //Матод не возвращает напрямую значение, а присваивает значение выходному параметру
            void Sum(int x, int y, out int result)
            {
                result = x + y;
            }
            int number;
            Sum(10, 15, out number);
            Console.WriteLine(number);   // 25


            //Прелесть использования подобных параметров состоит в том, что по сути мы можем вернуть из метода не одно значение, а несколько.
            void GetRectangleData(int width, int height, out int rectArea, out int rectPerimetr)
            {
                rectArea = width * height;       // площадь прямоугольника - произведение ширины на высоту
                rectPerimetr = (width + height) * 2; // периметр прямоугольника - сумма длин всех сторон  
            }
            GetRectangleData(10, 20, out int area, out int perimetr);
            Console.WriteLine($"Площадь прямоугольника: {area}");       // 200
            Console.WriteLine($"Периметр прямоугольника: {perimetr}");   // 60
        }

        public void VariablesWithIn()
        {
            //Модификатор in указывает, что данный параметр будет передаваться в метод по ссылке, однако внутри метода его значение параметра нельзя будет изменить.
            //Например, возьмем следующий метод:
            void GetRectangleData(in int width, in int height, out int rectArea, out int rectPerimetr)
            {
                //width = 25; // нельзя изменить, так как width - входной параметр
                rectArea = width * height;
                rectPerimetr = (width + height) * 2;
            }

            int w = 10;
            int h = 20;
            GetRectangleData(w, h, out var area, out var perimetr);

            Console.WriteLine($"Площадь прямоугольника: {area}");       // 200
            Console.WriteLine($"Периметр прямоугольника: {perimetr}");   // 60
            //В данном случае через входные параметры width и height в метод передаются значения,
            //но в самом методе мы не можем изменить значения этих параметров, так как они определены с модификатором in.
        }
    }
}
