using System.Threading.Tasks;
using BETShop.Application.Commands;
using BETShop.Application.Queries;
using BETShop.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BETShop.Api.Controllers
{
    [Authorize]
    [Route("Cart")]
    public class CartController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var cartProducts = await Mediator.Send(new GetCartQuery { });
            var cart = new Cart(cartProducts);
            return View(cart);
        }

        [Route("Add/{id}")]
        public async Task<IActionResult> Add(int id)
        {
            await Mediator.Send(new AddToCartCommand { Id = id });
            return RedirectToAction("Index");
        }

        [Route("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveFromCartCommand { Id = id });
            return RedirectToAction("Index");
        }
    }
}
