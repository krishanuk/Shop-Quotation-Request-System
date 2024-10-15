using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        localhostOrderManage.OrderManageService sms = new localhostOrderManage.OrderManageService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrderDetails();
            }
        }

        private void LoadOrderDetails()
        {
            try
            {
                string userRole = Session["UserRole"] as string;
                string userShop = Session["UserShop"] as string;

                DataSet orders = sms.GetProducts(userRole, userShop);

                if (orders != null && orders.Tables.Count > 0 && orders.Tables[0].Rows.Count > 0)
                {
                    gvOrderDetails.DataSource = orders.Tables[0];
                    gvOrderDetails.DataBind();
                    gvOrderDetails.Visible = true; 
                }
                else
                {
                    lblMessage.Text = "No orders found.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error loading orders: {ex.Message}";
                lblMessage.Visible = true;
            }
        }

    }
}