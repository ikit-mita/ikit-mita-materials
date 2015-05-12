using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStepsConsole
{
    public class Dog : Animal
    {
        public Dog() : this("noname-dog", DateTime.Now) { }
        public Dog(string name, DateTime birthDate) : base(name, birthDate) { }

        public void Wag()
        {
            string s = string.Format("{0} wagging", Name);
            Console.WriteLine(s);
        }

        static Random _rnd = new Random();
        public override void Pet()
        {
            if (_rnd.Next(0, 10) < 8)
            {
                Wag();
            }
            else
            {
                Bite();
            }
        }

        public override string WhatYouSay()
        {
            return "Bark" + base.WhatYouSay();
        }
    }
}
