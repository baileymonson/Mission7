using Amazon.Models;
using Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index(int pageNum =1)
        {
            // instructioins said for 10 a page and database was only seeded with 10 items. the pagination does work if there were to be more entrires, right now it is just chilling
            int pageSize = 10;



            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };

         

            return View(x);
        }

        //public IActionResult Index() => View();
    }
}
