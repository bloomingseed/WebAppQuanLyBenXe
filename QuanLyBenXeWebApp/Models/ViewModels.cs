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
		public string TenTaiXe { get; set; }
		public string LoaiXe { get; set; }
		public string DiemXuatPhat { get; set; }
		public string[] DiemDungXe { get; set; }
		public DateTime ThoiDiemXuatBen { get; set; }
		public DateTime ThoiDiemDungXe { get; set; }
		public TimeSpan ThoiGianDiChuyen { get; set; }
		public int GiaVe { get; set; }
		public string SdtNhaXe { get; set; }
		public ChuyenDiViewModel(XeKhach xeKhach, string[] tenDiemDungList, DateTime ngayKhoiHanh)
		{
			MaXeKhach = xeKhach.MaXeKhach;
			TenNhaXe = xeKhach.NhaXe.TenNhaXe;
			TenTaiXe = xeKhach.TaiXe.Ten;
			LoaiXe = xeKhach.LoaiXe;
			DiemXuatPhat = "Đà Nẵng";
			DiemDungXe = tenDiemDungList;
			ThoiDiemXuatBen = new DateTime(
				ngayKhoiHanh.Year, ngayKhoiHanh.Month, ngayKhoiHanh.Day,
				xeKhach.GioKhoiHanh.Hours, xeKhach.GioKhoiHanh.Minutes,xeKhach.GioKhoiHanh.Seconds);
			ThoiDiemDungXe = ThoiDiemXuatBen.Add(xeKhach.ThoiGianDiChuyen);
			GiaVe = xeKhach.GiaVe;
			SdtNhaXe = xeKhach.NhaXe.Sdt;
			MaXeKhach = xeKhach.MaXeKhach;
		}
	}
}
