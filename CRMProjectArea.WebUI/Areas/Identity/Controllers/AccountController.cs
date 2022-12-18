using CRMProjectArea.DTO.Concrete.Account;
using CRMProjectArea.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace CRMProjectArea.WebUI.Areas.Identity.Controllers
{
	[Area("identity")]
	public class AccountController : Controller
	{
		private readonly UserManager<UserAccount> _userManager;
		private readonly SignInManager<UserAccount> _signInManager;

		public UserAccount CreateUser
		{
			get
			{
				try
				{
					return Activator.CreateInstance<UserAccount>();
				}
				catch (Exception)
				{
					throw new InvalidOperationException("Kullanıcı nesnesi oluşturulurken hata alındı. Kullanıcı nesnesi üzerindeki bağlı bulunan nesneleri kontrol edin");
				}
			}
		}

		public AccountController(UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet("{area}/login")]
		public async Task<IActionResult> Login()
		{
			//using Microsoft.AspNetCore.Authentication;
			//clear aut.
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			return View();
		}

		[HttpPost("{area}/login")]
		public async Task<IActionResult> Login(LoginDTO login)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home", new { area = "" });
				}
			}
			return View();
		}


		[HttpGet("{area}/register")]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost("{area}/register")]
		public async Task<IActionResult> Register(UserRegisterDTO registerDTO)
		{
			if (ModelState.IsValid)
			{
				var user = CreateUser;
				user.Email = registerDTO.Email;
				user.UserName = registerDTO.Email;
				var result = await _userManager.CreateAsync(user, registerDTO.Password);

				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(registerDTO);
		}


		[HttpGet("{area}/logout")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			//login sayfasına yönlendir.
			return RedirectToAction("Login", "Account", new { area = "Identity" });
		}

	}
}
