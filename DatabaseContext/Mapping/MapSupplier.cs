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
    public class MapSupplier : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Tb_Supplier");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CorporateName).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).HasColumnType("varchar(15)").IsRequired();
            builder.Property(x => x.Able).HasColumnType("bool").IsRequired();
            builder.Property(x => x.Street).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Number).HasMaxLength(10).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.Complemet).HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Neighborhood).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.City).HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.State).HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.ZipCode).HasMaxLength(8).HasColumnType("varchar(8)").IsRequired();

        }
    }
}
