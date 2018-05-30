using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
   public class Cart
    {

        private List<CartLine> LineCollection = new List<CartLine>();
        public void AddItem(Book book, int quantity = 1)
        {
            CartLine Line = LineCollection
                            .Where(b => b.Book.ISBN == book.ISBN)
                            .FirstOrDefault();

            if (Line == null)
            {
                LineCollection.Add(new CartLine { Book = book, Quantity = quantity });
            }
            else
            {
                Line.Quantity += quantity;
            }

        }

        public void RemoveLine(Book book)
        {
            LineCollection.RemoveAll(b => b.Book.ISBN == book.ISBN);

        }

        public decimal ComputeTotalValue()
        {

           return LineCollection.Sum(cl => cl.Book.Price * cl.Quantity);   
        }

        public void Clear()
        {

            LineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return LineCollection; }

        }

    }//end of cart class

    public class CartLine
    {

        public Book Book { get; set; }
        public int Quantity { set; get; }

    }//end of CartLine 

}//end of namespace 
