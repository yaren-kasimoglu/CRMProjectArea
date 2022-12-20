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
			//kullanıcı nesnesi
			var user = await _userManager.FindByIdAsync(userid.ToString());
			//kullanıcının dbdeki rolleri
			var roles = await _userManager.GetRolesAsync(user);
			var result = await _userManager.RemoveFromRolesAsync(user, roles);
			if (result.Succeeded)
			{
				var selectedRoles = userRoles.Where(t0 => t0.IsSelected == true).Select(t0 => t0.Name).ToList();
				await _userManager.AddToRolesAsync(user, selectedRoles);
			}
			var userRoleList = await GetUserRoles(userid);
			return View(userRoleList);
		}

		private async Task<List<UserRoleDTO>> GetUserRoles(int userid)
		{
			var user = _userManager.Users.FirstOrDefault(t0 => t0.Id == userid);
			ViewBag.userid = userid;
			ViewBag.userName = user?.UserName;

			var userRoleList = new List<UserRoleDTO>();

			foreach (var item in _roleManager.Roles)
			{
				var userRole = new UserRoleDTO();
				userRole.Name = item.Name;
				userRole.Id = item.Id;
				if (await _userManager.IsInRoleAsync(user, item.NormalizedName))
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
