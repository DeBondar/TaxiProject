using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiProject.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    LicenseNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "No name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.LicenseNumber);
                    table.CheckConstraint("LicenseNumber", "LicenseNumber > 0");
                });

            migrationBuilder.CreateTable(
                name: "taxis",
                columns: table => new
                {
                    TaxiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxis", x => x.TaxiId);
                    table.ForeignKey(
                        name: "FK_taxis_drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "drivers",
                        principalColumn: "LicenseNumber");
                });

            migrationBuilder.InsertData(
                table: "drivers",
                columns: new[] { "LicenseNumber", "Name" },
                values: new object[,]
                {
                    { 1, "James Clear" },
                    { 2, "Lucy Monte" },
                    { 3, "Bob Whalley" },
                    { 4, "Jack Rassel" }
                });

            migrationBuilder.InsertData(
                table: "taxis",
                columns: new[] { "TaxiId", "Brand", "DriverId", "Model", "RegistrationNumber" },
                values: new object[,]
                {
                    { 1, "Renault", null, "Logan", "KA2211НР" },
                    { 2, "Renault", null, "Megane", "KA3258СК" },
                    { 3, "Chevrolet", null, "Cruze", "KA0258МН" },
                    { 4, "Nissan", null, "X-trail", "АІ9135НН" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_taxis_DriverId",
                table: "taxis",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taxis");

            migrationBuilder.DropTable(
                name: "drivers");
        }
    }
}
