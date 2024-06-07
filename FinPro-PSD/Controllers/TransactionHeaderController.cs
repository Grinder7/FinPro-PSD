using FinPro_PSD.Handlers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Controllers
{
    public class TransactionHeaderController
    {

        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            return TransactionHeaderHandler.GetAllTransactionHeaders();
        }

        public static Response<List<TransactionHeader>> GetTransactionHeaderByUserId(int id)
        {
            return TransactionHeaderHandler.GetTransactionHeaderByUserId(id);

        }

        public static Response<TransactionHeader> GetTransactionHeaderById(int id)
        {
            return TransactionHeaderHandler.GetTransactionHeaderById(id);
        }

        public static Response<TransactionHeader> UpdateTransactionHeaderStatus(TransactionHeader transaction)
        {
            return TransactionHeaderHandler.UpdateTransactionHeaderStatus(transaction);
        }


        public static Response<TransactionHeader> CheckoutCart(List<Cart> cartList)
        {
            List<string> errors = new List<string>();
            List<Cart> carts = CartListValidate(cartList, errors);
            if (errors.Count > 0)
            {
                return GenerateErrorResponse<TransactionHeader>(errors);
            }
            return TransactionHeaderHandler.CheckoutCart(carts);
        }

        private static Response<T> GenerateErrorResponse<T>(List<string> errors)
        {
            string message = "";
            foreach (var error in errors)
            {
                message += error + "|";
            }
            return new Response<T>
            {
                Message = message,
                IsSuccess = false,
                Payload = default
            };
        }

        private static List<Cart> CartListValidate(List<Cart> cartList, List<string> errors)
        {
            if (cartList == null)
            {
                errors.Add("Cart is empty");
            }
            else if (cartList.Count == 0)
            {
                errors.Add("Cart is empty");
            }
            return cartList;
        }

        private static int TransactionIdValidate(int transactionId, List<string> errors)
        {
            try
            {
                if (transactionId <= 0)
                {
                    errors.Add("Transaction Id must be greater than 0");
                }
                return transactionId;
            }
            catch (Exception e)
            {
                errors.Add(e.Message);
            }
            return 0;
        }

        private static int UserIdValidate(int userId, List<string> errors)
        {
            if (userId <= 0)
            {
                errors.Add("User Id must be greater than 0");
            }
            return userId;
        }

        private static DateTime TransactionDateValidate(DateTime transactionDate, List<string> errors)
        {
            if (transactionDate == null)
            {
                errors.Add("Transaction Date is required");
            }
            return transactionDate;
        }

        private static string TransactionStatusValidate(string transactionStatus, List<string> errors)
        {
            if (transactionStatus.Length == 0)
            {
                errors.Add("Transaction Status is required");
            }
            else if (transactionStatus != "unhandled" && transactionStatus != "success" && transactionStatus != "failed")
            {
                errors.Add("Transaction Status must be unhandled, success, or failed");
            }
            return transactionStatus;
        }
    }
}