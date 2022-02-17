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
    public class CreateOrderCommandHandlerTests
    {
        private readonly IEmailService _emailService;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandlerTests(TestFixture fixture)
        {
            _emailService = fixture.EmailService;
            _orderRepository = fixture.OrderRespository;
        }

        [Fact]
        public async Task Create_Order_Success()
        {
            //Arrange
            var sut = new CreateOrderCommandHandler(_orderRepository, _emailService);

            //Act
            var result = await sut.Handle(
              new Commands.CreateOrderCommand(),
              CancellationToken.None);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Unit>();
        }
    }
}
