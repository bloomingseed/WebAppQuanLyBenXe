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
	public class BenXeDaNangContext : IdentityDbContext<QuanTriVien>
	{
		public DbSet<TaiXe> TaiXe { get; set; }
		public DbSet<NhaXe> NhaXe { get; set; }
		public DbSet<DiemDung> DiemDung { get; set; }
		public DbSet<XeKhach> XeKhach { get; set; }
		public DbSet<XeKhach_DiemDung> XeKhach_DiemDung { get; set; }
		public DbSet<ViTriDo> ViTriDo { get; set; }
		public DbSet<TTBenXe> TTBenXe { get; set; }
		public DbSet<LichSuVaoRa> LichSuVaoRa { get; set; }
		public DbSet<GiaoDich> GiaoDich { get; set; }

		public BenXeDaNangContext(DbContextOptions<BenXeDaNangContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<XeKhach_DiemDung>()
				.HasIndex(record => new {
					record.MaXeKhach, record.MaDiemDung, record.GioDiKhoiDN,
					record.GioDiToiDN, record.TGDCkhoiDN, record.TGDCtoiDN})
				.IsUnique();
		}
	}

	public class NhaXe
	{
		[Key, StringLength(10,MinimumLength =10)]
		public string MaNhaXe { get; set; }
		[Required, StringLength(40)]
		public string TenNhaXe { get; set; }
		public int SoLuongXe { get; set; }
		[Required, StringLength(12,MinimumLength =10)]
		public string Sdt { get; set; }
		[Required, StringLength(7, MinimumLength =7)]
		public string MauBieuTuong { get; set; }
		[Required, StringLength(60)]
		public string DiaChi { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime GiaoDichCuoi { get; set; }

		public List<XeKhach> XeKhachList { get; set; }
	}

	public class TaiXe
	{
		[Key, StringLength(10, MinimumLength = 10)]
		public string MaTaiXe { get; set; }
		[Required, StringLength(20)]
		public string HoDem { get; set; }
		[Required, StringLength(10)]
		public string Ten { get; set; }
		public bool GioiTinh { get; set; }
		[StringLength(50)]
		public string NoiSinh { get; set; }
		[Required, StringLength(12, MinimumLength = 10)]
		public string Sdt { get; set; }

		public XeKhach XeKhach { get; set; }

		public override string ToString()
		{
			return $"{HoDem} {Ten}";
		}
	}

	public class XeKhach
	{
		[Key, StringLength(10, MinimumLength = 10)]
		public string MaXeKhach { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaNhaXe { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaTaiXe { get; set; }
		[Required, StringLength(12, MinimumLength =12)]
		public string BienSoXe { get; set; }
		public int SoGhe { get; set; }
		public int GiaVe { get; set; }

		public TaiXe TaiXe { get; set; }
		public NhaXe NhaXe { get; set; }
		public List<XeKhach_DiemDung> DiemDungList { get; set; }
	}

	public class GiaoDich
	{
		[Key, StringLength(10, MinimumLength = 10)]
		public string MaGiaoDich { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaNhaXe { get; set; }
		[Required, DataType(DataType.DateTime)]
		public DateTime NgayGiaoDich { get; set; }

		public NhaXe NhaXe { get; set; }
	}

	public class ViTriDo
	{
		[Key, StringLength(10, MinimumLength = 10)]
		public string MaViTri { get; set; }
	}

	public class TTBenXe
	{
		[Key]
		public int Stt { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaXeKhach { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaViTri { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime GioNhapBen { get; set; }

		public XeKhach XeKhach { get; set; }
		public ViTriDo ViTriDo { get; set; }
	}

	public class LichSuVaoRa
	{
		[Key]
		public int Stt { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaXeKhach { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaViTri { get; set; }
		public bool VaoBen { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime ThoiDiem { get; set; }

		public XeKhach XeKhach { get; set; }
		public ViTriDo ViTriDo { get; set; }
	}

	public class DiemDung
	{
		[Key, StringLength(10, MinimumLength = 10)]
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

		public List<XeKhach_DiemDung> XeKhachList { get; set; }

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

	public class XeKhach_DiemDung
	{
		[Key]
		public int Stt { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaXeKhach { get; set; }
		[Required, StringLength(10, MinimumLength = 10)]
		public string MaDiemDung { get; set; }
		public TimeSpan GioDiKhoiDN { get; set; }
		public TimeSpan TGDCkhoiDN{ get; set; }
		public TimeSpan GioDiToiDN { get; set; }
		public TimeSpan TGDCtoiDN{ get; set; }

		public XeKhach XeKhach { get; set; }
		public DiemDung DiemDung { get; set; }
	}
	
	[NotMapped]
	public class ChuyenDi
	{
		//core information
		[Required]
		public string DiemDi { get; set; }
		[Required]
		public string DiemDen { get; set; }
		[Required]
		public DateTime NgayKhoiHanh { get; set; }
		//nullable information
		public string TenNhaXe { get; set; }
		public int? SoGhe { get; set; }
		public TimeSpan? ThoiGianDiChuyenMax { get; set; }
		public int? GiaVeMax { get; set; }
		
	}
	public static class Utils
	{
		public static string IncrementString(string id)
		{
			StringBuilder s = new StringBuilder();
			string indexString = (int.Parse(id) + 1).ToString();
			s.Append(new String('0', id.Length - indexString.Length));
			s.Append(indexString);
			return s.ToString();
		}
	}
}
