using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class VisitaCancelada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("108537ee-0bba-4935-b3ed-ba8ee65aa67a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1f3be911-d092-4f62-97fd-e8c73e165a44"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f9b68285-1216-4798-8dae-2bb977a53555"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8ab84098-cb8f-42ea-a1fd-5518be31f93b"), null, "Agent", "AGENT" },
                    { new Guid("bd6f0b06-c908-4cac-a5b9-5da95f2694ed"), null, "Person", "PERSON" },
                    { new Guid("e6f6e87e-4dcc-4389-b1bc-d1deacaca4c9"), null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "Visit_Status",
                columns: new[] { "Id", "Status" },
                values: new object[] { 4, "Canceled" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8ab84098-cb8f-42ea-a1fd-5518be31f93b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bd6f0b06-c908-4cac-a5b9-5da95f2694ed"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e6f6e87e-4dcc-4389-b1bc-d1deacaca4c9"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("108537ee-0bba-4935-b3ed-ba8ee65aa67a"), null, "Supervisor", "SUPERVISOR" },
                    { new Guid("1f3be911-d092-4f62-97fd-e8c73e165a44"), null, "Agent", "AGENT" },
                    { new Guid("f9b68285-1216-4798-8dae-2bb977a53555"), null, "Person", "PERSON" }
                });
        }
    }
}
