using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;  //add this to your library declarations

namespace MoreEcommerce
{
    public partial class Index : System.Web.UI.Page
    {
        public static string websiteData = HttpContext.Current.Server.MapPath(".") +
                                           @"\data\";
        public static ArrayList cart = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {

        }           

        protected void btnCatalogue_Click(object sender, EventArgs e)
        {
            CustomerFrame.Attributes.Add("src", "Catalogue.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            CustomerFrame.Attributes.Add("src", "Cart.aspx");
        }
    }
}