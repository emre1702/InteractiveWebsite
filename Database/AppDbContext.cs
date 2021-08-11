using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Database.Entities;
using InteractiveWebsite.Database.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace InteractiveWebsite.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        #nullable disable
        public virtual DbSet<ClaimsSettings> ClaimsSettings { get; set; }
        public virtual DbSet<News> News { get; set; }

        #nullable restore

        static AppDbContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<NavigationItem>();
        }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfigurationsFromAssembly(GetType().Assembly)
                .HasSeeds()
                .HasPostgresEnum<NavigationItem>();
        }
    }
}
