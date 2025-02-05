using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "Country", "Email", "FirstName", "LastName", "PhoneNumber", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "", "San Francisco", "", "kanthoni@pge.com", "Kaitlyn", "Anthoni", "", "", "" },
                    { 2, "", "Washington", "", "ania@mma.nidc.com", "Ania", "Irvin", "", "", "" },
                    { 3, "", "Mission Viejo", "", "", "Gonzalo", "Keeton", "", "", "" },
                    { 4, "", "Sacramento", "", "amauro@yahoo.org", "Anton", "Mauro", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Code", "Name", "ReleaseDate", "YearlyPrice" },
                values: new object[] { 1, "TRNY10", "Tournament Master 1.0", new DateTime(2024, 11, 3, 10, 39, 31, 169, DateTimeKind.Local).AddTicks(5220), 4.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "alison@sportprosoftware.com", "Alison Diaz", "800-555-0443" },
                    { 2, "awilson@sportprosoftware.com", "Andrew Wilson", "800-555-0449" },
                    { 3, "gfiori@sportprosoftware.com", "Gina Fiori", "800-555-0459" },
                    { 4, "gunter@sportprosoftware.com", "Gunter Wendt", "800-555-0400" },
                    { 5, "jason@sportprosoftware.com", "Jason Lee", "800-555-0440" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CloseDate", "CustomerId", "Description", "OpenDate", "ProductId", "TechnicianId", "Title" },
                values: new object[] { 1, null, 1, "Program fails to install.", new DateTime(2024, 11, 3, 10, 39, 31, 169, DateTimeKind.Local).AddTicks(5527), 1, 1, "Could not install" });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Technicians");
        }
    }
}
