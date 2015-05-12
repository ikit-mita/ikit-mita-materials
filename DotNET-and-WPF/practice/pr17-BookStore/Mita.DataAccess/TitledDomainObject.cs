using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Mita.DataAccess
{
    [DebuggerDisplay("[{Id}] {Title}")]
    public class TitledDomainObject : DomainObject
    {
        [Required]
        public virtual string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
