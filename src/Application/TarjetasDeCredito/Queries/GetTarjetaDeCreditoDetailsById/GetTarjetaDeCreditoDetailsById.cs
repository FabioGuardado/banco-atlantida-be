using BancoAtlantidaChallenge.Application.Common.Interfaces;

namespace BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetTarjetaDeCreditoDetailsById;
public record GetTarjetaDeCreditoDetailsByIdQuery : IRequest<TarjetaDeCreditoDetailDto>
{
    public int Id { get; set; }

    public GetTarjetaDeCreditoDetailsByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetTarjetaDeCreditoDetailsByIdHandler : IRequestHandler<GetTarjetaDeCreditoDetailsByIdQuery, TarjetaDeCreditoDetailDto>
{
    private readonly IApplicationDbContext _context;

    public GetTarjetaDeCreditoDetailsByIdHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TarjetaDeCreditoDetailDto> Handle(GetTarjetaDeCreditoDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var tarjetaDeCredito = await _context.TarjetasDeCredito.Include(t => t.Cliente).SingleOrDefaultAsync(t => t.Id == request.Id);

        if (tarjetaDeCredito != null)
        {
            var interesBonificable = (tarjetaDeCredito.SaldoTotal * tarjetaDeCredito.PorcentajeInteresConfigurable) / 100;
            var result = new TarjetaDeCreditoDetailDto
            {
                Id = tarjetaDeCredito.Id,
                NumeroDeTarjeta = tarjetaDeCredito.NumeroDeTarjeta,
                Limite = tarjetaDeCredito.Limite,
                TitularDeLaTarjeta = tarjetaDeCredito.Cliente.Nombres + tarjetaDeCredito.Cliente.Apellidos,
                SaldoTotal = tarjetaDeCredito.SaldoTotal,
                SaldoDisponible = tarjetaDeCredito.Limite - tarjetaDeCredito.SaldoTotal,
                InteresBonificable = interesBonificable,
                CuotaMinimaAPagar = (tarjetaDeCredito.SaldoTotal * tarjetaDeCredito.PorcentajeConfigurableSaldoMinimo) / 100,
                MontoTotalDeContadoConIntereses = tarjetaDeCredito.SaldoTotal + interesBonificable,
            };

            return result;
        }

        throw new NotFoundException("Id", "Tarjeta de Credito");
    }
}
