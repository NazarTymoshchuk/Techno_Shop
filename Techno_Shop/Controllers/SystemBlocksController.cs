using BusinessLogic.DTOs;
using BusinessLogic.Intefaces;
using BusinessLogic.Services;
using Data_Access.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Techno_Shop.Models;

namespace Techno_Shop.Controllers
{
    public class SystemBlocksController : Controller
    {
        private readonly ISystemBlocksService systemBlocksService;
        private readonly IProductsService productsService;

        public SystemBlocksController(ISystemBlocksService systemBlocksService, IProductsService productsService)
        {
            this.systemBlocksService = systemBlocksService;
            this.productsService = productsService;
        }

        private int LoadProducts()  
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
            //ViewBag.Processors = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 14), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.Coolers = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 15), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.Motherboards = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 16), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.RAMs = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 17), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.VideoCards = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 18), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.SSDs = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 19), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.HDDs = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 7), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.WiFiAdapters = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 8), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.PowerSupply = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 9), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.Cables = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 10), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.Ventilators = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 11), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.Cases = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 12), nameof(Product.Id), nameof(Product.Name));
            //ViewBag.Software = new SelectList(systemBlocksService.GetProducts().Where(c => c.CategoryId == 13), nameof(Product.Id), nameof(Product.Name));
        }

        public IActionResult Index()
        {
            return View(systemBlocksService.GetAll());
        }

        public IActionResult Create()
        {
            int count = LoadProducts();

            var model = new SystemBlockModel()
            {
                ProductIds = new int[count]
            };
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SystemBlockModel systemBlock)
        {
            if (!ModelState.IsValid)
            {
                LoadProducts();
                return View();
            }

            systemBlocksService.Create(systemBlock);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var systemBlock = systemBlocksService.GetByIdIncludeProducts(id);

            if (systemBlock == null) return NotFound();

            ViewBag.Products = systemBlock.Products;
            return View(systemBlock);
        }

        public IActionResult Delete(int id) 
        {
            var systemBlock = systemBlocksService.GetById(id);

            if (systemBlock == null) return NotFound();

            systemBlocksService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = systemBlocksService.GetById(id);

            if (product == null) return NotFound();

            int count = LoadProducts();

            var model = new SystemBlockModel()
            {
                Name = product.Name,
                Price = product.Price,
                ImagePath = product.ImagePath,
                ProductIds = new int[count]
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SystemBlockModel systemBlock)
        {
            if (!ModelState.IsValid)
            {
                return View(systemBlock);
            }

            systemBlocksService.Edit(systemBlock);

            return RedirectToAction(nameof(Index));
        }
    }
}
