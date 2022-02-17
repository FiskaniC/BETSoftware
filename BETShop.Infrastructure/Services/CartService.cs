using System.Collections.Generic;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Domain.Models;

namespace BETShop.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly string CART = "cart";
        private readonly ISessionService _sessionService;
        public CartService(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public void UpdateCart(IList<CartProduct> cartItems)
        {
            _sessionService.SetObjectAsJson(CART, cartItems);
        }

        public IList<CartProduct> GetCart()
        {
            return _sessionService.GetObjectFromJson<IList<CartProduct>>(CART);
        }

        public void RemoveFromCart(IList<CartProduct> cartItems)
        {
            _sessionService.SetObjectAsJson(CART, cartItems);
        }
    }
}
