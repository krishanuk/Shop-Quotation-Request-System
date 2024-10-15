using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                string userRole = Session["UserRole"] as string;
                string userShop = Session["UserShop"] as string;

        }

        protected void btnManageProducts_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ManageProduct.aspx");
        }

        protected void btnViewOrders_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ViewProduct.aspx");
        }

        protected void btnManageDeliveries_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ViewNotification.aspx");
        }

        protected void btnViewReports_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ViewOrdersSupplier.aspx");
        }

        protected void btnViewQuotation_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ViewApprovedQuotation.aspx");
        }
    }
}