using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class SuplierMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Abandon();  
            
            Response.Cookies[".ASPXAUTH"].Expires = DateTime.Now.AddDays(-1);

            
            Response.Redirect("Login.aspx");
        }
    }
}