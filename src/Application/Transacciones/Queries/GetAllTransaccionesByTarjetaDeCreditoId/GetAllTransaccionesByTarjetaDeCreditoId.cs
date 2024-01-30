using System.Linq;
using BancoAtlantidaChallenge.Application.Common.Interfaces;
using BancoAtlantidaChallenge.Application.Common.Mappings;
using BancoAtlantidaChallenge.Application.Common.Models;
using BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetTarjetaDeCreditoDetailsById;

namespace BancoAtlantidaChallenge.Application.Transacciones.Queries.GetAllTransaccionesByTarjetaDeCreditoId;
public record GetAllTransaccionesByTarjetaDeCreditoIdQuery : IRequest<PaginatedList<TransaccionDto>>
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
    public int Id { get; set; }

    public GetAllTransaccionesByTarjetaDeCreditoIdQuery(int pageNumber, int pageSize, int id)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Id = id;
    }
}

public class GetAllTransaccionesByTarjetaDeCreditoIdQueryHandler : IRequestHandler<GetAllTransaccionesByTarjetaDeCreditoIdQuery, PaginatedList<TransaccionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTransaccionesByTarjetaDeCreditoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TransaccionDto>> Handle(GetAllTransaccionesByTarjetaDeCreditoIdQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Compras
            .Where(c => c.TarjetaDeCreditoId == request.Id)
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
                .Where(p => p.TarjetaDeCreditoId == request.Id)
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
            .OrderByDescending(x => x.Fecha)
            .ProjectTo<TransaccionDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

    }
}
