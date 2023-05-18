using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79fff86f-6877-48e4-a5a3-fdcb1e02724e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e2fc035-d064-4475-afff-e7eaa0285769"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d82721be-6a86-463e-b21c-d3d5a6431da2"));

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Residential_Property",
                type: "varchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a1dd733d-0343-4541-89e0-9748828eb78e"), null, "Agent", "AGENT" },
                    { new Guid("b436124b-e3a3-44c3-97f3-1c2cb1340d95"), null, "Person", "PERSON" },
                    { new Guid("d4f5feec-773a-4224-9aa6-47970bf194f1"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1dd733d-0343-4541-89e0-9748828eb78e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b436124b-e3a3-44c3-97f3-1c2cb1340d95"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d4f5feec-773a-4224-9aa6-47970bf194f1"));

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Residential_Property");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("79fff86f-6877-48e4-a5a3-fdcb1e02724e"), null, "Person", "PERSON" },
                    { new Guid("9e2fc035-d064-4475-afff-e7eaa0285769"), null, "Admin", "ADMIN" },
                    { new Guid("d82721be-6a86-463e-b21c-d3d5a6431da2"), null, "Agent", "AGENT" }
                });
        }
    }
}
