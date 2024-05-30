using FinPro_PSD.Controllers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro_PSD.Views
{
    public partial class LoginPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            if (Request.Cookies["user-cred"] != null)
            {
                int id = Convert.ToInt32(Request.Cookies["user-cred"].Value);
                Response<User> response = UserController.GetUserById(id);
                Session["user"] = response.Payload;
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTbx.Text;
            string password = PasswordTbx.Text;

            Response<User> response = UserController.Login(username, password);

            if (response.IsSuccess)
            {
                Session["user"] = response.Payload;
                if (RememberChk.Checked)
                {
                    CreateUserCredCookie(response.Payload.UserID);
                }

                Response.Redirect("~/Views/HomePage.aspx");
            }


            ErrorLbl.Text = response.Message;
            ErrorLbl.Visible = true;
        }
        protected void CreateUserCredCookie(int userId)
        {
            HttpCookie cookie = new HttpCookie("user-cred")
            {
                Value = userId.ToString(),
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Add(cookie);
        }
    }
}
