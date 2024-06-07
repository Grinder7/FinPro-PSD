using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class TransactionRepository
    {
        public static List<TransactionHeader> GetTransactionHeaders()
        {
            Database1Entities db = new Database1Entities();
            return db.TransactionHeaders.ToList();
        }
    }
}