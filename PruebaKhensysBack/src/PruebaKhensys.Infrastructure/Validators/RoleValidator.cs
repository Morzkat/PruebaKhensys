using FluentValidation;
using PruebaKhensys.Core.Entities.DTOS;

namespace PruebaKhensys.Infrastructure.Validators
{
    public class ExcuseTypeValidator : AbstractValidator<ExcuseTypeDTO>
    {
        public ExcuseTypeValidator()
        {
            RuleFor(x => x.Description).NotNull();
        }
    }
}
