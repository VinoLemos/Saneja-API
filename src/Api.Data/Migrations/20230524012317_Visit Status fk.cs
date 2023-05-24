using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class VisitStatusfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5181643b-19e7-4eb6-8d28-678123da41c4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d3a4e42-f045-4c77-9933-204d4542029f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("db2462c8-cd5d-4e38-acd5-9c25931f49cf"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("0ad8e6dd-96b5-404b-9421-a4223cf5590f"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("29332052-da85-48ad-927f-ca580d0298f0"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("7cefe7cf-1679-48a7-ae36-3d492949026f"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("b71e3b79-5446-4ece-b18d-1bc6e9a777e0"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("195f6141-21da-4c28-a9c5-d79ec6658b91"), null, "Supervisor", "SUPERVISOR" },
                    { new Guid("ce397ceb-fa1e-4d44-8e75-0242e198cc30"), null, "Agent", "AGENT" },
                    { new Guid("fe6c9d53-7807-4014-b9ee-b7d57b617b55"), null, "Person", "PERSON" }
                });

            migrationBuilder.InsertData(
                table: "Visit_Status",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("03448e09-4d57-4f05-b0c2-ec1b10d7691d"), null, "Canceled", null },
                    { new Guid("0e52f812-32f8-4f59-97f0-003b1c21e385"), null, "Pending", null },
                    { new Guid("b678b444-4422-4b26-b26b-dd6c7220fbcf"), null, "In Progress", null },
                    { new Guid("e0a2eb2b-2b51-4e47-a7ca-b6afa3c966b5"), null, "Finished", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("195f6141-21da-4c28-a9c5-d79ec6658b91"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ce397ceb-fa1e-4d44-8e75-0242e198cc30"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fe6c9d53-7807-4014-b9ee-b7d57b617b55"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("03448e09-4d57-4f05-b0c2-ec1b10d7691d"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("0e52f812-32f8-4f59-97f0-003b1c21e385"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("b678b444-4422-4b26-b26b-dd6c7220fbcf"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("e0a2eb2b-2b51-4e47-a7ca-b6afa3c966b5"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5181643b-19e7-4eb6-8d28-678123da41c4"), null, "Person", "PERSON" },
                    { new Guid("7d3a4e42-f045-4c77-9933-204d4542029f"), null, "Agent", "AGENT" },
                    { new Guid("db2462c8-cd5d-4e38-acd5-9c25931f49cf"), null, "Supervisor", "SUPERVISOR" }
                });

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
        }
    }
}
