using System.Collections.Generic;
using System.Linq;

namespace BETShop.Domain.Models
{
    public class Cart
    {
        public Cart(IList<CartProduct> cartProducts)
        {
            CartProducts = cartProducts;
            Total = cartProducts.Sum(item => item.Product.Price * item.Quantity);
        }

        public IList<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        public decimal Total { get; private set; }
    }
}
