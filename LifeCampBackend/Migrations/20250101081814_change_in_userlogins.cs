using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeCamp.Migrations
{
    /// <inheritdoc />
    public partial class change_in_userlogins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            // Drop the existing Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLogins");

            // Add the Id column back with the new data type (bigint)
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserLogins",
                type: "bigint",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Re-add the primary key constraint
            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            // Drop the Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLogins");

            // Add the Id column back with the original data type (int)
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserLogins",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Re-add the primary key constraint
            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                column: "Id");
        }
    }
}
