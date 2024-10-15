using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayerTF;


namespace TechFix
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        // Service reference
        localhostQuotationManagement.QuotationManagementService sms = new localhostQuotationManagement.QuotationManagementService();
        localhostQuotationApprovalManage.QuotationApprovalService quot = new localhostQuotationApprovalManage.QuotationApprovalService();

        private decimal _subtotal = 0M; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
            }
        }

        protected void btnShowDetails_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true; 
            gvQuotationDetails.Visible = false; 

            
            string supplierType = ddlSupplierType.SelectedValue;

            if (!string.IsNullOrEmpty(supplierType))
            {
                LoadQuotationDetails(supplierType); 
            }
            else
            {
                lblLoading.Visible = false;
                lblMessage.Text = "Please select a Supplier Type.";
                lblMessage.Visible = true;
            }
        }

        private void LoadQuotationDetails(string supplierType)
        {
            try
            {
                
                QuotationRequest quotationRequest = new QuotationRequest
                {
                    SupplierType = supplierType
                };

                
                DataSet dsQuotationDetails = quotationRequest.GetQuotationDetailsWithProductNames();

                if (dsQuotationDetails != null && dsQuotationDetails.Tables.Count > 0 && dsQuotationDetails.Tables[0].Rows.Count > 0)
                {
                    _subtotal = 0M; 
                    gvQuotationDetails.DataSource = dsQuotationDetails;
                    gvQuotationDetails.DataBind();

                    foreach (DataRow row in dsQuotationDetails.Tables[0].Rows)
                    {
                        decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);
                        _subtotal += totalPrice;
                    }

                    lblSubtotal.Text = "Subtotal: " + _subtotal.ToString("C");

                    lblLoading.Visible = false; 
                    gvQuotationDetails.Visible = true; 
                }
                else
                {
                    lblLoading.Visible = false;
                    lblMessage.Text = "No quotation details found for the selected supplier.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblLoading.Visible = false;
                lblMessage.Text = $"Error loading quotation details: {ex.Message}";
                lblMessage.Visible = true;
            }
        }

        protected void gvQuotationDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal totalPrice = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalPrice"));
                _subtotal += totalPrice;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[8].Text = "Subtotal: " + _subtotal.ToString("C");
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;

                lblSubtotal.Text = "Subtotal: " + _subtotal.ToString("C");
            }
        }

        protected void gvQuotationDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteQuotation")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                int quotationRequestID = int.Parse(args[0]);
                string supplierType = args[1];

                try
                {
                    int result = sms.DeleteQuotation(quotationRequestID, supplierType);

                    if (result > 0)
                    {
                        lblMessage.Text = "Quotation deleted successfully.";
                        lblMessage.Visible = true;

                        LoadQuotationDetails(supplierType);
                    }
                    else
                    {
                        lblMessage.Text = "Failed to delete quotation.";
                        lblMessage.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"Error deleting quotation: {ex.Message}";
                    lblMessage.Visible = true;
                }
            }
        }

        protected void btnSendToApproval_Click(object sender, EventArgs e)
        {
            decimal subtotal = 0M; 

            try
            {
                
                string supplierType = ddlSupplierType.SelectedValue; 
                if (string.IsNullOrEmpty(supplierType))
                {
                    lblMessage.Text = "Please select a supplier type before sending to approval.";
                    lblMessage.Visible = true;
                    return;
                }

                
                if (gvQuotationDetails.Rows.Count == 0)
                {
                    lblMessage.Text = "No quotations to approve.";
                    lblMessage.Visible = true;
                    return;
                }

                
                foreach (GridViewRow row in gvQuotationDetails.Rows)
                {
                    if (gvQuotationDetails.DataKeys[row.RowIndex] != null)
                    {
                        int quotationRequestID = Convert.ToInt32(gvQuotationDetails.DataKeys[row.RowIndex].Value);

                        try
                        {
                            string result = quot.SendQuotationForApproval(quotationRequestID, supplierType);  

                            if (result == "Quotation sent for approval successfully.")
                            {
                                lblMessage.Text = "Quotations sent for approval.";
                                lblMessage.Visible = true;
                            }
                            else
                            {
                                lblMessage.Text = "Error sending quotation for approval: " + result;
                                lblMessage.Visible = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = "Error sending quotation for approval: " + ex.Message;
                            lblMessage.Visible = true;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Error: Could not retrieve QuotationRequestID for one or more rows.";
                        lblMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        protected void gvQuotationDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvQuotationDetails.SelectedRow != null)
            {
                
                GridViewRow selectedRow = gvQuotationDetails.SelectedRow;

                
                if (gvQuotationDetails.DataKeys[selectedRow.RowIndex] != null)
                {
                    int quotationRequestID = Convert.ToInt32(gvQuotationDetails.DataKeys[selectedRow.RowIndex].Value);
                    string supplierType = ddlSupplierType.SelectedValue; 

                    try
                    {
                        
                        int result = sms.DeleteQuotation(quotationRequestID, supplierType);

                        if (result > 0)
                        {
                            lblMessage.Text = "Quotation deleted successfully.";
                            lblMessage.Visible = true;

                            
                            LoadQuotationDetails(supplierType);
                        }
                        else
                        {
                            lblMessage.Text = "Failed to delete quotation.";
                            lblMessage.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = $"Error deleting quotation: {ex.Message}";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Error: Could not retrieve QuotationRequestID for the selected row.";
                    lblMessage.Visible = true;
                }
            }
        }

    }
}
