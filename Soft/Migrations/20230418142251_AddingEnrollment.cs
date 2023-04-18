using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contoso.Soft.Migrations
{
    /// <inheritdoc />
    public partial class AddingEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OfficeAssignment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "CourseAssignment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Person",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OfficeAssignment",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Enrollment",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "CourseAssignment",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Course",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
