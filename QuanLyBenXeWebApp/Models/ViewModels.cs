using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBenXeWebApp.Models
{
	public class ChuyenDiViewModel
	{
		public string MaXeKhach { get; set; }
		public string TenNhaXe { get; set; }
		public string MaNhaXe { get; set; }
		public int SoGhe { get; set; }
		public string TenTaiXe { get; set; }
		public string MaTaiXe { get; set; }
		public string DiemXuatPhat { get; set; }
		public string DiemDungXe { get; set; }
		public DateTime ThoiDiemDi { get; set; }
		public TimeSpan ThoiGianDiChuyen { get; set; }
		public DateTime ThoiDiemDen { get; set; }
		public int GiaVe { get; set; }
		public string SdtNhaXe { get; set; }
		public ChuyenDiViewModel(XeKhach xeKhach, string noiDi, string noiDen, DateTime thoiDiemDi, TimeSpan tg)
		{
			MaXeKhach = xeKhach.MaXeKhach;
			TenNhaXe = xeKhach.NhaXe.TenNhaXe;
			MaNhaXe = xeKhach.NhaXe.MaNhaXe;
			SoGhe = xeKhach.SoGhe;
			//LoaiXe = xeKhach.LoaiXe;
			TenTaiXe = xeKhach.TaiXe.ToString();
			MaTaiXe = xeKhach.TaiXe.MaTaiXe;
			GiaVe = xeKhach.GiaVe;
			SdtNhaXe = xeKhach.NhaXe.Sdt;

			DiemXuatPhat = noiDi;
			DiemDungXe = noiDen;
			ThoiDiemDi = thoiDiemDi;
			ThoiDiemDen = thoiDiemDi.Add(tg);
			ThoiGianDiChuyen = tg;			
		}
	}
}
