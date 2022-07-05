using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>

    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Keywords).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(500);

            builder.HasMany(x => x.Articles).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
