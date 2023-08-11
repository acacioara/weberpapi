using DatabaseContext.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Modelos.Modules;
using Models.Modelos.Users;
using Models.Modelos.UserModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Modelos.Inventories;

namespace DatabaseContext.Context
{
    public class ContextConfig: DbContext
    {
        public ContextConfig(DbContextOptions<ContextConfig> options) : base(options) {  }

        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<UserModules> UserModules { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            modelBuilder.ApplyConfiguration(new MapUser());
            modelBuilder.ApplyConfiguration(new MapUserModule());
            modelBuilder.ApplyConfiguration(new MapModule());
            modelBuilder.ApplyConfiguration(new MapCategory());
            modelBuilder.ApplyConfiguration(new MapInventory());
            modelBuilder.ApplyConfiguration(new MapSupplier());
            modelBuilder.ApplyConfiguration(new MapUnitType());
        }
    }
}
