using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Keywords).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);

            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);
        }
    }
}
