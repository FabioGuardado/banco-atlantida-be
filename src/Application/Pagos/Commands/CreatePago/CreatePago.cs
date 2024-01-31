using BancoAtlantidaChallenge.Application.Common.Interfaces;
using BancoAtlantidaChallenge.Application.Common.Utils;
using BancoAtlantidaChallenge.Application.Compras.Commands.CreateCompra;
using BancoAtlantidaChallenge.Domain.Entities;

namespace BancoAtlantidaChallenge.Application.Pagos.Commands.CreatePago;
public record CreatePagoCommand : IRequest
{
    public NewPagoDto NewPago { get; set; }
    public CreatePagoCommand(NewPagoDto newPago)
    {
        NewPago = newPago;
    }
}

public class CreatePagoCommandHandler : IRequestHandler<CreatePagoCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreatePagoCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(CreatePagoCommand request, CancellationToken cancellationToken)
    {
        if (request.NewPago != null)
        {
            var tarjetaDeCredito = await _context.TarjetasDeCredito.SingleOrDefaultAsync(t => t.Id == request.NewPago.TarjetaDeCreditoId);

            if (tarjetaDeCredito != null)
            {
                var newPago = _mapper.Map<NewPagoDto, Pago>(request.NewPago);
                var nuevoSaldoTotal = tarjetaDeCredito.SaldoTotal - newPago.Abono;

                if (nuevoSaldoTotal > 0)
                {
                    tarjetaDeCredito.SaldoTotal = nuevoSaldoTotal;
                    newPago.NumeroDeAutorizacion = NumeroDeAutorizacion.Generar();
                    _context.Pagos.Add(newPago);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ValidationException("La operación no pudo ser completada debido a que el abono ingresado excede el saldo total a pagar.");
                }
            }
            else
            {
                throw new ValidationException("El Id proporcionado no coincide con ninguna tarjeta de crédito existente.");
            }
        }
    }
}
