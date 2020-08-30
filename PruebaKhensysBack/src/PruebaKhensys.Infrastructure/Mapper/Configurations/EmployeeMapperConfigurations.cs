using AgileObjects.AgileMapper.Configuration;
using PruebaKhensys.Core.Entities.DTOS;
using PruebaKhensys.Core.Entities.Models;

namespace PruebaKhensys.Infrastructure.AppMapper.Configurations
{
    public class EmployeeMapperConfigurations : MapperConfiguration
    {
        protected override void Configure()
        {
            WhenMapping.From<Employee>().ToANew<EmployeeDTO>()
                .Map(ctx => ctx.Source.Date.ToString("MM/dd/yyyy"))
                .To(dto => dto.Date);
        }
    }

}
