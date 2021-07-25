using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InteractiveWebsite.Database.Entities
{
    #nullable disable
    public class News
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public AppUser Author { get; set; }
    }
#nullable restore

    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder
               .Property(e => e.Date)
               .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
               .HasDefaultValueSql("timezone('utc', now())");

            builder.Property(e => e.AuthorId).IsRequired(true);
            builder.Property(e => e.Content).IsRequired(true);

            builder
                .HasOne(e => e.Author)
                .WithMany(e => e.News)
                .HasForeignKey(e => e.AuthorId);
        }
    }
}
