using BancoAtlantidaChallenge.Domain.Common;

namespace BancoAtlantidaChallenge.Domain.Entities;
public class TarjetaDeCredito : BaseEntity
{
    public string NumeroDeTarjeta { get; set; } = string.Empty;
    public int Limite { get; set; }
    public decimal SaldoTotal { get; set; }
    public decimal PorcentajeInteresConfigurable { get; set; }
    public decimal PorcentajeConfigurableSaldoMinimo { get; set; }

    public virtual required Cliente Cliente { get; set; }
    public int ClienteId { get; set; }
}
