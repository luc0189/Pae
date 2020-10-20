using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "DeliveryActas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrefixSequence",
                table: "DeliveryActas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActaSequences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Prefix = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActaSequences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActaSequences");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "DeliveryActas");

            migrationBuilder.DropColumn(
                name: "PrefixSequence",
                table: "DeliveryActas");
        }
    }
}
