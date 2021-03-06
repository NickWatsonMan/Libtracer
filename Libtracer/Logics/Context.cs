﻿using System;
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

        //The list of lent books
        public async Task<List<PersonBook>> GetLentBooks()
        {
            List<PersonBook> list = new List<PersonBook>();

            var result = await Task<List<Book>>.Run(() =>
            {
                return PersonBooks;
            });

            foreach (var item in result)
            {
                list.Add(new PersonBook { Person = item.Person, Book = item.Book, StartDate = item.StartDate, EndDate = item.EndDate });
            };

            return list;
        }

        //The list of debtors
        public async Task<List<PersonBook>> GetDebtors()
        {
            List<PersonBook> list = new List<PersonBook>();

            var result = await Task<List<Book>>.Run(() =>
            {
                return PersonBooks.Where(x => x.EndDate < DateTime.Now);

            });

            foreach (var item in result)
            {
                list.Add(new PersonBook { Person = item.Person, Book = item.Book, EndDate = item.EndDate });
            };

            return list;
        }

        public async Task<List<Book>> GetBook(string title, string author)
        {
            List<Book> list = new List<Book>();
            try
            {
                var result = await Task <List<Book>>.Run(() =>
                {
                    return Books.Where(x => x.Title == title && x.Author == author);

                });

                if (title != "" && author != "")
                {
                    result = await Task<List<Book>>.Run(() =>
                    {
                        return Books.Where(x => x.Title == title && x.Author == author);

                    });

                } 
                else
                {
                    result = await Task<List<Book>>.Run(() =>
                    {
                        return Books.Where(x => x.Title == title || x.Author == author);

                    });
                }

                foreach (var item in result)
                {
                    list.Add(new Book {Title = item.Title, Author = item.Author, BookId = item.BookId, Shelf = item.Shelf, Available = item.Available});
                };

                return list;
            }

            catch (Exception err) { Console.WriteLine(err); return null; }
           
        }

        //Add new User
        public  void AddNewUser(string name, string lastName, int passport, DateTime birth, string phone, string email, bool role, string pwd)
        {
            //Check if the user with the passport has already signed up
            var check = People.Where(x => x.Passport == passport).FirstOrDefault();
            if (check == null)
            {
                try
                {
                    People.Add(new Person { Name = name, LastName = lastName, Passport = passport, DateOfBirth = birth, Email = email, Password = pwd, Phone = phone, Role = role });
                     SaveChanges();
                }
                catch (Exception err) { Console.WriteLine(err);}

            }
            else
            {
                Console.WriteLine("The user already exists");
            }
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
        public bool HandOutBook(int personId, int bookId, DateTime start, DateTime end)
        {
            try
            {
                var book = Books.Select(x => new
                {
                    BookId = x.BookId,
                    Available = x.Available,
                    Shelf_Number = x.Shelf.Number
                }).Where(x => x.BookId == bookId).FirstOrDefault();
                //check if this book is available
                bool checker = book.Available;

                if (book.Available)
                {
                    var id = book.BookId;
                    foreach (var item in Books.Where(x => x.Available == true && x.BookId == id))
                    {
                        item.Available = !book.Available;
                    }
                    //Remove the book from the shelf

                    //Give it to the person
                    PersonBooks.Add(new PersonBook { PersonId = personId, BookId = bookId, StartDate = start, EndDate = end });
                    SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                    throw new Exception();
                }
            }
            catch (Exception err) { Console.WriteLine(err); return false; }
        }

        public bool HandInBook(int personId, int bookId, int shelfNumber)
        {
            try
            {
                //Get the book
                var book = Books.Where(x => x.BookId == bookId).FirstOrDefault();
                book.Available = !book.Available;

                //Remove it from PersonBooks
                var borrowed = PersonBooks.Where(x => x.BookId == bookId).FirstOrDefault();
                PersonBooks.Remove(borrowed);

                //Put the book on the shelf
                var shelf = Shelves.Where(x => x.Number == shelfNumber).FirstOrDefault();
                book.Shelf = shelf;
                SaveChanges();
                return true;
            }
            catch (Exception err) { Console.WriteLine(err); return false; }

        }

        //AddNewShelf
        public void AddNewShelf(int number, string department)
        {
                //Add Shelf
                Shelves.Add(new Shelf { Number = number, Department = department });
                SaveChanges();
        }

        //Auth
        public bool Auth(string login, string pwd)
        {
            var data = People.Select(x => new {
                Id = x.PersonId,
                Password = x.Password
            }).Where(y => y.Id.ToString() == login).ToList().FirstOrDefault();

            if (data.Password == pwd && data.Id.ToString() == login)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
