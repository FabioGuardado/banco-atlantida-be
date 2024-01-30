using BancoAtlantidaChallenge.Application.Common.Interfaces;
using BancoAtlantidaChallenge.Application.Common.Mappings;

namespace BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;
public record GetComprasByTarjetaDeCreditoIdQuery : IRequest<IEnumerable<CompraSummaryDto>>
{
    public int Id { get; set; }

    public GetComprasByTarjetaDeCreditoIdQuery(int id)
    {
        Id = id;
    }

    public class GetComprasByTarjetaDeCreditoId : IRequestHandler<GetComprasByTarjetaDeCreditoIdQuery, IEnumerable<CompraSummaryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetComprasByTarjetaDeCreditoId(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompraSummaryDto>> Handle(GetComprasByTarjetaDeCreditoIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Compras
                .Where(c => c.TarjetaDeCreditoId == request.Id)
                .Where(c => c.Fecha >= DateTime.Today.AddMonths(-1))
                .OrderByDescending(c => c.Fecha)
                .ProjectToListAsync<CompraSummaryDto>(_mapper.ConfigurationProvider);
        }
    }
}
