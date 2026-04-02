using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiInAsp.netcoreMvcDemo.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21511b62-f9b7-4e19-9515-4850e73dec3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cd2bfba-fd34-4a00-b166-ceff8fa1ca57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c97d0e2-c0d9-4b3c-9f4e-333f7214c01d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10d6db29-87e9-4c87-9144-ae72b2ae8fef", "3", "HR", "HR" },
                    { "14004795-09f9-4dbb-bea2-d9e573043fc5", "2", "User", "User" },
                    { "b9f9e103-925f-4a0c-8526-ea4073590a5d", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10d6db29-87e9-4c87-9144-ae72b2ae8fef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14004795-09f9-4dbb-bea2-d9e573043fc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9f9e103-925f-4a0c-8526-ea4073590a5d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21511b62-f9b7-4e19-9515-4850e73dec3b", "2", "User", "User" },
                    { "4cd2bfba-fd34-4a00-b166-ceff8fa1ca57", "1", "Admin", "Admin" },
                    { "5c97d0e2-c0d9-4b3c-9f4e-333f7214c01d", "3", "HR", "HR" }
                });
        }
    }
}
