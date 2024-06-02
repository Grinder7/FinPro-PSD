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
    public partial class ManageMakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                if (user.UserRole == "admin")
                {
                    Response<List<Makeup>> responseMakeup = MakeupController.GetAllMakeups();
                    Response<List<MakeupType>> responseMakeupType = MakeupController.GetAllMakeupTypes();
                    Response<List<MakeupBrand>> responseMakeupBrand = MakeupController.GetAllMakeupBrands();

                    if (responseMakeup.IsSuccess)
                    {
                        MakeupGv.DataSource = responseMakeup.Payload;
                        MakeupGv.DataBind();
                    }
                    if (responseMakeupType.IsSuccess)
                    {
                        MakeupTypeGv.DataSource = responseMakeupType.Payload;
                        MakeupTypeGv.DataBind();
                    }
                    if (responseMakeupBrand.IsSuccess)
                    {
                        MakeupBrandGv.DataSource = responseMakeupBrand.Payload;
                        MakeupBrandGv.DataBind();
                    }
                }
            }
        }

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeup.aspx");
        }

        protected void InsertMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupType.aspx");
        }

        protected void InsertMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrand.aspx");
        }
        protected void GridView_RowEditingMakeup(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(MakeupGv.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("~/Views/UpdateMakeup.aspx?Id=" + id);
        }

        protected void GridView_RowDeletingMakeup(object sender, GridViewDeleteEventArgs e)
        {

            int id = Convert.ToInt32(MakeupGv.DataKeys[e.RowIndex].Value);

            Response<Makeup> deleteResponse = MakeupController.DeleteMakeup(id);

            if (deleteResponse.IsSuccess)
            {
                Response<List<Makeup>> response = MakeupController.GetAllMakeups();
                if (response.IsSuccess)
                {
                    MakeupGv.DataSource = response.Payload;
                    MakeupGv.DataBind();
                }
            }

        }
        protected void GridView_RowEditingMakeupType(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void GridView_RowDeletingMakeupType(object sender, GridViewDeleteEventArgs e)
        {


        }

        protected void GridView_RowEditingMakeupBrand(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView_RowDeletingMakeupBrand(object sender, GridViewDeleteEventArgs e)
        {


        }
    }
}