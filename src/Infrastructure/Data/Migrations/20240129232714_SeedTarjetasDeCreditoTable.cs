using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BancoAtlantidaChallenge.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTarjetasDeCreditoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TarjetasDeCredito",
                columns: new[] { "Id", "ClienteId", "Limite", "NumeroDeTarjeta", "PorcentajeConfigurableSaldoMinimo", "PorcentajeInteresConfigurable", "SaldoTotal" },
                values: new object[,]
                {
                    { 1, 1, 2000, "5454-8513-1122-3150", 5m, 25m, 114.47m },
                    { 2, 1, 600, "4345-6212-8713-2152", 5m, 20m, 0m },
                    { 3, 2, 1000, "5695-1245-3572-6197", 10m, 30m, 549.30m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TarjetasDeCredito",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TarjetasDeCredito",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TarjetasDeCredito",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
