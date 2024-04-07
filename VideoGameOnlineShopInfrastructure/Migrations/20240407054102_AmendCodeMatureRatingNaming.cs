using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameOnlineShopInfrastructure.Migrations
{
    public partial class AmendCodeMatureRatingNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatureRating",
                table: "Game",
                newName: "CodeMatureRating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodeMatureRating",
                table: "Game",
                newName: "MatureRating");
        }
    }
}
