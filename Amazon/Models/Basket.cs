using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//this is the basket page that adds new line items to each basekt

namespace Amazon.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book proj, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == proj.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new BasketLineItem{
                    Book = proj,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity = line.Quantity + qty;
            }
        }
        //delete item
        public virtual void RemoveItem(Book proj)
        {
            Items.RemoveAll(x => x.Book.BookId == proj.BookId);
        }

        //clear the basket
        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        // this calculates the total price for all of the books in the shopping cart
        public double CalculateTotal()
        {
            double sum = Items.Sum(b => b.Quantity * b.Book.Price);
            return sum;
        }
    }


    public class BasketLineItem
    {
        [Key]
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
