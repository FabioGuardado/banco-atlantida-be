using BancoAtlantidaChallenge.Domain.Common;

namespace BancoAtlantidaChallenge.Domain.Entities;
public class Pago : BaseEntity
{
    public string? NumeroDeAutorizacion { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal Abono { get; set; }
    public int TarjetaDeCreditoId { get; set; }
    public TarjetaDeCredito? TarjetaDeCredito { get; set; }
}
