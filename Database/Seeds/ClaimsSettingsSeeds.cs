using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace InteractiveWebsite.Database.Seeds
{
    internal static class ClaimsSettingsSeeds
    {
        public static ModelBuilder HasClaimsSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimsSettings>().HasData(
                new ClaimsSettings { Id = Enum.GetName(NavigationItem.Home), Navigation = NavigationItem.Home, MinLevel = 0 }
            );

            return modelBuilder;
        }
    }
}
