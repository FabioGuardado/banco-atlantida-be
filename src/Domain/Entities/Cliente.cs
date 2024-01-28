using BancoAtlantidaChallenge.Domain.Common;

namespace BancoAtlantidaChallenge.Domain.Entities;
public class Cliente : BaseEntity
{
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public ICollection<TarjetaDeCredito>? TarjetasDeCredito { get; set; }
}
