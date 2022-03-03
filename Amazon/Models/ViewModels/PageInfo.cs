using System;

namespace Amazon.Models.ViewModels
{
    // creating info about pages to use in slug
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        // figure out how many pages we need
        // the int changes and casts the double to an int
        // ceiling rounds it up 
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}
