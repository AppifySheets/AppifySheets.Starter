using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3.EfCore.Migrations.Migrations
{
    public partial class Next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsControlling",
                table: "ApplicationRoles");

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Condition",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Condition_PatientId",
                table: "Condition",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Condition_Patient_PatientId",
                table: "Condition",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condition_Patient_PatientId",
                table: "Condition");

            migrationBuilder.DropIndex(
                name: "IX_Condition_PatientId",
                table: "Condition");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Condition");

            migrationBuilder.AddColumn<bool>(
                name: "IsControlling",
                table: "ApplicationRoles",
                type: "boolean",
                nullable: true);
        }
    }
}
