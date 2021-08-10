using Microsoft.EntityFrameworkCore;

namespace InteractiveWebsite.Database.Seeds
{
    internal static class SeedsProvider
    {
        public static ModelBuilder HasSeeds(this ModelBuilder modelBuilder) 
            => modelBuilder.HasClaimsSettings();

    }
}
