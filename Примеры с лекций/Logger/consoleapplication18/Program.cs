using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication18;

namespace ConsoleApplication18
{
    internal class Program
    {
        private static void Main(string[] args)
        {
             Program p = new Program();
            p.aaa();
        }

        public void aaa()
        {
            
            var assembly =
                new AssemblyCatalog(Assembly.GetEntryAssembly());


            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assembly);
            catalog.Catalogs.Add(new DirectoryCatalog("."));


            var compositionContainer
                = new CompositionContainer(catalog);
           


            var pr = new Processor();
            compositionContainer.ComposeParts(pr);

            pr.Process();
        }
    }



    public interface ILogger
    {
        void Log(string message);
    }

    [Export(typeof (ILogger))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Processor
    {
        [Import]
        public ILogger Logger { private get; set; }

        public void Process()
        {
            Logger.Log("Hello world");
        }
    }

}
