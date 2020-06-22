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
		private UserManager<QuanTriVien> userManager;
		private RoleManager<IdentityRole> roleManager;
		
		public AccountController(
			SignInManager<QuanTriVien> signInMng,
			RoleManager<IdentityRole> roleMng,
			UserManager<QuanTriVien> userMng
			)
		{
			signInManager = signInMng;
			roleManager = roleMng;
			userManager = userMng;
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
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Đăng nhập thất bại. Hãy thử lại hoặc liên hệ với đội ngũ hỗ trợ kỹ thuật");
					var res = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
				if (res.Succeeded)
				{
					QuanTriVien qtv = await userManager.FindByNameAsync(loginViewModel.UserName);
					string qtvRole = (await userManager.GetRolesAsync(qtv)).FirstOrDefault();
					if (qtvRole == null)
						throw new Exception("Quản trị viên này chưa được phân quyền");
					if(qtvRole == "QtvVanPhong")
						return RedirectToAction("Index", "qtv0");
					if (qtvRole == "QtvVaoRa")
						return RedirectToAction("Index", "qtv1");
					if(qtvRole == "QtvNhaXe")
						return RedirectToAction("Index", "qtv2");
				}
			}
			catch (Exception err)
			{
				ModelState.AddModelError("", err.Message);
			}
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