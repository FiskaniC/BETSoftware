using System.Threading.Tasks;
using BETShop.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BETShop.Api.Controllers
{
    [Authorize]
    [Route("Product")]
    public class ProductController : BaseController
    {
        [Route("")]
        [Route("~/")]
        [Route("Index")]
        public async Task<IActionResult> Index(int id)
        {
            return View(await Mediator.Send(new GetProductsByFilterQuery { Skip = id }));
        }
    }
}
