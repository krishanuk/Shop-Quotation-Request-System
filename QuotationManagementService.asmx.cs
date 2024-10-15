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
    /// Summary description for QuotationManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QuotationManagementService : System.Web.Services.WebService
    {

        [WebMethod]
        public int AddQuotation(int requestedByUserID, string supplierType, int productID,
            int quantity, decimal quotedPrice)
        {
            try
            {
                QuotationRequest quotationRequest = new QuotationRequest
                {
                    RequestedByUserID = requestedByUserID,
                    SupplierType = supplierType,
                    ProductID = productID,
                    Quantity = quantity,
                    QuotedPrice = quotedPrice
                };

                return quotationRequest.AddQuotation();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding quotation request: " + ex.Message);
            }
        }

        [WebMethod]
        public DataSet GetQuotationDetailsWithProductNames(string supplierType)
        {
            try
            {
                if (string.IsNullOrEmpty(supplierType) || (supplierType != "A" && supplierType != "B"))
                {
                    throw new ArgumentException("Invalid Supplier Type. Must be 'A' or 'B'.");
                }

               
                QuotationRequest quotationRequest = new QuotationRequest
                {
                    SupplierType = supplierType
                };

                
                DataSet ds = quotationRequest.GetQuotationDetailsWithProductNames();

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    throw new DataException("No data found for the selected Supplier Type.");
                }

                return ds;
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Input Error: " + ex.Message);
            }
            catch (DataException ex)
            {
                throw new Exception("Data Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving quotation details with product names: " + ex.Message);
            }
        }

        [WebMethod]
        public int DeleteQuotation(int quotationRequestID, string supplierType)
        {
            try
            {
                if (string.IsNullOrEmpty(supplierType) || (supplierType != "A" && supplierType != "B"))
                {
                    throw new ArgumentException("Invalid Supplier Type. Must be 'A' or 'B'.");
                }

                if (quotationRequestID <= 0)
                {
                    throw new ArgumentException("Invalid Quotation Request ID.");
                }

                QuotationRequest quotationRequest = new QuotationRequest();

                return quotationRequest.DeleteQuotation(quotationRequestID, supplierType);
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Input Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting quotation request: " + ex.Message);
            }
        }


        [WebMethod]
        public int DeleteAllQuotationsForSupplier(string supplierType)
        {
            try
            {
                if (string.IsNullOrEmpty(supplierType) || (supplierType != "A" && supplierType != "B"))
                {
                    throw new ArgumentException("Invalid Supplier Type. Must be 'A' or 'B'.");
                }

                QuotationRequest quotationRequest = new QuotationRequest();

                return quotationRequest.DeleteAllQuotationsForSupplierType(supplierType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting quotations for supplier type {supplierType}: {ex.Message}");
            }
        }

    }

}
