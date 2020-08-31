using FluentValidation;
using PruebaKhensys.Core.Entities.DTOS;

namespace PruebaKhensys.Infrastructure.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator(IValidator<RoleDTO> roleValidator)
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.Role).NotNull();
            RuleFor(x => x.Role).SetValidator(roleValidator);
        }
    }
}
