using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
        name: "UserType",
        type: "varchar(10)",
        table: "Agent",
        nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                type: "varchar(10)",
                table: "Person",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "userType",
        table: "Agent");

            migrationBuilder.DropColumn(
                name: "userType",
                table: "Person");
        }
    }
}
