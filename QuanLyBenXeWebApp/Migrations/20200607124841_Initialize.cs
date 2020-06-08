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
                    MaQTV = table.Column<string>(maxLength: 10, nullable: true),
                    TenNhaXe = table.Column<string>(maxLength: 40, nullable: true),
                    SoLuongXe = table.Column<int>(nullable: false),
                    Sdt = table.Column<string>(maxLength: 12, nullable: true),
                    MauBieuTuong = table.Column<string>(maxLength: 9, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 60, nullable: true)
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
                    NamGioi = table.Column<bool>(nullable: false),
                    NoiSinh = table.Column<string>(maxLength: 50, nullable: true),
                    Sdt = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiXe", x => x.MaTaiXe);
                });

            migrationBuilder.CreateTable(
                name: "ViTroDo",
                columns: table => new
                {
                    MaViTri = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTroDo", x => x.MaViTri);
                });

            migrationBuilder.CreateTable(
                name: "XeKhach",
                columns: table => new
                {
                    MaXeKhach = table.Column<string>(maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(maxLength: 10, nullable: true),
                    MaTaiXe = table.Column<string>(maxLength: 10, nullable: true),
                    BienSoXe = table.Column<string>(maxLength: 12, nullable: true),
                    SoGhe = table.Column<int>(nullable: false),
                    GiaVe = table.Column<int>(nullable: false),
                    LoaiXe = table.Column<string>(maxLength: 20, nullable: true),
                    GiaoDichCuoi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeKhach", x => x.MaXeKhach);
                    table.ForeignKey(
                        name: "FK_XeKhach_NhaXe_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXe",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XeKhach_TaiXe_MaTaiXe",
                        column: x => x.MaTaiXe,
                        principalTable: "TaiXe",
                        principalColumn: "MaTaiXe",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TTBenXe",
                columns: table => new
                {
                    Stt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaXeKhach = table.Column<string>(maxLength: 10, nullable: true),
                    MaViTri = table.Column<string>(maxLength: 10, nullable: true),
                    GioNhapBen = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTBenXe", x => x.Stt);
                    table.ForeignKey(
                        name: "FK_TTBenXe_ViTroDo_MaViTri",
                        column: x => x.MaViTri,
                        principalTable: "ViTroDo",
                        principalColumn: "MaViTri",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TTBenXe_XeKhach_MaXeKhach",
                        column: x => x.MaXeKhach,
                        principalTable: "XeKhach",
                        principalColumn: "MaXeKhach",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "XeKhachDiemDung",
                columns: table => new
                {
                    Stt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaXeKhach = table.Column<string>(maxLength: 10, nullable: true),
                    MaDiemDung = table.Column<string>(maxLength: 10, nullable: true),
                    GioDiKhoiDN = table.Column<TimeSpan>(nullable: false),
                    TGDCkhoiDN = table.Column<TimeSpan>(nullable: false),
                    GioDiToiDN = table.Column<TimeSpan>(nullable: false),
                    TGDCtoiDN = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XeKhachDiemDung", x => x.Stt);
                    table.ForeignKey(
                        name: "FK_XeKhachDiemDung_DiemDung_MaDiemDung",
                        column: x => x.MaDiemDung,
                        principalTable: "DiemDung",
                        principalColumn: "MaDiemDung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XeKhachDiemDung_XeKhach_MaXeKhach",
                        column: x => x.MaXeKhach,
                        principalTable: "XeKhach",
                        principalColumn: "MaXeKhach",
                        onDelete: ReferentialAction.Restrict);
                });

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
                unique: true,
                filter: "[MaTaiXe] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_XeKhachDiemDung_MaDiemDung",
                table: "XeKhachDiemDung",
                column: "MaDiemDung");

            migrationBuilder.CreateIndex(
                name: "IX_XeKhachDiemDung_MaXeKhach_MaDiemDung_GioDiKhoiDN_GioDiToiDN_TGDCkhoiDN_TGDCtoiDN",
                table: "XeKhachDiemDung",
                columns: new[] { "MaXeKhach", "MaDiemDung", "GioDiKhoiDN", "GioDiToiDN", "TGDCkhoiDN", "TGDCtoiDN" },
                unique: true,
                filter: "[MaXeKhach] IS NOT NULL AND [MaDiemDung] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TTBenXe");

            migrationBuilder.DropTable(
                name: "XeKhachDiemDung");

            migrationBuilder.DropTable(
                name: "ViTroDo");

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
