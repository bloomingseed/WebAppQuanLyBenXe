using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBenXeWebApp.Models
{
	public class QuanTriVien : IdentityUser
	{
		[Key, StringLength(10)]
		public override string Id { get; set; }
		[StringLength(10)]
		public string MaNhaXe { get; set; }
		[Required, StringLength(30)]
		public override string UserName { get; set; }
		[Required, StringLength(20)]
		public string HoDem { get; set; }
		[Required, StringLength(10)]
		public string Ten { get; set; }
		public bool NamGioi { get; set; }
		[StringLength(40)]
		public string NoiSinh { get; set; }
		[Required, StringLength(12)]
		public override string PhoneNumber { get; set; }

		[NotMapped]
		public string GioiTinh { get
			{
				return NamGioi ? "Nam" : "Nữ";
			} }

		public NhaXe NhaXe { get; set; }
	}
	public class LoginViewModel
	{
		[Required, StringLength(30)]
		public string UserName { get; set; }
		[Required, StringLength(18)]
		public string Password { get; set; }
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
		public bool RememberMe { get; set; }
		public string ReturnUrl { get; set; }
	}
}
