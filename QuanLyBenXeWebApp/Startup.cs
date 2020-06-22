using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

using QuanLyBenXeWebApp.Models;

namespace QuanLyBenXeWebApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<BenXeDaNangContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			//add identity
			services.AddIdentity<QuanTriVien, IdentityRole>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredLength = 4;
				options.Password.RequireUppercase = false;
			})
				.AddEntityFrameworkStores<BenXeDaNangContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication().AddCookie(options =>
			{
				options.Cookie.Name = "UserBenXeDN";
				options.LoginPath = "/account/login";
				options.AccessDeniedPath = "/account/denied";
			});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("QTTTGiaoDich", policy => policy.RequireRole("QTVGiaoDich"));
				options.AddPolicy("QTTTNhaXe", policy => policy.RequireAssertion(context => context.User.IsInRole("QTVGiaoDich")||context.User.IsInRole("QTVNhaXe")));
				options.AddPolicy("QTTTVaoRa", policy => policy.RequireAssertion(context=>context.User.IsInRole("QTVGiaoDich")||context.User.IsInRole("QTVVaoRa")));
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseCookiePolicy();
			//enablle authenticating
			//app.UseCookieAuthentication(new CookieAuthenticationOptions()
			//{

			//})
			app.UseAuthentication();
			
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
