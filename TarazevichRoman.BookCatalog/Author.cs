using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TarazevichRoman.BookCatalog
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        // both models will have collection properties through which communication is performed
        public ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }

        // get the list of authors
        public void GetAllAuthors()
        {
            using (BookCatalogContext db = new BookCatalogContext())
            {
                var _authors = db.Authors.ToList();

                Console.WriteLine("Id\t\t Author\t\t Title Book |id|\t Year\t\t");

                foreach (Author ax in db.Authors.Include(x => x.Books))
                {
                    Console.Write("{0}\t\t {1}\t\t ", ax.Id, ax.AuthorName);
                    foreach (Book bx in ax.Books)
                    {
                        Console.Write("{0} |id-{1}|\t\t {2}\t\t", bx.Title, bx.Id, bx.Year);
                    }
                    Console.WriteLine();
                }
            }
        }

        // get the author by ID and a list of all his books
        public void GetAuthorById(int _id)
        {
            using (BookCatalogContext db = new BookCatalogContext())
            {
                Author _getAuthorId = db.Authors.Where(x => x.Id == _id).FirstOrDefault();
                

                Console.WriteLine("Id\t\t Author\t\t Title Book |id|\t\t Year\t\t");
                foreach (Author aq in db.Authors.Where(x => x.AuthorName == _getAuthorId.AuthorName).Include(x => x.Books))
                {
                    Console.Write("{0}\t\t {1}\t\t ", _getAuthorId.Id, _getAuthorId.AuthorName);
                    foreach (Book bx in aq.Books)
                    {
                        Console.Write("{0} |id-{1}|\t\t {2}\t\t", bx.Title, bx.Id, bx.Year);
                    }
                    Console.WriteLine();
                }

            }
        }
        //delete
        public void DeleteAuthor(int _id)
        {
            using (BookCatalogContext db = new BookCatalogContext())
            {
                Author _delAuthor = db.Authors.Where(x => x.Id == _id).FirstOrDefault();
                if (_delAuthor != null)
                {
                    db.Authors.Remove(_delAuthor);
                    db.SaveChanges();
                }
            }
        }
    }
}
