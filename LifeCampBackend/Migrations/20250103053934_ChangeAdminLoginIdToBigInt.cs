using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeCamp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminLoginIdToBigInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint on AdminLogins
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminLogins",
                table: "AdminLogins");

            // Drop the existing Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdminLogins");

            // Add the Id column back with the new data type (bigint)
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "AdminLogins",
                type: "bigint",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Re-add the primary key constraint
            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminLogins",
                table: "AdminLogins",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminLogins",
                table: "AdminLogins");

            // Drop the Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdminLogins");

            // Add the Id column back with the original data type (int)
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AdminLogins",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Re-add the primary key constraint
            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminLogins",
                table: "AdminLogins",
                column: "Id");
        }

    }
}
