using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class longTelMOvil1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageStudentUrl",
                table: "DetailsDeliveries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageDeliveryUrl",
                table: "DetailsDeliveries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageAcudienteUrl",
                table: "DetailsDeliveries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageActaUrl",
                table: "DetailsDeliveries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageStudentUrl",
                table: "DetailsDeliveries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageDeliveryUrl",
                table: "DetailsDeliveries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageAcudienteUrl",
                table: "DetailsDeliveries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageActaUrl",
                table: "DetailsDeliveries",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
