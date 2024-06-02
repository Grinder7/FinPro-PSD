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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];

                if (user.UserRole == "admin")
                {
                    Response<List<User>> response = UserController.GetAllUsers();
                    if (response.IsSuccess)
                    {
                        UserDataGv.DataSource = response.Payload;
                        UserDataGv.DataBind();
                    }
                }
            }
        }
    }
}