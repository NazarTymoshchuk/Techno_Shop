using BusinessLogic.Intefaces;
using Data_Access.Entities;
using Data_Access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class FavouriteService : IFavouriteServices
    {
        private readonly IRepository<Favourite> fav;

        public FavouriteService(IRepository<Favourite> fav)
        {
            this.fav = fav;
        }

        public void AddProduct(int productId, string userId)
        {
            if(!fav.Get(f => f.UserId == userId && f.ProductId == productId).Any())
            { 
                fav.Insert(new Favourite() { ProductId = productId, UserId = userId });
                fav.Save();
            }

        }

        public void AddSystemBlock(int sbId, string userId)
        {
            if (!fav.Get(f => f.UserId == userId && f.SystemBlockId == sbId).Any())
            {
                fav.Insert(new Favourite() { SystemBlockId = sbId, UserId = userId });
                fav.Save();
            }
        }

        public List<Product> GetProducts(string userId)
        {
            List<Product> products = fav.Get(x => x.UserId == userId && x.ProductId != null, includeProperties: new[] { "Product" }).Select(x => x.Product).ToList();

            return products;
        }

        public List<SystemBlock> GetSystemBlocks(string userId)
        {
            List<SystemBlock> products = fav.Get(x => x.UserId == userId && x.SystemBlockId != null, includeProperties: new[] { "SystemBlock" }).Select(x => x.SystemBlock).ToList();

            return products;
        }

        public bool IsFavouriteProduct(int productId, string userId)
        {
            return fav.Get(f => f.UserId == userId && f.ProductId == productId).Any();
        }

        public bool IsFavouriteSystemBlock(int sbId, string userId)
        {
            return fav.Get(f => f.UserId == userId && f.SystemBlockId == sbId).Any();
        }

        public void RemoveProduct(int productId, string userId)
        {
            var favourite = fav.Get(f => f.UserId == userId && f.ProductId == productId).FirstOrDefault();
            if (favourite != null)
            {
                fav.Delete(favourite);
            }
            fav.Save();
        }

        public void RemoveSystemBlock(int sbId, string userId)
        {
            var favourite = fav.Get(f => f.UserId == userId && f.SystemBlockId == sbId).FirstOrDefault();
            if (favourite != null)
            {
                fav.Delete(favourite);
            }
            fav.Save();
        }
    }
}
