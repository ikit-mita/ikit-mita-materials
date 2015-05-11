using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStepsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Cycles();
            //Animals();
            Console.ReadLine();

        }

        static void Cycles()
        {
            Console.WriteLine("How many bugs?");
            string countStr = Console.ReadLine();//запрашиваем количество багов в проекте. С консоли вернутс строка

            int count = int.Parse(countStr);//переводим строку в число

            if (count >= 1 && count <= 25)//Если число в интервале [1, 25]
            {
                //вывести в цикле «Было в проекте N багов, один исправили, осталось N-1 багов»
                for (int i = 0; i < count; i++)
                {
                    var s = string.Format("Было в проекте {0} багов, один исправили, осталось {1} багов", count - i, count - i - 1);
                    Console.WriteLine(s);
                }
            }
            else if (count < 1) //Если число меньше 1 – вывести строку «Плохо тестируете»
            {
                Console.WriteLine("Bad testing");
            }
            else //В остальных случаях – «Проект обречен, попробуйте стать врачем»
            {
                Console.WriteLine("Project is failed");
            }
        }

        static void Animals()
        {
            //проверяем, что счетчики по нулям
            Console.WriteLine(Cat.Count);
            Console.WriteLine(Animal.Count);

            //создаем кошку. проверяем, что счетчики увеличились
            var cat = new Cat();
            Console.WriteLine(Animal.Count);
            Console.WriteLine(Cat.Count);

            //создаем кошку другим конструктором. проверяем, что счетчики увеличились
            var cat1 = new Cat("Cat", new DateTime(1999, 1, 1));
            Console.WriteLine(Animal.Count);
            Console.WriteLine(Cat.Count);

            //создаем кошку. проверяем, что счетчик животных увеличисся, счетчик кошек не изменился
            var dog = new Dog();
            Console.WriteLine(Animal.Count);
            Console.WriteLine(Cat.Count);

            //гладим кошку, чтобы проверить, что исправление логики генерации случайных чисел сработала
            for (int i = 0; i < 10; i++)
            {
                cat1.Pet();
            }

            //Проверяем, что перегруженный метод возвращает разные значения для разных классов.
            Console.WriteLine(cat.WhatYouSay());
            Console.WriteLine(dog.WhatYouSay());
        }
    }
}
