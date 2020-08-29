using Microsoft.EntityFrameworkCore;
using PruebaKhensys.Core.Entities.Models;
using PruebaKhensys.Core.Interfaces.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaKhensys.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : Repository<Role>, IRolesRepositories
    {
        public RoleRepository(DbSet<Role> roles) : base (roles)
        {

        }
    }
}
