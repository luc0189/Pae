using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class chague_site_sede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudents_Sites_SiteId",
                table: "Estudents");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "Estudents",
                newName: "SedesId");

            migrationBuilder.RenameIndex(
                name: "IX_Estudents_SiteId",
                table: "Estudents",
                newName: "IX_Estudents_SedesId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Estudents",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Mesa",
                table: "Estudents",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameSedes = table.Column<string>(maxLength: 100, nullable: false),
                    InstitucionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sedes_Institucions_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Institucions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_InstitucionId",
                table: "Sedes",
                column: "InstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudents_Sedes_SedesId",
                table: "Estudents",
                column: "SedesId",
                principalTable: "Sedes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudents_Sedes_SedesId",
                table: "Estudents");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropColumn(
                name: "Mesa",
                table: "Estudents");

            migrationBuilder.RenameColumn(
                name: "SedesId",
                table: "Estudents",
                newName: "SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Estudents_SedesId",
                table: "Estudents",
                newName: "IX_Estudents_SiteId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Estudents",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstitucionId = table.Column<int>(nullable: true),
                    NameSite = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Institucions_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Institucions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sites_InstitucionId",
                table: "Sites",
                column: "InstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudents_Sites_SiteId",
                table: "Estudents",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
