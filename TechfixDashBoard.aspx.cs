using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userRole = Session["UserRole"] as string;
            string userShop = Session["UserShop"] as string;
        }
        protected void btnManageUsers_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("TFViewProduct.aspx");
        }

        
        protected void btnManageOrders_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("WebForm14.aspx");
        }

        protected void btnViewReports_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("AddQuotation.aspx");
        }

        protected void btnManageInventory_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ViewOrdersTF.aspx");
        }

        protected void btnViewApprovedQuotations_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewApprovedQuotationsTF.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm14.aspx");
        }
    }
}