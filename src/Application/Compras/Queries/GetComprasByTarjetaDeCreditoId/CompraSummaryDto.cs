using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;

public class CompraDto
{
    public int Id { get; set; }
    public string? NumeroDeAutorizacion { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal Monto { get; set; }

}

public class CompraSummaryDto
{

    public IEnumerable<CompraDto>? Compras { get; set; }
    public decimal ComprasTotalesMesPasado { get; set; }
    public decimal ComprasTotalesMesActual { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Compra, CompraDto>();
        }
    }
}
