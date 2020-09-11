using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class updateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDeliveryUrl",
                table: "DetailsDeliveries");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Estudents",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "NOrden",
                table: "Estudents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NOrden",
                table: "Estudents");

            migrationBuilder.AlterColumn<long>(
                name: "Document",
                table: "Estudents",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ImageDeliveryUrl",
                table: "DetailsDeliveries",
                nullable: true);
        }
    }
}
