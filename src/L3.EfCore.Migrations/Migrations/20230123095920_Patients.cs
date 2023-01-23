using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppifySheets.EFCore.Migrations.Migrations
{
    public partial class Patients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_ApplicationUsers_CreatedById",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_ApplicationUsers_ExpiredById",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_ApplicationUsers_LastModifiedById",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Patients");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_LastModifiedById",
                table: "Patients",
                newName: "IX_Patients_LastModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_ExpiredById",
                table: "Patients",
                newName: "IX_Patients_ExpiredById");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CreatedById",
                table: "Patients",
                newName: "IX_Patients_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ApplicationUsers_CreatedById",
                table: "Patients",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ApplicationUsers_ExpiredById",
                table: "Patients",
                column: "ExpiredById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ApplicationUsers_LastModifiedById",
                table: "Patients",
                column: "LastModifiedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ApplicationUsers_CreatedById",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ApplicationUsers_ExpiredById",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ApplicationUsers_LastModifiedById",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_LastModifiedById",
                table: "Persons",
                newName: "IX_Persons_LastModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_ExpiredById",
                table: "Persons",
                newName: "IX_Persons_ExpiredById");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_CreatedById",
                table: "Persons",
                newName: "IX_Persons_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_ApplicationUsers_CreatedById",
                table: "Persons",
                column: "CreatedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_ApplicationUsers_ExpiredById",
                table: "Persons",
                column: "ExpiredById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_ApplicationUsers_LastModifiedById",
                table: "Persons",
                column: "LastModifiedById",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");
        }
    }
}
