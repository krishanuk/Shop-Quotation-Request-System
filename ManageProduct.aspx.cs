using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayerTF;

namespace TechFix
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        localhostProductManage.WebService1 sms = new localhostProductManage.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateSupplierDropdown();
        }

        private void PopulateSupplierDropdown()
        {
            string userRole = Session["UserRole"] as string;
            string userShop = Session["UserShop"] as string;

            if (userRole == "Supplier")
            {
                ddlSupplier.Items.Clear();  // Clear existing items
                ddlSupplier.Items.Add(new ListItem(userShop, userShop));
                ddlSupplier.Enabled = false; // Disable dropdown if only one option
            }
            else
            {
                // If not a supplier, populate with all suppliers or from a service
                // Example:
                // DataTable suppliers = sms.GetAllSuppliers();
                // ddlSupplier.DataSource = suppliers;
                // ddlSupplier.DataTextField = "SupplierName";
                // ddlSupplier.DataValueField = "SupplierId";
                // ddlSupplier.DataBind();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = txtProductName.Text;
                string productPrice = txtProductPrice.Text;
                string productQuantity = txtProductQuantity.Text;
                string productDescription = txtProductDescription.Text;
                string category = ddlCategory.SelectedValue;
                string supplier = ddlSupplier.SelectedValue;
                byte[] productImage = null;

                if (fileProductImage.HasFile)
                {
                    productImage = fileProductImage.FileBytes;
                }

                if (sms.InsertProduct(productName, productPrice, productQuantity, productDescription, category, supplier, productImage) > 0)
                {
                    txtMessage.Text = "Product added successfully!";
                    txtMessage.CssClass = "success-message";
                }
                else
                {
                    txtMessage.Text = "Failed to add product.";
                    txtMessage.CssClass = "error-message";
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "An error occurred: " + ex.Message;
                txtMessage.CssClass = "error-message";
            }
        }



        protected void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                // Logic for finding a product by ID
                int productId = int.Parse(txtProductID.Text);
                string productName = txtProductName.Text;

                // Create an instance of the Products class and call FindProduct
                Products product = new Products();
                DataSet ds = product.FindProduct(productId,productName);

                // Check if the product exists
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    // Populate the form fields with the retrieved product details
                    txtProductName.Text = row["ProductName"].ToString();
                    txtProductPrice.Text = row["ProductPrice"].ToString();
                    txtProductQuantity.Text = row["ProductQuantity"].ToString();
                    txtProductDescription.Text = row["ProductDescription"].ToString();
                    ddlCategory.SelectedValue = row["Category"].ToString();
                    ddlSupplier.SelectedValue = row["Supplier"].ToString();
                    // You may need to handle the ProductImage separately if you want to display it
                    txtMessage.Text = "Product found!";
                    txtMessage.CssClass = "success-message";
                }
                else
                {
                    // Product not found
                    txtMessage.Text = "No product found with the given ID.";
                    txtMessage.CssClass = "error-message";
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the find operation
                txtMessage.Text = "An error occurred: " + ex.Message;
                txtMessage.CssClass = "error-message";
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Logic for updating a product
                int productId = int.Parse(txtProductID.Text);
                string productName = txtProductName.Text;
                string productPrice = txtProductPrice.Text;
                string productQuantity = txtProductQuantity.Text;
                string productDescription = txtProductDescription.Text;
                string category = ddlCategory.SelectedValue;
                string supplier = ddlSupplier.SelectedValue;
                byte[] productImage = null;

                // Check if an image is uploaded
                if (fileProductImage.HasFile)
                {
                    productImage = fileProductImage.FileBytes;
                }

                if (sms.UpdateProduct(productId, productName, productPrice, productQuantity, productDescription, category, supplier, productImage) > 0)
                {
                    txtMessage.Text = "Product Details Updated!";
                    txtMessage.CssClass = "success-message";
                }
                else
                {
                    txtMessage.Text = "Product Update Failed";
                    txtMessage.CssClass = "error-message";
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the find operation
                txtMessage.Text = "An error occurred: " + ex.Message;
                txtMessage.CssClass = "error-message";
            }

            // Update product in the database (Business Layer logic)
            // Example: Call UpdateProduct method from Products class
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                // Logic for deleting a product by ID
                int productId = int.Parse(txtProductID.Text);
                if (sms.DeleteProduct(productId) > 0)
                {
                    txtMessage.Text = "Product Details Deleted!";
                    txtMessage.CssClass = "success-message";
                }
                else
                {
                    txtMessage.Text = "Product Delete Failed";
                    txtMessage.CssClass = "error-message";
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the find operation
                txtMessage.Text = "An error occurred: " + ex.Message;
                txtMessage.CssClass = "error-message";
            }

            // Delete product from the database (Business Layer logic)
            // Example: Call DeleteProduct method from Products class
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text  = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
            txtProductDescription.Text = string.Empty;
            ddlCategory.SelectedValue = string.Empty;
         
            
        }

        protected void txtProductPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}