namespace BancoAtlantidaChallenge.Application.Transacciones.Queries.GetAllTransaccionesByTarjetaDeCreditoId;
public class GetAllTransaccionesByTarjetaDeCreditoIdQueryValidator : AbstractValidator<GetAllTransaccionesByTarjetaDeCreditoIdQuery>
{
    public GetAllTransaccionesByTarjetaDeCreditoIdQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber debe ser igual o mayor a 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize debe ser igual o mayor a 1.");

        RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(1).WithMessage("Id debe ser un número entero igual o mayor a 1.");
    }
}
