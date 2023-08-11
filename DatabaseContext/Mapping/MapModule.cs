using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Modelos.Modules;

namespace DatabaseContext.Mapping
{
    public class MapModule : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("Tb_Module");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Code).HasMaxLength(10).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.Able).HasColumnType("bool").IsRequired();
        }
    }
}
