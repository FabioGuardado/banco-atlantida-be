using BancoAtlantidaChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoAtlantidaChallenge.Infrastructure.Data.Configurations;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.Property(c => c.Nombres).IsRequired();

        builder.Property(c => c.Apellidos).IsRequired();

        builder.HasMany(c => c.TarjetasDeCredito).WithOne(t => t.Cliente).HasForeignKey(t => t.ClienteId);
    }
}
