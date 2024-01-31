namespace BancoAtlantidaChallenge.Application.Pagos.Commands.CreatePago;
public class CreatePagoCommandValidator : AbstractValidator<CreatePagoCommand>
{
    public CreatePagoCommandValidator()
    {

        RuleFor(x => x.NewPago)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetros inválidos para crear nuevo pago.");

    }
}
