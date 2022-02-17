using System.Threading;
using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Queries;
using BETShop.Domain.Models;
using MediatR;

namespace BETShop.Application.QueryHandlers
{
    public class GetProductsByFilterQueryHandler : IRequestHandler<GetProductsByFilterQuery, ProductsByFilter>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByFilterQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductsByFilter> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByFilter(request.Skip);
        }
    }
}
