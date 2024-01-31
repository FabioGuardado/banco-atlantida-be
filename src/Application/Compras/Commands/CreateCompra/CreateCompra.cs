using BancoAtlantidaChallenge.Application.Common.Interfaces;
using BancoAtlantidaChallenge.Domain.Entities;
using BancoAtlantidaChallenge.Application.Common.Utils;

namespace BancoAtlantidaChallenge.Application.Compras.Commands.CreateCompra;
public record CreateCompraCommand : IRequest
{
    public NewCompraDto NewCompra { get; set; }
    public CreateCompraCommand(NewCompraDto newCompra)
    {
        NewCompra = newCompra;
    }
}

public class CreateCompraCommandHandler : IRequestHandler<CreateCompraCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateCompraCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(CreateCompraCommand request, CancellationToken cancellationToken)
    {
        if (request.NewCompra != null)
        {
            var tarjetaDeCredito = await _context.TarjetasDeCredito.SingleOrDefaultAsync(t => t.Id == request.NewCompra.TarjetaDeCreditoId);

            if (tarjetaDeCredito != null)
            {
                var newCompra = _mapper.Map<NewCompraDto, Compra>(request.NewCompra);
                var nuevoSaldoTotal = tarjetaDeCredito.SaldoTotal + newCompra.Monto;

                if (nuevoSaldoTotal <= tarjetaDeCredito.Limite)
                {
                    tarjetaDeCredito.SaldoTotal = nuevoSaldoTotal;
                    newCompra.NumeroDeAutorizacion = NumeroDeAutorizacion.Generar();
                    _context.Compras.Add(newCompra);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ValidationException("La operación no pudo ser completada debido a que el monto ingresado supera el limite de la tarjeta de crédito.");
                }
            }
            else
            {
                throw new ValidationException("El Id proporcionado no coincide con ninguna tarjeta de crédito existente.");
            }
        }
    }
}
