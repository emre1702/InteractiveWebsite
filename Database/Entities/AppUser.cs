using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace InteractiveWebsite.Database.Entities
{
    public class AppUser : IdentityUser
    {
#nullable disable
        public int NumberId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastOnline { get; set; }
        public int Postcode { get; set; }
        public bool IsAdmin { get; set; }

        public virtual IEnumerable<News> News { get; set; }

#nullable restore
    }

    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.NumberId).UseIdentityAlwaysColumn();

            builder.Property(e => e.Birthdate)
                .HasConversion(v => v, v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : null);

            builder.Property(e => e.Created)
                .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                .HasDefaultValueSql("timezone('utc', now())");

            builder.Property(e => e.LastOnline)
                .HasConversion(v => v, v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : null);
        }
    }
}
