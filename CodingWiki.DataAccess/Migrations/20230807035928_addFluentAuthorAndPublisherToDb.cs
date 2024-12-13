using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentAuthorAndPublisherToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book_fluent",
                table: "Book_fluent");

            migrationBuilder.RenameTable(
                name: "Book_fluent",
                newName: "Fluent_Book");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book",
                column: "BookId");

            migrationBuilder.CreateTable(
                name: "Fluent_Author",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Author", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Publisher",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Publisher", x => x.Publisher_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_Author");

            migrationBuilder.DropTable(
                name: "Fluent_Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book");

            migrationBuilder.RenameTable(
                name: "Fluent_Book",
                newName: "Book_fluent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book_fluent",
                table: "Book_fluent",
                column: "BookId");
        }
    }
}
