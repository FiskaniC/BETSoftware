using System.Collections.Generic;
using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Domain.Models;

namespace BETShop.Application.Tests.Initialize
{
    internal class TestProductRespository : IProductRepository
    {
        public async Task<Products> GetProduct(int id)
        {
            return new Products 
            { 
                Id = 1 
            };
        }

        public async Task<ProductsByFilter> GetProductByFilter(int skip)
        {
            return new ProductsByFilter();
        }

        public async Task<IList<Products>> GetProducts()
        {
            return new List<Products>();
        }
    }
}