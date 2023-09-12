﻿// <auto-generated />
using System;
using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseContext.Migrations
{
    [DbContext(typeof(ContextConfig))]
    [Migration("20230911125528_InclusãoCampoDescription")]
    partial class InclusãoCampoDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Modelos.Inventories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Able")
                        .HasColumnType("bool");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tb_Category", (string)null);
                });

            modelBuilder.Entity("Models.Modelos.Inventories.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Able")
                        .HasColumnType("bool");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("IdCategory")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdSupplier")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUnitType")
                        .HasColumnType("uuid");

                    b.Property<decimal>("ProfitPercentage")
                        .HasColumnType("decimal");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("IdSupplier");

                    b.HasIndex("IdUnitType");

                    b.ToTable("Tb_Inventory", (string)null);
                });

            modelBuilder.Entity("Models.Modelos.Inventories.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Able")
                        .HasColumnType("bool");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemet")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Tb_Supplier", (string)null);
                });

            modelBuilder.Entity("Models.Modelos.Inventories.UnitType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tb_UnitType", (string)null);
                });

            modelBuilder.Entity("Models.Modelos.Modules.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Able")
                        .HasColumnType("bool");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tb_Module", (string)null);
                });

            modelBuilder.Entity("Models.Modelos.UserModules.UserModules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdModule")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdModule");

                    b.HasIndex("IdUser");

                    b.ToTable("Tb_UserModule", (string)null);
                });

            modelBuilder.Entity("Models.Modelos.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Able")
                        .HasColumnType("bool");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemet")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("Date");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("FirstAccess")
                        .HasColumnType("bool");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Tb_User", (string)null);
                });

            modelBuilder.Entity("Models.Modelos.Inventories.Inventory", b =>
                {
                    b.HasOne("Models.Modelos.Inventories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdSupplier")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Modelos.Inventories.Supplier", "Suppliers")
                        .WithMany()
                        .HasForeignKey("IdSupplier")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Modelos.Inventories.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("IdUnitType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Suppliers");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("Models.Modelos.UserModules.UserModules", b =>
                {
                    b.HasOne("Models.Modelos.Modules.Module", "Module")
                        .WithMany()
                        .HasForeignKey("IdModule")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Modelos.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
