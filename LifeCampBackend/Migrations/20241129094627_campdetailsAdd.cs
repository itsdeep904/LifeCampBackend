using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeCamp.Migrations
{
    /// <inheritdoc />
    public partial class campdetailsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "CampDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "CampDetails",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "CampDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "CampDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "OrganizerId",
                table: "CampDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CampDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "CampDetails",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "CampDetails");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "CampDetails");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CampDetails");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CampDetails");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "CampDetails");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CampDetails");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "CampDetails");
        }
    }
}
