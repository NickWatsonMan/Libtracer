using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logics.Models;

namespace Logics
{
    public class Context : DbContext
    {
        public Context() : base("libtracer")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<PersonBook> PersonBooks { get; set; }

    }
}
