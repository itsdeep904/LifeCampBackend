using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeCamp.Migrations
{
    /// <inheritdoc />
    public partial class roleTypechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "UserLogins",
                newName: "roleType");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "AdminLogins",
                newName: "roleType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "roleType",
                table: "UserLogins",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "roleType",
                table: "AdminLogins",
                newName: "UserType");
        }
    }
}
