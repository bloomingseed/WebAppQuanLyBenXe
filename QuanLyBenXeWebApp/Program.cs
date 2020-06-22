using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuanLyBenXeWebApp.Models;


namespace QuanLyBenXeWebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();
			//seed db
			#region 
			using (var services = host.Services.CreateScope())
			{
				var dbContext = services.ServiceProvider.GetRequiredService<BenXeDaNangContext>();
				var userManager = services.ServiceProvider.GetRequiredService<UserManager<QuanTriVien>>();
				var roleManager = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				IdentityRole vp, nx, vr;
				vp = new IdentityRole("QtvVanPhong");
				vr = new IdentityRole("QTVVaoRa");
				nx = new IdentityRole("QtvNhaXe");


				if (!dbContext.Roles.Any(role => role.Name == "QtvVanPhong"))
					roleManager.CreateAsync(vp).GetAwaiter().GetResult();
				if (!dbContext.Roles.Any(role => role.Name == "QtvVaoRa"))
					roleManager.CreateAsync(vr).GetAwaiter().GetResult();
				if (!dbContext.Roles.Any(role => role.Name == "QtvNhaXe"))
					roleManager.CreateAsync(nx).GetAwaiter().GetResult();


				if (!dbContext.Users.Any(user => user.Id == "QT00000001"))
				{
					var adminUser = new QuanTriVien
					{
						Id = "QT00000001",
						UserName = "officeadmin",
						HoDem = "Tăng Bá Hồng",
						Ten = "Phúc",
						NamGioi = true,
						PhoneNumber = "19001009"
					};
					string pwd = "se12";
					var result = userManager.CreateAsync(adminUser, pwd).GetAwaiter().GetResult();
					userManager.AddToRoleAsync(adminUser, vp.Name).GetAwaiter().GetResult();
				}
				//if (!dbContext.Users.Any(user => user.Id == "QT00000002"))
				//{
				//	var adminUser = new QuanTriVien
				//	{
				//		Id = "QT00000002",
				//		MaNhaXe = "NX00000001",
				//		UserName = "admin@nhaxeA",
				//		HoDem = "Trần Đinh Phước",
				//		Ten = "Nghĩa",
				//		NamGioi = true,
				//		PhoneNumber = "19009001"
				//	};
				//	string pwd = "se12";
				//	var result = userManager.CreateAsync(adminUser, pwd).GetAwaiter().GetResult();
				//	userManager.AddToRoleAsync(adminUser, nx.Name).GetAwaiter().GetResult();
				//}


				//}
				#endregion
				host.Run();
			}
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
