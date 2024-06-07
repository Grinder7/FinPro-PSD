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
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int userId = ((FinPro_PSD.Models.User)Session["user"]).UserID;
                Response<List<TransactionHeader>> response = TransactionHeaderController.GetTransactionHeaderByUserId(userId);

                if (response.IsSuccess)
                {
                    TransactionGV.DataSource = response.Payload;
                    TransactionGV.DataBind();
                }
            }
        }

        protected void TransactionGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = TransactionGV.SelectedRow;
            String id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/TransactionDetailPage.aspx?ID=" + id);
        }
    }
}