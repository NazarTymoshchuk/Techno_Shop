using BusinessLogic.DTOs;
using BusinessLogic.Intefaces;
using BusinessLogic.Services;
using Data_Access.Entities;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Techno_Shop.Models;

namespace Techno_Shop.Controllers
{
    public class ConfiguratorController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IMailServices mailService;
        private readonly ISystemBlocksService systemBlocksService;

        public ConfiguratorController(IMailServices mailService, IProductsService productsService, ISystemBlocksService systemBlocksService)
        {
            this.mailService = mailService;
            this.productsService = productsService;
            this.systemBlocksService = systemBlocksService;
        }

        private string Username => User.FindFirstValue(ClaimTypes.Name);

        private int LoadProductsByCategory()
        {
            var items = systemBlocksService.GetProducts()
                .GroupBy(x => x.Category.Name)
                .Select(x => new ProductGroupVM()
                {
                    CategoryName = x.Key,
                    Products = new SelectList(x, nameof(Product.Id), nameof(Product.Name))
                })
                .ToList();

            ViewBag.ProductGroups = items;


            return items.Count();
        }

        private void LoadProducts(int[] ids)
        {
            ViewBag.Products = productsService.Get(ids);
        }

        private void LoadTotalPrice(int[] ids)
        {
            ViewBag.TotalPrice = productsService.Get(ids).Select(x => x.Price).Sum();
        }

        public IActionResult Index()
        {
            LoadProductsByCategory();
            return View();
        }

        [HttpPost, Authorize]
        public IActionResult Create(SystemBlockModel product)
        {
            //LoadProducts(new int[] { product.ProcessorId, product.MotherboardId, product.CoolerId, product.RAMId, product.VideoCardId, product.SSDId, product.HDDId, product.WiFiAdapterId, product.PowerSupplyId, product.CablesId, product.VentilatorsId, product.CaseId, product.SoftwareId });
            LoadProducts(product.ProductIds);
            LoadTotalPrice(product.ProductIds);

            return View(product);
        }

        [Authorize]
        public IActionResult Confirm()
        {
            mailService.SendMailAsync("Order confirmation", "<h2 style='color: darkcyan;'>Order information</h2><p>Order was successfully confirmed!</p>", Username);

            return RedirectToAction(nameof(Index));
        }
    }
}
