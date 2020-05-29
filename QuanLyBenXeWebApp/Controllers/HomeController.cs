using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyBenXeWebApp.Models;

namespace QuanLyBenXeWebApp.Controllers
{
	public class HomeController : Controller
	{
		private BenXeDaNangContext context;
		public HomeController(BenXeDaNangContext _context)
		{
			context = _context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpPost]
		public JsonResult XeKhach(ChuyenDi chuyenDi)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Model binding failed");
				return new JsonResult(new { });
			}
			var xeKhachList = context.XeKhach.AsEnumerable<XeKhach>();
			bool val = false;
			var res = xeKhachList.Where(xk=> {
				if (chuyenDi.TenNhaXe != null)
					val |= xk.NhaXe.TenNhaXe == chuyenDi.TenNhaXe;
				if (chuyenDi.LoaiXe != null)
					val |= xk.LoaiXe == chuyenDi.LoaiXe;
				foreach (var rec in xk.DiemDungList)
				{
					if (chuyenDi.MaDiemDung.Contains(rec.MaDiemDung))
					{
						val |= true;
						break;
					}
					val |= false;
				}
				if (xk.ThoiGianDiChuyen >= chuyenDi.ThoiGianDiChuyenMin &&
				xk.ThoiGianDiChuyen <= chuyenDi.ThoiGianDiChuyenMax)
					val |= true;
				else val |= false;
				if (xk.GiaVe >= chuyenDi.GiaVeMin &&
				xk.GiaVe <= chuyenDi.GiaVeMax)
					val |= true;
				else val |= false;
				return val;
			});
			List<ChuyenDiViewModel> models = new List<ChuyenDiViewModel>();
			foreach(var xk in res)
			{
				var diemDungList = from diemdung in context.DiemDung
								   where diemdung.MaDiemDung == 
				models.Add(new ChuyenDiViewModel(xk))
			}
		}
	}
}
