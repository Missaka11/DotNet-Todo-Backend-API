using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class JobRolefieldaddedtoauthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobRole",
                table: "Authors",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "JobRole",
                value: "Software Engineer");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "JobRole",
                value: "Actor");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "JobRole",
                value: "Doctor");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Due" },
                values: new object[] { new DateTime(2025, 4, 28, 12, 10, 46, 129, DateTimeKind.Local).AddTicks(9570), new DateTime(2025, 5, 8, 12, 10, 46, 129, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Due" },
                values: new object[] { new DateTime(2025, 4, 28, 12, 10, 46, 129, DateTimeKind.Local).AddTicks(9590), new DateTime(2025, 5, 5, 12, 10, 46, 129, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Due" },
                values: new object[] { new DateTime(2025, 4, 28, 12, 10, 46, 129, DateTimeKind.Local).AddTicks(9600), new DateTime(2025, 5, 3, 12, 10, 46, 129, DateTimeKind.Local).AddTicks(9600) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobRole",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Due" },
                values: new object[] { new DateTime(2025, 4, 27, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(400), new DateTime(2025, 5, 7, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Due" },
                values: new object[] { new DateTime(2025, 4, 27, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(440), new DateTime(2025, 5, 4, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Due" },
                values: new object[] { new DateTime(2025, 4, 27, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(450), new DateTime(2025, 5, 2, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(450) });
        }
    }
}
