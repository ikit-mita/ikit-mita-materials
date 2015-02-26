using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryModel;

namespace LibraryApp
{
    public class Library
    {
        public Library()
        {
            Readers = new List<Reader>();
            LibItems = new List<LibItem>();
            ReadingItems = new Dictionary<Reader, List<LibItem>>();
        }

        public List<Reader> Readers { get; set; }
        public List<LibItem> LibItems { get; set; }
        public Dictionary<Reader, List<LibItem>> ReadingItems { get; set; }

        public Reader FindReader(string readerName)
        {
            return Readers
                .Where(r => r.Name == readerName)
                .FirstOrDefault();
        }

        public Reader RegReader(string readerName)
        {
            var reader = new Reader();
            reader.Name = readerName;
            reader.RegistrationDate = DateTime.Now;
            Readers.Add(reader);
            return reader;
        }

        public List<LibItem> GetReadingItems(Reader reader)
        {
            if (!ReadingItems.ContainsKey(reader))
            {
                ReadingItems[reader] = new List<LibItem>();
            }

            return ReadingItems[reader];
        }

        public void TakeItem(Reader reader, LibItem item)
        {
            GetReadingItems(reader).Add(item);
        }

        public void ReturnItem(Reader reader, LibItem item)
        {
            GetReadingItems(reader).Remove(item);
        }

        public Book AddBook(string code, string name, string author)
        {
            var book = new Book
            {
                Author = author,
                Code = code,
                Name = name
            };
            LibItems.Add(book);
            return book;
        }

        public Magazine AddMagazine(string code, string name, string number)
        {
            var magazine = new Magazine
            {
                Number = number,
                Code = code,
                Name = name
            };
            LibItems.Add(magazine);
            return magazine;
        }
    }
}
