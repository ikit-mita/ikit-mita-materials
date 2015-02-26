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
            //Создаем новый объект Кошка
            var cat = new Cat();
            cat.Name = "Ололошка"; //Устанавливаем имя
            cat.FavouriteToy = "Робот-пылесос"; //устанавливаем любимую игрушку

            Console.WriteLine("Возраст кошки " + cat.Name + ": " + cat.Age + " минут");//выводим на консоль имя и возраст
            Console.WriteLine("Любимая игрушка: " + cat.FavouriteToy);                 //выводим на консоль любимую игрушку
            //гладим 5 раз
            cat.Pet();
            cat.Pet();
            cat.Pet();
            cat.Pet();
            cat.Pet();

            Console.ReadLine();//ожидание ввода пользователя(нучно, чтобы консоль не закрылась сразу послу выполения)
        }
    }
}
