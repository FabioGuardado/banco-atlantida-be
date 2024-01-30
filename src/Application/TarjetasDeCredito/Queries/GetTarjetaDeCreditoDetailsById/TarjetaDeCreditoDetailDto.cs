namespace BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetTarjetaDeCreditoDetailsById;
public class TarjetaDeCreditoDetailDto
{
    public int Id { get; set; }
    public string? NumeroDeTarjeta { get; set; }

    public string? TitularDeLaTarjeta { get; set; }

    public int Limite { get; set; }

    public decimal SaldoTotal { get; set; }

    public decimal SaldoDisponible { get; set; }

    public decimal InteresBonificable { get; set; }

    public decimal CuotaMinimaAPagar { get; set; }

    public decimal MontoTotalDeContadoConIntereses { get; set; }
}
