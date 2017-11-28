using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; } 

      //  public int Shelf_Number { get; set; }

        public Shelf Shelf { get; set; }
        public virtual List<PersonBook> PersonBooks { get; set; }
    }
}
