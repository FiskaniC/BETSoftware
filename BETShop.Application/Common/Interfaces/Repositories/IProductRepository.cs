using System.Collections.Generic;
using System.Threading.Tasks;
using BETShop.Domain.Models;

namespace BETShop.Application.Common.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IList<Products>> GetProducts();
        Task<Products> GetProduct(int id);
        Task<ProductsByFilter> GetProductByFilter(int skip);
    }
}
