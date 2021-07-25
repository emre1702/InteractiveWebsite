using InteractiveWebsite.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InteractiveWebsite.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        #nullable disable
        public virtual DbSet<News> News { get; set; }

        #nullable restore

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
