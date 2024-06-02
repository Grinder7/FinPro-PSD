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
    public partial class InsertMakeupType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTbx.Text;

                Response<MakeupType> response = MakeupTypeController.InsertMakeupType(name);
                if (response.IsSuccess)
                {
                    Response.Redirect("~/Views/ManageMakeup.aspx");
                }

                ErrorLbl.Text = response.Message;
                ErrorLbl.Visible = true;
            }
            catch (Exception error)
            {
                ErrorLbl.Text = error.Message;
                ErrorLbl.Visible = true;

            }

        }
        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeup.aspx");
        }
    }
}