using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BancoAtlantidaChallenge.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPagosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "Abono", "Descripcion", "Fecha", "NumeroDeAutorizacion", "TarjetaDeCreditoId" },
                values: new object[,]
                {
                    { 1, 3.00m, "Pago de TC", new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "005185", 1 },
                    { 2, 12.43m, "Pago de TC", new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "224235", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
