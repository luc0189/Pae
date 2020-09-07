using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class initial2_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryActa_Estudents_EstudentsId",
                table: "DeliveryActa");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryActa_Periodos_PeriodosId",
                table: "DeliveryActa");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsDeliveries_DeliveryActa_DeliveryActaId",
                table: "DetailsDeliveries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryActa",
                table: "DeliveryActa");

            migrationBuilder.RenameTable(
                name: "DeliveryActa",
                newName: "DeliveryActas");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryActa_PeriodosId",
                table: "DeliveryActas",
                newName: "IX_DeliveryActas_PeriodosId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryActa_EstudentsId",
                table: "DeliveryActas",
                newName: "IX_DeliveryActas_EstudentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryActas",
                table: "DeliveryActas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryActas_Estudents_EstudentsId",
                table: "DeliveryActas",
                column: "EstudentsId",
                principalTable: "Estudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryActas_Periodos_PeriodosId",
                table: "DeliveryActas",
                column: "PeriodosId",
                principalTable: "Periodos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsDeliveries_DeliveryActas_DeliveryActaId",
                table: "DetailsDeliveries",
                column: "DeliveryActaId",
                principalTable: "DeliveryActas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryActas_Estudents_EstudentsId",
                table: "DeliveryActas");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryActas_Periodos_PeriodosId",
                table: "DeliveryActas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsDeliveries_DeliveryActas_DeliveryActaId",
                table: "DetailsDeliveries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryActas",
                table: "DeliveryActas");

            migrationBuilder.RenameTable(
                name: "DeliveryActas",
                newName: "DeliveryActa");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryActas_PeriodosId",
                table: "DeliveryActa",
                newName: "IX_DeliveryActa_PeriodosId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryActas_EstudentsId",
                table: "DeliveryActa",
                newName: "IX_DeliveryActa_EstudentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryActa",
                table: "DeliveryActa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryActa_Estudents_EstudentsId",
                table: "DeliveryActa",
                column: "EstudentsId",
                principalTable: "Estudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryActa_Periodos_PeriodosId",
                table: "DeliveryActa",
                column: "PeriodosId",
                principalTable: "Periodos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsDeliveries_DeliveryActa_DeliveryActaId",
                table: "DetailsDeliveries",
                column: "DeliveryActaId",
                principalTable: "DeliveryActa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
