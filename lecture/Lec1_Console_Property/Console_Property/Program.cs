using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Property
{
    class Program
    {
        static void Main(string[] args)
        {
            var staff = new Staff("Ivanov"); //Создаем объект нашего класса.
            //staff.Fam = "Petrov"; // Мы не имеем возможность изменить фамилию у объекта. Разработчик класса предусмотрительно это запретил, так как данная функциональность требовалась бизнес-правилами.

            Console.WriteLine(staff.Fam); // Но узнать фамилию мы можем.
            //Console.WriteLine(staff.Salary); // А вот узнать зарплату нет.
            staff.Salary = 60000; // Мы можем только задать зарплату.
            staff.Salary = 80000; // Можем изменить ее.

            staff.Age = 30; // Можем задать возраст сотрудника. Теперь он приравняется к 30 годам.
            staff.Age = 40; // Изменить мы его не сможем. Возраст сотрудника останется равным 30 годам...
        }
    }
}
