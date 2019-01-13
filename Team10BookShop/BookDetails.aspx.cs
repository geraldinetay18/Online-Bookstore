using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10BookShop
{
    public partial class Book_Details : System.Web.UI.Page
    {
        MyBooks context;
        Book selectedBook;
        int selectedID;
        Category cat;
        int qty;

        List<Book> bookList;

        protected void Page_Load(object sender, EventArgs e)
        {
            selectedID =(int) Session["id"];

            if (!IsPostBack)
            {
                ViewState["qty"] = 1;
            }
            //txQty.Controls[0].Dispose();

            qty =(int) ViewState["qty"];
            context = new MyBooks();
            selectedBook = context.Books.Where(b => b.BookID.Equals(selectedID)).First();

            cat = new Category();
            cat = context.Categories.Where(c => c.CategoryID.Equals(selectedBook.CategoryID)).First();

            display(selectedBook);

            bookList = (List<Book>)Session["cart"];
        }

        protected void bookID(int id)
        {
            selectedID = id;
        }

        protected void display(Book a)
        {
            lbTitle.Text = a.Title;
            lbAuthor.Text = a.Author;
            lbBookID.Text = a.BookID.ToString();
            lbCategory.Text = cat.Name;
            lbISBN.Text = a.ISBN;
            lbPrice.Text = $"{a.Price:c}";
            lbStock.Text = a.Stock.ToString();
            Image1.ImageUrl = $"Images/{a.ISBN}.jpg";
            txQty.Text = qty.ToString();
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            qty =(int) ViewState["qty"];
            if (qty > 1)
            {
                qty--;
            }
            else
            {
                qty = 1;
                btnMinus.Enabled = false;
            }
            txQty.Text = qty.ToString();
            ViewState["qty"] = qty;
        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            qty = (int)ViewState["qty"];
            if (qty >= selectedBook.Stock)
            {
                qty = selectedBook.Stock;
                btnPlus.Enabled = false;
            }
            else
            {
                qty++;
            }
            txQty.Text = qty.ToString();
            ViewState["qty"] = qty;
        }

        protected void txQty_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txQty.Text)<=selectedBook.Stock&& Convert.ToInt32(txQty.Text) > 0)
            {
                qty= Convert.ToInt32(txQty.Text);
                ViewState["qty"] = qty;
            }
            txQty.Text= qty.ToString();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            qty = (int)ViewState["qty"];

            if (qty <= selectedBook.Stock)
            {
                for (int i = 0; i < qty; i++)
                {
                    bookList.Add(selectedBook);
                    Label1.Text += selectedBook.BookID;
                }
                Session["cart"] = bookList;
            }
            else
            {
                btnAddToCart.Enabled = false;
            }
            
            
        }
    }
}