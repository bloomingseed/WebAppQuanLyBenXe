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
			DiemDung[] diemDungList = context.DiemDung.GroupBy(dd => dd.TenTinhTp)
				.Select(group => group.First()).ToArray();
			NhaXe[] nhaXeList = context.NhaXe.ToArray();
			IndexViewModel model = new IndexViewModel()
			{
				DiemDungList = diemDungList,
				NhaXeList = nhaXeList
			};
			return View(model);
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
		public JsonResult Search(ChuyenDi chuyenDi)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Model binding failed");
				return new JsonResult(new { });
			}
			string diemDungA = null;
			bool isToDN = false;
			if (chuyenDi.DiemDen.Contains("Đà Nẵng"))
			{
				isToDN = true;
				diemDungA = chuyenDi.DiemDi;
			}
			else if (chuyenDi.DiemDi.Contains("Đà Nẵng"))
				diemDungA = chuyenDi.DiemDen;
			else
			{
				return new JsonResult(new { });
			}
			//dsDiemDungA
			var dsDiemDungA = from stop in context.DiemDung where stop.TenTinhTp == diemDungA select stop;
			//dsXeKhachA
			var dsXK_DDA = from xk_dd in context.XeKhach_DiemDung
							 from dd in dsDiemDungA
							 where xk_dd.MaDiemDung == dd.MaDiemDung
							 select xk_dd;
			//filter
			List<ChuyenDiViewModel> res = new List<ChuyenDiViewModel>();
			foreach(XeKhach_DiemDung xkdd in dsXK_DDA)
			{
				xkdd.XeKhach = context.XeKhach.Find(xkdd.MaXeKhach);
				xkdd.XeKhach.NhaXe = context.NhaXe.Find(xkdd.XeKhach.MaNhaXe);
				xkdd.XeKhach.TaiXe = context.TaiXe.Find(xkdd.XeKhach.MaTaiXe);
				xkdd.DiemDung = context.DiemDung.Find(xkdd.MaDiemDung);
				if (xkdd.XeKhach.NhaXe.GiaoDichCuoi.AddDays(180) < DateTime.Today)
					continue;
				if (chuyenDi.TenNhaXe != null && chuyenDi.TenNhaXe != xkdd.XeKhach.NhaXe.TenNhaXe)
					continue;
				if (chuyenDi.SoGhe != null && chuyenDi.SoGhe != xkdd.XeKhach.SoGhe)
					continue;
				if (chuyenDi.ThoiGianDiChuyenMax != null)
				{
					if (isToDN && chuyenDi.ThoiGianDiChuyenMax < xkdd.TGDCtoiDN)
						continue;
					else if (!isToDN && chuyenDi.ThoiGianDiChuyenMax < xkdd.TGDCkhoiDN)
						continue;
				}
				if (chuyenDi.GiaVeMax != null && chuyenDi.GiaVeMax < xkdd.XeKhach.GiaVe)
					continue;
				string noiXuatPhat = null, noiDen = null;
				TimeSpan tg;
				DateTime khoiHanh;
				//giả sử đi từ A -> đà nẵng
				if (isToDN)
				{
					noiDen = chuyenDi.DiemDen;
					noiXuatPhat = xkdd.DiemDung.ToString();
					tg = xkdd.TGDCtoiDN;
				}
				else
				{
					noiDen = xkdd.DiemDung.ToString();
					noiXuatPhat = chuyenDi.DiemDi;
					tg = xkdd.TGDCkhoiDN;
				}
				khoiHanh = chuyenDi.NgayKhoiHanh.Add(tg);
				res.Add(new ChuyenDiViewModel(xkdd.XeKhach, noiXuatPhat, noiDen, khoiHanh, tg));
			}

			//return
			return new JsonResult(res.ToArray());
		}

		public IActionResult NhaXe(string id, string returnUrl)
		{
			if (!ModelState.IsValid) {
				ModelState.AddModelError("", "Server error. Please try again or request technical support");
				if (String.IsNullOrEmpty(returnUrl))
					return RedirectToAction("Index");
				else
					return Redirect(returnUrl);
			}
			NhaXe res = context.NhaXe.Find(id);
			if (res == null)
			{
				ModelState.AddModelError("", "Không tìm thấy nhà xe với mã " + id);
				if (String.IsNullOrEmpty(returnUrl))
					return RedirectToAction("Index");
				else
					return Redirect(returnUrl);
			}
			return View("NhaXe",res);
		}
		public IActionResult TaiXe(string id, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Server error. Please try again or request technical support");
				if (String.IsNullOrEmpty(returnUrl))
					return RedirectToAction("Index");
				else
					return Redirect(returnUrl);
			}
			TaiXe res = context.TaiXe.Find(id);
			if (res == null)
			{
				ModelState.AddModelError("", "Không tìm thấy tài xế với mã " + id);
				if (String.IsNullOrEmpty(returnUrl))
					return RedirectToAction("Index");
				else
					return Redirect(returnUrl);
			}
			return View("TaiXe", res);
		}
	}
	
}
