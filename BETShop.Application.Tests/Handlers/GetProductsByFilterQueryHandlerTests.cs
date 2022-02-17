using System.Threading;
using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Queries;
using BETShop.Application.QueryHandlers;
using BETShop.Application.Tests.Initialize;
using BETShop.Domain.Models;
using Shouldly;
using Xunit;

namespace BETShop.Application.Tests.Handlers
{
    [Collection("Providers For Tests")]
    public class GetProductsByFilterQueryHandlerTests
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByFilterQueryHandlerTests(TestFixture fixture)
        {
            _productRepository = fixture.ProductRespository;
        }

        [Fact]
        public async Task Get_Products_By_Filter_Success()
        {
            //Arrange
            var sut = new GetProductsByFilterQueryHandler(_productRepository);

            //Act
            var result = await sut.Handle(
              new GetProductsByFilterQuery(),
              CancellationToken.None);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductsByFilter>();
        }
    }
}
