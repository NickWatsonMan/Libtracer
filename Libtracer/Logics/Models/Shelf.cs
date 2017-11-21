using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class Shelf
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }
        public string Department { get; set; }

        public virtual List<Book> Books{ get; set; }
    }
}
