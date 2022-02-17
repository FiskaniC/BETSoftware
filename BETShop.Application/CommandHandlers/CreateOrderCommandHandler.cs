using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BETShop.Application.Commands;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Domain.Models;
using MediatR;

namespace BETShop.Application.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IEmailService emailService)
        {
            _orderRepository = orderRepository;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _orderRepository.CreateOrder(new Order
            {
                UserId = request.UserId,
                Date = request.Date,
                Cart = request.Cart
            });

            await _emailService.SendEmail(new Mail
            {
                To = request.UserId,
                Subject = $"BETSHOP: New Order {1234}",
                Content = request.ToString()
            });
            return Unit.Value;
        }
    }
}
