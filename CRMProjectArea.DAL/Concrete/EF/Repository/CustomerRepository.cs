using CRMProjectArea.DAL.Abstract;
using CRMProjectArea.DAL.Concrete.EF.Context;
using CRMProjectArea.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DAL.Concrete.EF.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private CRMContext _dbContext;
        public CustomerRepository(CRMContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
