using FluentValidation;
using PruebaKhensys.Core.Entities.DTOS;

namespace PruebaKhensys.Infrastructure.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator(IValidator<ExcuseTypeDTO> excuseTypeValidator)
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.ExcuseType).NotNull();
            RuleFor(x => x.ExcuseType).SetValidator(excuseTypeValidator);
        }
    }
}
