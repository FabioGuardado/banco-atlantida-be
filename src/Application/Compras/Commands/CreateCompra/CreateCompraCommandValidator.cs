using BancoAtlantidaChallenge.Application.Common.Interfaces;
using MediatR;

namespace BancoAtlantidaChallenge.Application.Compras.Commands.CreateCompra;
public class CreateCompraCommandValidator : AbstractValidator<CreateCompraCommand>
{
    public CreateCompraCommandValidator()
    {

        RuleFor(x => x.NewCompra)
            .NotNull()
            .NotEmpty()
            .WithMessage("Parámetros inválidos para crear nueva compra.");

    }
}
