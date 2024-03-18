
namespace Mission_11.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BookstoreContext _Bookscontext;
        public EFBooksRepository(BookstoreContext b) 
        { 
            _Bookscontext = b;
        }
        public IQueryable<Book> Books => _Bookscontext.Books;
     
    }
}
