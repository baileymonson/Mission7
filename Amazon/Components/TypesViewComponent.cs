using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


//this page hilton will explain later 
namespace Amazon.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public TypesViewComponent(IBookRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedType = RouteData?.Values["projectType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
