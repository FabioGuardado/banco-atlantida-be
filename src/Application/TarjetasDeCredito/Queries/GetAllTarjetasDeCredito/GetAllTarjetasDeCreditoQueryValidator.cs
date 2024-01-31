namespace BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetAllTarjetasDeCredito;
public class GetAllTarjetasDeCreditoQueryValidator : AbstractValidator<GetAllTarjetasDeCreditoQuery>
{
    public GetAllTarjetasDeCreditoQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber debe ser igual o mayor a 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize debe ser igual o mayor a 1.");
    }
}
