using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10BookShop.Anonymous
{
    public partial class Browsing2 : System.Web.UI.Page
    {
        int catid;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (MyBooks mb = new MyBooks())
                {
                    DataList1.DataSource = mb.Books.ToList<Book>();
                    DataList1.DataBind();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchMessage.Text = "";
            using (MyBooks mb = new MyBooks())
            {
                if (ddCategory.SelectedItem.Text == "All")
                {
                    if (txtSearch.Text != null)
                    {
                        switch (ddDetails.SelectedValue)
                        {
                            case "Author":

                                catid = Convert.ToInt32(ddCategory.SelectedValue);
                                var q = from x in mb.Books where x.Author.Contains(txtSearch.Text) select x;
                                if (q.Count() != 0)
                                {
                                    DataList1.DataSource = q.ToList();
                                    DataList1.DataBind();
                                }
                                else
                                {
                                    SearchMessage.Text = "Failed";
                                    Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                }
                                break;
                            case "Title":
                                catid = Convert.ToInt32(ddCategory.SelectedValue);
                                var q1 = from x in mb.Books where x.Title.Contains(txtSearch.Text) select x;
                                if (q1.Count() != 0)
                                {
                                    DataList1.DataSource = q1.ToList();
                                    DataList1.DataBind();
                                }
                                else
                                {
                                    SearchMessage.Text = "Failed";
                                    Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                }
                                break;
                            case "ISBN":
                                catid = Convert.ToInt32(ddCategory.SelectedValue);
                                var q2 = from x in mb.Books where x.ISBN == (txtSearch.Text) select x;
                                if (q2.Count() != 0)
                                {
                                    DataList1.DataSource = q2.ToList();
                                    DataList1.DataBind();
                                }
                                else
                                {
                                    SearchMessage.Text = "Failed";
                                    Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                }
                                break;

                            default:
                                SearchMessage.Text = "Failed";
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                break;
                        }
                    }
                    else
                    {
                        SearchMessage.Text = "Failed";
                        Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                    }
                }
                else
                {
                    catid = Convert.ToInt32(ddCategory.SelectedValue);
                    if (txtSearch.Text != null)
                    {
                        switch (ddDetails.SelectedValue)
                        {
                            case "Author":

                                //catid = Convert.ToInt32(CategoryDL.SelectedValue);
                                var q = from x in mb.Books where x.Author.Contains(txtSearch.Text) && x.CategoryID == catid select x;
                                if (q.Count() != 0)
                                {
                                    DataList1.DataSource = q.ToList();
                                    DataList1.DataBind();
                                }
                                else
                                {
                                    SearchMessage.Text = "Failed";
                                    Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                }
                                break;
                            case "Title":
                                //catid = Convert.ToInt32(CategoryDL.SelectedValue);
                                var q1 = from x in mb.Books where x.Title.Contains(txtSearch.Text) && x.CategoryID == catid select x;
                                if (q1.Count() != 0)
                                {
                                    DataList1.DataSource = q1.ToList();
                                    DataList1.DataBind();
                                }
                                else
                                {
                                    SearchMessage.Text = "Failed";
                                    Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                }
                                break;
                            case "ISBN":
                                //catid = Convert.ToInt32(CategoryDL.SelectedValue);
                                var q2 = from x in mb.Books where x.ISBN == (txtSearch.Text) && x.CategoryID == catid select x;
                                if (q2.Count() != 0)
                                {
                                    DataList1.DataSource = q2.ToList();
                                    DataList1.DataBind();
                                }
                                else
                                {
                                    SearchMessage.Text = "Failed";
                                    Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                }
                                break;

                            default:
                                SearchMessage.Text = "Failed";
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                                break;
                        }
                    }

                    else
                    {
                        SearchMessage.Text = "Failed";
                        Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                    }
                }
            }
        }
        protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchMessage.Text = "";
            using (MyBooks mb = new MyBooks())
            {
                int s;
                if (ddCategory.SelectedItem.Text == "All")
                {
                    var q4 = from x in mb.Books select x;
                    if (q4.Count() != 0)
                    {
                        DataList1.DataSource = q4.ToList();
                        DataList1.DataBind();
                    }
                }
                else
                {
                    s = Convert.ToInt32(ddCategory.SelectedValue);
                    var q4 = from x in mb.Books where (x.CategoryID == s) select x;
                    if (q4.Count() != 0)
                    {
                        DataList1.DataSource = q4.ToList();
                        DataList1.DataBind();
                    }
                }

            }
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                Control control;
                control = e.Item.FindControl("BookIDLabel");
                int bookID = Convert.ToInt32(((Label)control).Text);
                Book b = BusinessLogic.getBookByID(bookID);
                Session["id"] = b.BookID;
                Console.WriteLine("book id is:" + Session["id"]);
                Response.Redirect("~/Anonymous/BookDetails.aspx");
            }
        }
    }
}