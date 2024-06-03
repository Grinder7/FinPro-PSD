using FinPro_PSD.Handlers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Controllers
{
    public class CartController
    {
        public static Response<List<Cart>> RemoveCartsById(List<int> cartIds)
        {
            List<string> errors = new List<string>();
            foreach (var cartId in cartIds)
            {
                CartIdValidate(cartId, errors);
            }
            if (errors.Count > 0)
            {
                return GenerateErrorResponse<List<Cart>>(errors);
            }
            return CartHandler.RemoveCartsById(cartIds);
        }

        public static Response<Cart> GetCartById(int cartId)
        {
            List<string> errors = new List<string>();
            int cId = CartIdValidate(cartId, errors);
            if (errors.Count > 0)
            {
                return GenerateErrorResponse<Cart>(errors);
            }
            return CartHandler.GetCartById(cId);
        }

        public static Response<Cart> InsertCart(int userId, int makeupId, int quantity)
        {
            List<string> errors = new List<string>();
            int uId = UserIdValidate(userId, errors);
            int mId = MakeupIdValidate(makeupId, errors);
            int qty = QuantityValidate(quantity, errors);
            if (errors.Count > 0)
            {
                return GenerateErrorResponse<Cart>(errors);
            }
            return CartHandler.InsertCart(uId, mId, qty);
        }

        public static Response<List<Cart>> GetCardByUserId(int userId)
        {
            List<string> errors = new List<string>();
            int uId = UserIdValidate(userId, errors);
            if (errors.Count > 0)
            {
                return GenerateErrorResponse<List<Cart>>(errors);
            }
            return CartHandler.GetCartByUserId(uId);
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

        private static int CartIdValidate(int cartId, List<string> errors)
        {
            if (cartId <= 0)
            {
                errors.Add("Cart Id must be greater than 0");
            }
            return cartId;
        }

        private static int MakeupIdValidate(int makeupId, List<string> errors)
        {
            if (makeupId <= 0)
            {
                errors.Add("Makeup Id must be greater than 0");
            }
            return makeupId;
        }

        private static int QuantityValidate(int qty, List<string> errors)
        {
            if (qty <= 0)
            {
                errors.Add("Quantity must be greater than 0");
            }
            return qty;
        }

        private static int UserIdValidate(int userId, List<string> errors)
        {
            if (userId <= 0)
            {
                errors.Add("User Id must be greater than 0");
            }
            return userId;
        }
    }
}