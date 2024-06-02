using FinPro_PSD.Controllers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FinPro_PSD.Views
{
    public partial class UpdateMakeup : System.Web.UI.Page
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
                    if (int.TryParse(Request.QueryString["id"], out int id))
                    {
                        Response<Makeup> response3 = MakeupController.GetMakeupById(id);
                        if (response3.IsSuccess)
                        {
                            Makeup makeup = response3.Payload;
                            if (makeup != null)
                            {
                                NameTbx.Text = makeup.MakeupName;
                                PriceTbx.Text = makeup.MakeupPrice.ToString();
                                WeightTbx.Text = makeup.MakeupWeight.ToString();
                                TypeIDDdl.SelectedValue = makeup.MakeupTypeID.ToString();
                                BrandIDDdl.SelectedValue = makeup.MakeupBrandID.ToString();
                                ViewState["MakeupID"] = id;
                            }
                        }
                        else
                        {
                            ErrorLbl.Text = response.Message;
                            ErrorLbl.Visible = true;
                        }
                    }
                    else
                    {
                        ErrorLbl.Text = "Invalid ID.";
                        ErrorLbl.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["Id"];
                string name = NameTbx.Text;
                string price = PriceTbx.Text;
                string weight = WeightTbx.Text;
                string typeid = TypeIDDdl.SelectedValue;
                string brandid = BrandIDDdl.SelectedValue;

                Response<Makeup> response = MakeupController.Update(id, name, price, weight, typeid, brandid);
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