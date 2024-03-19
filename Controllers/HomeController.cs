using Microsoft.AspNetCore.Mvc;
using Mission11.Models;
using Mission11.Models.ViewModels;
using System.Diagnostics;

namespace Mission11.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepository;

        public HomeController(IBookRepository temp)
        {
            _bookRepository = temp;
        }

        public IActionResult Index(int pageNum)
        { 
            int pageSize = 5;

            var blah = new BookListViewModel
            {
                Books = _bookRepository.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrntPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepository.Books.Count()

                }
            };

         
            return View(blah);
        }
    }
}
