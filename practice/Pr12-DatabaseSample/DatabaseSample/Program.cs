using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Db();
            var item = db.Items.FirstOrDefault();

            if (item == null)
            {
                item = new Item { Name = "Item-" + DateTime.Now };
                db.Items.Add(item);
            }

            var childItem = new ChildItem
            {
                Name = "ChildItem-" + DateTime.Now,
                Parent = item
            };

            db.ChildItems.Add(childItem);
            db.SaveChanges();

            Console.WriteLine("{0} - {1}", item.Id, item.Name);

            var latestItems = db.ChildItems
                .Include(ci => ci.Parent)
                .Where(ci => ci.Parent.Id == item.Id)
                .ToArray();

            var chItems = item.ChildItems.ToArray();

            foreach (var chIt in latestItems)
            {
                Console.WriteLine("{0} - {1}", chIt.Name, chIt.Parent.Name);
            }

            Console.ReadLine();
        }
    }
}
