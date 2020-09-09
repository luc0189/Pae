using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class fieldMesaStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mesa",
                table: "Estudents",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mesa",
                table: "Estudents");
        }
    }
}
