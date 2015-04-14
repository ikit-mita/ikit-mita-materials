using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Mita.Core;

namespace Mita.DataAccess
{
    [DebuggerDisplay("[{Id}] {FullName}")]
    public class FullNamedDomainObject : DomainObject
    {
        [Required]
        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        public virtual string Initials
        {
            get
            {
                string initials = string.Empty;

                if (!FirstName.IsNullOrEmpty())
                {
                    initials = FirstName[0] + ".";

                    if (!MiddleName.IsNullOrEmpty())
                    {
                        initials += " " + MiddleName[0] + ".";
                    }
                }

                return initials;
            }
        }

        public virtual string FullName
        {
            get { return string.Join(" ", LastName, FirstName, MiddleName); }
        }

        public virtual string ShortName
        {
            get { return string.Join(" ", LastName, Initials); }
        }
    }
}
