using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class Shelf
    {
        [Key]
        public int Number { get; set; }
        public string Department { get; set; }

        public virtual List<Book> Books{ get; set; }
    }
}
