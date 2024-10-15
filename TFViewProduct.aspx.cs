using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            try
            {
                
                WebService1 service = new WebService1();
                
                DataSet ds = service.GetAllProducts();

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
                
                Image imgProduct = (Image)e.Row.FindControl("imgProduct");

                if (imgProduct != null)
                {
                    
                    byte[] imageBytes = DataBinder.Eval(e.Row.DataItem, "ProductImage") as byte[];

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                        imgProduct.ImageUrl = "data:image/jpeg;base64," + base64String;
                    }
                    else
                    {
                        imgProduct.ImageUrl = "~/Images/default.png"; 
                    }
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OrderNow")
            {
                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];

                
                int productId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);

                
                string productName = row.Cells[1].Text;
                decimal productPrice = Convert.ToDecimal(row.Cells[2].Text);

                
                TextBox txtOrderQuantity = row.FindControl("txtOrderQuantity") as TextBox;
                if (txtOrderQuantity != null && int.TryParse(txtOrderQuantity.Text, out int quantity) && quantity > 0)
                {
                    
                    string shippingAddress = txtShippingAddress.Text;

                    if (!string.IsNullOrWhiteSpace(shippingAddress))
                    {
                        
                        OrderManageService service = new OrderManageService();

                        
                        int result = service.InsertOrder(Convert.ToInt32(Session["UserID"]), productId, productName, productPrice, quantity, "Pending", row.Cells[5].Text, shippingAddress);

                        if (result > 0)
                        {
                            lblError.Text = "Order placed successfully.";

                            
                            txtShippingAddress.Text = "";
                            txtOrderQuantity.Text = "";
                            LoadProducts();
                        }
                        else
                        {
                            lblError.Text = "Failed to place order.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Please enter a shipping address.";
                    }
                }
                else
                {
                    lblError.Text = "Please enter a valid quantity.";
                }
            }
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
