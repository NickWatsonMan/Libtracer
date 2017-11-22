using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public int Passport { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; } //false - user, true - admin
        public string Password { get; set; } //if Person is admin
        
        public virtual List<PersonBook> PersonBooks { get; set; }
    }
}
