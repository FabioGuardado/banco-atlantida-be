using BancoAtlantidaChallenge.Application.Common.Models;
using BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetAllTarjetasDeCredito;
using BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetTarjetaDeCreditoDetailsById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BancoAtlantidaChallenge.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarjetasDeCreditoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TarjetasDeCreditoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<TarjetaDeCreditoSummaryDto>>> GetAllTarjetasDeCredito([FromQuery, BindRequired] int pageNumber, [FromQuery, BindRequired] int pageSize, [FromQuery] string? searchString)
    {
        return Ok(await _mediator.Send(new GetAllTarjetasDeCreditoQuery(pageNumber, pageSize, searchString)));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<TarjetaDeCreditoDetailDto>> GetTarjetaDeCreditoDetailsById([FromRoute, BindRequired] int id)
    {
        return Ok(await _mediator.Send(new GetTarjetaDeCreditoDetailsByIdQuery(id)));
    }
}
