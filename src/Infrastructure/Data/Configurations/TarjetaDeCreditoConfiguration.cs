using BancoAtlantidaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoAtlantidaChallenge.Infrastructure.Data.Configurations;
public class TarjetaDeCreditoConfiguration : IEntityTypeConfiguration<TarjetaDeCredito>
{
    public void Configure(EntityTypeBuilder<TarjetaDeCredito> builder)
    {
        builder.Property(t => t.NumeroDeTarjeta).IsRequired();

        builder.Property(t => t.PorcentajeInteresConfigurable).HasPrecision(5, 2);

        builder.Property(t => t.PorcentajeConfigurableSaldoMinimo).HasPrecision(5, 2);

        builder.HasData(
            new TarjetaDeCredito { Id = 1, NumeroDeTarjeta = "5454-8513-1122-3150", Limite = 2000, SaldoTotal = 114.47M, PorcentajeConfigurableSaldoMinimo = 5, PorcentajeInteresConfigurable = 25, ClienteId = 1 },
            new TarjetaDeCredito { Id = 2, NumeroDeTarjeta = "4345-6212-8713-2152", Limite = 600, SaldoTotal = 0, PorcentajeConfigurableSaldoMinimo = 5, PorcentajeInteresConfigurable = 20, ClienteId = 1 },
            new TarjetaDeCredito { Id = 3, NumeroDeTarjeta = "5695-1245-3572-6197", Limite = 1000, SaldoTotal = 549.30M, PorcentajeConfigurableSaldoMinimo = 10, PorcentajeInteresConfigurable = 30, ClienteId = 2 }
        );
    }
}
