using MediatR;

namespace BETShop.Application.Commands
{
    public class AddToCartCommand : IRequest
    {
        public int Id { get; set; }
    }
}
