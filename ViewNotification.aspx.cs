using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string userRole = Session["UserRole"] as string;
                string userShop = Session["UserShop"] as string;

                
                if (userRole == "Supplier" && !string.IsNullOrEmpty(userShop))
                {
                    LoadNotifications(userShop); 
                }
                else
                {
                    lblNoNotifications.Text = "You do not have access to view notifications.";
                    lblNoNotifications.Visible = true;
                }
            }
        }

        private void LoadNotifications(string supplierName)
        {
            try
            {
                WebService1 service = new WebService1();
                List<string> notifications = service.GetLowStockNotification(supplierName);

                if (notifications != null && notifications.Count > 0)
                {
                    
                    List<Notification> notificationList = new List<Notification>();
                    foreach (var message in notifications)
                    {
                        notificationList.Add(new Notification
                        {
                            NotificationMessage = message,
                            DateTime = DateTime.Now.ToString("g") 
                        });
                    }

                    RepeaterNotifications.DataSource = notificationList;
                    RepeaterNotifications.DataBind();
                }
                else
                {
                    lblNoNotifications.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblNoNotifications.Text = "Error loading notifications: " + ex.Message;
                lblNoNotifications.Visible = true;
            }
        }

        public class Notification
        {
            public string NotificationMessage { get; set; }
            public string DateTime { get; set; }
        }

    }
}