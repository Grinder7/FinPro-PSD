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
    public partial class TransactionDetailAdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string idStr = Request.QueryString["ID"];
                if (int.TryParse(idStr, out int id))
                {
                    Response<List<TransactionDetail>> transaction = TransactionDetailController.GetTransactionDetailById(id);

                    if (transaction.IsSuccess)
                    {
                        TransactionDetailAdminGV.DataSource = transaction.Payload;
                        TransactionDetailAdminGV.DataBind();
                    }
                }
            }
        }
    }
}