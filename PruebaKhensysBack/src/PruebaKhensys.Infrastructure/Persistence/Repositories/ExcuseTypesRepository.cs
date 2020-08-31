using Microsoft.EntityFrameworkCore;
using PruebaKhensys.Core.Entities.Models;
using PruebaKhensys.Core.Interfaces.Persistence.Repositories;

namespace PruebaKhensys.Infrastructure.Persistence.Repositories
{
    public class ExcuseTypeRepository : Repository<ExcuseType>, IExcuseTypesRepositories
    {
        public ExcuseTypeRepository(DbSet<ExcuseType> excuseTypes) : base (excuseTypes)
        {

        }
    }
}
