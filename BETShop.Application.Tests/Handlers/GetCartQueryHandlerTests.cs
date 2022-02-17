using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Application.Queries;
using BETShop.Application.QueryHandlers;
using BETShop.Application.Tests.Initialize;
using BETShop.Domain.Models;
using Shouldly;
using Xunit;

namespace BETShop.Application.Tests.Handlers
{
    [Collection("Providers For Tests")]

    public class GetCartQueryHandlerTests
    {
        private readonly ICartService _cartService;
        public GetCartQueryHandlerTests(TestFixture fixture)
        {
            _cartService = fixture.CartService;
        }

        [Fact]
        public async Task Get_Cart_Success()
        {
            //Arrange
            var sut = new GetCartQueryHandler(_cartService);

            //Act
            var result = await sut.Handle(
              new GetCartQuery(),
              CancellationToken.None);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<CartProduct>>();
        }
    }
}
