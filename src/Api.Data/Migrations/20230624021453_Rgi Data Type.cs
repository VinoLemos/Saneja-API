using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RgiDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5506d35c-a5d2-44f5-b0bb-70953dfcced2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("563191b8-5dec-4253-b5d2-8cddba6b79ce"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e59463b8-0c73-4b56-9b5b-52344980bd1f"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("386dcac8-e70b-42b7-990a-f6822c822245"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("3b61677a-9b53-43f5-a74b-de48c4d2c6ed"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("442ed696-b819-493f-aab8-b754104673c6"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("a63ddc8b-3a81-4bcc-b2c4-71a6089e776b"));

            migrationBuilder.AlterColumn<string>(
                name: "Rgi",
                table: "Residential_Property",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("14a1bc50-a345-4dfa-bb52-2868932b8040"), null, "Supervisor", "SUPERVISOR" },
                    { new Guid("2a18ce7c-3105-426b-9062-7920904ff0c0"), null, "Person", "PERSON" },
                    { new Guid("c8a9e94f-6c5a-432c-ac96-7fca1656c2c5"), null, "Agent", "AGENT" }
                });

            migrationBuilder.InsertData(
                table: "Visit_Status",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("009b9b5f-f6fa-4200-ac4e-e517bc2edd6e"), null, "Pending", null },
                    { new Guid("0253e33a-dc30-4ec3-9cd8-49446a83176d"), null, "In Progress", null },
                    { new Guid("138cead1-dd33-4a18-81a4-0bd154671694"), null, "Finished", null },
                    { new Guid("e5d2a979-1961-4d58-b6c5-d82eb2b7f02d"), null, "Canceled", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("14a1bc50-a345-4dfa-bb52-2868932b8040"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2a18ce7c-3105-426b-9062-7920904ff0c0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c8a9e94f-6c5a-432c-ac96-7fca1656c2c5"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("009b9b5f-f6fa-4200-ac4e-e517bc2edd6e"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("0253e33a-dc30-4ec3-9cd8-49446a83176d"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("138cead1-dd33-4a18-81a4-0bd154671694"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: new Guid("e5d2a979-1961-4d58-b6c5-d82eb2b7f02d"));

            migrationBuilder.AlterColumn<int>(
                name: "Rgi",
                table: "Residential_Property",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5506d35c-a5d2-44f5-b0bb-70953dfcced2"), null, "Agent", "AGENT" },
                    { new Guid("563191b8-5dec-4253-b5d2-8cddba6b79ce"), null, "Person", "PERSON" },
                    { new Guid("e59463b8-0c73-4b56-9b5b-52344980bd1f"), null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "Visit_Status",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("386dcac8-e70b-42b7-990a-f6822c822245"), null, "In Progress", null },
                    { new Guid("3b61677a-9b53-43f5-a74b-de48c4d2c6ed"), null, "Canceled", null },
                    { new Guid("442ed696-b819-493f-aab8-b754104673c6"), null, "Pending", null },
                    { new Guid("a63ddc8b-3a81-4bcc-b2c4-71a6089e776b"), null, "Finished", null }
                });
        }
    }
}
