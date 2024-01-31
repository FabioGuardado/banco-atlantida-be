namespace BancoAtlantidaChallenge.Application.Pagos.Commands.CreatePago;
public class CreatePagoCommandValidator : AbstractValidator<CreatePagoCommand>
{
    public CreatePagoCommandValidator()
    {

        RuleFor(x => x.NewPago.Abono)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("Parámetro Abono es inválido.");

        RuleFor(x => x.NewPago.Descripcion)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetro Descripcion es inválido.");

        RuleFor(x => x.NewPago.Fecha)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetro Fecha es inválido.");

        RuleFor(x => x.NewPago.TarjetaDeCreditoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetro TarjetaDeCreditoId es inválido.");

    }
}
