using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayerTF;

namespace TechFix
{
    public partial class WebForm10 : System.Web.UI.Page
    {
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

                Orders order = new Orders();
                DataSet ds = order.GetAllProducts(userRole, userShop);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvOrderDetails.DataSource = ds;
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
                lblMessage.Text = "Error loading orders: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        protected void gvOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateStatus")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                DropDownList ddlOrderStatus = (DropDownList)row.FindControl("ddlOrderStatus");
                string newStatus = ddlOrderStatus.SelectedValue;

                try
                {
                    Orders order = new Orders();
                    int result = order.UpdateOrderStatus(orderId, newStatus);

                    if (result > 0)
                    {
                        lblMessage.Text = "Order status updated successfully.";
                        lblMessage.Visible = true;

                        
                        LoadOrderDetails();
                    }
                    else
                    {
                        lblMessage.Text = "Failed to update order status.";
                        lblMessage.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error updating order status: " + ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }
    }
}