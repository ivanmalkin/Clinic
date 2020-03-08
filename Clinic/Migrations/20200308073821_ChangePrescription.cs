using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Migrations
{
    public partial class ChangePrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Prescriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}