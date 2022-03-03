using Amazon.Models;
using Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Amazon.Controllers
{
    // main home controller
    public class HomeController : Controller
    {
        private IBookRepository repo;

        public HomeController(IBookRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string projectType, int pageNum = 1)
        {
            // instructioins said for 10 a page and database was only seeded with 10 items. the pagination does work if there were to be more entrires, right now it is just chilling
            int pageSize = 10;



            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == projectType || projectType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (projectType == null
                        ? repo.Books.Count()
                        : repo.Books
                        .Where(x => x.Category == projectType)
                        .Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };



            return View(x);
        }

        //public IActionResult Index() => View();
    }
}
