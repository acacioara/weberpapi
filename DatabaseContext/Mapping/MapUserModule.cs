using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Modelos.UserModules;

namespace DatabaseContext.Mapping
{
    public class MapUserModule : IEntityTypeConfiguration<UserModules>
    {
        public void Configure(EntityTypeBuilder<UserModules> builder)
        {
            builder.ToTable("Tb_UserModule");

            builder.HasKey(x => x.Id);
            //CHAVE ESTRANGEIRAS
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Module).WithMany().HasForeignKey(x => x.IdModule).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
