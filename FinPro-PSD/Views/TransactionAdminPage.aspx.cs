using FinPro_PSD.Controllers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace FinPro_PSD.Views
{
    public partial class TransactionAdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response<List<TransactionHeader>> response = TransactionHeaderController.GetAllTransactionHeaders();

                if (response.IsSuccess)
                {
                    TransactionAdminGV.DataSource = response.Payload;
                    TransactionAdminGV.DataBind();
                }
            }

        }

        protected void TransactionAdminGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = TransactionAdminGV.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            Response<TransactionHeader> tran = TransactionHeaderController.GetTransactionHeaderById(id);

            if (tran.IsSuccess)
            {
                TransactionHeaderController.UpdateTransactionHeaderStatus(tran.Payload);
            
            }

            Response<List<TransactionHeader>> response = TransactionHeaderController.GetAllTransactionHeaders();
            if (response.IsSuccess)
            {
                TransactionAdminGV.DataSource = response.Payload;
                TransactionAdminGV.DataBind();
            }

            Response.Redirect("~/Views/TransactionAdminPage.aspx");

        }

        protected void TransactionAdminGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = TransactionAdminGV.SelectedRow;
            String id = row.Cells[0].Text.ToString();
            Response.Redirect("~/Views/TransactionDetailAdminPage.aspx?ID="+id);
        }
    }
}