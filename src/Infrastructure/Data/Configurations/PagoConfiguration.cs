using BancoAtlantidaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoAtlantidaChallenge.Infrastructure.Data.Configurations;
public class PagoConfiguration : IEntityTypeConfiguration<Pago>
{
    public void Configure(EntityTypeBuilder<Pago> builder)
    {
        builder.Property(p => p.NumeroDeAutorizacion).HasMaxLength(6);

        builder.Property(p => p.Fecha).IsRequired();

        builder.HasData(
            new Pago { Id = 1, NumeroDeAutorizacion = "005185", Descripcion = "Pago de TC", Abono = 3.00M, Fecha = new DateTime(2024, 1, 9), TarjetaDeCreditoId = 1 },
            new Pago { Id = 2, NumeroDeAutorizacion = "224235", Descripcion = "Pago de TC", Abono = 12.43M, Fecha = new DateTime(2024, 1, 14), TarjetaDeCreditoId = 1 }
        );
    }
}
