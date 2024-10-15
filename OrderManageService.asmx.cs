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
    /// Summary description for OrderManageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderManageService : System.Web.Services.WebService
    {

        [WebMethod]
        public int InsertOrder(int userID, int productID, string productName, decimal productPrice, int productQuantity, string orderStatus, string supplier, string shippingAddress)
        {
            try
            {
                Orders order = new Orders
                {
                    UserID = userID,
                    ProductID = productID,
                    ProductName = productName,
                    ProductPrice = productPrice,
                    ProductQuantity = productQuantity,
                    TotalPrice = productPrice * productQuantity,
                    OrderStatus = orderStatus,
                    Supplier = supplier,
                    ShippingAddress = shippingAddress
                };

                int result = order.InsertOrder();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting order: " + ex.Message);
            }
        }

        [WebMethod]
        public DataSet GetProducts(string userRole, string userShop)
        {
            try
            {
                // Instantiate Orders and call GetAllProducts 
                Orders orders = new Orders();
                DataSet ds = orders.GetAllProducts(userRole, userShop);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    throw new DataException("No products found for the specified user role and shop.");
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving product list: " + ex.Message);
            }
        }

        [WebMethod]
        public string UpdateOrderStatus(int orderId, string newStatus)
        {
            try
            {
                Orders order = new Orders();
                int result = order.UpdateOrderStatus(orderId, newStatus);

                if (result > 0)
                {
                    return "Order status updated successfully.";
                }
                else
                {
                    return "Failed to update order status.";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
