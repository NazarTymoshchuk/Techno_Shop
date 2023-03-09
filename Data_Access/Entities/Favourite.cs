using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class Favourite
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? SystemBlockId { get; set; }
        public SystemBlock? SystemBlock { get; set; }
    }
}
