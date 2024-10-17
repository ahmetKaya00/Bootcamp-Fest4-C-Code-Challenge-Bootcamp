using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreapp.Migrations
{
    /// <inheritdoc />
    public partial class ColumnOgretmenIdRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Ogretmenler_OgretmenId",
                table: "Bootcamps");

            migrationBuilder.AlterColumn<int>(
                name: "OgretmenId",
                table: "Bootcamps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Ogretmenler_OgretmenId",
                table: "Bootcamps",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Ogretmenler_OgretmenId",
                table: "Bootcamps");

            migrationBuilder.AlterColumn<int>(
                name: "OgretmenId",
                table: "Bootcamps",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Ogretmenler_OgretmenId",
                table: "Bootcamps",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId");
        }
    }
}
