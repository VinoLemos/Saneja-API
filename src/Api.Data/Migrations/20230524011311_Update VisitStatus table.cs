using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitStatustable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Visit_Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit_Status", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Visit_Status",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0ad8e6dd-96b5-404b-9421-a4223cf5590f"), null, "Finished", null },
                    { new Guid("29332052-da85-48ad-927f-ca580d0298f0"), null, "In Progress", null },
                    { new Guid("7cefe7cf-1679-48a7-ae36-3d492949026f"), null, "Pending", null },
                    { new Guid("b71e3b79-5446-4ece-b18d-1bc6e9a777e0"), null, "Canceled", null }
                });

            migrationBuilder.CreateIndex(
            name: "IX_Technical_Visit_StatusId1",
            table: "Technical_Visit",
            column: "StatusId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role_Claims");

            migrationBuilder.DropTable(
                name: "Technical_Visit");

            migrationBuilder.DropTable(
                name: "User_Claims");

            migrationBuilder.DropTable(
                name: "User_Logins");

            migrationBuilder.DropTable(
                name: "User_Roles");

            migrationBuilder.DropTable(
                name: "User_Tokens");

            migrationBuilder.DropTable(
                name: "Residential_Property");

            migrationBuilder.DropTable(
                name: "Visit_Status");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
