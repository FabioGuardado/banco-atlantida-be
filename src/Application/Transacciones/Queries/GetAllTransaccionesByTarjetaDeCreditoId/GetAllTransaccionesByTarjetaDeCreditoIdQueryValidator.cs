namespace BancoAtlantidaChallenge.Application.Transacciones.Queries.GetAllTransaccionesByTarjetaDeCreditoId;
public class GetAllTransaccionesByTarjetaDeCreditoIdQueryValidator : AbstractValidator<GetAllTransaccionesByTarjetaDeCreditoIdQuery>
{
    public GetAllTransaccionesByTarjetaDeCreditoIdQueryValidator()
    {
        RuleFor(x => x.TarjetaDeCreditoId)
            .GreaterThanOrEqualTo(1).WithMessage("Id debe ser un número entero igual o mayor a 1.");
    }
}
