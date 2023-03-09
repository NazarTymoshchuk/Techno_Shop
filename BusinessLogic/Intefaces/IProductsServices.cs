using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IProductsService
    {
        List<Category> GetCategories();
        List<Product> GetAll();
        List<Product> Get(int[] ids);
        Product? Get(int id);
        Product? Get(string name);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int id);
        List<Product> SortByPrice(int categoryId, bool sortDesc);
        List<Product> SortByName(int categoryId);
    }
}
