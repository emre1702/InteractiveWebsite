using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InteractiveWebsite.Database.Entities
{
    public class ClaimsSettings
    {
        #nullable disable
        public string Id { get; set; }
        public int MinLevel { get; set; }
        #nullable restore
    }

    public class ClaimsSettingsConfiguration : IEntityTypeConfiguration<ClaimsSettings>
    {
        public void Configure(EntityTypeBuilder<ClaimsSettings> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}
