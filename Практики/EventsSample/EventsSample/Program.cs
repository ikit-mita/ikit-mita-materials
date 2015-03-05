using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = new Zoo();
            zoo.Animals.Add(new Tiger { Name = "Sharhan" });
            zoo.Animals.Add(new Eliphant { Name = "Bimbo" });

            while (true)
            {
                zoo.Animals.RemoveAt(1);
                zoo.Animals.Add(new Eliphant { Name = "Bimbo" });
                Console.WriteLine(GC.GetTotalMemory(false)/1024);
            }

            while (true)
            {
                foreach (var animal in zoo.Animals)
                {
                    Console.WriteLine("{0} (h:{1}, s:{2})", animal.Name, animal.Health, animal.StarvingLevel);
                }

                Thread.Sleep(500);
            }
        }
    }
}
