using System;
using System.ComponentModel.DataAnnotations;
using Mita.DataAccess;

namespace BookStore.DataAccess.Model
{
    public class Customer : FullNamedDomainObject
    {
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
