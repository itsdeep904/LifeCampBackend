using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeCamp.Migrations
{
    /// <inheritdoc />
    public partial class camptable_Camptype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampType",
                table: "CampDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampType",
                table: "CampDetails");
        }
    }
}
