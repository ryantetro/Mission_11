
namespace Mission_11.Models
{
    // Implements the IBooksRepository interface using Entity Framework.
    public class EFBooksRepository : IBooksRepository
    {
        // Holds the database context.
        private BookstoreContext _Bookscontext;

        // Constructor that initializes the repository with a BookstoreContext.
        public EFBooksRepository(BookstoreContext b) 
        { 
            _Bookscontext = b;
        }

        // Provides access to the Books table in the database as a queryable collection.
        public IQueryable<Book> Books => _Bookscontext.Books;
     
    }
}
