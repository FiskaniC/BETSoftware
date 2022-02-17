using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BETShop.Application.Commands;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Application.Extensions;
using BETShop.Domain.Models;
using MediatR;

namespace BETShop.Application.CommandHandlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand>
    {
        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepository;

        public AddToCartCommandHandler(ICartService cartService, IProductRepository productRepository)
        {
            _cartService = cartService;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cartProducts = _cartService.GetCart();
            var product = await _productRepository.GetProduct(request.Id);
            if (cartProducts == null)
            {
                var cart = new List<CartProduct>
                {
                    new CartProduct { Product = product, Quantity = 1 }
                };
                _cartService.UpdateCart(cart);

            }
            else
            {
                var index = cartProducts.ProductIndexInCart(request.Id);
                if (index != -1)
                {
                    cartProducts[index].Quantity++;
                }
                else
                {
                    cartProducts.Add(new CartProduct { Product = product, Quantity = 1 });
                }
                _cartService.UpdateCart(cartProducts);
            }
            return Unit.Value;
        }
    }
}
