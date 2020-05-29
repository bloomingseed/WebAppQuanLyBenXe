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
				//required
				foreach (var rec in xk.DiemDungList)
				{
					if (chuyenDi.MaDiemDung.Contains(rec.MaDiemDung))
					{
						val |= true;
						break;
					}
					val |= false;
				}
				//required
				val |= xk.GioKhoiHanh == chuyenDi.GioKhoiHanh;
				//nullable
				if (chuyenDi.TenNhaXe != null)
					val |= xk.NhaXe.TenNhaXe == chuyenDi.TenNhaXe;
				if (chuyenDi.LoaiXe != null)
					val |= xk.LoaiXe == chuyenDi.LoaiXe;
				if(chuyenDi.ThoiGianDiChuyenMin != null && 
					chuyenDi.ThoiGianDiChuyenMax != null)
					if (xk.ThoiGianDiChuyen >= chuyenDi.ThoiGianDiChuyenMin &&
						xk.ThoiGianDiChuyen <= chuyenDi.ThoiGianDiChuyenMax)
						val |= true;
					else val |= false;
				if(chuyenDi.GiaVeMin != null && 
					chuyenDi.GiaVeMax != null)
					if (xk.GiaVe >= chuyenDi.GiaVeMin &&
						xk.GiaVe <= chuyenDi.GiaVeMax)
							val |= true;
					else val |= false;
				//returning
				return val;
			});
			//convert to view model
			List<ChuyenDiViewModel> models = new List<ChuyenDiViewModel>();
			foreach (XeKhach xk in res)
			{
				var diemDungList = context.DiemDung.AsEnumerable<DiemDung>();
				var fullDiemDung = from ctDiemDung in diemDungList
								   from diemDung in xk.DiemDungList
								   where diemDung.MaDiemDung == ctDiemDung.MaDiemDung
								   select ctDiemDung;
				List<string> tenDiemDungList = new List<string>();
				foreach (DiemDung diemDung in fullDiemDung)
						tenDiemDungList.Add(diemDung.ToString());
				models.Add(new ChuyenDiViewModel(xk, tenDiemDungList.ToArray(), chuyenDi.NgayKhoiHanh));
			}
			//return
			return new JsonResult(models.ToArray());
		}
	}
	
}
