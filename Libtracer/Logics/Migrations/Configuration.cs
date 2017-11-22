namespace Logics.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Logics.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Logics.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Logics.Context";
        }

        protected override void Seed(Logics.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Shelf shelf1 = new Shelf { Number = 1, Department = "Russian Literature" };
            Shelf shelf2 = new Shelf { Number = 2, Department = "English Literature" };

            //russian books
            Book book1 = new Book { BookId = 1, Title = "War and Peace", Author="Leo Tolstoy", Available=true, };
            Book book2 = new Book { Title = "War and Peace", Author = "Leo Tolstoy", Shelf = shelf1, Available = true };
            Book book3 = new Book { Title = "Anna Korenina", Author = "Leo Tolstoy", Shelf = shelf1, Available = true };
            Book book4 = new Book { Title = "The Death of Ivan Ilyich", Author = "Leo Tolstoy", Shelf = shelf1, Available = true };

            //Some english books
            Book book5 = new Book { BookId = 5, Title = "Great Expectations", Author = "Charles Dickens", Available = true };
            Book book6 = new Book { Title = "The Lord of the Rings", Author = "John Ronald Reuel Tolkien", Shelf = shelf2, Available = true };
            Book book7 = new Book { Title = "The Lord of the Rings", Author = "John Ronald Reuel Tolkien", Shelf = shelf2, Available = true };
            Book book8 = new Book { Title = "The Lord of the Rings", Author = "John Ronald Reuel Tolkien", Shelf = shelf2, Available = true };
            Book book9 = new Book { Title = "Moby-Dick", Author = "Herman Melville", Shelf = shelf2, Available = true };

            //Librarian Lucy ^_^
            Person lucy = new Person { Name = "Lucy", LastName = "Stone", Email = "Lucy@libtracer.com", DateOfBirth = new DateTime(1990, 02, 23), Passport = 727893, Role = true, Password = "password", Phone = "+132348729845" };

            //Readers
            Person reader1 = new Person {PersonId=1, Name = "Bob", LastName = "Jameson", Email = "BobJ@hotmail.com", DateOfBirth = new DateTime(1995, 03, 18), Passport = 718893, Role = false, Phone = "+131349743645" };
            Person reader2 = new Person { PersonId = 2, Name = "Rudolf", LastName = "Bystritsky", Email = "Rudolf777@gmail.com", DateOfBirth = new DateTime(1992, 10, 29), Passport = 126893, Role = false, Phone = "+101348928545" };

            //Books of Readers
            PersonBook bobBook = new PersonBook { BookId = 1, StartDate = new DateTime(2017, 11, 20), EndDate = new DateTime(2017, 12, 24), PersonId = 1 };
            book1.Available = false;

            PersonBook rudolfBook = new PersonBook { BookId = 5, StartDate = new DateTime(2017, 8, 1), EndDate = new DateTime(2017, 9, 10), PersonId = 2 };
            book5.Available = false;

            //Add Shelves
            context.Shelves.AddOrUpdate(shelf1);
            context.Shelves.AddOrUpdate(shelf2);

            //Add Books
            context.Books.AddOrUpdate(book1);
            context.Books.AddOrUpdate(book2);
            context.Books.AddOrUpdate(book3);
            context.Books.AddOrUpdate(book4);
            context.Books.AddOrUpdate(book5);
            context.Books.AddOrUpdate(book6);
            context.Books.AddOrUpdate(book7);
            context.Books.AddOrUpdate(book8);
            context.Books.AddOrUpdate(book9);

            //Add users
            context.People.AddOrUpdate(lucy);
            context.People.AddOrUpdate(reader1);
            context.People.AddOrUpdate(reader2);

            //Add Borrowings
            context.PersonBooks.AddOrUpdate(bobBook);
            context.PersonBooks.AddOrUpdate(rudolfBook); 
            






        }
    }
}
