using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MoreEcommerce
{
    public partial class Customers : System.Web.UI.Page
    {
        string websiteData = HttpContext.Current.Server.MapPath(".") + @"\data\";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblOutput.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Text = "Delete";
                StreamWriter output = new StreamWriter(websiteData + "Customer" +
                                                       txtCustomerNo.Text + ".txt");
                output.WriteLine(txtCustomerNo.Text);
                output.WriteLine(txtFirstName.Text);
                output.WriteLine(txtLastName.Text);
                output.Close();
                lblOutput.Text = "Thanks for your info.";
            }
            catch(Exception ex) 
            {
                StoreError(ex);
            }
        }

        private void StoreError(Exception ex)
        {
            lblOutput.Text = " There was an unexpected issue.  Our monkeys are looking " +
            "into it.  Thank you for your patience. Here is the error that was sent: " +
            ex.ToString();
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Text = "Delete";
                string filename = websiteData + "Customer" + txtCustomerNo.Text + ".txt";
                //check for the file
                if (File.Exists(filename))
                {
                    StreamReader input = new StreamReader(filename);
                    txtCustomerNo.Text = input.ReadLine();
                    txtFirstName.Text = input.ReadLine();
                    txtLastName.Text = input.ReadLine();
                    input.Close();
                }
                else
                {
                    lblOutput.Text = "This customer is nowhere to be found.";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                }
            }
            catch (Exception ex)
            {
                StoreError(ex);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDelete.Text == "Delete")
                {
                    btnLoad_Click(sender, e);
                    if (txtFirstName.Text != "")
                    {
                        //assuming that first name is required.  we find a customer
                        //and can change the name of the delete button
                        btnDelete.Text = "Confirm";
                    }

                }
                else 
                {
                    lblOutput.Text = DeleteCustomer(int.Parse(txtCustomerNo.Text));
                    btnDelete.Text = "Delete";
                }
            }
            catch (Exception ex)
            {
                StoreError(ex);
            }
        }

        public string DeleteCustomer(int custID)
        {
            string fileName = websiteData + "Customer" + custID.ToString() + ".txt";
            //throw a new exception("make it fail on this line"
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                //clean up the stale data
                txtCustomerNo.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                return String.Format("Customer has been deleted.");
            }
            else 
            {
                return "The customer you are deleting could not be found.";
            }
        }
    }
}