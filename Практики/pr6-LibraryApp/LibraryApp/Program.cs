using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryModel;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lib = new Library();
            FillLib(lib);

            Console.Write("Hello! What is your name? ");
            var readerName = Console.ReadLine();
            var reader = lib.FindReader(readerName);

            if (reader == null)
            {
                reader = lib.RegReader(readerName);
            }

            Console.WriteLine("All books:");
            PrintLibItems(lib.LibItems);
            Console.WriteLine();
            Console.WriteLine("{0} ({1}) reading books:", reader.Name, reader.RegistrationDate);
            PrintLibItems(lib.GetReadingItems(reader));
            Console.WriteLine();
            Console.Write("Enter book code:");
            var bookCode = Console.ReadLine();

            var libItem = lib.LibItems
                .FirstOrDefault(li => li.Code == bookCode);

            if (libItem != null)
            {
                if (lib.GetReadingItems(reader).Contains(libItem))
                {
                    lib.ReturnItem(reader, libItem);
                }
                else
                {
                    lib.TakeItem(reader, libItem);
                }
            }
            else
            {
                Console.WriteLine("There is no book with code " + bookCode);
            }

            Console.WriteLine("{0} ({1}) reading books:", reader.Name, reader.RegistrationDate);
            PrintLibItems(lib.GetReadingItems(reader));

            Console.ReadLine();
        }

        static void PrintLibItems(IEnumerable<LibItem> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        static void FillLib(Library lib)
        {
            var readers = new[]
            {
                lib.RegReader("r1"),
                lib.RegReader("r2"),
                lib.RegReader("r3"),
            };

            var items = new LibItem[]
            {
                lib.AddBook("bb01", "50 Shades Of Grey", "E. L. James"),
                lib.AddBook("bb02", "Harry Potter And Some Thing", "J. K. Rolling"),
                lib.AddMagazine("m001", "Cosmopolitan", "Jan, 2015"),
                lib.AddMagazine("m002", "Занимательная механика", "Янв, 2015"),
            };

            lib.TakeItem(readers[0], items[0]);
            lib.TakeItem(readers[0], items[2]);

            lib.TakeItem(readers[1], items[0]);
            lib.TakeItem(readers[1], items[1]);
            lib.TakeItem(readers[1], items[2]);
            lib.TakeItem(readers[1], items[3]);
        }
    }
}
