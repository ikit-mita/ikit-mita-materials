using System;
using System.ComponentModel.DataAnnotations;
using Mita.DataAccess;

namespace BookStore.DataAccess.Model
{
    public class User : DomainObject
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime LastLoginTime { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public Role Role { get; set; }
    }
}
