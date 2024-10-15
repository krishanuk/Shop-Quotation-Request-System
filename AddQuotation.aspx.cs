using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm7 : System.Web.UI.Page
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
                string selectedSupplier = ddlSupplierSelect.SelectedValue;
                WebService1 service = new WebService1();
                DataSet ds = service.GetProductsBySupplier(selectedSupplier);

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToQuotation")
            {
                
                int productId = Convert.ToInt32(e.CommandArgument);

                
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;

                
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                int quantity = 1; 
                if (txtQuantity != null && int.TryParse(txtQuantity.Text, out int enteredQuantity))
                {
                    quantity = enteredQuantity;
                }

                
                AddToQuotation(productId, quantity);
            }
        }

        private void AddToQuotation(int productId, int quantity)
        {
            try
            {
                string selectedSupplier = ddlSupplierSelect.SelectedValue;
                int requestedByUserID = Convert.ToInt32(Session["UserID"]);

                
                decimal quotedPrice = 100.00M;

                QuotationManagementService service = new QuotationManagementService();
                int result = service.AddQuotation(requestedByUserID, selectedSupplier, productId, quantity, quotedPrice);

                if (result > 0)
                {
                    lblError.Text = "Product added to quotation successfully.";
                }
                else
                {
                    lblError.Text = "Failed to add product to quotation.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error adding product to quotation: " + ex.Message;
            }
        }

        protected void ddlSupplierSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSupplier = ddlSupplierSelect.SelectedValue;

            if (selectedSupplier != "0")
            {
                LoadProductsBySupplier(selectedSupplier);
                lblError.Text = string.Empty;
            }
            else
            {
                lblError.Text = "Please select a valid supplier.";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        private void LoadProductsBySupplier(string supplierName)
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
                    lblError.Text = "No products found for the selected supplier.";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
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
                var imgProduct = e.Row.FindControl("imgProduct") as Image;

                if (imgProduct != null)
                {
                    byte[] imageBytes = DataBinder.Eval(e.Row.DataItem, "ProductImage") as byte[];
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        string base64String = Convert.ToBase64String(imageBytes);
                        imgProduct.ImageUrl = "data:image/jpeg;base64," + base64String;
                    }
                    else
                    {
                        imgProduct.ImageUrl = "path/to/default/image.jpg"; 
                    }
                }
            }
        }
    }
}
