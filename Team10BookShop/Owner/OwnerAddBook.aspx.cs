

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10BookShop
{
    public partial class OwnerAddBook : System.Web.UI.Page
    {
        
        MyBooks context = new MyBooks();
        Book b;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // Only proceed to save in database if book cover image is valid
            if (IsValidFile())
            {
                b = new Book();
                b.Title = txtBookTitle.Text;
                b.CategoryID = Convert.ToInt32(ddCategory.SelectedValue);
                b.ISBN = txtISBN.Text;
                b.Author = txtAuthor.Text;
                b.Stock = Convert.ToInt32(txtStock.Text);
                b.Price = Convert.ToInt32(txtPrice.Text);
                FileUploadImage.SaveAs(Server.MapPath("~/images/" + b.ISBN + System.IO.Path.GetExtension(FileUploadImage.FileName).ToLower()));

                try
                {
                    context.Books.Add(b);
                    context.SaveChanges();
                    Response.Write("<script>confirm('Success!'); window.location = 'OwnerAddBook.aspx';</script>");
                }
                catch (Exception a)
                {
                    Response.Write("<script> if(confirm('Book add was unsuccessful...Would you like to add new book?'))" +
                        "{window.location = 'OwnerAddBook.aspx';} else {window.location = 'BookSearch.aspx';} </script>");
                }
            }
        }

        private bool IsValidFile()
        {
            bool IsValid = false;

            // Validate whether file exists
            if (FileUploadImage.HasFile)
            {
                // Validate file type
                string fileExtension = System.IO.Path.GetExtension(FileUploadImage.FileName).ToLower();
                if ((fileExtension != ".jpg") && (fileExtension != ".png"))
                    lblErrorFileUpload.Text = "Only files with .jpg and .png are allowed.";

                else
                {
                    // Validate file size
                    int fileSize = FileUploadImage.PostedFile.ContentLength;

                    if (fileSize > 2097152)
                        lblErrorFileUpload.Text = "Maximum file size of 2MB has been exceeded.";

                    else
                         IsValid = true;
                }
            }
            else
                lblErrorFileUpload.Text = "Please select an image to upload.";

            return IsValid;
        }
    }
}