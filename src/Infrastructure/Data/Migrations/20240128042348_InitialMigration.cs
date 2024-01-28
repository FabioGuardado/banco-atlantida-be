using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoAtlantidaChallenge.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TarjetasDeCredito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Limite = table.Column<int>(type: "int", nullable: false),
                    SaldoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajeInteresConfigurable = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    PorcentajeConfigurableSaldoMinimo = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetasDeCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarjetasDeCredito_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeAutorizacion = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarjetaDeCreditoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_TarjetasDeCredito_TarjetaDeCreditoId",
                        column: x => x.TarjetaDeCreditoId,
                        principalTable: "TarjetasDeCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeAutorizacion = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abono = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarjetaDeCreditoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_TarjetasDeCredito_TarjetaDeCreditoId",
                        column: x => x.TarjetaDeCreditoId,
                        principalTable: "TarjetasDeCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_TarjetaDeCreditoId",
                table: "Compras",
                column: "TarjetaDeCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TarjetaDeCreditoId",
                table: "Pagos",
                column: "TarjetaDeCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetasDeCredito_ClienteId",
                table: "TarjetasDeCredito",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "TarjetasDeCredito");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
