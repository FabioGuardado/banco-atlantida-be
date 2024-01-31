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
    public async Task<IEnumerable<TransaccionDto>> GetAllTransacciones([FromQuery, BindRequired] int tarjetaDeCreditoId)
    {
        return await _mediator.Send(new GetAllTransaccionesByTarjetaDeCreditoIdQuery(tarjetaDeCreditoId));
    }
}
