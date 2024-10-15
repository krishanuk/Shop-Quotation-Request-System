using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TechFix
{
    public partial class WebForm5 : Page
    {
        localhostProductManage.WebService1 sms = new localhostProductManage.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userRole = Session["UserRole"] as string;
                string userShop = Session["UserShop"] as string;

                if (userRole == "Supplier" && !string.IsNullOrEmpty(userShop))
                {
                    LoadProducts(userShop);
                }
                else
                {
                    lblError.Text = "You do not have access to view products.";
                }
            }
        }

        private void LoadProducts(string supplierName)
        {
            try
            {
                WebService1 service = new WebService1();
                DataSet ds = service.GetProductsBySupplier(supplierName);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    lblError.Text = "No products found.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading products: " + ex.Message;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the Image control in the current row
                var imgProduct = e.Row.FindControl("imgProduct") as System.Web.UI.WebControls.Image;

                if (imgProduct != null)
                {
                    // Get the ProductImage from the DataRow
                    byte[] imageBytes = (byte[])DataBinder.Eval(e.Row.DataItem, "ProductImage");
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                        imgProduct.ImageUrl = "data:image/jpeg;base64," + base64String;
                    }
                    else
                    {
                        imgProduct.ImageUrl = "path/to/default/image.jpg"; 
                    }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}