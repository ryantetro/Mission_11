namespace Mission_11.Models
{
    // Defines the interface for a books repository.
    public interface IBooksRepository
    {
        // Property to get a queryable collection of books.
        public IQueryable<Book> Books { get; }
    }
}
