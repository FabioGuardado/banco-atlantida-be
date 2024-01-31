using BancoAtlantidaChallenge.Application.Pagos.Commands.CreatePago;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BancoAtlantidaChallenge.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PagosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PagosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IResult> PostNewPago([FromBody, BindRequired] NewPagoDto newPago)
    {
        await _mediator.Send(new CreatePagoCommand(newPago));
        return Results.Created();
    }
}
