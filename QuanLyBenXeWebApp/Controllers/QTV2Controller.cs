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
	[Authorize(Roles = "QtvNhaXe")]
	public class Qtv2Controller : Controller
	{
		private BenXeDaNangContext _context;
		private UserManager<QuanTriVien> uManager;
		private NhaXe nhaXe;

		public Qtv2Controller(BenXeDaNangContext context, UserManager<QuanTriVien> userManager)
		{
			_context = context;
			uManager = userManager;
			nhaXe = null;
		}

		private NhaXe getAssociatedNhaXe(UserManager<QuanTriVien> userManager)
		{
			string userNhaXe = userManager.GetUserAsync(HttpContext.User).GetAwaiter().GetResult().MaNhaXe;
			return _context.NhaXe.Find(userNhaXe);
		}

		public IActionResult Index()
		{
			nhaXe = getAssociatedNhaXe(uManager);
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			return View();
		}

		public IActionResult CoBan()
		{
			nhaXe = getAssociatedNhaXe(uManager);
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			return View("CoBan", nhaXe);
		}

		[HttpPost]
		public IActionResult UpdateCoBan(NhaXe nhaxe)
		{
			//flag = 0: create
			//flag = 1: update
			//flag = 2: delete
			if (!ModelState.IsValid)
				return View(nhaXe);
			NhaXe _nhaXe = null;
			try
			{
				_nhaXe = _context.NhaXe.Find(nhaxe.MaNhaXe);
				if (_nhaXe == null)
					throw new Exception("Không tìm thấy nhà xe");
				_nhaXe = nhaXe;
				_context.NhaXe.Update(_nhaXe);
				_context.SaveChanges();
			}
			catch (Exception err)
			{
				ModelState.AddModelError("", err.Message);
			}
			return View(_nhaXe);
		}

		public IActionResult XeKhach()
		{
			nhaXe = getAssociatedNhaXe(uManager);
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			var xkList = from xk in _context.XeKhach where xk.MaNhaXe == nhaXe.MaNhaXe select xk;
			return View("XeKhach", xkList.ToArray());
		}
		public IActionResult TaiXe()
		{
			nhaXe = getAssociatedNhaXe(uManager);
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			var xkList = from xk in _context.XeKhach where xk.MaNhaXe == nhaXe.MaNhaXe select xk;
			List<TaiXe> taiXeList = new List<TaiXe>();
			foreach (XeKhach xk in xkList)
				taiXeList.Add(_context.TaiXe.Find(xk.MaTaiXe));
			return View("TaiXe", taiXeList.ToArray());
		}

		//[HttpPost]
		//public IActionResult Create()
	}
}