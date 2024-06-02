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
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            if (!IsPostBack)
            {

                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    Response<Makeup> response = MakeupController.GetMakeupById(id);
                    if (response.IsSuccess)
                    {
                        Makeup makeup = response.Payload;
                        if (makeup != null)
                        {
                            NameTbx.Text = makeup.MakeupName;
                            PriceTbx.Text = makeup.MakeupPrice.ToString();
                            WeightTbx.Text = makeup.MakeupWeight.ToString();
                            TypeIDTbx.Text = makeup.MakeupTypeID.ToString();
                            BrandIDTbx.Text = makeup.MakeupBrandID.ToString();
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

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["Id"];
                string name = NameTbx.Text;
                string price = PriceTbx.Text;
                string weight = WeightTbx.Text;
                string typeid = TypeIDTbx.Text;
                string brandid = BrandIDTbx.Text;

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