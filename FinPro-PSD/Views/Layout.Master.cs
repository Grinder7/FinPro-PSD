using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FinPro_PSD.Views
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        public LinkButton LogoutBtn { get { return LogoutLb; } }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LogoutLb_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            if (Request.Cookies["user-cred"] != null)
            {
                HttpCookie cookie = new HttpCookie("user-cred")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}