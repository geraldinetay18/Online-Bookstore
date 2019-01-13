using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10BookShop
{
    public partial class Receipt : System.Web.UI.Page
    {
        List<Book> cartList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //// Dummy book a and b for testing purpose
                //Book a = new Book(); // to be deleted when combine
                //a.BookID = 1; // to be deleted when combine
                //a.Title = "The Trials of Apollo Book Two The Dark Prophecy"; // to be deleted when combine
                //a.Price = (decimal)19.99; // to be deleted when combine
                //a.Stock = 10; // to be deleted when combine
                //a.ISBN = "9781484746424"; // to be deleted when combine
                //a.CategoryID = 1; // to be deleted when combine
                //a.Author = "Rick Riordan"; // to be deleted when combine

                //Book b = new Book(); // to be deleted when combine
                //b.BookID = 2; // to be deleted when combine
                //b.Title = "The Wonderful Things You Will Be"; // to be deleted when combine
                //b.Price = (decimal)17.99; // to be deleted when combine
                //b.Stock = 10; // to be deleted when combine
                //b.ISBN = "9780385376716"; // to be deleted when combine
                //b.CategoryID = 1; // to be deleted when combine
                //b.Author = "Emily Winfield Martin"; // to be deleted when combine

                //// Assign Session["cart"] into cartList, and add dummy book a and b into cartList
                //cartList = Session["cart"] as List<Book>;
                //cartList.Add(a); // to be deleted when combine
                //cartList.Add(b); // to be deleted when combine
                //Session["cart"] = cartList; // to be deleted when combine


                // Assign Session["cart"] into cartList, and add dummy book a and b into cartList
                cartList = Session["cart"] as List<Book>;
                if (cartList != null)
                {
                    PurchaseGridView.DataSource = cartList;
                    PurchaseGridView.DataBind();
                }

                decimal sum = 0;
                foreach (Book c in cartList)
                {
                    sum += c.Price;
                }
                PriceLabel.Text = sum.ToString();

            }
        }
    }
}