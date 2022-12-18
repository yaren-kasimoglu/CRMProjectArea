using CRMProjectArea.DTO.Concrete.Account;
using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRMProjectArea.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class UserRoleController : Controller
	{
		private readonly RoleManager<UserRole> _roleManager;
		private readonly UserManager<UserAccount> _userManager;

		public UserRoleController(RoleManager<UserRole> roleManager, UserManager<UserAccount> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		[HttpGet("{area}/user-role-manage/{userid}")]
		public async Task<IActionResult> UserRoleManage(int userid)
		{
			var userRoleList = await GetUserRoles(userid);
			return View(userRoleList);
		}

		[HttpPost("{area}/user-role-manage/{userid}")]
		public async Task<IActionResult> UserRoleManage(int userid, List<UserRoleDTO> userRoles)
		{
			var userRoleList = await GetUserRoles(userid);
			return View(userRoleList);
		}

		private async Task<List<UserRoleDTO>> GetUserRoles(int userid)
		{
			var user = _userManager.Users.ToList().AsEnumerable().FirstOrDefault(t0 => t0.Id == userid);

			//ViewBag.userid = userid;
			//ViewBag.userName = user.UserName;

			var userRoleList = new List<UserRoleDTO>();

			foreach (var item in _roleManager.Roles)
			{
				var userRole = new UserRoleDTO();
				userRole.Name = item.Name;
				userRole.Id = item.Id;
				if (await _userManager.IsInRoleAsync(user, item.Id.ToString()))
				{
					userRole.IsSelected = true;
				}
				else
				{
					userRole.IsSelected = false;
				}
				userRoleList.Add(userRole);
			}
			return userRoleList;
		}

	}
}
