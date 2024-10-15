using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class UserManage : System.Web.UI.Page
    {
        localhostUserManageSR.UserManagementService sms = new localhostUserManageSR.UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = uusername.Text;
                string upassword = password.Text;
                string uemail = email.Text;
                string urole = role.Text;
                string ushop = shop.Text;

                if (sms.insertUser(username, upassword, uemail, urole, ushop) > 0)
                {
                    txtMessage.Text = "User Record Inserted";
                }
            }
            catch (Exception ex)
            {
                {
                    txtMessage.Text = "Error " + ex.Message;
                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(uuserid.Text);
                string username = uusername.Text;
                string upassword = password.Text;
                string uemail = email.Text;
                string urole = role.Text;
                string ushop = shop.Text;

                if(sms.updateUser(userid,username,upassword,uemail,urole,ushop) > 0)
                {
                    txtMessage.Text = "User Record Updated";
                }
            }
            catch(Exception ex)
            {
                txtMessage.Text = "Error " + ex.Message;
            }
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(uuserid.Text);
                DataSet ds = sms.finduser(userid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    uusername.Text = ds.Tables[0].Rows[0][1].ToString();
                    password.Text = ds.Tables[0].Rows[0][2].ToString();
                    email.Text = ds.Tables[0].Rows[0][3].ToString();
                    role.Text = ds.Tables[0].Rows[0][4].ToString();
                    shop.Text = ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    txtMessage.Text = "User Record Not Found";
                }


            }
            catch 
            {

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(uuserid.Text);
                if(sms.deleteUser(userid) > 0)
                {
                    txtMessage.Text = "User Record Deleted";

                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Error " + ex.Message;
            }
        }
    }
}