using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Modelos.Inventories;

namespace DatabaseContext.Mapping
{
    public class MapInventory : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Tb_Inventory");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.CostPrice).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.ProfitPercentage).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.SalePrice).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Able).HasColumnType("bool").IsRequired();

            builder.HasOne(x => x.Suppliers).WithMany().HasForeignKey(x => x.IdSupplier).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.IdSupplier).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.UnitType).WithMany().HasForeignKey(x => x.IdUnitType).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
