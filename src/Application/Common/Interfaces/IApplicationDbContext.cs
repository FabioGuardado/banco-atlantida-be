using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Cliente> Clientes { get; }
    DbSet<TarjetaDeCredito> TarjetasDeCredito { get; }
    DbSet<Compra> Compras { get; }
    DbSet<Pago> Pagos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
