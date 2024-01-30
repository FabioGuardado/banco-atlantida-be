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
    }
}
