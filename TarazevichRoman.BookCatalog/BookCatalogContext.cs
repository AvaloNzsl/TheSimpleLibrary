using System.Data.Entity;

namespace TarazevichRoman.BookCatalog
{
    //Database initialization
    //all settings are written in the web.config file

    //Code First
    class BookCatalogContext : DbContext
    {
        public BookCatalogContext()
        : base("dbConnectionCatalog")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
