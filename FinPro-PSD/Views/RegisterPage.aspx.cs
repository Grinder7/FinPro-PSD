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
    public partial class RegisterPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            if (Request.Cookies["user-cred"] != null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTbx.Text;
            string email = EmailTbx.Text;
            DateTime dob = DateTime.Parse(DOBCalendar.Text);
            string gender = GenderRbl.SelectedValue;
            string password = PasswordTbx.Text;
            string confirmPassword = ConfirmPasswordTbx.Text;

            Response<User> response = UserController.Register(username, email, dob, gender, password, confirmPassword);
            if (response.IsSuccess)
            {
                Session["user"] = response.Payload;
                Response.Redirect("~/Views/HomePage.aspx");
            }

            ErrorLbl.Text = response.Message;
            ErrorLbl.Visible = true;
        }
    }
}