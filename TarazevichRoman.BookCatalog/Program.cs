using System;

namespace TarazevichRoman.BookCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Book bk = new Book();
            Author aut = new Author();
            Console.WriteLine("===============================Welcome to Library===============================");
            bool goToTheLibrary = true;
            while (goToTheLibrary)
            {
                int _id = 0;
                Console.WriteLine("================================================================================");
                Console.WriteLine("1. Add book\t 2. Get all book(s)\t 3. Get book by ID\t 4. Delete book by ID\n" +
                                    "5. Get all authors\t 6. Get author by ID\t 7. Delete author by ID\n" +
                                    "8. Quit");
                Console.WriteLine("================================================================================");
                Console.Write("Your selection: ");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Add book");
                        bk.AddBook();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("Get all books");
                        bk.GetAllBooks();
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("Get book by ID");
                        _id = Int32.Parse(Console.ReadLine());
                        bk.GetBookById(_id);
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Delete book by ID");
                        _id = Int32.Parse(Console.ReadLine());
                        bk.DeleteBook(_id);
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine("Get all authors");
                        aut.GetAllAuthors();
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine("Get author by ID");
                        _id = Int32.Parse(Console.ReadLine());
                        aut.GetAuthorById(_id);
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.WriteLine("Delete author by ID");
                        _id = Int32.Parse(Console.ReadLine());
                        aut.DeleteAuthor(_id);
                        Console.WriteLine();
                        break;
                    case "8":
                        Console.WriteLine("\t Quitting...Bye");
                        goToTheLibrary = false;
                        break;
                    default:
                        Console.WriteLine("Once Again!?");
                        Console.WriteLine();
                        break;
                }
            }

            Console.ReadLine();

        }

        
       
       
        
    }
}
