using BancoAtlantidaChallenge.Application.Common.Models;
using BancoAtlantidaChallenge.Application.Transacciones.Queries.GetAllTransaccionesByTarjetaDeCreditoId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BancoAtlantidaChallenge.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransaccionesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransaccionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<TransaccionDto>>> GetAllTransacciones([FromQuery, BindRequired] int pageNumber, [FromQuery, BindRequired] int pageSize, [FromQuery, BindRequired] int id)
    {
        return Ok(await _mediator.Send(new GetAllTransaccionesByTarjetaDeCreditoIdQuery(pageNumber, pageSize, id)));
    }
}
