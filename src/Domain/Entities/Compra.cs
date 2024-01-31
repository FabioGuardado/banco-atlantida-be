using BancoAtlantidaChallenge.Domain.Common;

namespace BancoAtlantidaChallenge.Domain.Entities;
public class Compra : BaseEntity
{
    public string? NumeroDeAutorizacion { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal Monto { get; set; }
    public int TarjetaDeCreditoId { get; set; }
    public TarjetaDeCredito? TarjetaDeCredito { get; set; }
}
