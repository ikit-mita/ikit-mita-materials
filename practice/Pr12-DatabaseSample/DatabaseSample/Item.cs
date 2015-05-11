using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ChildItem> ChildItems { get; set; } 
    }
}
