using MediatR;

namespace BETShop.Application.Commands
{
    public class RemoveFromCartCommand : IRequest
    {
        public int Id { get; set; }
    }
}
