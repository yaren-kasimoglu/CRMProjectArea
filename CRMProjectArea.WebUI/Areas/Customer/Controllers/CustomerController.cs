using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CRMProjectArea.WebUI.Areas.Customer.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("customer")]
	public class CustomerController : Controller
	{
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
