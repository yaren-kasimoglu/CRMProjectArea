using CRMProjectArea.DAL.Concrete.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DAL.Concrete.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CRMContext>
    {
        public CRMContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<CRMContext>();
            string connectionString = config.GetConnectionString("DB");
            builder.UseSqlServer(connectionString);
            return new CRMContext(builder.Options);
        }
    }
}
