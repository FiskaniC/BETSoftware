using System.Collections.Generic;
using BETShop.Domain.Models;
using MediatR;

namespace BETShop.Application.Queries
{
    public class GetProductsQuery : IRequest<IList<Products>>
    {

    }
}
