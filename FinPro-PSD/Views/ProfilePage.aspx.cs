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
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                UsernameTbx.Text = user.Username;
                EmailTbx.Text = user.UserEmail;
                DOBCalendar.SelectedDate = user.UserDOB;
                GenderRbl.SelectedValue = user.UserGender;
                RoleTbx.Text = user.UserRole;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int userId = ((User)Session["user"]).UserID;
            string username = UsernameTbx.Text;
            string email = EmailTbx.Text;
            string gender = GenderRbl.SelectedValue;
            DateTime dob = DOBCalendar.SelectedDate;

            Response<User> response = UserController.UpdateUserData(userId, username, email, dob, gender);
            if (response.IsSuccess)
            {
                Response.Write("<script>alert(" + response.Message + ");</script>");
                Session["user"] = UserController.GetUserById(userId).Payload;
            }
            else
            {
                ErrorLbl.Visible = true;
                ErrorLbl.Text = response.Message;
            }
        }

        protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
        {
            int userId = ((User)Session["user"]).UserID;
            string oldPassword = OldPasswordTbx.Text;
            string newPassword = NewPasswordTbx.Text;
            Response<User> response = UserController.UpdateUserPassword(userId, oldPassword, newPassword);
            if (response.IsSuccess)
            {
                Response.Write("<script>alert(" + response.Message + ");</script>");
                Session["user"] = null;
                if (Request.Cookies["user-cred"] != null)
                {
                    HttpCookie cookie = new HttpCookie("user-cred")
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                PasswordErrorLbl.Visible = true;
                PasswordErrorLbl.Text = response.Message;
            }
        }
    }
}