using AutoMapper;
using BETShop.Application.Commands;
using BETShop.Infrastructure.Repositories.Models;

namespace BETShop.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOrderCommand, Domain.Models.Order>().ReverseMap();
            CreateMap<Order, Domain.Models.Order>().ReverseMap();
        }
    }
}
