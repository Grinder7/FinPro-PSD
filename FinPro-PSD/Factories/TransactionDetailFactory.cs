using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Factories
{
    public class TransactionDetailFactory
    {

        public static TransactionDetail CreateTransactionDetail(int transactionDetailId, int transactionId, int makeupId, int quantity)
        {
            return new TransactionDetail
            {
                TransactionDetailID = transactionDetailId,
                TransactionID = transactionId,
                MakeupID = makeupId,
                Quantity = quantity,
            };
        }
    }
}