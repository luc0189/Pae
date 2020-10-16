using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pae.web.Migrations
{
    public partial class datesincro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualización",
                table: "Sedes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualización",
                table: "Institucions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualización",
                table: "Estudents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualización",
                table: "DetailsDeliveries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualización",
                table: "DeliveryActas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaActualización",
                table: "Sedes");

            migrationBuilder.DropColumn(
                name: "FechaActualización",
                table: "Institucions");

            migrationBuilder.DropColumn(
                name: "FechaActualización",
                table: "Estudents");

            migrationBuilder.DropColumn(
                name: "FechaActualización",
                table: "DetailsDeliveries");

            migrationBuilder.DropColumn(
                name: "FechaActualización",
                table: "DeliveryActas");
        }
    }
}
