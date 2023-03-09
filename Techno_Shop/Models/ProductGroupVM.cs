using Microsoft.AspNetCore.Mvc.Rendering;

namespace Techno_Shop.Models
{
    public class ProductGroupVM
    {
        public string CategoryName { get; set; }
        public SelectList Products { get; set; }
    }
}
