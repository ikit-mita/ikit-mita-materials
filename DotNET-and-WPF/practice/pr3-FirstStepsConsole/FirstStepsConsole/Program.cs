using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLib; //подключаем пространство имен, чтобы для классов животных можно было использовать краткие имена.

namespace FirstStepsConsole //обычно, корневое пространство имен совпадает с именеим проекта (логика VS).
                            //но это лишь рекомендация, можно выбрать название провтранства имен на свое усмотрение
{
    class Program
    {
        static void Main(string[] args)
        {
            var t11 = new System.Object();  //полное имя класса состоит из пространства имен и имени класса
            var t12 = new Object();         //можно использовать только имя класс, т.к. пространство имен System объявлено в using

            var t21 = new System.Text.StringBuilder();//полное имя класса состоит из пространства имен и имени класса
            var t22 = new StringBuilder();            //можно использовать только имя класс, т.к. пространство имен System объявлено в using

            var t31 = new System.Collections.Specialized.StringCollection();//полное имя класса состоит из пространства имен и имени класса
            //var t32 = new StringCollection();            //нельзя обратиться к классу по краткому имени, т.к. компилятор не сможет его найти в подключенных простанствах имен


            //создаем кота
            Cat firstCat = new Cat("Catterpiller", DateTime.Now);
            firstCat.FavouriteToy = new Toy { Name = "Toy1", Color="Red" };

            Cat secondCat = firstCat;//две переменне указывают на обного и того же кота.

            //метод Clone создает нового кота с теми же параметрами.
            object clonedObj = firstCat.Clone();
            //метод Clone возвращает объект типа Object - самого базового типа всех классов в .NET
            //чтобы поместить объект в переменную типа Cat, нужно выполнить приведение типа
            //в переменной clonedObj лежит объект типа Cat (резулитат метода Clone), поэтому ошибки нет.
            Cat thirdCat = (Cat)clonedObj;
            //если попытаться привести объект (в котором кошка) к типу Dog, то во время выполнения упадет исключение
            //Dog dog = (Dog)clonedObj;

            //если изменяем поле в secondCat, то оно меняется и в firstCat (т.к. это один и тот же объект),
            //но неменяется в thirdCat, т.к. это уже другой объект
            secondCat.FavouriteToy = new Toy() { Name = "Toy2" };

            Console.ReadLine();

        }
    }
}
