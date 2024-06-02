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
    public partial class InsertMakeup : System.Web.UI.Page
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
                    Response<List<MakeupType>> response = MakeupTypeController.GetAllMakeupTypes();
                    if (response.IsSuccess)
                    {
                        TypeIDDdl.DataSource = response.Payload;
                        TypeIDDdl.DataValueField = "MakeupTypeID";
                        TypeIDDdl.DataTextField = "MakeupTypeName";
                        TypeIDDdl.DataBind();
                    }
                    Response<List<MakeupBrand>> response2 = MakeupBrandController.GetAllMakeupBrands();
                    if (response2.IsSuccess)
                    {
                        BrandIDDdl.DataSource = response2.Payload;
                        BrandIDDdl.DataValueField = "MakeupBrandID";
                        BrandIDDdl.DataTextField = "MakeupBrandName";
                        BrandIDDdl.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTbx.Text;
                string price = PriceTbx.Text;
                string weight = WeightTbx.Text;
                string typeid = TypeIDDdl.SelectedValue;
                string brandid = BrandIDDdl.SelectedValue;

                Response<Makeup> response = MakeupController.InsertMakeup(name, price, weight, typeid, brandid);
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