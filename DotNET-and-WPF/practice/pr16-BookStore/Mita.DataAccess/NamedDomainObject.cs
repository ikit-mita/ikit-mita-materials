using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Mita.DataAccess
{
    [DebuggerDisplay("[{Id}] {Name}")]
    public class NamedDomainObject : DomainObject
    {
        [Required]
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
