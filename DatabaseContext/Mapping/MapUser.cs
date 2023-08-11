using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Modelos.Users;

namespace DatabaseContext.Mapping
{
    public class MapUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Tb_User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Document).HasMaxLength(14).HasColumnType("varchar(14)").IsRequired();
            builder.Property(x => x.Able).HasColumnType("bool").IsRequired();
            builder.Property(x => x.FirstAccess).HasColumnType("bool").IsRequired();
            builder.Property(x => x.DateBirth).HasColumnType("Date").IsRequired();
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
