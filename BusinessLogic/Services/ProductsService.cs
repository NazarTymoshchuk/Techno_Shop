using Data_Access;
using Data_Access.Entities;
using Data_Access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> prod;
        private readonly IRepository<Category> categ;

        public ProductsService(IRepository<Product> prod, IRepository<Category> categ)
        {
            this.prod = prod;
            this.categ = categ;
        }

        public void Create(Product product)
        {
            prod.Insert(product);
            prod.Save();
        }

        public void Delete(int id)
        {
            var product = Get(id);

            if (product == null) return;

            prod.Delete(product);
            prod.Save();
        }

        public void Edit(Product product)
        {
            prod.Update(product);
            prod.Save();
        }

        public List<Product> GetAll()
        {
            return prod.Get().ToList();
        }

        public Product? Get(int id)
        {
            if (id < 0) return null;

            var product = prod.GetByID(id);

            return product;
        }

        public Product? Get(string name)
        {
            var product = prod.Get().Where(p => p.Name.Contains(name) == true).FirstOrDefault();

            return product;
        }

        public List<Category> GetCategories()
        {
            return categ.Get().ToList();
        }

        public List<Product> Get(int[] ids)
        {
            return prod.Get(x => ids.Contains(x.Id)).ToList();
        }

        public List<Product> SortByPrice(int categoryId, bool sortDesc)
        {
            if (categoryId == 0)
            {
                if (sortDesc)
                    return prod.Get(orderBy: p => p.OrderBy(x => x.Price)).ToList();
                else
                    return prod.Get(orderBy: p => p.OrderByDescending(x => x.Price)).ToList();
            }

            if (sortDesc)
                return prod.Get(orderBy: p => p.OrderBy(x => x.Price)).Where(p => p.CategoryId == categoryId).ToList();
            else
                return prod.Get(orderBy: p => p.OrderByDescending(x => x.Price)).Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> SortByName(int categoryId)
        {
            if(categoryId == 0)
                return prod.Get(orderBy: p => p.OrderBy(x => x.Name)).ToList();

            return prod.Get(orderBy: p => p.OrderBy(x => x.Name)).Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
