﻿// <auto-generated />
using System;
using BancoAtlantidaChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancoAtlantidaChallenge.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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