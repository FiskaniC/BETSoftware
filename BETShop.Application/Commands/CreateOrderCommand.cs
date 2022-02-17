using System;
using BETShop.Domain.Models;
using MediatR;

namespace BETShop.Application.Commands
{
    public class CreateOrderCommand : IRequest
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public Cart Cart { get; set; }
    }
}
