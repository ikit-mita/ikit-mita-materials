using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Book : LibItem
    {
        public string Author { get; set; }

        public override string ToString()
        {
            return string.Format("#{0} - {1}; {2}", Code, Name, Author);
        }
    }
}
