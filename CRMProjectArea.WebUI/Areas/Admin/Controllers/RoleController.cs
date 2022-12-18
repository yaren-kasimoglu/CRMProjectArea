using CRMProjectArea.DTO.Concrete.Account;
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
			var rolPageDTO = await FillRoles();
			return View(rolPageDTO);
		}

		[HttpPost("{area}/role-list")]
		public async Task<IActionResult> Index(RolePageDTO pageDTO)
		{
			if (!string.IsNullOrWhiteSpace(pageDTO.Name))
			{
				if (pageDTO.Method == "Delete")
				{
					await RoleDelete(pageDTO);
				}
				else if (pageDTO.Method == "InsertOrUpdate")
				{
					await RoleInsertOrUpdate(pageDTO);
				}
			}

			return RedirectToAction("Index", "Role", new { area = "Admin" });
		}

		private async Task RoleInsertOrUpdate(RolePageDTO pageDTO)
		{
			if (pageDTO.Id == 0)
			{
				//Insert Ekleme
				var userRole = new UserRole();
				userRole.Id = pageDTO.Id;
				userRole.Name = pageDTO.Name;

				var result = await _roleManager.CreateAsync(userRole);
			}
			else
			{
				//Güncelleme
				var userRole = await _roleManager.FindByIdAsync(pageDTO.Id.ToString());
				if (userRole != null)
				{
					userRole.Name = pageDTO.Name;
					var result = await _roleManager.UpdateAsync(userRole);
				}
			}
		}

		private async Task RoleDelete(RolePageDTO pageDTO)
		{
			var role = await _roleManager.FindByIdAsync(pageDTO.Id.ToString());
			if (role != null)
			{
				await _roleManager.DeleteAsync(role);
			}
		}

		private async Task<RolePageDTO> FillRoles()
		{
			RolePageDTO rolePageDTO = new RolePageDTO();
			rolePageDTO.Id = 0;
			rolePageDTO.Name = "";
			var roles = await _roleManager.Roles.ToListAsync();
			if (roles != null)
			{
				rolePageDTO.Roles = roles.Select(t0 => new RoleDTO()
				{
					Id = t0.Id,
					Name = t0.Name,
					ConcurrencyStamp = t0.ConcurrencyStamp,
					NormalizedName = t0.NormalizedName,
				}).ToList();
			}
			return rolePageDTO;
		}



	}
}
