using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(int transactionId, int userId, DateTime transactionDate, string status)
        {
            return new TransactionHeader
            {
                TransactionID = transactionId,
                UserID = userId,
                TransactionDate = transactionDate,
                Status = status
            };
        }
    }
}