using System;

namespace BETShop.Domain.Models
{
    public class Order
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public Cart Cart { get; set; }
    }
}
