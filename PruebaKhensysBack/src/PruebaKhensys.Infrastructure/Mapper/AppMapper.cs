using AgileObjects.AgileMapper;
using AgileObjects.AgileMapper.Configuration;
using PruebaKhensys.Infrastructure.AppMapper.Configurations;

namespace PruebaKhensys.Infrastructure.AppMapper
{

    public interface IAppMapper
    {
        public X MapToANew<T, X>(T source);
    }

    public class AppMapper : IAppMapper
    {
        public IMapper mapper { get; private set; }

        public AppMapper()
        {
            mapper = Mapper.CreateNew();
            ConfigureMapper();

        }

        public X MapToANew<T, X>(T source) => mapper.Map(source).ToANew<X>();

        protected void ConfigureMapper()
        {
            mapper.WhenMapping.UseConfigurations.From<EmployeeMapperConfigurations>();
        }

    }
}
