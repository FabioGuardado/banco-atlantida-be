using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.Pagos.Commands.CreatePago;
public class NewPagoDto
{
    public DateTime? Fecha { get; set; }
    public string? Descripcion { get; set; }
    public decimal Abono { get; set; }
    public int TarjetaDeCreditoId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Pago, NewPagoDto>();
            CreateMap<NewPagoDto, Pago>();
        }
    }
}
