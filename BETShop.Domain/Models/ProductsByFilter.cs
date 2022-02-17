using System.Collections.Generic;

namespace BETShop.Domain.Models
{
    public class ProductsByFilter
    {
        public IList<Products> Products { get; set; }
        public int Pages { get; set; }
    }
}
