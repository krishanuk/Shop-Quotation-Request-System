using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLayerTF;

namespace TechFix
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public int InsertProduct(string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, byte[] productImage)
        {
            try
            {
                Products product = new Products
                {
                    ProductName = productName,
                    ProductPrice = productPrice,
                    ProductQuantity = productQuantity,
                    ProductDescription = productDescription,
                    Category = category,
                    Supplier = supplier,
                    ProductImage = productImage
                };
                return product.Insert();
            }
            catch
            {
                throw;
            }
        }

        [WebMethod]
        public int UpdateProduct(int productID, string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, byte[] productImage)
        {
            try
            {
                Products product = new Products
                {
                    ProductID = productID,
                    ProductName = productName,
                    ProductPrice = productPrice,
                    ProductQuantity = productQuantity,
                    ProductDescription = productDescription,
                    Category = category,
                    Supplier = supplier,
                    ProductImage = productImage
                };
                return product.Update();
            }
            catch
            {
                throw;
            }
        }

        [WebMethod]
        public int DeleteProduct(int productID)
        {
            try
            {
                Products product = new Products
                {
                    ProductID = productID
                };
                return product.Delete();
            }
            catch
            {
                throw;
            }
        }
        [WebMethod]
        public DataSet FindProduct(int productID, string productName)
        {
            try
            {
                Products product = new Products();
                return product.FindProduct(productID, productName); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding product: " + ex.Message);
            }
        }

        [WebMethod]
        public DataSet GetAllProducts()
        {
            try
            {
                Products productBusiness = new Products();
                return productBusiness.GetAllProducts(); 
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error fetching products: " + ex.Message);
            }
        }

        [WebMethod]
        public DataSet GetProductsBySupplier(string supplierName)
        {
            try
            {
                Products productBusiness = new Products();
                return productBusiness.GetProductsBySupplier(supplierName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching products by supplier: " + ex.Message);
            }
        }

        [WebMethod]
        public List<string> GetLowStockNotification(string supplierName)
        {
            try
            {
                Products productBusiness = new Products();
                return productBusiness.CheckProductQuantity(supplierName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching low stock notifications: " + ex.Message);
            }
        }

    }
}
