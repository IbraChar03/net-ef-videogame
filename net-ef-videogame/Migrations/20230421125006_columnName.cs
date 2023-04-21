using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class columnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "videogame",
                newName: "Release_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Release_date",
                table: "videogame",
                newName: "release_date");
        }
    }
}
