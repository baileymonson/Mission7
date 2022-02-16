using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    // getting books
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
