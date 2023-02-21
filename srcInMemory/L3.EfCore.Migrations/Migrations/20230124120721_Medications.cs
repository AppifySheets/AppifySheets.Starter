using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3.EfCore.Migrations.Migrations
{
    public partial class Medications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ConditionId",
                table: "Medication",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medication_ConditionId",
                table: "Medication",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Condition_ConditionId",
                table: "Medication",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Condition_ConditionId",
                table: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_Medication_ConditionId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Medication");
        }
    }
}
