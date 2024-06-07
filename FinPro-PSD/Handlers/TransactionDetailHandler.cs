using FinPro_PSD.Factories;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using FinPro_PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Handlers
{
    public class TransactionDetailHandler
    {
        public static Response<TransactionDetail> InsertTransactionDetail(int transactionID, int makeupId, int quantity)
        {
            TransactionDetail transactionDetail = TransactionDetailFactory.CreateTransactionDetail(GenerateID(), transactionID, makeupId, quantity);
            if (TransactionDetailRepository.InsertTransactionDetail(transactionDetail) == 0)
            {
                return new Response<TransactionDetail>
                {
                    Message = "Failed to insert transaction detail",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<TransactionDetail>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = transactionDetail
            };
        }

        public static Response<List<TransactionDetail>> GetTransactionDetailById(int id)
        {
            List<TransactionDetail> transactionDetail = TransactionDetailRepository.GetTransactionDetailById(id);
            if (transactionDetail != null)
            {
                return new Response<List<TransactionDetail>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transactionDetail
                };
            }
            return new Response<List<TransactionDetail>>
            {
                Message = "no transaction detail",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<TransactionDetail> DeleteTransactionDetails(int transactionId)
        {
            if (TransactionDetailRepository.DeleteTransactionDetails(transactionId) == 0)
            {
                return new Response<TransactionDetail>
                {
                    Message = "Failed to delete transaction details",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<TransactionDetail>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = null
            };
        }

        private static int GenerateID()
        {
            TransactionDetail lastTransactionDetail = TransactionDetailRepository.GetLastTransactionDetail();
            if (lastTransactionDetail == null)
            {
                return 1;
            }
            return lastTransactionDetail.TransactionDetailID + 1;
        }
    }
}