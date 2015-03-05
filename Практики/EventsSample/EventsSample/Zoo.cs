using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EventsSample
{
    public class Zoo
    {
        private static Random _rand = new Random();
        private Timer _timer;
        private Emploee _emploee;


        public Zoo()
        {
            _emploee = new Emploee();
            Animals = new ObservableCollection<Animal>();
            Animals.CollectionChanged += Animals_CollectionChanged;

            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            //_timer.Start();
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (Animal animal in Animals)
            {
                animal.StarvingLevel = animal.StarvingLevel + 10;
                //animal.StarvingLevel += 10;
            }
        }

        void Animals_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var animal = (Animal)(e.NewItems[0]);
                MedicalComission(animal);
            }
        }

        public ObservableCollection<Animal> Animals { get; private set; }


        private void MedicalComission(Animal animal)
        {
            animal.Health = _rand.Next(100, 500);
            animal.StarvingLevel = 0;
            animal.Starving += animal_Starving;
        }

        void animal_Starving(object sender, EventArgs e)
        {
            _emploee.Feed((Animal)sender);
        }
    }
}
