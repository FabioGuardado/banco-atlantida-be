using BancoAtlantidaChallenge.Application.Compras.Queries.GetComprasByTarjetaDeCreditoId;

namespace BancoAtlantidaChallenge.Application.Compras.GetComprasByTarjetaDeCreditoId;
public class GetComprasByTarjetaDeCreditoIdQueryValidator : AbstractValidator<GetComprasByTarjetaDeCreditoIdQuery>
{
    public GetComprasByTarjetaDeCreditoIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThanOrEqualTo(1).WithMessage("Id debe ser un número entero igual o mayor a 1."); ;
    }
}
