using System.ComponentModel.DataAnnotations;
using Mita.DataAccess;

namespace BookStore.DataAccess.Model
{
    public class Employee : FullNamedDomainObject
    {
        [Required]
        public int BranchId { get; set; }

        [Required]
        public Branch Branch { get; set; }

        public User User { get; set; }

    }
}
