using System.Threading.Tasks;
using BETShop.Domain.Models;

namespace BETShop.Application.Common.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
