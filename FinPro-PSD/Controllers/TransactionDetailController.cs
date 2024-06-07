using FinPro_PSD.Handlers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Controllers
{
    public class TransactionDetailController
    {
        public static Response<List<TransactionDetail>> GetTransactionDetailById(int id)
        {
            return TransactionDetailHandler.GetTransactionDetailById(id);
        }
    }
}