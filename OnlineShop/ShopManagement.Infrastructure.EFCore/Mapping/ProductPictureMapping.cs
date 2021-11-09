using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    internal class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductPictures).HasForeignKey(x => x.ProductId);
        }
    }
}
