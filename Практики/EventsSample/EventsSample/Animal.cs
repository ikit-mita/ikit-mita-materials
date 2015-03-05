using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSample
{
    public abstract class Animal
    {
        private DateTime[] qqq = new DateTime[10000];

        private int _starvingLevel;

        public string Name { get; set; }
        public int Health { get; set; }

        public int StarvingLevel
        {
            get
            {
                return _starvingLevel;
            }
            set
            {
                _starvingLevel = value;

                if (_starvingLevel >= Health)
                {
                    if (Starving != null)
                    {
                        Starving(this, new EventArgs());
                    }
                }
            }
        }

        public event AnimalStarvingEventHandler Starving;
    }
}
