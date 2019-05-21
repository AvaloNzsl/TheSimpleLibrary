using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TarazevichRoman.BookCatalog
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public ICollection<Author> Authors { get; set; }
        public Book()
        {
            Authors = new List<Author>();
        }
        // add the first book to the library
        public void AddBook()
        {
            using (BookCatalogContext db = new BookCatalogContext())
            {
                Console.Write("Please enter the title of the book: ");
                string _title = Console.ReadLine();
                while (_title.Length < 2 || _title.Length > 20)
                {
                    Console.Write("Try again! Please enter the title of the book: ");
                    _title = Console.ReadLine();
                }

                Console.Write("Year of the book: ");
                int _year = Int32.Parse(Console.ReadLine());
                while (_year < 1 || _year > 2019)
                {
                    Console.Write("Try again! Year of the book: ");
                    _year = Int32.Parse(Console.ReadLine());
                }
                Book myBook = new Book
                {
                    Title = _title,
                    Year = _year
                };
                db.Books.Add(myBook);
                db.SaveChanges();

                // number of authors maximum 3
                for (int counter = 0; counter < 3;)
                {
                    Console.Write("Author of the book (maximum 3 authors): ");
                    string _authorName = Console.ReadLine();
                    while (_authorName.Length < 2 || _authorName.Length > 30)
                    {
                        Console.Write("Try again! Please enter the title of the book: ");
                        _authorName = Console.ReadLine();
                    }
                    

                    Author myAuthor = new Author()
                    {
                        AuthorName = _authorName
                    };
                    myAuthor.Books.Add(myBook);
                    db.Authors.Add(myAuthor);
                    db.SaveChanges();

                    Console.WriteLine("There are more authors? (Yes - y) or (No - press another button) - you have {0} author(s)", counter + 1);
                    string _y = Console.ReadLine();
                    if (_y == "y" || _y == "Y")
                        counter++;
                    else
                        counter = 3;
                }

            }
        }

        // get all the books that were left in the library
        public void GetAllBooks()
        {
            using (BookCatalogContext db = new BookCatalogContext())
            {
                var _books = db.Books.ToList();

                Console.WriteLine("Id\t\t Year\t\t Title\t\t Author(s) (id)\t\t");

                foreach (Book bk in db.Books.Include(x => x.Authors))
                {
                    Console.Write("{0}\t\t {1}\t\t {2}\t\t ", bk.Id, bk.Year, bk.Title);
                    foreach (Author ax in bk.Authors)
                    {
                        Console.Write("{0} |id-{1}|\t\t", ax.AuthorName, ax.Id);
                    }
                    Console.WriteLine();
                }
            }
        }

        // get the book by ID and its authors
        public void GetBookById(int _id)
        {
            using (BookCatalogContext db = new BookCatalogContext())
            {
                Book _getBook = db.Books.Where(x => x.Id == _id).Include(x => x.Authors).FirstOrDefault();

                Console.WriteLine("Id\t\t Year\t\t Title\t\t Author(s) (id)\t\t");
                Console.Write("{0}\t\t {1}\t\t {2}\t\t ", _getBook.Id, _getBook.Year, _getBook.Title);
                foreach (Author ax in _getBook.Authors)
                {
                    Console.Write("{0} |id-{1}|\t\t", ax.AuthorName, ax.Id);
                }
                Console.WriteLine();
            }
        }

        // deleting a book causes the author to remain, but there is no longer any connection between them.
        public void DeleteBook(int _id)
        {
            using (BookCatalogContext db = new BookCatalogContext())
            {
                Book _delBook = db.Books.Where(x => x.Id == _id).FirstOrDefault();
                if (_delBook != null)
                {
                    db.Books.Remove(_delBook);
                    db.SaveChanges();
                }
            }
        }

    }


}
