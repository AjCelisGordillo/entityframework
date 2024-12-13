using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMappingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Author_Author_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthorMap",
                newName: "BookAuthorMaps_Fluent");

            migrationBuilder.RenameTable(
                name: "BookAuthorMap",
                newName: "BookAuthorMaps");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthorMap_Book_Id",
                table: "BookAuthorMaps_Fluent",
                newName: "IX_BookAuthorMaps_Fluent_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "BookAuthorMaps",
                newName: "IX_BookAuthorMaps_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMaps_Fluent",
                table: "BookAuthorMaps_Fluent",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMaps",
                table: "BookAuthorMaps",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Authors_Author_Id",
                table: "BookAuthorMaps",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Books_Book_Id",
                table: "BookAuthorMaps",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Fluent_Fluent_Author_Author_Id",
                table: "BookAuthorMaps_Fluent",
                column: "Author_Id",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Fluent_Fluent_Book_Book_Id",
                table: "BookAuthorMaps_Fluent",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Authors_Author_Id",
                table: "BookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Books_Book_Id",
                table: "BookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Fluent_Fluent_Author_Author_Id",
                table: "BookAuthorMaps_Fluent");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Fluent_Fluent_Book_Book_Id",
                table: "BookAuthorMaps_Fluent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMaps_Fluent",
                table: "BookAuthorMaps_Fluent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMaps",
                table: "BookAuthorMaps");

            migrationBuilder.RenameTable(
                name: "BookAuthorMaps_Fluent",
                newName: "Fluent_BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "BookAuthorMaps",
                newName: "BookAuthorMap");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMaps_Fluent_Book_Id",
                table: "Fluent_BookAuthorMap",
                newName: "IX_Fluent_BookAuthorMap_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMaps_Book_Id",
                table: "BookAuthorMap",
                newName: "IX_BookAuthorMap_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Author_Author_Id",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
