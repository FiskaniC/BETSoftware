using System.Collections.Generic;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Domain.Models;

namespace BETShop.Application.Tests.Initialize
{
    internal class TestCartService : ICartService
    {
        public IList<CartProduct> GetCart()
        {
            return new List<CartProduct>
            {
                new CartProduct
                {
                    Product = new Products 
                    { 
                        Id = 1 
                    }
                }
            };
        }

        public void UpdateCart(IList<CartProduct> cartItems)
        {
            return;
        }
    }
}