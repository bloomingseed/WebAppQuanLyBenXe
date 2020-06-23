using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using QuanLyBenXeWebApp.Models;
using System.Text;

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
			GiaoDich giaoDichCuoi = _context.GiaoDich.LastOrDefault();
			string lastGiaoDichId = null;
			if (giaoDichCuoi != null)
				lastGiaoDichId = giaoDichCuoi.MaGiaoDich;
			else
				lastGiaoDichId = "GD00000000";
			ViewBag.NextGiaoDichId = String.Concat("GD", Utils.IncrementString(lastGiaoDichId.Substring(2)));
			ViewBag.MaNhaXes = _context.NhaXe.ToArray();
			return View(_context.GiaoDich.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> CreateLsGiaoDich(GiaoDich giaoDich)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				await _context.GiaoDich.AddAsync(giaoDich);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("LsGiaoDich"));
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
		public async Task<IActionResult> DeleteLsGiaoDich(GiaoDich giaoDich)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				GiaoDich _giaoDich = await _context.GiaoDich.FindAsync(giaoDich.MaGiaoDich);
				if (_giaoDich == null)
					throw new Exception("Không tìm thấy bản ghi giao dịch");
				_context.GiaoDich.Remove(_giaoDich);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("LsGiaoDich"));
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
		[HttpGet]
		public IActionResult TtDangNhap()
		{
			QuanTriVien[] qtvs = uManager.Users.ToArray();
			Dictionary<QuanTriVien, string> model = new Dictionary<QuanTriVien, string>();
			foreach(QuanTriVien qtv in qtvs)
			{
				string roleName = uManager.GetRolesAsync(qtv).Result.First();
				model.Add(qtv, roleName);
			}
			QuanTriVien lastQtv = uManager.Users.LastOrDefault();
			string lastQtvId = null;
			if (lastQtv != null)
				lastQtvId = lastQtv.Id;
			else
				lastQtvId = "QT00000000";
			ViewBag.NextQtvId = String.Concat("QT",Utils.IncrementString(lastQtvId.Substring(2)));
			ViewBag.Roles = roleManager.Roles;
			ViewBag.MaNhaXes = _context.NhaXe.ToArray();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateTtDangNhap(QuanTriVien qtv, string password, string roleName)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				var result = await uManager.CreateAsync(qtv, password);
				if (!result.Succeeded)
					throw new Exception("Tạo quản trị viên mới không thành công");
				result = await uManager.AddToRoleAsync(qtv, roleName);
				if (!result.Succeeded)
					throw new Exception("Phân quyền không thành công");
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("TtDangNhap"));
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
		public async Task<IActionResult> UpdateTtDangNhap(QuanTriVien qtv, string roleName)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				QuanTriVien _qtv = await uManager.FindByIdAsync(qtv.Id);
				if (_qtv == null)
					throw new Exception("Không tìm thấy quản trị viên");
				_qtv.MaNhaXe = qtv.MaNhaXe;
				_qtv.HoDem = qtv.HoDem;
				_qtv.Ten = qtv.Ten;
				_qtv.GioiTinh = qtv.GioiTinh;
				_qtv.NoiSinh = qtv.NoiSinh;
				_qtv.PhoneNumber = qtv.PhoneNumber;
				_qtv.UserName = qtv.UserName;
				await uManager.UpdateAsync(_qtv);

				string _role = (await uManager.GetRolesAsync(_qtv)).FirstOrDefault();
				if (_role != null)
				{
					await uManager.RemoveFromRoleAsync(_qtv, _role);
				}
				var res = await uManager.AddToRoleAsync(_qtv, roleName);
				if (!res.Succeeded)
					throw new Exception("Cập nhật không thành công");
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("TtDangNhap"));
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
		public async Task<IActionResult> DeleteTtDangNhap(QuanTriVien qtv)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				QuanTriVien _qtv = await uManager.FindByIdAsync(qtv.Id);
				if (_qtv == null)
					throw new Exception("Không tìm thấy quản trị viên");
				var res = await uManager.DeleteAsync(_qtv);
				if (!res.Succeeded)
					throw new Exception("Xoá không thành công");
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("TtDangNhap"));
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
		public async Task<IActionResult> ChangePassword(QuanTriVien qtv, string password)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				QuanTriVien _qtv = await uManager.FindByIdAsync(qtv.Id);
				if (_qtv == null)
					throw new Exception("Không tìm thấy quản trị viên");
				string token = await uManager.GeneratePasswordResetTokenAsync(_qtv);
				await uManager.ResetPasswordAsync(_qtv, token, password);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("TtDangNhap"));
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


		public IActionResult TtBenXe()
		{
			return View(_context.TTBenXe.ToArray());
		}

		public IActionResult LsVaoRa()
		{
			LichSuVaoRa lastRecord = _context.LichSuVaoRa.LastOrDefault();
			int lastStt = 0;
			if(lastRecord != null)
				lastStt = lastRecord.Stt;
			ViewBag.NextStt = lastStt + 1;
			return View(_context.LichSuVaoRa.ToArray());
		}
		[HttpPost]
		public async Task<IActionResult> DeleteLsVaoRa(LichSuVaoRa vaoRa)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				LichSuVaoRa _vaoRa = await _context.LichSuVaoRa.FindAsync(vaoRa.Stt);
				if (_vaoRa == null)
					throw new Exception("Không tìm thấy bản ghi vào-ra");
				_context.LichSuVaoRa.Remove(_vaoRa);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("LsVaoRa"));
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

		public IActionResult ViTriDo()
		{
			ViTriDo viTriCuoi = _context.ViTriDo.LastOrDefault();
			string lastViTriId = null;
			if (viTriCuoi != null)
				lastViTriId = viTriCuoi.MaViTri;
			else
				lastViTriId = "MB00000000";

			ViewBag.NextViTriId = String.Concat(lastViTriId.Substring(0, 2), Utils.IncrementString(lastViTriId.Substring(2))); ;
			ViTriDo[] model = _context.ViTriDo.ToArray();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateViTriDo(ViTriDo viTri)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				string meta = viTri.MaViTri.Substring(0, 2);
				if (meta != "MB" && meta != "MT" && meta != "MN")
					throw new Exception("Mã vị trí không hợp lệ");
				await _context.ViTriDo.AddAsync(viTri);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("ViTriDo"));
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
		public async Task<IActionResult> UpdateViTriDo(ViTriDo viTri)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				ViTriDo _viTri = await _context.ViTriDo.FindAsync(viTri.MaViTri);
				if (_viTri == null)
					throw new Exception("Không tìm thấy vị trí đỗ");
				_viTri.MaViTri = viTri.MaViTri;
				_context.ViTriDo.Update(_viTri);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("ViTriDo"));
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
		public async Task<IActionResult> DeleteViTriDo(ViTriDo viTri)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				ViTriDo _viTri = await _context.ViTriDo.FindAsync(viTri.MaViTri);
				if (_viTri == null)
					throw new Exception("Không tìm thấy vị trí đỗ");
				_context.ViTriDo.Remove(_viTri);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("ViTriDo"));
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

		public IActionResult NhaXe()
		{
			NhaXe nhaXeCuoi = _context.NhaXe.LastOrDefault();
			string lastNhaXeId = null;
			if (nhaXeCuoi != null)
				lastNhaXeId = nhaXeCuoi.MaNhaXe;
			else
				lastNhaXeId = "NX00000000";

			ViewBag.NextNhaXeId = String.Concat("NX", Utils.IncrementString(lastNhaXeId.Substring(2)));
			NhaXe[] model = _context.NhaXe.ToArray();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateNhaXe(NhaXe NhaXe)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				string meta = NhaXe.MaNhaXe.Substring(0, 2);
				if (meta != "NX")
					throw new Exception("Mã nhà xe không hợp lệ");
				await _context.NhaXe.AddAsync(NhaXe);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("NhaXe"));
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
		public async Task<IActionResult> UpdateNhaXe(NhaXe NhaXe)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				NhaXe _NhaXe = await _context.NhaXe.FindAsync(NhaXe.MaNhaXe);
				if (_NhaXe == null)
					throw new Exception("Không tìm thấy nhà xe");
				_NhaXe.MaNhaXe = NhaXe.MaNhaXe;
				_context.NhaXe.Update(_NhaXe);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("NhaXe"));
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
		public async Task<IActionResult> DeleteNhaXe(NhaXe NhaXe)
		{
			List<string> messages = new List<string>();
			try
			{
				if (!ModelState.IsValid)
					throw new Exception("Thông tin không hợp lệ");
				NhaXe _NhaXe = await _context.NhaXe.FindAsync(NhaXe.MaNhaXe);
				if (_NhaXe == null)
					throw new Exception("Không tìm thấy nhà xe");
				_context.NhaXe.Remove(_NhaXe);
				_context.SaveChanges();
				messages.Add("redirect");
				messages.Add(Url.Action("NhaXe"));
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