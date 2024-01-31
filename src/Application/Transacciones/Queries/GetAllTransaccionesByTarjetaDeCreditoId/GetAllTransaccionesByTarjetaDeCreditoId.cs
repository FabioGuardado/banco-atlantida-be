using System.Linq;
using BancoAtlantidaChallenge.Application.Common.Interfaces;
using BancoAtlantidaChallenge.Application.Common.Mappings;
using BancoAtlantidaChallenge.Application.Common.Models;
using BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetTarjetaDeCreditoDetailsById;

namespace BancoAtlantidaChallenge.Application.Transacciones.Queries.GetAllTransaccionesByTarjetaDeCreditoId;
public record GetAllTransaccionesByTarjetaDeCreditoIdQuery : IRequest<IEnumerable<TransaccionDto>>
{
    public int TarjetaDeCreditoId { get; set; }

    public GetAllTransaccionesByTarjetaDeCreditoIdQuery(int tarjetaDeCreditoId)
    {
        TarjetaDeCreditoId = tarjetaDeCreditoId;
    }
}

public class GetAllTransaccionesByTarjetaDeCreditoIdQueryHandler : IRequestHandler<GetAllTransaccionesByTarjetaDeCreditoIdQuery, IEnumerable<TransaccionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTransaccionesByTarjetaDeCreditoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TransaccionDto>> Handle(GetAllTransaccionesByTarjetaDeCreditoIdQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Compras
            .Where(c => c.TarjetaDeCreditoId == request.TarjetaDeCreditoId)
            .Select(c => new TransaccionDto
            {
                Id = c.Id,
                Descripcion = c.Descripcion,
                NumeroDeAutorizacion = c.NumeroDeAutorizacion,
                Fecha = c.Fecha,
                Monto = c.Monto,
                Abono = null
            })
            .Union(_context.Pagos
                .Where(p => p.TarjetaDeCreditoId == request.TarjetaDeCreditoId)
                .Select(p => new TransaccionDto
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    NumeroDeAutorizacion = p.NumeroDeAutorizacion,
                    Fecha = p.Fecha,
                    Abono = p.Abono,
                    Monto = null
                })
            ); ;

        return await result
            .Where(c => c.Fecha >= DateTime.Today.AddMonths(-1))
            .OrderByDescending(x => x.Fecha)
            .ProjectToListAsync<TransaccionDto>(_mapper.ConfigurationProvider);

    }
}
