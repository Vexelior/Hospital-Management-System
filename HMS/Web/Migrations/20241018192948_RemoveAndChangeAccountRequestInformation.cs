using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAndChangeAccountRequestInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVDocumentPath",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "CertificationDocumentPath",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "MedicalLicenseDocumentPath",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "MedicalLicenseNumber",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "AccountRequests");

            migrationBuilder.AddColumn<byte[]>(
                name: "Certification",
                table: "AccountRequests",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MedicalLicense",
                table: "AccountRequests",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Resume",
                table: "AccountRequests",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certification",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "MedicalLicense",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "AccountRequests");

            migrationBuilder.AddColumn<string>(
                name: "CVDocumentPath",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificationDocumentPath",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalLicenseDocumentPath",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalLicenseNumber",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "AccountRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
