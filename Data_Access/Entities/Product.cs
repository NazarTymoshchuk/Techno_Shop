using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? DetailInfo { get; set; }
        public string? ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Favourite>? Favourites { get; set; }
        public ICollection<SystemBlock>? SystemBlocks { get; set; }
    }
}
