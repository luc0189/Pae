using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class cambiodataEstudiantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudents_Sites_SiteId",
                table: "Estudents");

            migrationBuilder.DropColumn(
                name: "Mesa",
                table: "Estudents");

            migrationBuilder.DropColumn(
                name: "ImageActaUrl",
                table: "DetailsDeliveries");

            migrationBuilder.DropColumn(
                name: "ImageAcudienteUrl",
                table: "DetailsDeliveries");

            migrationBuilder.DropColumn(
                name: "ImageStudentUrl",
                table: "DetailsDeliveries");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Estudents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Document",
                table: "Estudents",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ImageDeliveryUrl",
                table: "DetailsDeliveries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Imagedoc2",
                table: "DetailsDeliveries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagedocl",
                table: "DetailsDeliveries",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudents_Sites_SiteId",
                table: "Estudents",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudents_Sites_SiteId",
                table: "Estudents");

            migrationBuilder.DropColumn(
                name: "Imagedoc2",
                table: "DetailsDeliveries");

            migrationBuilder.DropColumn(
                name: "Imagedocl",
                table: "DetailsDeliveries");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Estudents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Document",
                table: "Estudents",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "Mesa",
                table: "Estudents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageDeliveryUrl",
                table: "DetailsDeliveries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageActaUrl",
                table: "DetailsDeliveries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageAcudienteUrl",
                table: "DetailsDeliveries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageStudentUrl",
                table: "DetailsDeliveries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudents_Sites_SiteId",
                table: "Estudents",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
