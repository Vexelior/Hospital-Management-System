using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialClaimSubmitModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Providers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCompany",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceGroupNumber",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsurancePolicyNumber",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "Patients",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Claims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "InsuranceCompany",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InsuranceGroupNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "InsurancePolicyNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Claims",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
