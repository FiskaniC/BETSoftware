using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Domain.Models;
using BETShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BETShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly int TAKE = 4;
        private readonly BETShopContext _context;

        public ProductRepository(BETShopContext context)
        {
            _context = context;
        }

        public async Task<Products> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IList<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductsByFilter> GetProductByFilter(int skip)
        {
            var products = await GetProducts();
            return new ProductsByFilter
            {
                Products = products.Skip(skip*TAKE).Take(TAKE).ToList(),
                Pages = (int)Math.Ceiling(products.Count / (double)TAKE)
            };

        }
    }
}
