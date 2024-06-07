using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class TransactionHeaderRepository
    {
        private static readonly Database1Entities db = new Database1Entities();

        public static TransactionHeader GetLastTransactionHeader()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }

        public static int InsertTransactionHeader(TransactionHeader transactionHeader)
        {
            db.TransactionHeaders.Add(transactionHeader);
            return db.SaveChanges();
        }

        public static TransactionHeader GetTransactionHeaderById(int id)
        {
            return db.TransactionHeaders.Find(id);
        }

        public static List<TransactionHeader> GetTransactionHeaderByUserId(int userId)
        {
            return db.TransactionHeaders.Where(x => x.UserID == userId).ToList();
        }

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static TransactionHeader UpdateTransactionHeader(TransactionHeader transactionHeader)
        {
            TransactionHeader updatedTransactionHeader = db.TransactionHeaders.Find(transactionHeader.TransactionID);
            updatedTransactionHeader.UserID = transactionHeader.UserID;
            updatedTransactionHeader.TransactionDate = transactionHeader.TransactionDate;
            updatedTransactionHeader.Status = transactionHeader.Status;
            db.SaveChanges();
            return transactionHeader;
        }

        public static TransactionHeader UpdateTransactionHeaderStatus(TransactionHeader transaction)
        {
            TransactionHeader updatedTransactionHeader = db.TransactionHeaders.Find(transaction.TransactionID);
            if (updatedTransactionHeader.Status == "unhandled")
            {
                updatedTransactionHeader.Status = "handled";
            }
            else
            {
                updatedTransactionHeader.Status = "unhandled";
            }
            db.SaveChanges();
            return transaction;

        }

        public static int DeleteTransactionHeader(int id)
        {
            TransactionHeader deletedTransactionHeader = db.TransactionHeaders.Find(id);
            if (deletedTransactionHeader != null)
            {
                db.TransactionHeaders.Remove(deletedTransactionHeader);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}