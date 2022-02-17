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
    public class AddToCartCommandHandlerTests
    {
        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepository;

        public AddToCartCommandHandlerTests(TestFixture fixture)
        {
            _cartService = fixture.CartService;
            _productRepository = fixture.ProductRespository;
        }

        [Fact]
        public async Task Add_To_Cart_Success()
        {
            //Arrange
            var sut = new AddToCartCommandHandler(_cartService, _productRepository);

            //Act
            var result = await sut.Handle(
              new Commands.AddToCartCommand(),
              CancellationToken.None);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Unit>();
        }
    }
}
