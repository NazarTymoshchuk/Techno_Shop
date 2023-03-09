using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class SystemBlock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Favourite>? Favourites { get; set; }
    }
}
