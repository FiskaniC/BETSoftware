using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Application.Queries;
using BETShop.Domain.Models;
using MediatR;

namespace BETShop.Application.QueryHandlers
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, IList<CartProduct>>
    {
        private readonly ICartService _cartService;
        public GetCartQueryHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public Task<IList<CartProduct>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_cartService.GetCart());
        }
    }
}
