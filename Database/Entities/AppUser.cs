using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace InteractiveWebsite.Database.Entities
{
    public class AppUser : IdentityUser
    {
        #nullable disable
        public virtual IEnumerable<News> News { get; set; }

        #nullable restore
    }
}
