using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRMProjectArea.WebUI.Areas.Admin.Controllers
{
	[Authorize] //giriş yapılmadan bu sayfaya ulaşılamasın
	public class RoleController : Controller
	{
		private readonly RoleManager<UserRole> _roleManager;
		public RoleController(RoleManager<UserRole> roleManager)
		{
			_roleManager = roleManager;
		}


		[HttpGet("{area}/role-list")]
		public async Task<IActionResult> Index()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			return View();
		}

		

	}
}
