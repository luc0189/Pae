using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class longTelMOvil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "DetailsDeliveries");

            migrationBuilder.AlterColumn<long>(
                name: "TelMovil",
                table: "DetailsDeliveries",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TelMovil",
                table: "DetailsDeliveries",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "DetailsDeliveries",
                nullable: true);
        }
    }
}
