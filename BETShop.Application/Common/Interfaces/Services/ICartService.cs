using System.Collections.Generic;
using BETShop.Domain.Models;

namespace BETShop.Application.Common.Interfaces.Services
{
    public interface ICartService
    {
        void UpdateCart(IList<CartProduct> cartItems);
        IList<CartProduct> GetCart();
    }
}
