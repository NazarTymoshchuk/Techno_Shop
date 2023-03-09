using BusinessLogic;
using BusinessLogic.Services;
using BusinessLogic.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Techno_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IMailServices mailService;

        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string Username => User.FindFirstValue(ClaimTypes.Name);

        public CartController(ICartService cartService, IMailServices mailService)
        {
            this.cartService = cartService;
            this.mailService = mailService;
        }

        public IActionResult Index()
        {
            Favourites favourites = new Favourites();
            favourites.SystemBlocks = cartService.GetSystemBlocks();
            favourites.Products = cartService.GetProducts();

            return View(cartService.GetProducts());
        }

        public IActionResult Add(int productId, string returnUrl)
        {
            cartService.Add(productId);
            return Redirect(returnUrl);
        }

        public IActionResult Remove(int productId, string returnUrl)
        {
            cartService.Remove(productId);
            return Redirect(returnUrl);
        }

        public IActionResult Create()
        {
            mailService.SendMailAsync("Order confirmation", "<h2 style='color: darkcyan;'>Order information</h2><p>Order was successfully confirmed!</p>", Username);

            return RedirectToAction(nameof(Index));
        }
    }
}
