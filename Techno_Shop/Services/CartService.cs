using BusinessLogic.Services;
using BusinessLogic;
using Data_Access.Entities;
using BusinessLogic.Intefaces;

namespace Techno_Shop.Services
{
    public class CartService : ICartService
    {
        private readonly IProductsService productsService;
        private readonly ISystemBlocksService systemBlocksService;
        private readonly HttpContext? httpContext;

        public CartService(IProductsService productsService, IHttpContextAccessor httpContextAccessor, ISystemBlocksService systemBlocksService)
        {
            this.productsService = productsService;
            this.httpContext = httpContextAccessor.HttpContext;
            this.systemBlocksService = systemBlocksService;
        }

        public List<Product> GetProducts()
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            List<Product> products = new List<Product>();

            if (productIds != null)
                products = productsService.Get(productIds.ToArray());

            return products;
        }

        public List<SystemBlock> GetSystemBlocks()
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            List<SystemBlock> products = new List<SystemBlock>();

            if (productIds != null)
                products = systemBlocksService.Get(productIds.ToArray());

            return products;
        }

        public void Add(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            if (productIds == null) productIds = new List<int>();
            productIds.Add(productId);

            httpContext.Session.SetObject("cart", productIds);
        }

        public void Remove(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            if (productIds == null) productIds = new List<int>();
            productIds.Remove(productId);

            httpContext.Session.SetObject("cart", productIds);
        }

        public bool IsInCart(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            if (productIds == null) return false;

            return productIds.Contains(productId);
        }
    }
}
