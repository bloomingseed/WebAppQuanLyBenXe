using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyBenXeWebApp.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiemDung",
                columns: table => new
                {
                    MaDiemDung = table.Column<string>(maxLength: 10, nullable: false),
                    TenTinhTp = table.Column<string>(maxLength: 20, nullable: false),
                    HuyenQuan = table.Column<string>(maxLength: 50, nullable: true),
                    XaPhuong = table.Column<string>(maxLength: 50, nullable: true),
                    ThonAp = table.Column<string>(maxLength: 50, nullable: true),
                    SoNhaDuong = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemDung", x => x.MaDiemDung);
                });

            migrationBuilder.CreateTable(
                name: "NhaXe",
                columns: table => new
                {
                    MaNhaXe = table.Column<string>(maxLength: 10, nullable: false),
                    TenNhaXe = table.Column<string>(maxLength: 40, nullable: false),
                    SoLuongXe = table.Column<int>(nullable: false),
                    Sdt = table.Column<string>(maxLength: 12, nullable: false),
                    MauBieuTuong = table.Column<string>(maxLength: 7, nullable: false),
                    DiaChi = table.Column<string>(maxLength: 60, nullable: false),
                    GiaoDichCuoi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXe", x => x.MaNhaXe);
                });

            migrationBuilder.CreateTable(
                name: "TaiXe",
                columns: table => new
                {
                    MaTaiXe = table.Column<string>(maxLength: 10, nullable: false),
                    HoDem = table.Column<string>(maxLength: 20, nullable: false),
                    Ten = table.Column<string>(maxLength: 10, nullable: false),
                    GioiTinh = table.Column<bool>(nullable: false),
                    NoiSinh = table.Column<string>(maxLength: 50, nullable: true),
                    Sdt = table.Column<string>(maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiXe", x => x.MaTaiXe);
                });

            migrationBuilder.CreateTable(
                name: "ViTriDo",
                columns: table => new
                {
                    MaViTri = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTriDo", x => x.MaViTri);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    MaNhaXe = table.Column<string>(maxLength: 10, nullable: true),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    HoDem = table.Column<string>(maxLength: 20, nullable: false),
                    Ten = table.Column<string>(maxLength: 10, nullable: false),
                    GioiTinh = table.Column<bool>(nullable: false),
                    NoiSinh = table.Column<string>(maxLength: 40, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_NhaXe_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXe",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiaoDich",
                columns: table => new
                {
                    MaGiaoDich = table.Column<string>(maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(maxLength: 10, nullable: false),
                    NgayGiaoDich = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDich", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK_GiaoDich_NhaXe_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXe",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XeKhach",
                columns: table => new
                {
                    MaXeKhach = table.Column<string>(maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(maxLength: 10, nullable: false),
                    MaTaiXe = table.Column<string>(maxLength: 10, nullable: false),
                    BienSoXe = table.Column<string>(maxLength: 12, nullable: false),
                    SoGhe = table.Column<int>(nullable: false),
                    GiaVe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeKhach", x => x.MaXeKhach);
                    table.ForeignKey(
                        name: "FK_XeKhach_NhaXe_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXe",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XeKhach_TaiXe_MaTaiXe",
                        column: x => x.MaTaiXe,
                        principalTable: "TaiXe",
                        principalColumn: "MaTaiXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuVaoRa",
                columns: table => new
                {
                    Stt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaXeKhach = table.Column<string>(maxLength: 10, nullable: false),
                    MaViTri = table.Column<string>(maxLength: 10, nullable: false),
                    VaoBen = table.Column<bool>(nullable: false),
                    ThoiDiem = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuVaoRa", x => x.Stt);
                    table.ForeignKey(
                        name: "FK_LichSuVaoRa_ViTriDo_MaViTri",
                        column: x => x.MaViTri,
                        principalTable: "ViTriDo",
                        principalColumn: "MaViTri",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuVaoRa_XeKhach_MaXeKhach",
                        column: x => x.MaXeKhach,
                        principalTable: "XeKhach",
                        principalColumn: "MaXeKhach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTBenXe",
                columns: table => new
                {
                    Stt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaXeKhach = table.Column<string>(maxLength: 10, nullable: false),
                    MaViTri = table.Column<string>(maxLength: 10, nullable: false),
                    GioNhapBen = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTBenXe", x => x.Stt);
                    table.ForeignKey(
                        name: "FK_TTBenXe_ViTriDo_MaViTri",
                        column: x => x.MaViTri,
                        principalTable: "ViTriDo",
                        principalColumn: "MaViTri",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTBenXe_XeKhach_MaXeKhach",
                        column: x => x.MaXeKhach,
                        principalTable: "XeKhach",
                        principalColumn: "MaXeKhach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XeKhach_DiemDung",
                columns: table => new
                {
                    Stt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaXeKhach = table.Column<string>(maxLength: 10, nullable: false),
                    MaDiemDung = table.Column<string>(maxLength: 10, nullable: false),
                    GioDiKhoiDN = table.Column<TimeSpan>(nullable: false),
                    TGDCkhoiDN = table.Column<TimeSpan>(nullable: false),
                    GioDiToiDN = table.Column<TimeSpan>(nullable: false),
                    TGDCtoiDN = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeKhach_DiemDung", x => x.Stt);
                    table.ForeignKey(
                        name: "FK_XeKhach_DiemDung_DiemDung_MaDiemDung",
                        column: x => x.MaDiemDung,
                        principalTable: "DiemDung",
                        principalColumn: "MaDiemDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XeKhach_DiemDung_XeKhach_MaXeKhach",
                        column: x => x.MaXeKhach,
                        principalTable: "XeKhach",
                        principalColumn: "MaXeKhach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaNhaXe",
                table: "AspNetUsers",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDich_MaNhaXe",
                table: "GiaoDich",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuVaoRa_MaViTri",
                table: "LichSuVaoRa",
                column: "MaViTri");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuVaoRa_MaXeKhach",
                table: "LichSuVaoRa",
                column: "MaXeKhach");

            migrationBuilder.CreateIndex(
                name: "IX_TTBenXe_MaViTri",
                table: "TTBenXe",
                column: "MaViTri");

            migrationBuilder.CreateIndex(
                name: "IX_TTBenXe_MaXeKhach",
                table: "TTBenXe",
                column: "MaXeKhach");

            migrationBuilder.CreateIndex(
                name: "IX_XeKhach_MaNhaXe",
                table: "XeKhach",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_XeKhach_MaTaiXe",
                table: "XeKhach",
                column: "MaTaiXe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_XeKhach_DiemDung_MaDiemDung",
                table: "XeKhach_DiemDung",
                column: "MaDiemDung");

            migrationBuilder.CreateIndex(
                name: "IX_XeKhach_DiemDung_MaXeKhach_MaDiemDung_GioDiKhoiDN_GioDiToiDN_TGDCkhoiDN_TGDCtoiDN",
                table: "XeKhach_DiemDung",
                columns: new[] { "MaXeKhach", "MaDiemDung", "GioDiKhoiDN", "GioDiToiDN", "TGDCkhoiDN", "TGDCtoiDN" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GiaoDich");

            migrationBuilder.DropTable(
                name: "LichSuVaoRa");

            migrationBuilder.DropTable(
                name: "TTBenXe");

            migrationBuilder.DropTable(
                name: "XeKhach_DiemDung");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ViTriDo");

            migrationBuilder.DropTable(
                name: "DiemDung");

            migrationBuilder.DropTable(
                name: "XeKhach");

            migrationBuilder.DropTable(
                name: "NhaXe");

            migrationBuilder.DropTable(
                name: "TaiXe");
        }
    }
}
