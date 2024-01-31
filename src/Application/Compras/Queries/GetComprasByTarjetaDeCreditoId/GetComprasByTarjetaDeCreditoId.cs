using BancoAtlantidaChallenge.Application.Common.Interfaces;
using BancoAtlantidaChallenge.Application.Common.Mappings;

namespace BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;
public record GetComprasByTarjetaDeCreditoIdQuery : IRequest<CompraSummaryDto>
{
    public int Id { get; set; }

    public GetComprasByTarjetaDeCreditoIdQuery(int id)
    {
        Id = id;
    }

    public class GetComprasByTarjetaDeCreditoId : IRequestHandler<GetComprasByTarjetaDeCreditoIdQuery, CompraSummaryDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetComprasByTarjetaDeCreditoId(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompraSummaryDto> Handle(GetComprasByTarjetaDeCreditoIdQuery request, CancellationToken cancellationToken)
        {
            var compras = await _context.Compras
                .Where(c => c.TarjetaDeCreditoId == request.Id)
                .Where(c => c.Fecha >= DateTime.Today.AddMonths(-1))
                .OrderByDescending(c => c.Fecha)
                .ProjectToListAsync<CompraDto>(_mapper.ConfigurationProvider);

            var comprasTotalesMesPasado = await _context.Compras
                .Where(c => c.TarjetaDeCreditoId == request.Id)
                .Where(c => c.Fecha <= DateTime.Today.AddMonths(-1) && c.Fecha >= DateTime.Today.AddMonths(-2)).SumAsync(c => c.Monto);

            var comprasTotalesMesActual = await _context.Compras
                .Where(c => c.TarjetaDeCreditoId == request.Id)
                .Where(c => c.Fecha >= DateTime.Today.AddMonths(-1)).SumAsync(c => c.Monto);

            return new CompraSummaryDto { Compras = compras, ComprasTotalesMesPasado = comprasTotalesMesPasado, ComprasTotalesMesActual = comprasTotalesMesActual };
        }
    }
}
