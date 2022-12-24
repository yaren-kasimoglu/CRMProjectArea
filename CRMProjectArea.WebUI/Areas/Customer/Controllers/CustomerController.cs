using CRMProjectArea.BL.Abstract;
using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace CRMProjectArea.WebUI.Areas.Customer.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("customer")]
	public class CustomerController : Controller
	{
		private readonly UserManager<UserAccount> _userManager;
		private readonly RoleManager<UserRole> _roleManager;
		private readonly ICustomerManager _customerManager;

		public CustomerController(UserManager<UserAccount> userManager, RoleManager<UserRole> roleManager, ICustomerManager customerManager)
		{
			_userManager= userManager;
			_roleManager= roleManager;
			_customerManager= customerManager;
		}


		[Authorize(Roles = "CustomerList")]
		[HttpGet("{area}/customer-list")]
		public IActionResult CustomerList()
		{
			return View();
		}

		//rol based aut.
		[Authorize(Roles = "CustomerDetail")]
		[HttpGet("{area}/customer-detail/{id?}")]
		public IActionResult CustomerDetail(int? id)
		{
			//Yeni Müteri oluturma yetkisi
			//Müşteri silebilme yetkisi,
			//güncelleme yetkisi
			return View();
		}

		[AllowAnonymous]
		[HttpGet("{area}/customer-public")]
		public IActionResult CustomerPublic()
		{
			return View();
		}

	}
}
