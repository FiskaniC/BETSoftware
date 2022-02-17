using System.Threading;
using System.Threading.Tasks;
using BETShop.Application.Commands;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Application.Extensions;
using MediatR;

namespace BETShop.Application.CommandHandlers
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand>
    {
        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepository;

        public RemoveFromCartCommandHandler(ICartService cartService, IProductRepository productRepository)
        {
            _cartService = cartService;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var cartProducts = _cartService.GetCart();
            var product = await _productRepository.GetProduct(request.Id);
            if (cartProducts != null && product != null)
            {
                var index = cartProducts.ProductIndexInCart(request.Id);
                cartProducts.RemoveAt(index);
                _cartService.UpdateCart(cartProducts);
            }
            return Unit.Value;
        }
    }
}
