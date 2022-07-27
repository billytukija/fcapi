using FluentValidation;
using found_church_api.DataObjectTransfert;

namespace found_church_api.Validatores
{
    public class ChurchValidator: AbstractValidator<AddChurchDto>
    {
        public ChurchValidator()
        {
            RuleFor(x => x.ChurchName).NotEmpty().WithMessage("Church name is empty");
            RuleFor(x => x.PastorName).NotEmpty().WithMessage("Pastor name is empty");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country name is empty");
            RuleFor(x => x.State).NotEmpty().WithMessage("State name is empty");
            RuleFor(x => x.City).NotEmpty().WithMessage("City name is empty");
            RuleFor(x => x.Neighborhood).NotEmpty().WithMessage("Neighborhood name is empty");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street name is empty");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number name is empty");
            RuleFor(x => x.NameProvider).NotEmpty().WithMessage("Provider name is empty");
            RuleFor(x => x.EmailProvider).NotEmpty().WithMessage("Provider email is empty");
            RuleFor(x => x.EmailProvider).EmailAddress().WithMessage("Provider email is not valid");
        }
    }
}
