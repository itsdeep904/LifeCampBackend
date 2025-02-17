using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeCamp.Migrations
{
    /// <inheritdoc />
    public partial class userlogin_Adminlogin_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleType",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "roleType",
                table: "AdminLogins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roleType",
                table: "UserLogins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "roleType",
                table: "AdminLogins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
