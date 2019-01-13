using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Team10BookShop
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            string name = Username.Text;
            string pwd = Password.Text;
            try
            {
                if (name != null || pwd != null)
                {
                    SqlConnection con = new SqlConnection("data source=(local);integrated security=SSPI; initial catalog=Team10BookShop");
                    SqlParameter[] sp = new SqlParameter[2];
                    string sql = "insert into UserDetails(Username,Password) values(@a,@b)";
                    sp[0] = new SqlParameter("@a", Username.Text);
                    sp[1] = new SqlParameter("@b", Password.Text);
                    con.Open();
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddRange(sp);
                    int i = com.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Response.Write("Register succeed");
                    }
                    else
                    {
                        Response.Write("Register failed");
                    }
                }
                else
                {
                    Response.Write("Please fill the blanks");
                }
            }
            catch (Exception)
            {
                Response.Write("Username repeated");
            }
        }
    }
}