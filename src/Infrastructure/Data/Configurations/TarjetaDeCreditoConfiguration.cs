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
    }
}
