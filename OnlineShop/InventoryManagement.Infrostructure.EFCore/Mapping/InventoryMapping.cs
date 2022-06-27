using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EFCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);


            builder.OwnsMany(x => x.Operations, modelBuilder =>
            {
                modelBuilder.ToTable("InventoryOperations");
                modelBuilder.HasKey(x => x.Id);
                modelBuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
                modelBuilder.Property(x => x.Count).IsRequired();
                modelBuilder.Property(x => x.CurrentCount).IsRequired();
                modelBuilder.Property(x => x.Description);
                modelBuilder.Property(x => x.OrderId);
                modelBuilder.Property(x => x.Operation);
                modelBuilder.Property(x => x.OperatorId);
            });
        }
    }
}
