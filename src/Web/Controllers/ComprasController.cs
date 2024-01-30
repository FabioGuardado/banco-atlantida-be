using BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BancoAtlantidaChallenge.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComprasController : ControllerBase
{
    private readonly IMediator _mediator;

    public ComprasController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompraSummaryDto>>> GetComprasByTarjetaDeCreditoId([FromQuery, BindRequired] int id)
    {
        return Ok(await _mediator.Send(new GetComprasByTarjetaDeCreditoIdQuery(id)));
    }
}
