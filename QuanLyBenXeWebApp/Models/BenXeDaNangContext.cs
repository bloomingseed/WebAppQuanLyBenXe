using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBenXeWebApp.Models
{
	public class BenXeDaNangContext : DbContext
	{
		public DbSet<TaiXe> TaiXe { get; set; }
		public DbSet<NhaXe> NhaXe { get; set; }
		public DbSet<DiemDung> DiemDung { get; set; }
		public DbSet<XeKhach> XeKhach { get; set; }
		public DbSet<XeKhachDiemDung> XeKhachDiemDung { get; set; }
		public DbSet<ViTroDo> ViTroDo { get; set; }
		public DbSet<TTBenXe> TTBenXe { get; set; }


		public BenXeDaNangContext(DbContextOptions<BenXeDaNangContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<XeKhachDiemDung>()
				.HasIndex(record => new { record.MaXeKhach, record.MaDiemDung })
				.IsUnique();
		}
	}

	public class TaiXe
	{
		[Key, StringLength(10)]
		public string MaTaiXe { get; set; }
		[StringLength(20)]
		public string HoDem { get; set; }
		[StringLength(10)]
		public string Ten { get; set; }
		public bool NamGioi { get; set; }
		[StringLength(50)]
		public string NoiSinh { get; set; }
		[StringLength(12)]
		public string Sdt { get; set; }

		public XeKhach XeKhach { get; set; }
	}
	public class NhaXe
	{
		[Key, StringLength(10)]
		public string MaNhaXe { get; set; }
		[StringLength(40)]
		public string TenNhaXe { get; set; }
		public int SoLuongXe { get; set; }
		[StringLength(12)]
		public string Sdt { get; set; }
		[StringLength(9)]
		public string MauBieuTuong { get; set; }
		[StringLength(60)]
		public string DiaChi { get; set; }

		public List<XeKhach> XeKhachList { get; set; }
	}
	public class DiemDung
	{
		[Key, StringLength(10)]
		public string MaDiemDung { get; set; }
		[Required, StringLength(20)]
		public string TenTinhTp { get; set; }
		[StringLength(50)]
		public string HuyenQuan { get; set; }
		[StringLength(50)]
		public string XaPhuong { get; set; }
		[StringLength(50)]
		public string ThonAp { get; set; }
		[StringLength(40)]
		public string SoNhaDuong { get; set; }

		public List<XeKhachDiemDung> XeKhachList { get; set; }

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			string p = ", ";
			if (SoNhaDuong != null) builder.Append(SoNhaDuong + p);
			if (ThonAp != null) builder.Append(ThonAp + p);
			if (XaPhuong != null) builder.Append(XaPhuong + p);
			if (HuyenQuan != null) builder.Append(HuyenQuan + p);
			if (TenTinhTp != null) builder.Append(TenTinhTp);
			return builder.ToString();
		}
	}
	public class XeKhach
	{
		[Key, StringLength(10)]
		public string MaXeKhach { get; set; }
		[StringLength(10)]
		public string MaNhaXe { get; set; }
		[StringLength(10)]
		public string MaTaiXe { get; set; }
		[Required, StringLength(12)]
		public string BienSoXe { get; set; }
		public int SoGhe { get; set; }
		public int GiaVe { get; set; }
		[Required, StringLength(20)]
		public string LoaiXe { get; set; }
		[Required, DataType(DataType.Time)]
		public TimeSpan GioKhoiHanh { get; set; }
		[Required, DataType(DataType.Time)]
		public TimeSpan ThoiGianDiChuyen { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime GiaoDichCuoi { get; set; }

		public TaiXe TaiXe { get; set; }
		public NhaXe NhaXe { get; set; }
		public List<XeKhachDiemDung> DiemDungList { get; set; }
	}
	public class XeKhachDiemDung
	{
		[Key]
		public int Stt { get; set; }
		[StringLength(10)]
		public string MaXeKhach { get; set; }
		[StringLength(10)]
		public string MaDiemDung { get; set; }
	}
	public class TTBenXe
	{
		[Key]
		public int Stt { get; set; }
		[StringLength(10)]
		public string MaXeKhach { get; set; }
		[StringLength(10)]
		public string MaViTri { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime GioNhapBen { get; set; }

		public XeKhach XeKhach { get; set; }
		public ViTroDo ViTroDo { get; set; }
	}
	public class ViTroDo
	{
		[Key, StringLength(10)]
		public string MaViTri { get; set; }
	}
	[NotMapped]
	public class ChuyenDi
	{
		public string TenNhaXe { get; set; }
		public string LoaiXe { get; set; }
		[Required]
		public string[] MaDiemDung { get; set; }
		[Required]
		public TimeSpan? GioKhoiHanh { get; set; }
		public TimeSpan? ThoiGianDiChuyenMin { get; set; }
		public TimeSpan? ThoiGianDiChuyenMax { get; set; }
		public int? GiaVeMin { get; set; }
		public int? GiaVeMax { get; set; }
		[Required]
		public DateTime NgayKhoiHanh { get; set; }
	}
}
