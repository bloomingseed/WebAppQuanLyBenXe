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
	[Authorize(Roles = "QtvVanPhong")]
	public class Qtv0Controller : Controller
	{
		private BenXeDaNangContext _context;
		private UserManager<QuanTriVien> uManager;
		private RoleManager<IdentityRole> roleManager;

		public Qtv0Controller(BenXeDaNangContext context, 
			UserManager<QuanTriVien> userManager,
			RoleManager<IdentityRole> roleMng)
		{
			_context = context;
			uManager = userManager;
			roleManager = roleMng;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult LsGiaoDich()
		{
			return View(_context.GiaoDich.ToArray());
		}
		[HttpPost]
		public IActionResult CreateLsGiaoDich(GiaoDich giaoDich)
		{
			if (!ModelState.IsValid)
				return View(giaoDich);
			try
			{
				_context.GiaoDich.Add(giaoDich);
				_context.SaveChanges();
			}
			catch (Exception err)
			{
				ModelState.AddModelError("", err.Message);
			}
			return View(giaoDich);
		}

		public IActionResult TtDangNhap()
		{
			QuanTriVien[] qtvs = uManager.Users.ToArray();
			Dictionary<QuanTriVien, string> model = new Dictionary<QuanTriVien, string>();
			foreach(QuanTriVien qtv in qtvs)
			{
				string roleName = uManager.GetRolesAsync(qtv).Result.First();
				model.Add(qtv, roleName);
			}
			return View(model);
		}
		//[HttpPost]
		//public IActionResult CreateTtDangNhap(QuanTriVien qtv, string roleName)
		//{
		//	Dictionary<QuanTriVien, string> model = new Dictionary<QuanTriVien, string>();
		//	if (!ModelState.IsValid)
		//		return View();
		//	try
		//	{
		//		_context.GiaoDich.Add(giaoDich);
		//		_context.SaveChanges();
		//	}
		//	catch (Exception err)
		//	{
		//		ModelState.AddModelError("", err.Message);
		//	}
		//	return View(giaoDich);
		//	return View();
		//}
		//[HttpPost]
		//public IActionResult UpdateTtDangNhap(QuanTriVien qtv, string roleName)
		//{
		//	Dictionary<QuanTriVien, string> model = new Dictionary<QuanTriVien, string>();
		//	return View();
		//}
		//[HttpPost]
		//public IActionResult DeleteTtDangNhap(QuanTriVien qtv, string roleName)
		//{
		//	Dictionary<QuanTriVien, string> model = new Dictionary<QuanTriVien, string>();
		//	return View();
		//}


		public IActionResult TtBenXe()
		{
			return View(_context.TTBenXe.ToArray());
		}

		public IActionResult LsVaoRa()
		{
			return View(_context.LichSuVaoRa.ToArray());
		}
		[HttpPost]
		public IActionResult DeleteLsVaoRa(LichSuVaoRa vaoRa)
		{
			return View();
		}

		public IActionResult ViTriDo()
		{
			return View(_context.ViTriDo.ToArray());
		}
		[HttpPost]
		public IActionResult CreateViTriDo(ViTriDo viTri)
		{
			return View();
		}
		[HttpPost]
		public IActionResult UpdateViTriDo(ViTriDo viTri)
		{
			return View();
		}
		[HttpPost]
		public IActionResult DeleteViTriDo(ViTriDo viTri)
		{
			return View();
		}

		public IActionResult NhaXe()
		{
			return View(_context.NhaXe.ToArray());
		}
		[HttpPost]
		public IActionResult CreateNhaXe(NhaXe nhaXe)
		{
			return View();
		}
		[HttpPost]
		public IActionResult UpdateNhaXe(NhaXe nhaXe)
		{
			return View();
		}
		[HttpPost]
		public IActionResult DeleteNhaXe(NhaXe nhaXe)
		{
			return View();
		}

		//[HttpPost]
		//public IActionResult Create()
	}
}