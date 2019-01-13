using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;


namespace Team10BookShop
{
    public partial class OwnerUpdateInventoryNEW : System.Web.UI.Page
    {
        string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            title = Request.QueryString["title"];
            if (!IsPostBack)
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {
            GridView1.DataSource = BusinessLogic.ListBooksBy();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bookID = (int)GridView1.SelectedDataKey.Value;
            using (MyBooks entities = new MyBooks())
            {
                Book book = entities.Books.Where(x => x.BookID == bookID).First<Book>();
                DetailsView1.DataSource = new Book[] { book };
                DetailsView1.DataBind();
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int bookID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string title = (row.FindControl("TextBox2") as TextBox).Text;
            int categoryID = Convert.ToInt32(row.FindControl("TextBox3") as TextBox);
            string isbn = (row.FindControl("TextBox4") as TextBox).Text;
            string author = (row.FindControl("TextBox5") as TextBox).Text;
            int stock = Convert.ToInt32(row.FindControl("TextBox6") as TextBox);
            decimal price = Convert.ToDecimal(row.FindControl("TextBox7") as TextBox);
            float discount = Convert.ToInt32(row.FindControl("TextBox8") as TextBox);
            DateTime startDate = Convert.ToDateTime(row.FindControl("TextBox9") as TextBox);
            DateTime endDate = Convert.ToDateTime(row.FindControl("TextBox10") as TextBox);
            BusinessLogic.EditInventory(bookID, title, categoryID, isbn, author, stock, price);
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            BusinessLogic.DeleteBooks(Convert.ToString(bookID));
            BindGrid();
        }

    }
}