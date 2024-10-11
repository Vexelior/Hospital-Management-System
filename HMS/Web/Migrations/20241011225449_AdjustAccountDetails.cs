using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AdjustAccountDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AccountRequests");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AccountRequests",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AccountRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AccountRequests");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "AccountRequests",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
