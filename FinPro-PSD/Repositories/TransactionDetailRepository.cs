using FinPro_PSD.Handlers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class TransactionDetailRepository
    {
        private static readonly Database1Entities db = new Database1Entities();

        

        public static int InsertTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            return db.SaveChanges();
        }

        public static List<TransactionDetail> GetTransactionDetailByTransactionId(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
        }

        public static List<TransactionDetail> GetTransactionDetailById(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
        }

        public static TransactionDetail GetLastTransactionDetail()
        {
            return db.TransactionDetails.ToList().LastOrDefault();
        }

        public static TransactionDetail UpdateTransactionDetail(TransactionDetail transactionDetail)
        {
            TransactionDetail updatedTransactionDetail = db.TransactionDetails.Find(transactionDetail.TransactionID);
            updatedTransactionDetail.TransactionID = transactionDetail.TransactionID;
            updatedTransactionDetail.MakeupID = transactionDetail.MakeupID;
            updatedTransactionDetail.Quantity = transactionDetail.Quantity;
            db.SaveChanges();
            return transactionDetail;
        }

        public static int DeleteTransactionDetails(int transactionId)
        {
            List<TransactionDetail> transactionDetails = db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
            foreach (TransactionDetail transactionDetail in transactionDetails)
            {
                db.TransactionDetails.Remove(transactionDetail);
            }
            return db.SaveChanges();
        }

    }
}