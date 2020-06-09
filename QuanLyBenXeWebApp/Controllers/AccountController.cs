using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using QuanLyBenXeWebApp.Models;

namespace QuanLyBenXeWebApp.Controllers
{
    public class AccountController : Controller
    {
		private SignInManager<QuanTriVien> signInManager;
		
		public AccountController(
			SignInManager<QuanTriVien> signInMng
			)
		{
			signInManager = signInMng;
		}

        public IActionResult Login()
        {
            return View();
        }

		public IActionResult AccessDenied(string returnUrl)
		{
			return View("Denied");
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				var res = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
				if (res.Succeeded)
				{
					if (!String.IsNullOrEmpty(loginViewModel.ReturnUrl))
						return Redirect(loginViewModel.ReturnUrl);
					return RedirectToAction("Index", "Home");
				}
			}
			ModelState.AddModelError("", "Đăng nhập thất bại. Hãy thử lại hoặc liên hệ với đội ngũ hỗ trợ kỹ thuật");
			return View(loginViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}