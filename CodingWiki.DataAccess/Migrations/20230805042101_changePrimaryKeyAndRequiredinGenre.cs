using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changePrimaryKeyAndRequiredinGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "tb_genres",
                newName: "Genre_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre_Id",
                table: "tb_genres",
                newName: "GenreId");
        }
    }
}
