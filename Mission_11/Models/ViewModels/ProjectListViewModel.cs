namespace Mission_11.Models.ViewModels
{
    // Defines a view model for the project list page.
    public class ProjectListViewModel
    {

        // A collection of books to be displayed on the page. 
        public IQueryable<Book> Books { get; set; }

        // Contains pagination details like total items, items per page, current page, etc.
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
       
    }
}
