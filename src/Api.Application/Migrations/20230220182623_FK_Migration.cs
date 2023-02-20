using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class FKMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residencial_Property_Person_PersonId1",
                table: "Residencial_Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Technical_Visit_Agent_AgentId1",
                table: "Technical_Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Technical_Visit_Residencial_Property_ResidencialPropertyId1",
                table: "Technical_Visit");

            migrationBuilder.DropIndex(
                name: "IX_Technical_Visit_AgentId1",
                table: "Technical_Visit");

            migrationBuilder.DropIndex(
                name: "IX_Technical_Visit_ResidencialPropertyId1",
                table: "Technical_Visit");

            migrationBuilder.DropIndex(
                name: "IX_Residencial_Property_PersonId1",
                table: "Residencial_Property");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "Technical_Visit");

            migrationBuilder.DropColumn(
                name: "ResidencialPropertyId1",
                table: "Technical_Visit");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "Residencial_Property");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidencialPropertyId",
                table: "Technical_Visit",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "Technical_Visit",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Residencial_Property",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Technical_Visit_AgentId",
                table: "Technical_Visit",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Technical_Visit_ResidencialPropertyId",
                table: "Technical_Visit",
                column: "ResidencialPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Residencial_Property_PersonId",
                table: "Residencial_Property",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residencial_Property_Person_PersonId",
                table: "Residencial_Property",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technical_Visit_Agent_AgentId",
                table: "Technical_Visit",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technical_Visit_Residencial_Property_ResidencialPropertyId",
                table: "Technical_Visit",
                column: "ResidencialPropertyId",
                principalTable: "Residencial_Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residencial_Property_Person_PersonId",
                table: "Residencial_Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Technical_Visit_Agent_AgentId",
                table: "Technical_Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Technical_Visit_Residencial_Property_ResidencialPropertyId",
                table: "Technical_Visit");

            migrationBuilder.DropIndex(
                name: "IX_Technical_Visit_AgentId",
                table: "Technical_Visit");

            migrationBuilder.DropIndex(
                name: "IX_Technical_Visit_ResidencialPropertyId",
                table: "Technical_Visit");

            migrationBuilder.DropIndex(
                name: "IX_Residencial_Property_PersonId",
                table: "Residencial_Property");

            migrationBuilder.AlterColumn<int>(
                name: "ResidencialPropertyId",
                table: "Technical_Visit",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Technical_Visit",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId1",
                table: "Technical_Visit",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ResidencialPropertyId1",
                table: "Technical_Visit",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Residencial_Property",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId1",
                table: "Residencial_Property",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Technical_Visit_AgentId1",
                table: "Technical_Visit",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Technical_Visit_ResidencialPropertyId1",
                table: "Technical_Visit",
                column: "ResidencialPropertyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Residencial_Property_PersonId1",
                table: "Residencial_Property",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Residencial_Property_Person_PersonId1",
                table: "Residencial_Property",
                column: "PersonId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technical_Visit_Agent_AgentId1",
                table: "Technical_Visit",
                column: "AgentId1",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technical_Visit_Residencial_Property_ResidencialPropertyId1",
                table: "Technical_Visit",
                column: "ResidencialPropertyId1",
                principalTable: "Residencial_Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
