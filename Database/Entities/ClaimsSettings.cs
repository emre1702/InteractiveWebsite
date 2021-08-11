using InteractiveWebsite.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InteractiveWebsite.Database.Entities
{
    public class ClaimsSettings
    {
        #nullable disable
        public string Id { get; set; }
        public NavigationItem Navigation { get; set; }
        public int MinLevel { get; set; }
        #nullable restore
    }

    public class ClaimsSettingsConfiguration : IEntityTypeConfiguration<ClaimsSettings>
    {
        public void Configure(EntityTypeBuilder<ClaimsSettings> builder)
        {
            builder.HasKey(e => new { e.Id, e.Navigation });
            builder.HasIndex(e => e.Navigation).IsUnique(false);

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Navigation).ValueGeneratedNever();
        }
    }
}
