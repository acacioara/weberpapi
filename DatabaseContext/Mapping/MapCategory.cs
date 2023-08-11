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
    public class MapCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Tb_Category");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Able).HasColumnType("bool").IsRequired();
        }
    }
}