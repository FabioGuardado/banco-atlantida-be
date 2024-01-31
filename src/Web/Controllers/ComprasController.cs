using BancoAtlantidaChallenge.Application.Compras.Commands.CreateCompra;
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
    public async Task<IEnumerable<CompraSummaryDto>> GetComprasByTarjetaDeCreditoId([FromQuery, BindRequired] int id)
    {
        return await _mediator.Send(new GetComprasByTarjetaDeCreditoIdQuery(id));
    }

    [HttpPost]
    public async Task<IResult> PostNewCompra([FromBody, BindRequired] NewCompraDto newCompra)
    {
        await _mediator.Send(new CreateCompraCommand(newCompra));
        return Results.Created();
    }
}
