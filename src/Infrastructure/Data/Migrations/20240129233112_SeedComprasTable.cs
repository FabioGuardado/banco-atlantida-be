using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BancoAtlantidaChallenge.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedComprasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Compras",
                columns: new[] { "Id", "Descripcion", "Fecha", "Monto", "NumeroDeAutorizacion", "TarjetaDeCreditoId" },
                values: new object[,]
                {
                    { 1, "Walmart", new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.43m, "551341", 1 },
                    { 2, "Starbucks", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.78m, "454123", 1 },
                    { 3, "Recarga Tigo", new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.00m, "442152", 1 },
                    { 4, "Recarga Tigo", new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.50m, "785424", 1 },
                    { 5, "Farmacia San Nicolás", new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.00m, "623121", 1 },
                    { 6, "Super Selectos", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.76m, "323235", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Compras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Compras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Compras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Compras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Compras",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Compras",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
