using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class update_table_delivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocAcudiente",
                table: "DetailsDeliveries");

            migrationBuilder.DropColumn(
                name: "FullNameAcudiente",
                table: "DetailsDeliveries");

            migrationBuilder.DropColumn(
                name: "SiteDelivery",
                table: "DetailsDeliveries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocAcudiente",
                table: "DetailsDeliveries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullNameAcudiente",
                table: "DetailsDeliveries",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiteDelivery",
                table: "DetailsDeliveries",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }
    }
}
