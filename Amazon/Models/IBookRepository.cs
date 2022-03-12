using System.Linq;

namespace Amazon.Models
{
    // getting books
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}
