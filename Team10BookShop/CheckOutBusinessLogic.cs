using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team10BookShop
{
    public class CheckOutBusinessLogic
    {
        MyBooks myBooks = new MyBooks();

        public Order CreateOrderID(string userName)
        {
            Order order = new Order
            {
                UserName = userName
            };
            myBooks.Orders.Add(order);
            myBooks.SaveChanges();
            return order;
        }

        public void CreateOrderDetails(int orderID, int bookID, decimal price)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                OrderID = orderID,
                BookID = bookID,
                Price = price

            };
            myBooks.OrderDetails.Add(orderDetail);
            myBooks.SaveChanges();
        }

        public void ChangeStock(int bookID)
        {
            Book book = myBooks.Books.Where(b => b.BookID == bookID).First<Book>();
            book.Stock -= 1;
            myBooks.SaveChanges();
        }
    }
}