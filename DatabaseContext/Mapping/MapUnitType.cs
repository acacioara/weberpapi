using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Modelos.Inventories;

namespace DatabaseContext.Mapping
{
    public class MapUnitType : IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> builder)
        {
            builder.ToTable("Tb_UnitType");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
