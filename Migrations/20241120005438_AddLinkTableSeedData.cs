using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkTableSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerProduct",
                columns: new[] { "CustomersCustomerId", "ProductsProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 6, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "OpenDate",
                value: new DateTime(2024, 11, 19, 16, 54, 37, 868, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 11, 19, 16, 54, 37, 868, DateTimeKind.Local).AddTicks(5452));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerProduct",
                keyColumns: new[] { "CustomersCustomerId", "ProductsProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerProduct",
                keyColumns: new[] { "CustomersCustomerId", "ProductsProductId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerProduct",
                keyColumns: new[] { "CustomersCustomerId", "ProductsProductId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "OpenDate",
                value: new DateTime(2024, 11, 19, 16, 45, 40, 465, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 11, 19, 16, 45, 40, 465, DateTimeKind.Local).AddTicks(374));
        }
    }
}
