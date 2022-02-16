using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    // ef book repository page, need to ask question about what this page does just to make sure i have a clear understanding
    public class EFBookRepository : IBookRepository
    {

        private BookstoreContext context { get; set; }

        public EFBookRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;

    }
}
