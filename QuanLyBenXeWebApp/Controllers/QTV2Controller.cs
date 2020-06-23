using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using QuanLyBenXeWebApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace QuanLyBenXeWebApp.Controllers
{
	[Authorize(Roles = "QtvNhaXe")]
	public class Qtv2Controller : Controller
	{
		private BenXeDaNangContext _context;
		private UserManager<QuanTriVien> uManager;
		private NhaXe nhaXe;
		private QuanTriVien _user;

		public Qtv2Controller(BenXeDaNangContext context, UserManager<QuanTriVien> userManager)
		{
			_context = context;
			uManager = userManager;
			nhaXe = null;
		}

		private async Task<NhaXe> getAssociatedNhaXe(UserManager<QuanTriVien> userManager)
		{
			_user = await userManager.GetUserAsync(HttpContext.User);
			return _context.NhaXe.Find(_user.MaNhaXe);
		}

		public IActionResult Index()
		{
			nhaXe = getAssociatedNhaXe(uManager).Result;
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			return View();
		}

		public IActionResult CoBan()
		{
			nhaXe = getAssociatedNhaXe(uManager).Result;
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			return View("CoBan", nhaXe);
		}

		[HttpPost]
		public IActionResult UpdateCoBan(NhaXe nhaXe)
		{
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				nhaXe = getAssociatedNhaXe(uManager).Result;
				ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
				NhaXe _nhaXe = _context.NhaXe.Find(nhaXe.MaNhaXe);
				if (_nhaXe == null)
					throw new Exception("Không tìm thấy nhà xe");
				_nhaXe.TenNhaXe = nhaXe.TenNhaXe;
				_nhaXe.SoLuongXe = nhaXe.SoLuongXe;
				_nhaXe.Sdt = nhaXe.Sdt;
				_nhaXe.MauBieuTuong = nhaXe.MauBieuTuong;
				_nhaXe.DiaChi = nhaXe.DiaChi;

				_context.NhaXe.Update(_nhaXe);
				_context.SaveChanges();
			}
			catch (Exception err) { ModelState.AddModelError("", err.Message); }
			return View("CoBan", nhaXe);
		}
		public IActionResult TtDangNhap()
		{
			nhaXe = getAssociatedNhaXe(uManager).Result;
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			string _role = uManager.GetRolesAsync(_user).Result.FirstOrDefault();
			TtDangNhapViewModel model = new TtDangNhapViewModel()
			{
				Qtv = _user,
				Role = _role
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateTtDangNhap(TtDangNhapViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				QuanTriVien _qtv = await uManager.FindByIdAsync(viewModel.Qtv.Id);
				if (_qtv == null)
					throw new Exception("Không tìm thấy quản trị viên");
				_qtv.HoDem = viewModel.Qtv.HoDem;
				_qtv.Ten = viewModel.Qtv.Ten;
				_qtv.GioiTinh = viewModel.Qtv.GioiTinh;
				_qtv.NoiSinh = viewModel.Qtv.NoiSinh;
				_qtv.PhoneNumber = viewModel.Qtv.PhoneNumber;
				_qtv.UserName = viewModel.Qtv.UserName;
				await uManager.UpdateAsync(_qtv);
				_context.SaveChanges();
			}
			catch (Exception err) { ModelState.AddModelError("", err.Message); }
			return View("TtDangNhap", viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> ChangePassword(TtDangNhapViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				QuanTriVien _qtv = await uManager.FindByIdAsync(viewModel.Qtv.Id);
				if (_qtv == null)
					throw new Exception("Không tìm thấy quản trị viên");
				string token = await uManager.GeneratePasswordResetTokenAsync(_qtv);
				await uManager.ChangePasswordAsync(_qtv, viewModel.OldPassword, viewModel.NewPassword);
				_context.SaveChanges();
			}
			catch (Exception err) { ModelState.AddModelError("", err.Message); }
			return View("TtDangNhap", viewModel);
		}

		public IActionResult XeKhach()
		{
			nhaXe = getAssociatedNhaXe(uManager).Result;
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			var xkList = from xk in _context.XeKhach
						 where xk.MaNhaXe == nhaXe.MaNhaXe
						 select xk;
			XeKhach xeKhachCuoi = _context.XeKhach.LastOrDefault();
			string lastXeKhachId = null;
			if (xeKhachCuoi != null)
				lastXeKhachId = xeKhachCuoi.MaXeKhach;
			else
				lastXeKhachId = "XK00000000";
			ViewBag.NextXeKhachId = String.Concat("XK", Utils.IncrementString(lastXeKhachId.Substring(2)));
			return View("XeKhach", xkList.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> CreateXeKhach(XeKhach xeKhach)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				await _context.XeKhach.AddAsync(xeKhach);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("XeKhach"));
			}
			catch (Exception err)
			{
				messages.Add(err.Message);
				foreach (var value in ModelState.Values)
					if (value.ValidationState == ModelValidationState.Invalid)
						foreach (var modelErr in value.Errors)
							messages.Add(modelErr.ErrorMessage);
			}
			return Json(messages.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> UpdateXeKhach(XeKhach xeKhach)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				XeKhach _xeKhach = await _context.XeKhach.FindAsync(xeKhach.MaXeKhach);
				if (_xeKhach == null)
					throw new Exception("Không tìm thấy xe khách");
				_xeKhach.MaTaiXe = xeKhach.MaTaiXe;
				_xeKhach.BienSoXe = xeKhach.BienSoXe;
				_xeKhach.SoGhe = xeKhach.SoGhe;
				_xeKhach.GiaVe = xeKhach.GiaVe;
				_context.XeKhach.Update(_xeKhach);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("XeKhach"));
			}
			catch (Exception err)
			{
				messages.Add(err.Message);
				foreach (var value in ModelState.Values)
					if (value.ValidationState == ModelValidationState.Invalid)
						foreach (var modelErr in value.Errors)
							messages.Add(modelErr.ErrorMessage);
			}
			return Json(messages.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> DeleteXeKhach(XeKhach xeKhach)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				XeKhach _xeKhach = await _context.XeKhach.FindAsync(xeKhach.MaXeKhach);
				if (_xeKhach == null)
					throw new Exception("Không tìm thấy xe khách");
				_context.XeKhach.Remove(_xeKhach);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("XeKhach"));
			}
			catch (Exception err)
			{
				messages.Add(err.Message);
				foreach (var value in ModelState.Values)
					if (value.ValidationState == ModelValidationState.Invalid)
						foreach (var modelErr in value.Errors)
							messages.Add(modelErr.ErrorMessage);
			}
			return Json(messages.ToArray());
		}
		public IActionResult TaiXe()
		{
			nhaXe = getAssociatedNhaXe(uManager).Result;
			ViewData["TenNhaXe"] = nhaXe.TenNhaXe;
			var s = from xk in _context.XeKhach
					from tx in _context.TaiXe
					where xk.MaNhaXe == nhaXe.MaNhaXe && xk.MaTaiXe == tx.MaTaiXe
					select tx;
			TaiXe taiXeCuoi = _context.TaiXe.LastOrDefault();
			string lastTaiXeId = null;
			if (taiXeCuoi != null)
				lastTaiXeId = taiXeCuoi.MaTaiXe;
			else
				lastTaiXeId = "TX00000000";
			ViewBag.NextTaiXeId = String.Concat("TX", Utils.IncrementString(lastTaiXeId.Substring(2)));
			return View("TaiXe", s.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> CreateTaiXe(TaiXe taiXe)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				await _context.TaiXe.AddAsync(taiXe);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("TaiXe"));
			}
			catch (Exception err)
			{
				messages.Add(err.Message);
				foreach (var value in ModelState.Values)
					if (value.ValidationState == ModelValidationState.Invalid)
						foreach (var modelErr in value.Errors)
							messages.Add(modelErr.ErrorMessage);
			}
			return Json(messages.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> UpdateTaiXe(TaiXe taiXe)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				TaiXe _TaiXe = await _context.TaiXe.FindAsync(taiXe.MaTaiXe);
				if (_TaiXe == null)
					throw new Exception("Không tìm thấy tài xế");
				_TaiXe.HoDem = taiXe.HoDem;
				_TaiXe.Ten = taiXe.Ten;
				_TaiXe.GioiTinh = taiXe.GioiTinh;
				_TaiXe.NoiSinh = taiXe.NoiSinh;
				_TaiXe.Sdt = taiXe.Sdt;
				_context.TaiXe.Update(_TaiXe);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("TaiXe"));
			}
			catch (Exception err)
			{
				messages.Add(err.Message);
				foreach (var value in ModelState.Values)
					if (value.ValidationState == ModelValidationState.Invalid)
						foreach (var modelErr in value.Errors)
							messages.Add(modelErr.ErrorMessage);
			}
			return Json(messages.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> DeleteTaiXe(TaiXe taiXe)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				TaiXe _TaiXe = await _context.TaiXe.FindAsync(taiXe.MaTaiXe);
				if (_TaiXe == null)
					throw new Exception("Không tìm thấy tài xế");
				_context.TaiXe.Remove(_TaiXe);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("TaiXe"));
			}
			catch (Exception err)
			{
				messages.Add(err.Message);
				foreach (var value in ModelState.Values)
					if (value.ValidationState == ModelValidationState.Invalid)
						foreach (var modelErr in value.Errors)
							messages.Add(modelErr.ErrorMessage);
			}
			return Json(messages.ToArray());
		}

		
	}
}