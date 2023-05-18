using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class VisitStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("009ae658-3865-4130-9447-1452b4ce86dd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("35db444d-30b4-4d73-aecf-c96f1d55cb32"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("85c38783-e6b2-4c00-8622-ae3514993519"));

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("108537ee-0bba-4935-b3ed-ba8ee65aa67a"), null, "Supervisor", "SUPERVISOR" },
                    { new Guid("1f3be911-d092-4f62-97fd-e8c73e165a44"), null, "Agent", "AGENT" },
                    { new Guid("f9b68285-1216-4798-8dae-2bb977a53555"), null, "Person", "PERSON" }
                });

            migrationBuilder.InsertData(
                table: "Visit_Status",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "In Progress" },
                    { 3, "Finished" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visit_Status",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("009ae658-3865-4130-9447-1452b4ce86dd"), null, "Person", "PERSON" },
                    { new Guid("35db444d-30b4-4d73-aecf-c96f1d55cb32"), null, "Supervisor", "SUPERVISOR" },
                    { new Guid("85c38783-e6b2-4c00-8622-ae3514993519"), null, "Agent", "AGENT" }
                });

            migrationBuilder.InsertData(
                table: "Visit_Status",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { -3, "Finished" },
                    { -2, "In Progress" },
                    { -1, "Pending" }
                });
        }
    }
}
