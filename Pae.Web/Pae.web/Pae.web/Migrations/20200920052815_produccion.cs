using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class produccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryActas_Periodos_PeriodosId",
                table: "DeliveryActas");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryActas_PeriodosId",
                table: "DeliveryActas");

            migrationBuilder.DropColumn(
                name: "PeriodosId",
                table: "DeliveryActas");

            migrationBuilder.AlterColumn<string>(
                name: "NOrden",
                table: "Estudents",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "AcudienteName",
                table: "Estudents",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentAcu",
                table: "Estudents",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Jornada",
                table: "Estudents",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Entrega3",
                table: "DeliveryActas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Entrega4",
                table: "DeliveryActas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Entrega5",
                table: "DeliveryActas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Entrega6",
                table: "DeliveryActas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Entrega7",
                table: "DeliveryActas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcudienteName",
                table: "Estudents");

            migrationBuilder.DropColumn(
                name: "DocumentAcu",
                table: "Estudents");

            migrationBuilder.DropColumn(
                name: "Jornada",
                table: "Estudents");

            migrationBuilder.DropColumn(
                name: "Entrega3",
                table: "DeliveryActas");

            migrationBuilder.DropColumn(
                name: "Entrega4",
                table: "DeliveryActas");

            migrationBuilder.DropColumn(
                name: "Entrega5",
                table: "DeliveryActas");

            migrationBuilder.DropColumn(
                name: "Entrega6",
                table: "DeliveryActas");

            migrationBuilder.DropColumn(
                name: "Entrega7",
                table: "DeliveryActas");

            migrationBuilder.AlterColumn<int>(
                name: "NOrden",
                table: "Estudents",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "PeriodosId",
                table: "DeliveryActas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryActas_PeriodosId",
                table: "DeliveryActas",
                column: "PeriodosId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryActas_Periodos_PeriodosId",
                table: "DeliveryActas",
                column: "PeriodosId",
                principalTable: "Periodos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
