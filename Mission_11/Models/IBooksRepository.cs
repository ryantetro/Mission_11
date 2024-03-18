namespace Mission_11.Models
{
    public interface IBooksRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
