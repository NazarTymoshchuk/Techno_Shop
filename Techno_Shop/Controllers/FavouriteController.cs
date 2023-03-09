using BusinessLogic.Intefaces;
using BusinessLogic.Services;
using Data_Access.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Techno_Shop.Controllers
{
    [Authorize]
    public class FavouriteController : Controller
    {
        private string userId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        readonly IFavouriteServices favouriteServices;
        public Favourites favourites;

        public FavouriteController(IFavouriteServices favouriteServices)
        {
            this.favouriteServices = favouriteServices;
            favourites = new Favourites();
        }

        public IActionResult Index()
        {
            favourites.Products = favouriteServices.GetProducts(userId);
            favourites.SystemBlocks = favouriteServices.GetSystemBlocks(userId);

            return View(favourites);
        }

        public IActionResult AddProduct(int productId, string returnUrl)
        {
            favouriteServices.AddProduct(productId, userId);
            return Redirect(returnUrl);
        }

        public IActionResult AddSystemBlock(int sbId, string returnUrl)
        {
            favouriteServices.AddSystemBlock(sbId, userId);
            return Redirect(returnUrl);
        }

        public IActionResult RemoveProduct(int productId, string returnUrl)
        {
            favouriteServices.RemoveProduct(productId, userId);
            return Redirect(returnUrl);
        }

        public IActionResult RemoveSystemBlock(int sbId, string returnUrl)
        {
            favouriteServices.RemoveSystemBlock(sbId, userId);
            return Redirect(returnUrl);
        }
    }
}
