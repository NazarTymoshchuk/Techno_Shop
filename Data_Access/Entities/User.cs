using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Favourite> Favourites { get; set; }
    }
}
