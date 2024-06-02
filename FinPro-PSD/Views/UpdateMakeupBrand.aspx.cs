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
    public partial class UpdateMakeupBrand : System.Web.UI.Page
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
                    Response<MakeupBrand> response = MakeupBrandController.GetMakeupBrandById(Convert.ToInt32(Request.QueryString["Id"]));
                    if (response.IsSuccess)
                    {
                        MakeupBrand makeupBrand = response.Payload;
                        MakeupBrandIdTbx.Text = makeupBrand.MakeupBrandID.ToString();
                        MakeupBrandNameTbx.Text = makeupBrand.MakeupBrandName;
                        MakeupBrandRatingTbx.Text = makeupBrand.MakeupBrandRating.ToString();
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

        protected void UpdateMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            string id = MakeupBrandIdTbx.Text;
            string name = MakeupBrandNameTbx.Text;
            string rating = MakeupBrandRatingTbx.Text;

            Response<MakeupBrand> response = MakeupBrandController.UpdateMakeupBrand(id, name, rating);

            if (response.IsSuccess)
            {
                Response.Redirect("~/Views/ManageMakeup.aspx");
            }
            MakeupBrandErrorLbl.Text = response.Message;
            MakeupBrandErrorLbl.Visible = true;
        }
    }
}