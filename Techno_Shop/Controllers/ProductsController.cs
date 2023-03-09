using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data_Access;
using Data_Access.Entities;
using BusinessLogic.Services;
using MessagePack;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Techno_Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        private void LoadCategories()
        {
            ViewBag.CategoryList = new SelectList(productsService.GetCategories(), nameof(Category.Id), nameof(Category.Name));
        }

        private void LoadTitle(int id)
        {
            if(id == 0)
            {
                ViewBag.Title = "\r\nComponents for computers";
                return;
            }

            ViewBag.CategoryId = id;
            ViewBag.Title = productsService.GetCategories().Where(c => c.Id == id).Select(c => c.Name).FirstOrDefault();
        }

        [AllowAnonymous]
        public IActionResult Index(int id)
        {
            LoadTitle(id);

            if (id == 0)
                return View(productsService.GetAll());

            return View(productsService.GetAll().Where(p => p.CategoryId == id).ToList());
        }

        [AllowAnonymous]
        public IActionResult Details(int Id)
        {
            if (Id < 0) return BadRequest();

            var product = productsService.Get(Id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Details(string name)
        {
            if (name == null) return NotFound();

            var product = productsService.Get(name);

            return View(product);
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            productsService.Create(product);

            return RedirectToAction(nameof(Index), new { id = 0 });
        }

        public IActionResult Delete(int id)
        {
            var product = productsService.Get(id);

            if (product == null) return NotFound();

            productsService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = productsService.Get(id);

            if (product == null) return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            productsService.Edit(product);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult SortByPrice(int id, bool sortDesc)
        {
            LoadTitle(id);

            return View("Index", productsService.SortByPrice(id, sortDesc));
        }

        [AllowAnonymous]
        public IActionResult SortByName(int id)
        {
            LoadTitle(id);

            return View("Index", productsService.SortByName(id));
        }
    }
}
