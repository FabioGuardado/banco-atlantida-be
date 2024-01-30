﻿// <auto-generated />
using System;
using BancoAtlantidaChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoAtlantidaChallenge.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240129233112_SeedComprasTable")]
    partial class SeedComprasTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Castro",
                            Nombres = "David"
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "Martinez",
                            Nombres = "Jose"
                        });
                });

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroDeAutorizacion")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("TarjetaDeCreditoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarjetaDeCreditoId");

                    b.ToTable("Compras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Walmart",
                            Fecha = new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 12.43m,
                            NumeroDeAutorizacion = "551341",
                            TarjetaDeCreditoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Starbucks",
                            Fecha = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 7.78m,
                            NumeroDeAutorizacion = "454123",
                            TarjetaDeCreditoId = 1
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Recarga Tigo",
                            Fecha = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 3.00m,
                            NumeroDeAutorizacion = "442152",
                            TarjetaDeCreditoId = 1
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Recarga Tigo",
                            Fecha = new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2.50m,
                            NumeroDeAutorizacion = "785424",
                            TarjetaDeCreditoId = 1
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Farmacia San Nicolás",
                            Fecha = new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 54.00m,
                            NumeroDeAutorizacion = "623121",
                            TarjetaDeCreditoId = 1
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Super Selectos",
                            Fecha = new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 34.76m,
                            NumeroDeAutorizacion = "323235",
                            TarjetaDeCreditoId = 1
                        });
                });

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Abono")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroDeAutorizacion")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("TarjetaDeCreditoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarjetaDeCreditoId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.TarjetaDeCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Limite")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDeTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PorcentajeConfigurableSaldoMinimo")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("PorcentajeInteresConfigurable")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("SaldoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TarjetasDeCredito");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1,
                            Limite = 2000,
                            NumeroDeTarjeta = "5454-8513-1122-3150",
                            PorcentajeConfigurableSaldoMinimo = 5m,
                            PorcentajeInteresConfigurable = 25m,
                            SaldoTotal = 114.47m
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 1,
                            Limite = 600,
                            NumeroDeTarjeta = "4345-6212-8713-2152",
                            PorcentajeConfigurableSaldoMinimo = 5m,
                            PorcentajeInteresConfigurable = 20m,
                            SaldoTotal = 0m
                        },
                        new
                        {
                            Id = 3,
                            ClienteId = 2,
                            Limite = 1000,
                            NumeroDeTarjeta = "5695-1245-3572-6197",
                            PorcentajeConfigurableSaldoMinimo = 10m,
                            PorcentajeInteresConfigurable = 30m,
                            SaldoTotal = 549.30m
                        });
                });

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.Compra", b =>
                {
                    b.HasOne("BancoAtlantidaChallenge.Domain.Entities.TarjetaDeCredito", "TarjetaDeCredito")
                        .WithMany()
                        .HasForeignKey("TarjetaDeCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TarjetaDeCredito");
                });

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.Pago", b =>
                {
                    b.HasOne("BancoAtlantidaChallenge.Domain.Entities.TarjetaDeCredito", "TarjetaDeCredito")
                        .WithMany()
                        .HasForeignKey("TarjetaDeCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TarjetaDeCredito");
                });

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.TarjetaDeCredito", b =>
                {
                    b.HasOne("BancoAtlantidaChallenge.Domain.Entities.Cliente", "Cliente")
                        .WithMany("TarjetasDeCredito")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("BancoAtlantidaChallenge.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("TarjetasDeCredito");
                });
#pragma warning restore 612, 618
        }
    }
}
