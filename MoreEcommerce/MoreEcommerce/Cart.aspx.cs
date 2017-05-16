using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;  // add the new collections library

namespace MoreEcommerce
{
    public partial class Cart : System.Web.UI.Page
    {
        //column indexes for easier reading of codew
        const int PROD_ID = 0;
        const int NAME = 1;
        const int IMAGE = 2;
        const int PHONE = 3;
        const int PRICE = 4;
        const int QTY = 5;


        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateCartGrid();
            CalculateCartTotal();
        }

        private void PopulateCartGrid()
        {
            //make sure we are starting with a clean table
            tblCart.Rows.Clear();

            //build the header that used to reside in the aspx
            TableHeaderRow header = new TableHeaderRow();
            header.CssClass = "TableHeader";
            tblCart.Rows.Add(header);

            //image 

            //add a cell as a placeholder for the image
            //since I don't care about the contents of the 
            //cell i can add it directly
            header.Cells.Add(new TableCell());

            //name

            TableCell tcHeaderName = new TableCell();
            tcHeaderName.Text = "Name";
            header.Cells.Add(tcHeaderName);

            //Qty
            TableCell tcHeaderQty = new TableCell();
            tcHeaderQty.Text = "Qty";
            header.Cells.Add(tcHeaderQty);

            //Price
            TableCell tcHeaderPrice = new TableCell();
            tcHeaderPrice.Text = "Price";
            header.Cells.Add(tcHeaderPrice);

            //Total
            TableCell tcHeaderTotal = new TableCell();
            tcHeaderTotal.Text = "Total";
            header.Cells.Add(tcHeaderTotal);

            //remove button
            header.Cells.Add(new TableCell());

            //get each item into the cart
            int i = 0;
            foreach (ArrayList prodData in Index.cart)
            {// ... and build the table
                TableRow tr = new TableRow();
                tblCart.Rows.Add(tr);

                // image
                Image img = new Image();
                img.ImageUrl = prodData[IMAGE].ToString();
                img.Height = 100;
                img.Width = 100;
                TableCell tcImage = new TableCell();
                tcImage.Controls.Add(img);
                tr.Cells.Add(tcImage);

                // product name
                TableCell tcName = new TableCell();
                tcName.Text = prodData[NAME].ToString();
                tr.Cells.Add(tcName);

                // quantity
                if (prodData.Count == QTY)
                    prodData.Add(1);
                TextBox txtQty = new TextBox();
                int quantity = int.Parse(prodData[QTY].ToString());
                txtQty.Text = quantity.ToString();
                TableCell tcQty = new TableCell();
                tcQty.Controls.Add(txtQty);
                tr.Cells.Add(tcQty);

                // price
                TableCell tcPrice = new TableCell();
                decimal price = decimal.Parse(prodData[PRICE].ToString());
                tcPrice.Text = price.ToString("C");
                tcPrice.HorizontalAlign = HorizontalAlign.Right;
                tr.Cells.Add(tcPrice);

                // total
                TableCell tcLineTotal = new TableCell();
                tcLineTotal.Text = (price * quantity).ToString("#,##0.00");
                tr.Cells.Add(tcLineTotal);

                // remove
                TableCell tcRemove = new TableCell();
                Button btnRemove = new Button();
                btnRemove.ID = "btnRemove_" + i++;
                btnRemove.Text = "Remove";
                btnRemove.Click += new EventHandler(Remove_Click);
                tcRemove.Controls.Add(btnRemove);
                tr.Cells.Add(tcRemove);
            }
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            string ID = ((Button)sender).ID; // get the id of the butdon that got clicked
            string[] IDParts = ID.Split('_'); // break the id into it's parts
            int rowID = int.Parse(IDParts[1]); // part 1 has the row index

            // remove the item from the cart
            Index.cart.RemoveAt(rowID);

            // rebuild the table without the item we just removed
            PopulateCartGrid();
        }

        private void CalculateCartTotal()
        {
            decimal grandTotal = 0;

            // loop through the table
            int i = 0; // this index references our location within the cart
            foreach (TableRow tr in tblCart.Rows)
            {
                if (tr.GetType().ToString() == "System.Web.UI.WebControls.TableRow")
                {
                    // get the quantity (the first control we added to the quantity cell)
                    TextBox txtQty = (TextBox)tr.Cells[2].Controls[0];
                    int qty = int.Parse(txtQty.Text);

                    // update the quantity within the cart
                    ArrayList cartItem = (ArrayList)Index.cart[i];
                    cartItem[QTY] = qty;
                    Index.cart[i] = cartItem;

                    // get the price for this row of the table
                    decimal price = decimal.Parse(tr.Cells[3].Text.Replace("$", ""));

                    // update the total for this row
                    tr.Cells[4].Text = (qty * price).ToString("C");

                    // update the grand total
                    grandTotal += (qty * price);

                    // increment the counter
                    i++;
                }                   
            }
            // update the grand total on the screen
            lblGrandTotal.Text = grandTotal.ToString("C");  
        }
        protected void btnHiddenRemove_Click(object sender, EventArgs e)
        {

        }

        protected void btnRecalculate_Click(object sender, EventArgs e)
        {
            CalculateCartTotal();
        }
    }
}