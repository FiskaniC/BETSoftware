using System;
using System.Threading.Tasks;
using BETShop.Application.Commands;
using BETShop.Application.Queries;
using BETShop.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BETShop.Api.Controllers
{
    [Authorize]
    [Route("Order")]
    public class OrderController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public OrderController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [Route("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Signin", "Account");
            }

            var cartProducts = await Mediator.Send(new GetCartQuery { });
            await Mediator.Send(new CreateOrderCommand
            {
                UserId = User.Identity.Name,
                Date = DateTime.UtcNow,
                Cart = new Cart(cartProducts)
            });
            return RedirectToAction("Checkout", "Order");
        }
    }
}
