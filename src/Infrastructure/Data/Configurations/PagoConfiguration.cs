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
    }
}
