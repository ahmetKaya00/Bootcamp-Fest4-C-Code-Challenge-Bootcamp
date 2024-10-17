using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreapp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOgretmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "Bootcamps",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: true),
                    Eposta = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_BootcampId",
                table: "KursKayitlari",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_Bootcamps_OgretmenId",
                table: "Bootcamps",
                column: "OgretmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Ogretmenler_OgretmenId",
                table: "Bootcamps",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Bootcamps_BootcampId",
                table: "KursKayitlari",
                column: "BootcampId",
                principalTable: "Bootcamps",
                principalColumn: "BootcampId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Ogretmenler_OgretmenId",
                table: "Bootcamps");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Bootcamps_BootcampId",
                table: "KursKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_BootcampId",
                table: "KursKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_Bootcamps_OgretmenId",
                table: "Bootcamps");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "Bootcamps");
        }
    }
}
