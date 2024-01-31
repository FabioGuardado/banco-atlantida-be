using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetAllTarjetasDeCredito;

public class ClienteSummaryDto
{
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
}

public class TarjetaDeCreditoSummaryDto
{
    public int Id { get; set; }
    public string? NumeroDeTarjeta { get; set; }
    public decimal SaldoTotal { get; set; }
    public int Limite { get; set; }

    public ClienteSummaryDto? Cliente { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TarjetaDeCredito, TarjetaDeCreditoSummaryDto>();
            CreateMap<Cliente, ClienteSummaryDto>();
        }
    }
}
