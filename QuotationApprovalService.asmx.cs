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
    /// Summary description for QuotationApprovalService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QuotationApprovalService : System.Web.Services.WebService
    {

        [WebMethod]
        public string SendQuotationForApproval(int quotationRequestID, string supplierType)
        {
            try
            {
                QuotationApproval quotationApproval = new QuotationApproval
                {
                    QuotationRequestID = quotationRequestID,
                    SupplierType = supplierType
                };

                int result = quotationApproval.SendQuotationForApprovalAndProducts();

                if (result > 0)
                {
                    return "Quotation sent for approval successfully.";
                }
                else
                {
                    return "Failed to send the quotation for approval.";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public DataSet GetApprovedQuotationsBySupplierType(string supplierType)
        {
            try
            {
                QuotationApproval quotationApproval = new QuotationApproval();

                DataSet ds = quotationApproval.GetApprovedQuotationsBySupplierType(supplierType);

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    throw new DataException("No approved quotations found for the supplier type.");
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving approved quotations for supplier type: " + ex.Message);
            }
        }

        [WebMethod]
        public DataSet GetAllApprovedQuotations()
        {
            try
            {
                QuotationApproval quotationApproval = new QuotationApproval();

                DataSet ds = quotationApproval.GetAllApprovedQuotations();

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    throw new DataException("No approved quotations found.");
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all approved quotations: " + ex.Message);
            }
        }


    }
}
