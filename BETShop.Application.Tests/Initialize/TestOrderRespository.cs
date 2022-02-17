using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Domain.Models;

namespace BETShop.Application.Tests.Initialize
{
    internal class TestOrderRespository : IOrderRepository
    {
        public void CreateOrder(Order order)
        {
            return;
        }
    }
}