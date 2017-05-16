using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace MoreEcommerce
{
    public partial class Products : System.Web.UI.Page
    {
        string websiteData = HttpContext.Current.Server.MapPath(".") + @"\data\";
        string imageLocation = HttpContext.Current.Server.MapPath(".") + @"\images\";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOutput.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //set up the string verification
                String PhoneRegex = @"^(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
                String Moneyregex = @"^([0-9]{3}, ([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
                
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, PhoneRegex))
                {
                    lblOutput.Text = "The phone number is not in an appropriate format for saving.";
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, Moneyregex))
                {
                    lblOutput.Text = "The phone number is not in a proper format.";
                }
                else if (txtProdID.Text.Trim().Length == 0 || txtName.Text.Trim().Length == 0 || txtPhone.Text.Trim().Length == 0 || txtPrice.Text.Trim().Length ==0)
                {
                    lblOutput.Text = "You missed some important data.  Please provide the information so it can be saved.";
                }
                else
                {
                    if (fulImage.HasFile)
                    {
                        //upload the image to the images folder
                        fulImage.SaveAs(imageLocation + fulImage.FileName);
                        //ave the data to a text file
                        StreamWriter output = new StreamWriter(websiteData + "Product" + txtProdID.Text + ".txt");
                        output.WriteLine(txtProdID.Text);
                        output.WriteLine(txtName.Text);
                        output.WriteLine(@"/images/" + fulImage.FileName);
                        output.WriteLine(txtPhone.Text);
                        output.WriteLine(txtPrice.Text);
                        output.Close();
                        //thank the user
                        lblOutput.Text = "Thanks for the information.";
                    }
                    else
                    {
                        lblOutput.Text = "Please supply an image for this product. The product information was not saved";
                    }
                }
            }
            catch (Exception ex)
            {
                //generally asking a user to debug the code is not a good idea
                lblOutput.Text = "There was an error.  Please debug!";
            }
        }
    }
}