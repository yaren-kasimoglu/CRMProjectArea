using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DAL.Concrete.EF.Context
{
    public class CRMContext : IdentityDbContext<UserAccount, UserRole, int>
    {
        public CRMContext(DbContextOptions options) : base(options)
        {

        }

    


    }
}
