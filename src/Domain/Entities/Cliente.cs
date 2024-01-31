using BancoAtlantidaChallenge.Domain.Common;

namespace BancoAtlantidaChallenge.Domain.Entities;
public class Cliente : BaseEntity
{
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public ICollection<TarjetaDeCredito>? TarjetasDeCredito { get; set; }
}
