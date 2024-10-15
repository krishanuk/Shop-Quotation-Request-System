using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayerTF;

namespace TechFix
{
    public partial class Login : System.Web.UI.Page
    {
        UserManagementService sms = new UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = uusername.Text;
                string upassword = password.Text;

                
                DataTable userInfo = sms.LoginUser(username, upassword);

                if (userInfo != null && userInfo.Rows.Count > 0)
                {
                    
                    string id = userInfo.Rows[0]["UserID"].ToString();
                    string role = userInfo.Rows[0]["UserRole"].ToString();
                    string shop = userInfo.Rows[0]["UserShop"].ToString();
                    string userName = userInfo.Rows[0]["UserName"].ToString();

                    // Store user info in session
                    Session["UserID"] = id;
                    Session["Username"] = userName;
                    Session["UserRole"] = role;
                    Session["UserShop"] = shop;

                    
                    if (role == "Admin" || role == "Employee")
                    {
                        Response.Redirect("TechfixDashBoard.aspx");
                    }
                    else if (role == "Supplier")
                    {
                        Response.Redirect("SupplierDashboard.aspx");
                    }
                }
                else
                {
                 
                    txtMessage.Text = "Invalid login credentials.";
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}