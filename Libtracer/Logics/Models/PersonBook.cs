using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Models
{
    public class PersonBook
    {
        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PersonId { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Person Person { get; set; }

        public virtual Book Book { get; set; }

    }
}
