using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLib
{
    public class Cat : Animal, ICloneable
    {
        /// <summary>
        /// В этом поле будет посчитываться, сколько кошек создано в программе
        /// </summary>
        public static int Count = 0;

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Cat()
            : this("noname", DateTime.Now)
        {
            //Перед выполнением логики будет исполнен другой конструктор класса Cat (c 2 параметрами)
        }

        public Cat(string name, DateTime bd) : base(name, bd)
        {
            //Перед выполнением логики будет исполнен конструктор базового класса Animal
            Count++; //при создании каждой кошки увеличиваем значение поля
        }

        /// <summary>
        /// Мяукнуть.
        /// Закрытый метод.
        /// </summary>
        private void Nya()
        {
            Console.WriteLine(Name + " мяукает");
        }

        /// <summary>
        /// Экземпляр класса Random для получения
        /// </summary>
        static Random _rnd = new Random();

        public override void Pet()
        {
            if (_rnd.Next(0, 10) < 5)
            {
                Nya();
            }
            else
            {
                Bite();
            }
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Метод создает нового кота на основе значений полей текущего объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = new Cat(this.Name, this._birthday);
            clone.FavouriteToy = this.FavouriteToy;
            return clone;
        }
    }
}
