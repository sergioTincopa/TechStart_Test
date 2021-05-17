using Microsoft.EntityFrameworkCore.Migrations;

namespace TechStart_Test.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    IdHospital = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.IdHospital);
                });

            migrationBuilder.CreateTable(
                name: "ItemVendor",
                columns: table => new
                {
                    IdItemVendor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendor", x => x.IdItemVendor);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    IdPharmacy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHospital = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.IdPharmacy);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyInventory",
                columns: table => new
                {
                    IdPharmacy = table.Column<int>(type: "int", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    QuantityOnHand = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(11,3)", precision: 11, scale: 3, nullable: false),
                    ReorderQuantity = table.Column<int>(type: "int", nullable: false),
                    SellingUnitMeasure = table.Column<decimal>(type: "decimal(11,3)", precision: 11, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyInventory", x => new { x.IdPharmacy, x.ItemNumber });
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UPC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimunOrderQuantity = table.Column<decimal>(type: "decimal(11,3)", precision: 11, scale: 3, nullable: false),
                    PurchaseUnitMeasure = table.Column<decimal>(type: "decimal(11,3)", precision: 11, scale: 3, nullable: false),
                    ItemCost = table.Column<decimal>(type: "decimal(11,3)", precision: 11, scale: 3, nullable: false),
                    IdItemVendor = table.Column<int>(type: "int", nullable: false),
                    ItemVendorIdItemVendor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemNumber);
                    table.ForeignKey(
                        name: "FK_Item_ItemVendor_ItemVendorIdItemVendor",
                        column: x => x.ItemVendorIdItemVendor,
                        principalTable: "ItemVendor",
                        principalColumn: "IdItemVendor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemVendorIdItemVendor",
                table: "Item",
                column: "ItemVendorIdItemVendor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "PharmacyInventory");

            migrationBuilder.DropTable(
                name: "ItemVendor");
        }
    }
}
