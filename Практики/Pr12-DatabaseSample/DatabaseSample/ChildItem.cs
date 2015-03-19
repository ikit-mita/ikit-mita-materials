using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample
{
    public class ChildItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Item Parent { get; set; }
    }
}
