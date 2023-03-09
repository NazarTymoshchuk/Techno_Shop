using BusinessLogic.DTOs;
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
    public class SystemBlocksService : ISystemBlocksService
    {
        private readonly IRepository<SystemBlock> sb;
        private readonly IRepository<Category> categ;
        private readonly IRepository<Product> prod;

        public SystemBlocksService(IRepository<SystemBlock> sb, IRepository<Category> categ, IRepository<Product> prod)
        {
            this.sb = sb;
            this.categ = categ;
            this.prod = prod;
        }

        private SystemBlock ConvertToSB(SystemBlockModel systemBlockModel)
        {
            SystemBlock systemBlock = new SystemBlock()
            {
                Name = systemBlockModel.Name,
                Price = systemBlockModel.Price,
                ImagePath = systemBlockModel.ImagePath,
            };

            systemBlock.Products = new List<Product>();

            systemBlock.Products = GetByIds(systemBlockModel.ProductIds);

            return systemBlock;
        }

        public void Create(SystemBlock product)
        {
            sb.Insert(product);
            sb.Save();
        }

        public void Delete(int id)
        {
            sb.Delete(id);
            sb.Save();
        }

        public void Edit(SystemBlock product)
        {
            sb.Update(product);
            sb.Save();
        }

        public void Edit(SystemBlockModel product)
        {
            sb.Update(ConvertToSB(product));
            sb.Save();
        }

        public List<SystemBlock> GetAll()
        {
            return sb.Get().ToList();
        }

        public SystemBlock GetById(int id)
        {
            return sb.GetByID(id);
        }

        public List<Category> GetCategories()
        {
            return categ.Get().ToList();
        }

        public List<Product> GetProducts()
        {
            return prod.Get(includeProperties: nameof(Product.Category)).ToList();
        }

        public SystemBlock GetByIdIncludeProducts(int id)
        {
            return sb.Get(p => p.Id == id, includeProperties: nameof(SystemBlock.Products)).First();
        }

        public List<SystemBlock> Get(int[] ids)
        {
            return sb.Get(x => ids.Contains(x.Id)).ToList();
        }

        public List<Product> GetByIds(int[] ids)
        {
            return prod.Get(x => ids.Contains(x.Id)).ToList();
        }

        public void Create(SystemBlockModel product)
        {
            sb.Insert(ConvertToSB(product));
            sb.Save();
        }
    }
}
