using FluentValidation;
using PruebaKhensys.Core.Entities.DTOS;

namespace PruebaKhensys.Infrastructure.Validators
{
    public class RoleValidator : AbstractValidator<RoleDTO>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Description).NotNull();
        }
    }
}
