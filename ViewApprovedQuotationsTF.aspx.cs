using System;
using System.Data;
using System.Web.UI;

namespace TechFix
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        
        QuotationApprovalService quotationService = new QuotationApprovalService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                lblMessage.Text = "";
                lblMessage.Visible = false;

                
                LoadApprovedQuotations();
            }
        }

        private void LoadApprovedQuotations()
        {
            try
            {
                
                DataSet dsApprovedQuotations = quotationService.GetAllApprovedQuotations();

                if (dsApprovedQuotations != null && dsApprovedQuotations.Tables.Count > 0 && dsApprovedQuotations.Tables[0].Rows.Count > 0)
                {
                    
                    gvApprovedQuotations.DataSource = dsApprovedQuotations;
                    gvApprovedQuotations.DataBind();
                    gvApprovedQuotations.Visible = true;
                }
                else
                {
                    
                    lblMessage.Text = "No approved quotations found.";
                    lblMessage.Visible = true;
                    gvApprovedQuotations.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
                gvApprovedQuotations.Visible = false;
            }
        }
    }
}
