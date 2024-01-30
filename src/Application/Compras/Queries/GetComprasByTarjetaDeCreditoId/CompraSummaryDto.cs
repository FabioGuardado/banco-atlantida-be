using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;
public class CompraSummaryDto
{
    public int Id { get; set; }
    public string? NumeroDeAutorizacion { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal Monto { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Compra, CompraSummaryDto>();
        }
    }
}
