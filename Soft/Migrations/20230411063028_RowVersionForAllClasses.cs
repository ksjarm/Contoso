using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contoso.Soft.Migrations
{
    /// <inheritdoc />
    public partial class RowVersionForAllClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Person",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OfficeAssignment",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "OfficeAssignment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "OfficeAssignment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Enrollment",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "Enrollment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Enrollment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "CourseAssignment",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "CourseAssignment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "CourseAssignment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Course",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OfficeAssignment");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "OfficeAssignment");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "OfficeAssignment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "CourseAssignment");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "CourseAssignment");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "CourseAssignment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Course");
        }
    }
}
