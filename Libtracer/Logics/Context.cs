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

        public void AddNewUser(string name, string lastName, int passport, DateTime birth, string phone, string email, bool role, string pwd ){
            try
            {
                People.Add(new Person { Name = name, LastName = lastName, Passport = passport, DateOfBirth = birth, Email = email, Password = pwd, Phone = phone, Role = role });
                SaveChanges();
            }
            catch (Exception err) { Console.WriteLine(err); }
        }

        //The list of lent books
        public void GetLentBooks()
        {
            var result = PersonBooks.Select(x => new {
                BookId = x.BookId,
                BookTitle = x.Book.Title,
                FirstName = x.Person.Name,
                LastName = x.Person.LastName,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToList();
        }

        //Add a new book to the library and put it on the shelf
        public void AddBookToLibrary (string title, string author, int shelfNumber)
        {
            try
            {
                var shelf = Shelves.Where(x => x.Number == shelfNumber).FirstOrDefault();
                Books.Add(new Book { Title = title, Author = author, Available = true, Shelf = shelf });
                SaveChanges();
            }
            catch (Exception err) { Console.WriteLine(err); }
        }

        //Give the book to the person
        public void HandOutBook(int personId, int bookId, DateTime start, DateTime end)
        {
            try
            {
                var book = Books.Where(x => x.BookId == bookId).FirstOrDefault();
                //check if this book is available
                if (book.Available)
                {
                    //Remove the book from the shelf
                    book.Available = false;
                    book.Shelf = null;

                    //Give it to the person
                    PersonBooks.Add(new PersonBook { PersonId = personId, BookId = bookId, StartDate = start, EndDate = end });
                    SaveChanges();
                }
            }
            catch (Exception err) { Console.WriteLine(err); }
        }

        public void HandInBook(int personId, int bookId, int shelfNumber)
        {
            try
            {
                //Get the book
                var book = Books.Where(x => x.BookId == bookId).FirstOrDefault();
                book.Available = true;

                //Remove it from PersonBooks
                var borrowed = PersonBooks.Where(x => x.BookId == bookId).FirstOrDefault();
                PersonBooks.Remove(borrowed);

                //Put the book on the shelf
                var shelf = Shelves.Where(x => x.Number == shelfNumber).FirstOrDefault();
                book.Shelf = shelf;
                SaveChanges();
            }
            catch (Exception err) { Console.WriteLine(err); }
        }
    }
}
