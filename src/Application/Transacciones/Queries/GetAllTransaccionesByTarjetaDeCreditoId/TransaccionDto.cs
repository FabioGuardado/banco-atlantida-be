using BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;
using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.Transacciones.Queries.GetAllTransaccionesByTarjetaDeCreditoId;
public class TransaccionDto
{
    public int Id { get; set; }
    public string? NumeroDeAutorizacion { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal? Abono { get; set; }
    public decimal? Monto { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Compra, TransaccionDto>();
            CreateMap<Pago, TransaccionDto>();
            CreateMap<TransaccionDto, TransaccionDto>();
        }
    }
}
