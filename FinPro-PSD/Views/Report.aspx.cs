using FinPro_PSD.Dataset;
using FinPro_PSD.Handlers;
using FinPro_PSD.Models;
using FinPro_PSD.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro_PSD.Views
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = getData(TransactionHandler.GetTransactionHeaders());
            report.SetDataSource(data);
        }

        private DataSet1 getData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            var headertable = data.TransactionHeaders;
            var detailtable = data.TransactionDetails;
            foreach ( TransactionHeader t in transactions ) 
            { 
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["Status"] = t.Status;
                headertable.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailtable.NewRow();
                    drow["TransactionDetailID"] = d.TransactionDetailID;
                    drow["TransactionID"] = d.TransactionID;
                    drow["MakeupID"] = d.MakeupID;
                    drow["Quantity"] = d.Quantity;
                    detailtable.Rows.Add(drow);
                }
            }
            return data;
        }
       
    }
}