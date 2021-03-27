using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Person : EntityHelper.Entity
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public PersonType PersonType { get; set; }
    }
}
