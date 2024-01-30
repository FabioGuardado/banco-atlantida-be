using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAtlantidaChallenge.Application.TarjetasDeCredito.Queries.GetTarjetaDeCreditoDetailsById;
internal class GetTarjetaDeCreditoDetailsByIdQueryValidator : AbstractValidator<GetTarjetaDeCreditoDetailsByIdQuery>
{
    public GetTarjetaDeCreditoDetailsByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThanOrEqualTo(1).WithMessage("Id debe ser un número entero igual o mayor a 1."); ;
    }
}
