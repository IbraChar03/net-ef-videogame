using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class tableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_SoftwareHouses_SoftwareHouseId",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses");

            migrationBuilder.RenameTable(
                name: "SoftwareHouses",
                newName: "software_house");

            migrationBuilder.AddPrimaryKey(
                name: "PK_software_house",
                table: "software_house",
                column: "SoftwareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_software_house_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId",
                principalTable: "software_house",
                principalColumn: "SoftwareHouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_software_house_SoftwareHouseId",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_software_house",
                table: "software_house");

            migrationBuilder.RenameTable(
                name: "software_house",
                newName: "SoftwareHouses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareHouses",
                table: "SoftwareHouses",
                column: "SoftwareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_SoftwareHouses_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId",
                principalTable: "SoftwareHouses",
                principalColumn: "SoftwareHouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
