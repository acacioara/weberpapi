using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseContext.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descrition = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Able = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CorporateName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Able = table.Column<bool>(type: "bool", nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Complemet = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_UnitType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_UnitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    ProfitPercentage = table.Column<decimal>(type: "decimal", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal", nullable: false),
                    Able = table.Column<bool>(type: "bool", nullable: false),
                    IdSupplier = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCategory = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUnitType = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Inventory_Tb_Category_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Tb_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Inventory_Tb_Supplier_IdSupplier",
                        column: x => x.IdSupplier,
                        principalTable: "Tb_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Inventory_Tb_UnitType_IdUnitType",
                        column: x => x.IdUnitType,
                        principalTable: "Tb_UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Inventory_IdSupplier",
                table: "Tb_Inventory",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Inventory_IdUnitType",
                table: "Tb_Inventory",
                column: "IdUnitType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Inventory");

            migrationBuilder.DropTable(
                name: "Tb_Category");

            migrationBuilder.DropTable(
                name: "Tb_Supplier");

            migrationBuilder.DropTable(
                name: "Tb_UnitType");
        }
    }
}
