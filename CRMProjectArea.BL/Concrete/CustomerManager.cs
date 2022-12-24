using CRMProjectArea.BL.Abstract;
using CRMProjectArea.DAL.Abstract;
using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.BL.Concrete
{
    public class CustomerManager : ICustomerManager
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly HttpContextAccessor _context;
        private readonly ICustomerRepository repo;

        public CustomerManager(ICustomerRepository _repo)
        {
            this.repo = _repo;
        }
        public async Task Add(Customer entity)
        {
            var user = await _userManager.GetUserAsync(_context.HttpContext.User);
            bool isCustomerCreate = await _userManager.IsInRoleAsync(user, "CustomerCreate");
            if (isCustomerCreate)
            {

            }
            else
            {
                throw new Exception("Yetkiniz bulunmuyor");
            }
        }

        public async Task Delete(Customer entity)
        {
            var user = await _userManager.GetUserAsync(_context.HttpContext.User);
            bool isCustomerDelete = await _userManager.IsInRoleAsync(user, "CustomerDelete");
            if (isCustomerDelete)
            {


            }
            else
            {
                throw new Exception("Yetkiniz bulunmuyor");
            }
        }

        public async Task<Customer> GetById(int id)
        {
            var user = await _userManager.GetUserAsync(_context.HttpContext.User);
            bool isCustomerDetail = await _userManager.IsInRoleAsync(user, "CustomerDetail");

            return new Customer();
        }

        public async Task<IEnumerable<Customer>> Select(Expression<Func<Customer, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
