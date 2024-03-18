using Microsoft.AspNetCore.Mvc;
using Mission_11.Models;
using Mission_11.Models.ViewModels;
using System.Diagnostics;

namespace Mission_11.Controllers
{
    public class HomeController : Controller
    {
        private IBooksRepository _booksRepository;

        public HomeController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var b = new ProjectListViewModel
            {
                Books = _booksRepository.Books
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _booksRepository.Books.Count()
                }
            };
            
            return View(b);
        }

    }
}
