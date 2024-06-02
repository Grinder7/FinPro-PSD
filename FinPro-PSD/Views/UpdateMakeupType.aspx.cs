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
    public partial class UpdateMakeupType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserRole != "admin")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
                if (!Page.IsPostBack)
                {
                    Response<MakeupType> response = MakeupTypeController.GetMakeupTypeById(Convert.ToInt32(Request.QueryString["Id"]));
                    if (response.IsSuccess)
                    {
                        MakeupType makeupType = response.Payload;
                        MakeupTypeIdTbx.Text = makeupType.MakeupTypeID.ToString();
                        MakeupTypeNameTbx.Text = makeupType.MakeupTypeName;
                    }
                    else
                    {
                        Response.Write(response.Message);
                    }
                }
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeup.aspx");
        }

        protected void UpdateMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            string id = MakeupTypeIdTbx.Text;
            string name = MakeupTypeNameTbx.Text;

            Response<MakeupType> response = MakeupTypeController.UpdateMakeupType(id, name);

            if (response.IsSuccess)
            {
                Response.Redirect("~/Views/ManageMakeup.aspx");
            }
            MakeupTypeErrorLbl.Text = response.Message;
            MakeupTypeErrorLbl.Visible = true;
        }
    }
}