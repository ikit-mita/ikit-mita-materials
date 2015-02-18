﻿using System;

namespace Console_Property
{
    // Тут мы описываем собственный тип данных - класс Staff.
    // Согласно условиям задачи, наш собственный тип данных должен позволить нам
    // удобное манипулирование следующей информацией о сотруднике: название компании, фамилия, возраст и зарплата.
    // Важно предусмотреть следующие нюансы:
    // - фамилию мы обязаны задать, так как по сотрудникам строятся отчеты и Фамилия - это обязательное поле в данных отчетах,
    //   более того, фамилия должна задаваться единожды и не подлежать дальнейшей смене в момент существования объекта;
    // - зарплату сотрудника мы имеем права изменять, но не должны иметь возможности узнать текущее ее значение;
    // - возраст сотрудника задается только один раз, изменяться в дальнейшем не должен;
    // - на наименование компании нет никаких бизнес-ограничений.
    public class Staff
    {
        // Объявляем поля, которыми характеризуется нужная нам сущность.
        // Сами поля (филды) делаем приватными, что бы код использующий наш тип 
        // не мог нарушить спланированную нами стратегию работы с экземплярами класса.
        private int? _age; // у данного типа значение по умолчанию null.

        // Конструктор с параметром. 
        public Staff(string fam) // Теперь тот программист, которым будет использовать наш класс, 
        {                        // не сможет создать объект не указав фамилию.
            Fam = fam;           // Более того, свойство Fam будет иметь приватный метод set, что не позволит изменять его на всем протяжении 
        }


        public string Fam { get; private set; } // Мы делаем метод set приватным с целью обеспечить невозможность изменения фамилии у нашего созданого объекта.

        public int Salary { private get; set; }
        // Мы делаем метод get приватным с целью обеспечить невозможность узнать текущее значение данного поля у созданого объекта.

        public int? Age
        {
            get { return _age; }
            set
            {
                if (_age == null) // Проверяем не задавалось ли значение приватной филде ранее. Если нет, то задаем.
                {
                    _age = value;
                }
            }
        }

        public string CompanyName { get; set; } // Полностью публичное свойство. Открыто как для записи, так и для чтения.
    }
}
