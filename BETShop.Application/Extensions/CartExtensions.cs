using System.Collections.Generic;
using BETShop.Domain.Models;

namespace BETShop.Application.Extensions
{
    public static class CartExtensions
    {
        public static int ProductIndexInCart(this IList<CartProduct> cartProducts, int id)
        {
            foreach (var item in cartProducts)
            {
                if (item.Product.Id == id)
                {
                    return cartProducts.IndexOf(item);
                }
            }
            return -1;
        }
    }
}
