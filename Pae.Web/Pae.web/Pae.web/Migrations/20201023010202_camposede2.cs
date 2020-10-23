using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class camposede2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdSedes",
                table: "Sedes",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdIns",
                table: "Institucions",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sedes2",
                table: "Estudents",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "ActaSequences",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSedes",
                table: "Sedes");

            migrationBuilder.DropColumn(
                name: "IdIns",
                table: "Institucions");

            migrationBuilder.DropColumn(
                name: "sedes2",
                table: "Estudents");

            migrationBuilder.AlterColumn<string>(
                name: "Prefix",
                table: "ActaSequences",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
