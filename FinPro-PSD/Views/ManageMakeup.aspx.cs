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
            if (Session["user"] != null && ((User)Session["user"]).UserRole == "admin")
            {
                RenderMakeupGridView();
                RenderMakeupTypeGridView();
                RenderMakeupBrandGridView();
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
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
                RenderMakeupGridView();
            }

        }
        protected void GridView_RowEditingMakeupType(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(MakeupTypeGv.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("~/Views/UpdateMakeupType.aspx?Id=" + id);
        }

        protected void GridView_RowDeletingMakeupType(object sender, GridViewDeleteEventArgs e)
        {
            string id = MakeupTypeGv.DataKeys[e.RowIndex].Value.ToString();
            Response<MakeupType> deleteResponse = MakeupTypeController.RemoveMakeupType(id);
            if (deleteResponse.IsSuccess)
            {
                RenderMakeupGridView();
                RenderMakeupTypeGridView();
            }
            else
            {
                Response.Write(deleteResponse.Message);
            }
        }

        protected void GridView_RowEditingMakeupBrand(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(MakeupBrandGv.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("~/Views/UpdateMakeupBrand.aspx?Id=" + id);
        }

        protected void GridView_RowDeletingMakeupBrand(object sender, GridViewDeleteEventArgs e)
        {
            string id = MakeupBrandGv.DataKeys[e.RowIndex].Value.ToString();
            Response<MakeupBrand> deleteResponse = MakeupBrandController.RemoveMakeupBrandById(id);

            if (deleteResponse.IsSuccess)
            {
                RenderMakeupGridView();
                RenderMakeupBrandGridView();
            }
            else
            {
                Response.Write(deleteResponse.Message);
            }
        }

        private void RenderMakeupGridView()
        {
            Response<List<Makeup>> response = MakeupController.GetAllMakeups();
            if (response.IsSuccess)
            {
                MakeupGv.DataSource = response.Payload;
                MakeupGv.DataBind();
            }
        }

        private void RenderMakeupTypeGridView()
        {
            Response<List<MakeupType>> response = MakeupTypeController.GetAllMakeupTypes();
            if (response.IsSuccess)
            {
                MakeupTypeGv.DataSource = response.Payload;
                MakeupTypeGv.DataBind();
            }
        }

        private void RenderMakeupBrandGridView()
        {
            Response<List<MakeupBrand>> response = MakeupBrandController.GetAllMakeupBrands();
            if (response.IsSuccess)
            {
                MakeupBrandGv.DataSource = response.Payload;
                MakeupBrandGv.DataBind();
            }
        }
    }
}