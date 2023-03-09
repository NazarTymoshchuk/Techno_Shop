using BusinessLogic.DTOs;
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Intefaces
{
    public interface ISystemBlocksService
    {
        List<Category> GetCategories();
        List<Product> GetProducts();
        List<SystemBlock> GetAll();
        void Create(SystemBlock product);
        void Create(SystemBlockModel product);
        void Edit(SystemBlock product);
        void Edit(SystemBlockModel product);
        void Delete(int id);
        SystemBlock GetById(int id);
        List<SystemBlock> Get(int[] ids);
        public SystemBlock GetByIdIncludeProducts(int id);
    }
}
