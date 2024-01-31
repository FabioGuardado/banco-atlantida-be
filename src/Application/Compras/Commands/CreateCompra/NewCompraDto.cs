using BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;
using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.Compras.Commands.CreateCompra;
public class NewCompraDto
{
    public DateTime? Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal Monto { get; set; }
    public int TarjetaDeCreditoId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Compra, NewCompraDto>();
            CreateMap<NewCompraDto, Compra>();
        }
    }
}
