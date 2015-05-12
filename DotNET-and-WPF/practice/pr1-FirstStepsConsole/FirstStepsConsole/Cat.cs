using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStepsConsole
{
    class Cat
    {
        /// <summary>
        /// День рождения кошки
        /// закрытое поле с присвоением значения (inline инициализация)
        /// </summary>
        private DateTime _birthday = DateTime.Now;

        /// <summary>
        /// Имя кошки
        /// Публичное автосвойство.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст кошки в минутах.
        /// Вычисляемое поле.
        /// </summary>
        public double Age
        {
            get
            {
                return (DateTime.Now - _birthday).TotalMinutes;
            }
        }

        /// <summary>
        /// Любимая игрушка.
        /// </summary>
        public string FavouriteToy { get; set; }

        /// <summary>
        /// Мяукнуть.
        /// Закрытый метод.
        /// </summary>
        private void Nya()
        {
            Console.WriteLine(Name + " мяукает");
        }

        /// <summary>
        /// Укусить.
        /// Закрытый метод.
        /// </summary>
        private void Bite()
        {
            Console.WriteLine(Name + " кусает");
        }

        /// <summary>
        /// Погладить.
        /// Публичный метод. 
        /// </summary>
        public void Pet()
        {
            var rand = new Random();//создаем объект для получения случайных значений
            var i = rand.Next(10);//получаем целое число [0; 10)

            if (i < 5)
            {
                Bite();
            }
            else
            {
                Nya();
            }
            //ПРОБЛЕМА: класс Random инициализируются начальным значением для построения последовательности случайных чисел.
            //При одинаковых начальных значениях будет и одинаковая последовательность.
            //Т.к. мы не передаем начальное значения в конструктор, то Random инициализируется количеством милисекунд с 01.01.1970
            //Если вызвать метод Pet часто (несколько раз за 1 милисекунду), то в i будут одинаковые значения.
            //РЕШЕНИЕ: перенести объект Random в статическое поле (Практика 2)
        }
    }
}
