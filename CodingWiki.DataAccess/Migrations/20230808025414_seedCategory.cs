using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Category 1')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Category 2')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Category 3')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
