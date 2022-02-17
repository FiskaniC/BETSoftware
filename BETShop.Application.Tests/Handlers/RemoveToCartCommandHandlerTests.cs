using System.Threading;
using System.Threading.Tasks;
using BETShop.Application.CommandHandlers;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Application.Tests.Initialize;
using MediatR;
using Shouldly;
using Xunit;

namespace BETShop.Application.Tests.Handlers
{
    [Collection("Providers For Tests")]
    public class RemoveToCartCommandHandlerTests
    {
        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepository;

        public RemoveToCartCommandHandlerTests(TestFixture fixture)
        {
            _cartService = fixture.CartService;
            _productRepository = fixture.ProductRespository;
        }

        [Fact]
        public async Task Add_To_Cart_Success()
        {
            //Arrange
            var sut = new RemoveFromCartCommandHandler(_cartService, _productRepository);

            //Act
            var result = await sut.Handle(
              new Commands.RemoveFromCartCommand { Id = 1 },
              CancellationToken.None);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Unit>();
        }
    }
}
