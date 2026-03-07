using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeFirstEFDemo.Migrations
{
    /// <inheritdoc />
    public partial class ManytoManySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 3, 2 });
        }
    }
}
