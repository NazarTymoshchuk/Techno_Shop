using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICartService
    {
        List<Product> GetProducts();
        List<SystemBlock> GetSystemBlocks();
        void Add(int productId);
        void Remove(int productId);
        bool IsInCart(int productId);
    }
}
