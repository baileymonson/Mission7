using System.Linq;

namespace Amazon.Models
{
    // getting books
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
