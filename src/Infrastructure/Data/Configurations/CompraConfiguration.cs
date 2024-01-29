using BancoAtlantidaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoAtlantidaChallenge.Infrastructure.Data.Configurations;
public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.Property(c => c.NumeroDeAutorizacion).HasMaxLength(6);

        builder.Property(c => c.Fecha).IsRequired();

        builder.HasData(
            new Compra { Id = 1, NumeroDeAutorizacion = "551341", Descripcion = "Walmart", Monto = 12.43M, Fecha = new DateTime(2023, 12, 14), TarjetaDeCreditoId = 1 },
            new Compra { Id = 2, NumeroDeAutorizacion = "454123", Descripcion = "Starbucks", Monto = 7.78M, Fecha = new DateTime(2024, 1, 1), TarjetaDeCreditoId = 1 },
            new Compra { Id = 3, NumeroDeAutorizacion = "442152", Descripcion = "Recarga Tigo", Monto = 3.00M, Fecha = new DateTime(2023, 12, 28), TarjetaDeCreditoId = 1 },
            new Compra { Id = 4, NumeroDeAutorizacion = "785424", Descripcion = "Recarga Tigo", Monto = 2.50M, Fecha = new DateTime(2024, 1, 12), TarjetaDeCreditoId = 1 },
            new Compra { Id = 5, NumeroDeAutorizacion = "623121", Descripcion = "Farmacia San Nicolás", Monto = 54.00M, Fecha = new DateTime(2024, 1, 7), TarjetaDeCreditoId = 1 },
            new Compra { Id = 6, NumeroDeAutorizacion = "323235", Descripcion = "Super Selectos", Monto = 34.76M, Fecha = new DateTime(2024, 1, 16), TarjetaDeCreditoId = 1 }
        );
    }
}
