using CRMProjectArea.DTO.Concrete.Account;
using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRMProjectArea.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class UserAccountController : Controller
	{
		private readonly UserManager<UserAccount> _userManager;
		private readonly RoleManager<UserRole> _roleManager;
		public UserAccountController(UserManager<UserAccount> userManager, RoleManager<UserRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpGet("{area}/user-account-list")]
		public async Task<IActionResult> UserAccountList()
		{
			var userList = await _userManager.Users.ToListAsync();
			List<UserAccountDTO> users = new List<UserAccountDTO>();
			foreach (var item in userList)
			{
				var user = new UserAccountDTO();
				user.UserName = item.UserName;
				user.Email = item.Email;
				user.Id = item.Id;
				user.Roles = await GetUserRole(item);
				users.Add(user);
			}

			return View(users);
		}

		private async Task<List<string>> GetUserRole(UserAccount user)
		{
			return new List<string>(await _userManager.GetRolesAsync(user));
		}
	}
}
