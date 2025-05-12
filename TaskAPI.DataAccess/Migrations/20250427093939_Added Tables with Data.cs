using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableswithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Due = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AddressNo", "City", "FullName", "Street" },
                values: new object[,]
                {
                    { 1, "789", "California", "John Doe", "Smith St" },
                    { 2, "456", "Los Angeles", "Will Smith", "Johnson St" },
                    { 3, "123", "New York", "Robert Hendry", "Main St" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AuthorId", "Created", "Description", "Due", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 4, 27, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(400), "Get some fruits for the week", new DateTime(2025, 5, 7, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(440), 0, "Get fruits" },
                    { 2, 1, new DateTime(2025, 4, 27, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(440), "Get some text books for school", new DateTime(2025, 5, 4, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(440), 0, "Get books for school - DB" },
                    { 3, 2, new DateTime(2025, 4, 27, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(450), "Get some vegitables for the week", new DateTime(2025, 5, 2, 15, 9, 39, 409, DateTimeKind.Local).AddTicks(450), 2, "Get vegetables" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_AuthorId",
                table: "Todos",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
