using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class modify_endate_sincro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EndUpdate",
                table: "Sincros",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndUpdate",
                table: "Sincros",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
