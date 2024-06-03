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
    public class CartHandler
    {

        public static int GenerateId()
        {
            Cart cart = CartRepository.GetLastCart();
            if (cart == null)
            {
                return 1;
            }
            return cart.CartID + 1;
        }

        public static Response<List<Cart>> RemoveCartsById(List<int> cartIds)
        {
            string errorMessage = "Failed to remove cart: ";
            foreach (int cartId in cartIds)
            {
                if (CartRepository.RemoveCartById(cartId) == 0)
                {
                    errorMessage += cartId + ", ";
                }
            }
            if (errorMessage != "Failed to remove cart: ")
            {
                return new Response<List<Cart>>
                {
                    IsSuccess = false,
                    Message = errorMessage.Substring(0,errorMessage.Length - 2),
                    Payload = null
                };
            }
            return new Response<List<Cart>>
            {
                IsSuccess = true,
                Message = "All Carts removed",
                Payload = null
            };
        }

        public static Response<Cart> InsertCart(int userId, int makeupId, int quantity)
        {
            Cart cart = CartFactory.CreateCart(GenerateId(), userId, makeupId, quantity);
            if (CartRepository.InsertCart(cart) == 0)
            {
                return new Response<Cart>
                {
                    IsSuccess = false,
                    Message = "Failed to insert cart",
                    Payload = null
                };
            }
            return new Response<Cart>
            {
                IsSuccess = true,
                Message = "Cart inserted",
                Payload = cart
            };
        }
        public static Response<Cart> GetCartById(int id)
        {
            Cart cart = CartRepository.GetCartById(id);
            if (cart == null)
            {
                return new Response<Cart>
                {
                    IsSuccess = false,
                    Message = "Cart not found",
                    Payload = null
                };
            }
            return new Response<Cart>
            {
                IsSuccess = true,
                Message = "Cart found",
                Payload = cart
            };
        }

        public static Response<List<Cart>> GetCartByUserId(int userId)
        {
            List<Cart> carts = CartRepository.GetCartByUserId(userId);
            if (carts.Count == 0)
            {
                return new Response<List<Cart>>
                {
                    IsSuccess = false,
                    Message = "Cart not found",
                    Payload = null
                };
            }
            return new Response<List<Cart>>
            {
                IsSuccess = true,
                Message = "Cart found",
                Payload = carts
            };
        }
    }
}