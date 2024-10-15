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
    /// Summary description for UserManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserManagementService : System.Web.Services.WebService
    {

        [WebMethod]
        public int insertUser(string username, string upassword, string uemail, string urole, string ushop)
        {
            try
            {
                Users user = new Users();
                user.UserUsername = username;
                user.UserPassword = upassword;
                user.UserEmail = uemail;
                user.UserRole = urole;
                user.UserShop = ushop;
                return user.insert();
            }   
            catch 
            {
                throw;
            }
        }

        [WebMethod]
        public int updateUser(int userid, string username, string upassword, string uemail, string urole, string ushop)
        {
            try
            {
                Users user = new Users();
                user.UserID = userid;
                user.UserUsername = username;
                user.UserPassword = upassword;
                user.UserEmail = uemail;
                user.UserRole = urole;
                user.UserShop = ushop;
                return user.update();
            }
            catch 
            {
                throw;
            }
        }

        [WebMethod]
        public int deleteUser(int userid)
        {
            try
            {
                Users user = new Users();
                user.UserID = userid;
                return user.delete();
            }
            catch 
            {
                throw;
            }
            
        }

        [WebMethod]
        public DataSet finduser(int userid) 
        {
            try
            {
                Users user = new Users();
                user.UserID = userid;
                return user.find();
            }
            catch 
            {
                throw;
            }
        }
        [WebMethod]
        public DataTable LoginUser(string username, string password)
        {
            try
            {
                Users user = new Users();
                return user.login(username, password);  
            }
            catch
            {
                throw;
            }
        }



    }
}
