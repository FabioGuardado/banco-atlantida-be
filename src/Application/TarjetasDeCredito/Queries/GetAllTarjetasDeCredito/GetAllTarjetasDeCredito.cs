using BancoAtlantidaChallenge.Application.Common.Interfaces;
using BancoAtlantidaChallenge.Application.Common.Mappings;
using BancoAtlantidaChallenge.Application.Common.Models;
using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetAllTarjetasDeCredito;
public record GetAllTarjetasDeCreditoQuery : IRequest<PaginatedList<TarjetaDeCreditoSummaryDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchString { get; set; }

    public GetAllTarjetasDeCreditoQuery(int pageNumber, int pageSize, string? searchString = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
    }
}

public class GetAllTarjetasDeCreditoQueryHandler : IRequestHandler<GetAllTarjetasDeCreditoQuery, PaginatedList<TarjetaDeCreditoSummaryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTarjetasDeCreditoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TarjetaDeCreditoSummaryDto>> Handle(GetAllTarjetasDeCreditoQuery request, CancellationToken cancellationToken)
    {
        var tarjetasDeCredito = _context.TarjetasDeCredito
            .Include(t => t.Cliente)
            .AsQueryable();

        if (request.SearchString != null)
        {
            var keyword = "%" + request.SearchString + "%";
            tarjetasDeCredito = tarjetasDeCredito.Where(t =>
                EF.Functions.Like(t.NumeroDeTarjeta, keyword) ||
                EF.Functions.Like(t.Cliente.Nombres, keyword) ||
                EF.Functions.Like(t.Cliente.Apellidos, keyword)
            );
        }

        return await tarjetasDeCredito
            .ProjectTo<TarjetaDeCreditoSummaryDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
