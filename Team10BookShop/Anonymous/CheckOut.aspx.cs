using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10BookShop
{
    public partial class CheckOut : System.Web.UI.Page
    {
        //List<Book> cartList;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {

        //        cartList = Session["cart"] as List<Book>;
        //        if (cartList != null)
        //        {
        //            CartGridView.DataSource = cartList;
        //            CartGridView.DataBind();
        //        }

        //        decimal sum = 0;
        //        foreach (Book c in cartList)
        //        {
        //            sum += c.Price;
        //        }
        //        PriceLabel.Text = sum.ToString();
        //    }

        //}
        //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    cartList = Session["cart"] as List<Book>;
        //    int Index = e.RowIndex;
        //    cartList.RemoveAt(Index);
        //    Session["cart"] = cartList;
        //    CartGridView.DataSource = cartList;
        //    CartGridView.DataBind();

        //    decimal sum = 0;
        //    foreach (Book c in cartList)
        //    {
        //        sum += c.Price;
        //    }
        //    PriceLabel.Text = sum.ToString();
        //}

        List<Book> cartList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cartList = Session["cart"] as List<Book>;
                if (cartList != null)
                {
                    CartGridView.DataSource = cartList;
                    CartGridView.DataBind();
                }
                PopulateTotalPrice();
                DisableConfirmButton();
            }
        }

        private void PopulateTotalPrice()
        {
            decimal sum = 0;
            foreach (Book c in cartList)
            {
                sum += c.Price;
            }
            PriceLabel.Text = sum.ToString();
        }
        private void DisableConfirmButton()
        {
            if (cartList.Count() == 0)
            {
                ConfirmButton.Visible = false;
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            cartList = Session["cart"] as List<Book>;
            int Index = e.RowIndex;
            cartList.RemoveAt(Index);
            Session["cart"] = cartList;
            CartGridView.DataSource = cartList;
            CartGridView.DataBind();
            PopulateTotalPrice();
            DisableConfirmButton();
        }
        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            cartList = Session["cart"] as List<Book>;
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    CheckOutBusinessLogic b = new CheckOutBusinessLogic();
                    Order order = b.CreateOrderID(User.Identity.Name);
                    foreach (Book d in cartList)
                    {
                        b.CreateOrderDetails(order.OrderID, d.BookID, d.Price);
                        b.ChangeStock(d.BookID);
                    }
                }
                catch (Exception)
                {
                    Page.Response.Redirect("~/Anonymous/Sorry");
                }
            }
            else
            {
                Page.Response.Redirect("~/Account/Login?ReturnUrl=~/Anonymous/CheckOut");
            }

            Page.Response.Redirect("~/Anonymous/Receipt");

        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Anonymous/Browsing2");
        }
    }
}