using System;
using System.Data;
using System.Web.UI;

namespace TechFix
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        QuotationApprovalService quotationService = new QuotationApprovalService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                lblMessage.Text = "";
                lblMessage.Visible = false;

                string supplierType = Session["UserShop"] as string;

                if (!string.IsNullOrEmpty(supplierType))
                {
                    
                    LoadApprovedQuotations(supplierType);
                }
                else
                {
                    lblMessage.Text = "Supplier type not found. Please log in again.";
                    lblMessage.Visible = true;
                }
            }
        }

        private void LoadApprovedQuotations(string supplierType)
        {
            try
            {
                
                DataSet dsApprovedQuotations = quotationService.GetApprovedQuotationsBySupplierType(supplierType);

                if (dsApprovedQuotations != null && dsApprovedQuotations.Tables.Count > 0 && dsApprovedQuotations.Tables[0].Rows.Count > 0)
                {
                    
                    gvApprovedQuotations.DataSource = dsApprovedQuotations;
                    gvApprovedQuotations.DataBind();
                    gvApprovedQuotations.Visible = true;
                }
                else
                {
                    
                    lblMessage.Text = "No approved quotations found for the supplier type.";
                    lblMessage.Visible = true;
                    gvApprovedQuotations.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
            }
        }
    }
}
