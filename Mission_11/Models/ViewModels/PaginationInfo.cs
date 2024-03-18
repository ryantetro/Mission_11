namespace Mission_11.Models.ViewModels
{
    // Represents pagination-related information for displaying items across multiple pages.
    public class PaginationInfo
    {
        // The total number of items to be paginated.
        public int TotalItems { get; set; }

        // The number of items to display on each page.
        public int ItemsPerPage { get; set; }

        // The current page number being displayed.
        public int CurrentPage { get; set; }

        // The total number of pages, calculated based on TotalItems and ItemsPerPage.
        // Uses Ceiling to ensure we get a whole page for any remaining items.
        public int TotalNumPages => (int) (Math.Ceiling((decimal) TotalItems / ItemsPerPage));

    }
}
