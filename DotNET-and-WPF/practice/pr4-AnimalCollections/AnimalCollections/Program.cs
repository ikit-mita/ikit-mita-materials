using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLib;

namespace AnimalCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //массив - коллекция фиксированого размера
            var intArr = new int[45];

            //список - коллекция с возможностью добавления/удаления элементов
            var stringList = new List<string>();
            stringList.Add("string1");
            stringList.Add("string2");
            stringList.Add("string3");
            stringList.Remove("string2");

            //словарь - хранение данных в виде ключ-значение. дает быстрый доступ к элементу по ключу
            var dict = new Dictionary<int, string>();
            dict.Add(2, "string 2");

            var int5 = intArr[5];           //обращение по индексу к 6-ому элементу. Индексация с 0, т.е. intArr[0]- первый
            var string1 = stringList[1];    //обращение по индексу ко 2-ому элементу. Индексация с 0, т.е. stringList[0]- первый
            string s2 = dict[2];            //обращение по ключу

            //intArr[5000], stringList[1000] - ошибка выхода за границы коллекции
            //dict[9] - ошибка доступа по ключу, которого нет в словаре

            Cat cat1 = new Cat();
            Animal animal1 = new Cat();
            Animal animal2 = new Dog();
            Animal animal3 = animal1;
            Dog dog2 = (Dog)animal3;
            dog2.Wag();

            var animals = new List<Animal>();
            var cats = new List<Cat>();

            animals.Add(cat1);
            animals.Add(dog2);
            animals.Add(animal1);

            var namelesstAnimalsCount = animals
                .Where(a => a.Name == "")
                .Count();

            var youngestAnimal = animals
                .OrderBy(a => a.Age)
                .FirstOrDefault();

        }
    }
}
