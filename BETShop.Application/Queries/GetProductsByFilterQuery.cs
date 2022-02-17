using BETShop.Domain.Models;
using MediatR;

namespace BETShop.Application.Queries
{
    public class GetProductsByFilterQuery : IRequest<ProductsByFilter>
    {
        public int Skip { get; set; }
    }
}
