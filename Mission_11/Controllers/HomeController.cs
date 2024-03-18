using Microsoft.AspNetCore.Mvc;
using Mission_11.Models;
using Mission_11.Models.ViewModels;
using System.Diagnostics;

namespace Mission_11.Controllers
{
    // HomeController manages web page requests related to books.
    public class HomeController : Controller
    {
        // A repository to access book data.
        private IBooksRepository _booksRepository;

        // HomeController constructor, uses dependency injection to get access to books data.
        public HomeController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // The Index action displays a page of books. It takes a page number as a parameter.
        public IActionResult Index(int pageNum)
        {
            // Defines how many books to show per page.
            int pageSize = 10;

            // Prepares the data model for the view, including a page of books and pagination info.
            var b = new ProjectListViewModel
            {
                // Selects a subset of books for the requested page using pagination logic.
                Books = _booksRepository.Books
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // Sets up pagination details like current page, items per page, and total item count.
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _booksRepository.Books.Count()
                }
            };

            // Sends the prepared data model to the view to be displayed to the user.
            return View(b);
        }

    }
}
