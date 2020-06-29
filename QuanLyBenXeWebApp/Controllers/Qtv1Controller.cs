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
    [Authorize(Roles = "QtvVaoRa")]
    public class Qtv1Controller : Controller
    {
        private BenXeDaNangContext _context;
        private UserManager<QuanTriVien> uManager;
        private RoleManager<IdentityRole> roleManager;

        public Qtv1Controller(BenXeDaNangContext context,
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

        public IActionResult ViTriDo()
        {
            return View(_context.ViTriDo.ToArray());
        }

        public IActionResult NhaXe()
        {
            return View(_context.NhaXe.ToArray());
        }

        public IActionResult TtBenXe()
        {
            TTBenXe ttbx = _context.TTBenXe.LastOrDefault();
            int lastStt = 0;
            if (ttbx != null) lastStt = ttbx.Stt;
            else
                ViewBag.NextStt = lastStt + 1;
            return View(_context.TTBenXe.ToArray());

        }

        [HttpPost]

        public async Task<IActionResult> CreateTtBenXe(TTBenXe tt)
        {
            List<string> message = new List<string>();
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Thông tin không hợp lệ");
                await _context.TTBenXe.AddAsync(tt);
                message.Add("redirect");
                message.Add(Url.Action("TtBenXe"));
            }
            catch (Exception ex)
            {
                message.Add(ex.Message);
                foreach (var value in ModelState.Values)
                    if (value.ValidationState == ModelValidationState.Invalid)
                        foreach (var modelErr in value.Errors)
                            message.Add(modelErr.ErrorMessage);
            }
            return Json(message.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTtbenxe(TTBenXe tt)
        {
            List<string> message = new List<string>();
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Thông tin không hợp lệ");
                TTBenXe _tt = await _context.TTBenXe.FindAsync(tt.Stt);
                if (_tt == null)
                    throw new Exception("không tìm thấy  bảng ghi trạng thái bến xe");
                _tt.Stt = tt.Stt;
                _context.TTBenXe.Update(_tt);
                _context.SaveChanges();
                message.Add("redirect");
                message.Add(Url.Action("TtBenXe"));


            }
            catch (Exception ex)
            {
                message.Add(ex.Message);
                foreach (var value in ModelState.Values)
                    if (value.ValidationState == ModelValidationState.Invalid)
                        foreach (var modelErr in value.Errors)
                            message.Add(modelErr.ErrorMessage);
            }
            return Json(message.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTtBenXe(TTBenXe tt)
        {
            List<string> messages = new List<string>();
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("thông tin không chính xác");
                TTBenXe _tt = await _context.TTBenXe.FindAsync(tt.Stt);
                if (_tt == null)
                    throw new Exception("không tìm thấy bảng ghi TTBenXe");
                _context.TTBenXe.Remove(_tt);
                _context.SaveChanges();
                messages.Add("redirect");
                messages.Add(Url.Action("TtBenXe"));
            }
            catch (Exception ex)
            {
                messages.Add(ex.Message);
                foreach (var value in ModelState.Values)
                    if (value.ValidationState == ModelValidationState.Invalid)
                        foreach (var modelErr in value.Errors)
                            messages.Add(modelErr.ErrorMessage);
            }
            return Json(messages.ToArray());
        }

        public IActionResult LsVaoRa()
        {
            LichSuVaoRa ls = _context.LichSuVaoRa.LastOrDefault();
            int lastStt = 0;
            if (ls != null)
                lastStt = ls.Stt;
            ViewBag.NextStt = lastStt + 1;
            return View(_context.LichSuVaoRa.ToArray());
        }

        [HttpPost]

        public async Task<IActionResult> CreateLsVaoRa(LichSuVaoRa ls)
        {
            List<string> message = new List<string>();
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Thông tin không hợp lệ");
                await _context.LichSuVaoRa.AddAsync(ls);
                message.Add("redirect");
                message.Add(Url.Action("LsVaoRa"));
            }
            catch (Exception ex)
            {
                message.Add(ex.Message);
                foreach (var value in ModelState.Values)
                    if (value.ValidationState == ModelValidationState.Invalid)
                        foreach (var modelErr in value.Errors)
                            message.Add(modelErr.ErrorMessage);
            }
            return Json(message.ToArray());
        }

        public IActionResult TtDangNhap()
        {
            QuanTriVien _user = uManager.GetUserAsync(HttpContext.User).Result;
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
                QuanTriVien _qtv = (from qtv in uManager.Users
                                    where qtv.UserName == HttpContext.User.Identity.Name
                                    select qtv).First();
                viewModel.Qtv = _qtv;
                viewModel.Role = uManager.GetRolesAsync(_qtv).Result.First();
                IdentityResult res = await uManager.ChangePasswordAsync(_qtv, viewModel.OldPassword, viewModel.NewPassword);
                if (!res.Succeeded)
                    throw new Exception("Đổi mật khẩu thất bại");
                _context.SaveChanges();
            }
            catch (Exception err) { ModelState.AddModelError("", err.Message); }
            return View("TtDangNhap", viewModel);
        }

    }
}
