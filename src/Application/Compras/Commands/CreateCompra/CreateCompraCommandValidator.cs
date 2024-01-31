using BancoAtlantidaChallenge.Application.Common.Interfaces;
using MediatR;

namespace BancoAtlantidaChallenge.Application.Compras.Commands.CreateCompra;
public class CreateCompraCommandValidator : AbstractValidator<CreateCompraCommand>
{
    public CreateCompraCommandValidator()
    {

        RuleFor(x => x.NewCompra.Monto)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("Parámetro Monto es inválido.");

        RuleFor(x => x.NewCompra.Descripcion)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetro Descripcion es inválido.");

        RuleFor(x => x.NewCompra.Fecha)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetro Fecha es inválido.");

        RuleFor(x => x.NewCompra.TarjetaDeCreditoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetro TarjetaDeCreditoId es inválido.");

    }
}
