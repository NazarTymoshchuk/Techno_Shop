using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Intefaces
{
    public interface IFavouriteServices
    {
        List<Product> GetProducts(string userId);
        void AddProduct(int productId, string userId);
        List<SystemBlock> GetSystemBlocks(string userId);
        void RemoveProduct(int productId, string userId);
        void AddSystemBlock(int sbId, string userId);
        void RemoveSystemBlock(int sbId, string userId);
        bool IsFavouriteProduct(int productId, string userId);
        bool IsFavouriteSystemBlock(int sbId, string userId);
    }
}
